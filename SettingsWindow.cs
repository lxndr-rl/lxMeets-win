using lxMsgBox;
using Microsoft.Win32;
using Newtonsoft.Json;
using NHotkey.WindowsForms;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lxMeets
{
    public partial class SettingsWindow : Form
    {
        readonly WebClient client = new WebClient();
        public SettingsWindow()
        {
            InitializeComponent();
            CenterToScreen();
            keyboardShortCutText.Text = Properties.Settings.Default.KeyBoardShortCut.Replace("Keys.", "");
            cedDefault.Text = Properties.Settings.Default.Cedula;
            autoRunCheck.Checked = Properties.Settings.Default.AutoStart;
            useKeyboardCheck.Checked = Properties.Settings.Default.UseKeyboard;
            sendNotificationsCheck.Checked = Properties.Settings.Default.Notifications;
            useCedulaCheck.Checked = Properties.Settings.Default.UseDefaultCed;

            this.KeyPreview = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UseKeyboardCheck_CheckedChanged(object sender, EventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<lxMeets>().Single();
            if (useKeyboardCheck.Checked)
            {
                HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, mainForm.FromKeyboard);
                Properties.Settings.Default.UseKeyboard = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                HotkeyManager.Current.Remove("AbrirClase");
                Properties.Settings.Default.UseKeyboard = false;
                Properties.Settings.Default.Save();
            }
        }
        private void AutoRunCheck_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (autoRunCheck.Checked)
            {
                registryKey.SetValue("lxMeets", $"{Process.GetCurrentProcess().MainModule.FileName} --start-minimized");
                Properties.Settings.Default.AutoStart = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                registryKey.DeleteValue("lxMeets");
                Properties.Settings.Default.AutoStart = false;
                Properties.Settings.Default.Save();
            }


        }
        private void SendNotificationsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (sendNotificationsCheck.Checked)
            {
                Properties.Settings.Default.Notifications = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.Notifications = false;
                Properties.Settings.Default.Save();
            }
        }

        private void useCedulaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (useCedulaCheck.Checked)
            {
                Properties.Settings.Default.UseDefaultCed = true;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.UseDefaultCed = false;
                Properties.Settings.Default.Save();
            }
        }

        private async void AuthUser(string cedula)
        {
            try
            {
                string url = @"https://api.lxndr.dev/uae/estudiantes/?cedula=" + cedula;
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error)
                {
                    MessageBox.Show(stuff.message.ToString());
                    while (true)
                    {
                        lxMessageBox.Show("La aplicación corre en segundo plano incluso cuando se presiona X\n\nPuede usar el atajo (Ctrl Alt Shift) para abrir la clase actual.\n\nLas alertas se muestran 5 minutos antes de una clase y al empezar la clase.\n\nLa aplicación se abre al iniciar windows", "lxMeets " + Properties.Settings.Default.Version, lxMessageBox.Buttons.OK, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
                        cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

                        while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
                        {
                            if (cedula == "Cancel") break;
                            MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                        }
                        if (cedula != "Cancel") AuthUser(cedula);
                        break;
                    }
                }
                else
                {
                    Properties.Settings.Default.Cedula = cedula;
                    Properties.Settings.Default.Save();
                    cedDefault.Text = Properties.Settings.Default.Cedula;
                }
            }
            catch { }
        }

        private void cambiarCedula_Click(object sender, EventArgs e)
        {
            string cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

            while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
            {
                if (cedula == "Cancel") break;
                MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
            }
            if (cedula != "Cancel") AuthUser(cedula);

            
        }
    }
}
