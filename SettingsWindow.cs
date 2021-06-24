using Microsoft.Win32;
using Newtonsoft.Json;
using NHotkey.WindowsForms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lxMeets {
    public partial class SettingsWindow : Form {
        readonly WebClient client = new WebClient();
        public SettingsWindow() {
            InitializeComponent();
            CenterToScreen();
            keyboardShortCutText.Text = Properties.Settings.Default.KeyBoardShortCut.Replace("Keys.", "");
            cedDefault.Text = Properties.Settings.Default.Cedula;
            autoRunCheck.Checked = Properties.Settings.Default.AutoStart;
            useKeyboardCheck.Checked = Properties.Settings.Default.UseKeyboard;
            sendNotificationsCheck.Checked = Properties.Settings.Default.Notifications;
            useCedulaCheck.Checked = Properties.Settings.Default.UseDefaultCed;
            usuarioDefault.Text = Decode(Properties.Settings.Default.Usuario);
            useUsuarioCheck.Checked = Properties.Settings.Default.UseDefaultUser;
            this.KeyPreview = true;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void UseKeyboardCheck_CheckedChanged(object sender, EventArgs e) {
            try {
                var mainForm = Application.OpenForms.OfType<lxMeets>().Single();
                if (useKeyboardCheck.Checked) {
                    HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, mainForm.FromKeyboard);
                    Properties.Settings.Default.UseKeyboard = true;
                    Properties.Settings.Default.Save();
                } else {
                    HotkeyManager.Current.Remove("AbrirClase");
                    Properties.Settings.Default.UseKeyboard = false;
                    Properties.Settings.Default.Save();
                }
            } catch { }
        }
        private void AutoRunCheck_CheckedChanged(object sender, EventArgs e) {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRunCheck.Checked) {
                registryKey.SetValue("lxMeets", $"{Process.GetCurrentProcess().MainModule.FileName} --start-minimized");
                Properties.Settings.Default.AutoStart = true;
                Properties.Settings.Default.Save();
            } else {
                registryKey.DeleteValue("lxMeets");
                Properties.Settings.Default.AutoStart = false;
                Properties.Settings.Default.Save();
            }


        }
        private void SendNotificationsCheck_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.Notifications = sendNotificationsCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void useCedulaCheck_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UseDefaultCed = useCedulaCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private async void AuthUser(string cedula) {
            try {
                string url = @"https://api.lxndr.dev/uae/estudiantes/?cedula=" + cedula;
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error) {
                    MessageBox.Show(stuff.message.ToString());
                    while (true) {
                        cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

                        while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$")) {
                            if (cedula == "Cancel") break;
                            MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                        }
                        if (cedula != "Cancel") AuthUser(cedula);
                        break;
                    }
                } else {
                    Properties.Settings.Default.Cedula = cedula;
                    Properties.Settings.Default.Save();
                    cedDefault.Text = Properties.Settings.Default.Cedula;
                }
            } catch { }
        }

        private void cambiarCedula_Click(object sender, EventArgs e) {
            string cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

            while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$")) {
                if (cedula == "Cancel") break;
                MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
            }
            if (cedula != "Cancel") AuthUser(cedula);


        }

        private void useUsuarioCheck_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.UseDefaultUser = useUsuarioCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private async void AuthMoodle(string contra, string user) {
            try {
                string url = @"https://api.lxndr.dev/uae/moodle?usuario=" + Encode(user) + "&contrasena=" + Encode(contra);
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error) {
                    MessageBox.Show(stuff.message.ToString());
                    string res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                    string usuario = res.Split('[', ']')[1];
                    string contrasena = res.Split('(', ')')[1];
                    while ((res.Length < 9 && res.Length > 0)) {
                        if (contrasena == "Cancel") break;
                        res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                        usuario = res.Split('[', ']')[1];
                        contrasena = res.Split('(', ')')[1];
                    }
                    if (contrasena != "Cancel") AuthMoodle(usuario, contrasena);
                } else {
                    Properties.Settings.Default.Contrasena = Encode(contra);
                    Properties.Settings.Default.Usuario = Encode(user);
                    Properties.Settings.Default.Save();
                }

            } catch { }
        }

        public static string Encode(string plainText) {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string encoded) {
            var base64EncodedBytes = Convert.FromBase64String(encoded);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void cambiarUsuario_Click(object sender, EventArgs e) {
            string res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
            string usuario = res.Split('[', ']')[1];
            string contrasena = res.Split('(', ')')[1];
            while ((res.Length < 9 && res.Length > 0)) {
                if (contrasena == "Cancel") break;
                res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                usuario = res.Split('[', ']')[1];
                contrasena = res.Split('(', ')')[1];
            }
            if (contrasena != "Cancel") AuthMoodle(usuario, contrasena);
        }
    }
}
