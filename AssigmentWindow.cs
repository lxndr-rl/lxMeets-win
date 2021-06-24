using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace lxMeets {
    public partial class AssigmentWindow : Form {
        List<String> materias = new List<String>();
        dynamic stuff;
        string res = "OK", usuario, contrasena;
        bool decoded = true;
        readonly WebClient client = new WebClient();
        public AssigmentWindow() {
            dynamic json;
            InitializeComponent();
            CenterToScreen();
            if (Properties.Settings.Default.UseDefaultUser && Properties.Settings.Default.Usuario.Length > 0 && Properties.Settings.Default.Contrasena.Length > 0) {
                usuario = Properties.Settings.Default.Usuario;
                contrasena = Properties.Settings.Default.Contrasena;
                decoded = false;
            } else {
                res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                contrasena = res.Split('[', ']')[1];
                usuario = res.Split('(', ')')[1];
                while ((res.Length < 9 && res.Length > 0)) {
                    if (usuario == "Cancel") break;
                    res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                    contrasena = res.Split('[', ']')[1];
                    usuario = res.Split('(', ')')[1];
                }
            }
            if (usuario != "Cancel") FetchAPI(usuario, contrasena, decoded);
        }

        public static string Encode(string plainText) {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private async void FetchAPI(string usuario, string contrasena, bool decoded) {
            compAsignCheck.Enabled = false;
            delayAsignCheck.Enabled = false;
            if (decoded) {
                usuario = Encode(usuario);
                contrasena = Encode(contrasena);
            }
            nombreLabel.Visible = false;
            profilePicture.Visible = false;
            cargandoPicture.Visible = true;
            quizzLayout.Controls.Clear();
            assigmentLayout.Controls.Clear();
            try {
                string url = @"https://api.lxndr.dev/uae/moodle?usuario=" + usuario + "&contrasena=" + contrasena;
                var json = await client.DownloadStringTaskAsync(url);
                stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error) {
                    MessageBox.Show(stuff.message.ToString());
                    Close();
                } else {
                    nombreLabel.Visible = true;
                    profilePicture.Visible = true;
                    nombreLabel.Text = stuff.user.fullname;
                    profilePicture.LoadAsync(stuff.user.ppicture.ToString());
                    materiasBox.DataSource = stuff.courses;
                    compAsignCheck.Enabled = true;
                    delayAsignCheck.Enabled = true;
                }

            } catch { }
            cargandoPicture.Visible = false;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private Image Base64ToImage(string base64String) {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        Button AddButton(string titulo, string hora, bool atrasado = false, bool completado = false) {
            string image;
            Button lx = new Button {
                Name = titulo,
                Text = titulo
            };
            if (atrasado && !completado) lx.Text += " (Atrasado)\n" + hora; else if (completado) lx.Text += " (Completado)\n" + hora; else lx.Text += " (Pendiente)\n" + hora;
            lx.FlatAppearance.MouseOverBackColor = Color.Gray;
            lx.FlatStyle = FlatStyle.Flat;
            lx.ForeColor = Color.White;
            lx.FlatStyle = FlatStyle.Flat;
            lx.Font = new Font("Serif", 12);
            lx.Width = 750;
            lx.Height = 80;
            lx.TextAlign = ContentAlignment.MiddleLeft;
            lx.Margin = new Padding(5);
            return lx;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void materiasBox_SelectedIndexChanged(object sender, EventArgs e) {
            cargandoPicture.Visible = true;
            quizzLayout.Controls.Clear();
            assigmentLayout.Controls.Clear();
            try {
                try {
                    foreach (var s in stuff.quizzes[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                        if (compAsignCheck.Checked && (bool)s.submitted) continue;
                        if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.timeclose.ToString())) continue;
                        Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString()))));
                        quizzLayout.Controls.Add(l);
                        l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, "", "<p style='color: white'>" + s.description.ToString() + " </p>", true, UnixTimeStampToDateTime(Convert.ToDouble(s.timeopen.ToString())), UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString())), TimeSpan.FromSeconds(Convert.ToDouble(s.timelimit)).ToString()); };

                    }
                } catch { }
                foreach (var s in stuff.assigments[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                    if (compAsignCheck.Checked && (bool)s.submitted) continue;
                    if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString())) continue;
                    Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString()))), Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString()), (bool)s.submitted);
                    assigmentLayout.Controls.Add(l);
                    l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString())), "<p style='color: white'>" + s.description.ToString() + " </p>"); };

                }

            } catch { }
            cargandoPicture.Visible = false;
        }

        public static string UnixTimeStampToDateTime(double unixTimeStamp) {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return Convert.ToString(dtDateTime);
        }

        private void recargarButton_Click(object sender, EventArgs e) {
            FetchAPI(usuario, contrasena, decoded);
        }

        private void delayAsignCheck_CheckedChanged(object sender, EventArgs e) {
            cargandoPicture.Visible = true;
            quizzLayout.Controls.Clear();
            assigmentLayout.Controls.Clear();
            try {
                try {
                    foreach (var s in stuff.quizzes[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                        if (compAsignCheck.Checked && (bool)s.submitted) continue;
                        if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.timeclose.ToString())) continue;
                        Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString()))));
                        quizzLayout.Controls.Add(l);
                        l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, "", "<p style='color: white'>" + s.description.ToString() + " </p>", true, UnixTimeStampToDateTime(Convert.ToDouble(s.timeopen.ToString())), UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString())), TimeSpan.FromSeconds(Convert.ToDouble(s.timelimit)).ToString()); };

                    }
                } catch { }
                foreach (var s in stuff.assigments[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                    if (compAsignCheck.Checked && (bool)s.submitted) continue;
                    if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString())) continue;
                    Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString()))), Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString()), (bool)s.submitted);
                    assigmentLayout.Controls.Add(l);
                    l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString())), "<p style='color: white'>" + s.description.ToString() + " </p>"); };

                }

            } catch { }
            cargandoPicture.Visible = false;
        }

        private void compAsignCheck_CheckedChanged(object sender, EventArgs e) {
            cargandoPicture.Visible = true;
            quizzLayout.Controls.Clear();
            assigmentLayout.Controls.Clear();
            try {
                try {
                    foreach (var s in stuff.quizzes[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                        if (compAsignCheck.Checked && (bool)s.submitted) continue;
                        if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.timeclose.ToString())) continue;
                        Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString()))));
                        quizzLayout.Controls.Add(l);
                        l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, "", "<p style='color: white'>" + s.description.ToString() + " </p>", true, UnixTimeStampToDateTime(Convert.ToDouble(s.timeopen.ToString())), UnixTimeStampToDateTime(Convert.ToDouble(s.timeclose.ToString())), TimeSpan.FromSeconds(Convert.ToDouble(s.timelimit)).ToString()); };

                    }
                } catch { }
                foreach (var s in stuff.assigments[materiasBox.GetItemText(materiasBox.SelectedItem)]) {
                    if (compAsignCheck.Checked && (bool)s.submitted) continue;
                    if (delayAsignCheck.Checked && Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString())) continue;
                    Button l = AddButton(s.name.ToString(), Convert.ToString(UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString()))), Convert.ToDouble(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()) > Convert.ToDouble(s.duedate.ToString()), (bool)s.submitted);
                    assigmentLayout.Controls.Add(l);
                    l.Click += delegate (object sender, EventArgs e) { lxAssigmentView.ShowDialog(s.name.ToString(), s.attachments, UnixTimeStampToDateTime(Convert.ToDouble(s.duedate.ToString())), "<p style='color: white'>" + s.description.ToString() + " </p>"); };

                }

            } catch { }
            cargandoPicture.Visible = false;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void AssigmentWindow_Shown(object sender, EventArgs e) {
            if (usuario == "Cancel") Close();
        }
    }
}
