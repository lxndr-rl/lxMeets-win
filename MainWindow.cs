﻿using lxMsgBox;
using Microsoft.Win32;
using Newtonsoft.Json;
using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace lxMeets {
#pragma warning disable IDE1006 // Estilos de nombres
    public partial class lxMeets : Form
#pragma warning restore IDE1006 // Estilos de nombres
    {
        private static int lastHour1;
        private static int lastHour2;
        private static string anteriorAsignatura = "";
        private readonly FormCollection fc = Application.OpenForms;
        private readonly ToolTip ToolTip1 = new ToolTip();
        readonly WebClient client = new WebClient();

        public lxMeets() {
            InitializeComponent();
        }

        private void RegisterInStartup() {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("lxMeets", $"{Process.GetCurrentProcess().MainModule.FileName} --start-minimized");
        }

        private void TriggerNotif(object source, ElapsedEventArgs e) {
            if (DateTime.Now.Hour < 12) {
                if (lastHour1 < DateTime.Now.Hour || (lastHour1 == 23 && DateTime.Now.Hour == 0)) {
                    if (DateTime.Now.Minute == 55) {
                        lastHour1 = DateTime.Now.Hour;
                        FiveMinutes();
                    }
                }
                if (lastHour2 < DateTime.Now.Hour || (lastHour2 == 23 && DateTime.Now.Hour == 0)) {
                    if (DateTime.Now.Minute == 00) {
                        lastHour2 = DateTime.Now.Hour;
                        InstantAlert();
                    }
                }
            } else {
                if (lastHour1 < DateTime.Now.Hour || (lastHour1 == 23 && DateTime.Now.Hour == 0)) {
                    if (DateTime.Now.Minute == 25) {
                        lastHour1 = DateTime.Now.Hour;
                        FiveMinutes();
                    }
                }
                if (lastHour2 < DateTime.Now.Hour || (lastHour2 == 23 && DateTime.Now.Hour == 0)) {
                    if (DateTime.Now.Minute == 30) {
                        lastHour2 = DateTime.Now.Hour;
                        InstantAlert();
                    }
                }
            }
        }

        private async void FetchLatestVer() {
            try {
                string url = @"https://lxmeets.lxndr.dev/latest.php";
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                dynamic stuffwin = stuff.windows;
                horarioexamButton.Visible = (bool)stuff.examen;
                notasButton.Visible = (bool)stuff.notas;
                moodleButton.Visible = (bool)stuff.moodle;
                if (stuffwin.latest > Properties.Settings.Default.Version) {
                    string seleccion = lxMessageBox.Show("<p style='color: white'>" + stuffwin.cambios.ToString().Replace("\n", "<br>") + "</p>", stuffwin.type.ToString(), lxMessageBox.Buttons.OKCancel, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
                    if (seleccion == "OK") {
                        try {
                            if (!File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", "") + "\\updater.exe ")) {
                                MessageBox.Show("Parece ser que no tienes el instalador.\nDescargando Instalador ;)");
                                client.DownloadFile("https://lxmeets.lxndr.dev/updater.exe", Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", "") + "\\updater.exe ");
                            }
                            ProcessStartInfo proc = new ProcessStartInfo {
                                FileName = Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", "") + "\\updater.exe ",
                                Arguments = Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", ""),
                                UseShellExecute = true,
                                Verb = "runas"
                            };
                            Process.Start(proc);
                        } catch (Exception e) {
                            MessageBox.Show("No se pudo actualizar de forma automática :(\n" + e.Message);
                        }

                    }
                }
            } catch { }
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
                }
            } catch { }
        }

        private async void AuthMoodle(string user, string contra) {
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

        public async void FromKeyboard(object sender, HotkeyEventArgs e) {
            e.Handled = true;
            try {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php?ced=" + Properties.Settings.Default.Cedula;
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if (stuff.materia.ToString() == "No hay nada por ahora") {
                    notifyIcon1.BalloonTipTitle = "lxMeets";
                    notifyIcon1.BalloonTipText = stuff.materia.ToString();
                    notifyIcon1.ShowBalloonTip(1000);
                    return;
                }
                OpenUrl1(stuff.url.ToString());
            } catch { }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            FetchAPI();
            label2.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private string GetDay(string dayName) {
            if (dayName == "Monday" || dayName == "Lunes") {
                return "Lunes";
            } else if (dayName == "Tuesday" || dayName == "Martes") {
                return "Martes";
            } else if (dayName == "Wednesday" || dayName == "Miércoles") {
                return "Miercoles";
            } else if (dayName == "Thursday" || dayName == "Jueves") {
                return "Jueves";
            } else if (dayName == "Friday" || dayName == "Viernes") {
                return "Viernes";
            } else if (dayName == "Saturday" || dayName == "Sábado") {
                return "Sabado";
            } else if (dayName == "Sunday" || dayName == "Domingo") {
                return "Domingo";
            } else {
                return "";
            }
        }


        private void OpenFromIcon(object sender, EventArgs e) {
            flowLayoutPanel1.Controls.Clear();
            FetchAPI();
            FetchLatestVer();
            Show();
        }

        private void CloseFromIcon(object sender, EventArgs e) {
            notifyIcon1.Icon = null;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();
            Environment.Exit(0);

        }

        private async void FetchAPI() {
            flowLayoutPanel1.Controls.Clear();
            cargandoAPI.Visible = true;
            try {
                string url = @"https://api.lxndr.dev/uae/meets/?dia=" + comboBox1.GetItemText(comboBox1.SelectedItem) + "&ced=" + Properties.Settings.Default.Cedula;
                var client = new WebClient();
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                flowLayoutPanel1.Controls.Clear();
                foreach (var s in stuff) {
                    if (s.materia.ToString() == "No hay nada por ahora") { cargandoAPI.Visible = false; return; }
                    Button l = AddButton(s.materia.ToString(), s.hora.ToString());
                    flowLayoutPanel1.Controls.Add(l);
                    l.Click += delegate (object sender, EventArgs e) { ShowAlert(sender, e, s.materia.ToString(), s.hora.ToString(), s.url.ToString()); };

                }
            } catch { }
            cargandoAPI.Visible = false;
        }

        private void OpenUrl1(string url) {
            try {
                Process.Start(url);
            } catch {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    Process.Start("xdg-open", url);
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                } else {
                    throw;
                }
            }
        }

#pragma warning disable IDE0060 // Quitar el parámetro no utilizado
        private void OpenUrl2(object sender, EventArgs e, string url)
#pragma warning restore IDE0060 // Quitar el parámetro no utilizado
        {
            try {
                Process.Start(url);
            } catch {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    Process.Start("xdg-open", url);
                } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                } else {
                    throw;
                }
            }
        }

#pragma warning disable IDE0060 // Quitar el parámetro no utilizado
        private void ShowAlert(object sender, EventArgs e, string materia, string horas, string url)
#pragma warning restore IDE0060 // Quitar el parámetro no utilizado
        {
            string seleccion = lxMessageBox.Show("<p style='color: white'>" + horas.Replace("\n", "<br>") + " </p>", materia, lxMessageBox.Buttons.YesNoCancel, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
            if (seleccion == "No") {
                Clipboard.SetText(url);
            } else if (seleccion == "Yes") {
                OpenUrl1(url);
            }

        }
        DateTime RoundUp(DateTime dt, TimeSpan d) {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private async void FiveMinutes() {
            try {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php?ced=" + Properties.Settings.Default.Cedula + "&hora=" + RoundUp(DateTime.Parse(DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm") + ":00"), TimeSpan.FromMinutes(15)).ToShortTimeString();
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((string)stuff.diff == "0" && (anteriorAsignatura == stuff.materia.ToString())) return;
                if (stuff.materia.ToString() == "No hay nada por ahora" || !Properties.Settings.Default.Notifications) return;
                anteriorAsignatura = stuff.materia.ToString();
                notifyIcon1.BalloonTipTitle = "lxMeets";
                notifyIcon1.BalloonTipText = "Dentro de 5 minutos: " + stuff.materia.ToString();
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.BalloonTipClicked += delegate (object sender, EventArgs e) { OpenUrl2(sender, e, stuff.url.ToString()); };
            } catch { }
        }
        private void RemoveClickEvent(NotifyIcon b) {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);

            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private async void InstantAlert() {
            try {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php?ced=" + Properties.Settings.Default.Cedula;
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((string)stuff.diff == "0" && (anteriorAsignatura == stuff.materia.ToString())) return;
                if (stuff.materia.ToString() == "No hay nada por ahora" || !Properties.Settings.Default.Notifications) return;
                anteriorAsignatura = stuff.materia.ToString();
                notifyIcon1.BalloonTipTitle = stuff.materia.ToString();
                notifyIcon1.BalloonTipText = stuff.hora.ToString();
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.BalloonTipClicked += delegate (object sender, EventArgs e) { OpenUrl2(sender, e, stuff.url.ToString()); };
            } catch { }
        }

        Button AddButton(string materia, string hora) {
            Button lx = new Button {
                Name = materia,
                Text = materia + "\n" + hora
            };
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

        private void Button1_Click(object sender, EventArgs e) {
            FetchAPI();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Button1_Click_1(object sender, EventArgs e) {
            try { RemoveClickEvent(notifyIcon1); } catch { }
            //Close();
            Hide();
            notifyIcon1.DoubleClick += OpenFromIcon;
        }
        private void Settings_Click(object sender, EventArgs e) {
            bool exist = false;
            foreach (Form frm in fc) {
                if (frm.Name == "SettingsWindow") exist = true;
            }
            if (!exist) { SettingsWindow Settings = new SettingsWindow(); Settings.Show(); }
        }

        private void SettingsButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(settingsButton, "Configuración de lxMeets");
        }

        private void HorarioexamButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(horarioexamButton, "Ver horario de examenes");
        }

        private void HorarioButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(horarioButton, "Ver Horario de Clases");
        }

        private void HorarioexamButton_Click(object sender, EventArgs e) {
            bool exist = false;
            foreach (Form frm in fc) {
                if (frm.Name == "ScheduleWindow") {
                    exist = true;
                }
            }
            if (!exist) { ScheduleWindow horarioEx = new ScheduleWindow("Examen"); horarioEx.Show(); }

        }

        private void HorarioButton_Click(object sender, EventArgs e) {

            bool exist = false;
            foreach (Form frm in fc) {
                if (frm.Name == "ScheduleWindow") {
                    exist = true;
                }
            }
            if (!exist) { ScheduleWindow horarioEx = new ScheduleWindow("Clase"); horarioEx.Show(); }
        }

        private void OpenlxndrButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(openlxndrButton, "Abrir sitio web");
        }

        private void OpenlxndrButton_Click(object sender, EventArgs e) {
            OpenUrl1("https://lxmeets.lxndr.dev");
        }

        private void GithubButton_Click(object sender, EventArgs e) {
            OpenUrl1("https://github.com/lxndr-rl/lxMeets-win");
        }

        private void GithubButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(githubButton, "Ver código fuente");
        }

        private void NotasButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(notasButton, "Consulta calificaciones");
        }

        private void NotasButton_Click(object sender, EventArgs e) {
            bool exist = false;
            foreach (Form frm in fc) {
                if (frm.Name == "GradeWindow") {
                    exist = true;
                }
            }
            if (!exist) { GradeWindow notas = new GradeWindow(); notas.Show(); }

        }

#pragma warning disable IDE1006 // Estilos de nombres
        private void lxMeets_Shown(object sender, EventArgs e)
#pragma warning restore IDE1006 // Estilos de nombres
        {
            CenterToScreen();
            Cerrar.Click += CloseFromIcon;
            FetchLatestVer();
            FetchAPI();
            DateTime dt = DateTime.Now;
            String dayName = dt.DayOfWeek.ToString();
            comboBox1.SelectedItem = GetDay(dayName);
            label2.Text = GetDay(dayName);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            notifyIcon1.Icon = null;
            notifyIcon1.Icon = Icon;
            if (Properties.Settings.Default.UseKeyboard) {
                try {
                    HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, FromKeyboard);
                } catch { }
            }
            if (Properties.Settings.Default.FirstRun) {
                RegisterInStartup();
                try {
                    if (!File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", "") + "\\updater.exe ")) {
                        client.DownloadFile("http://lxmeets.lxndr.dev/updater.exe", Process.GetCurrentProcess().MainModule.FileName.Replace("\\lxMeets.exe", "") + "\\updater.exe ");
                    }
                } catch { }
                lxMessageBox.Show("<p style='color: white'>La aplicación corre en segundo plano incluso cuando se presiona X<br><br>Puede usar el atajo (Ctrl Alt Shift) para abrir la clase actual.<br><br>Las alertas se muestran 5 minutos antes de una clase y al empezar la clase.<br><br>La aplicación se abre al iniciar windows</p>", "lxMeets " + Properties.Settings.Default.Version.ToString(CultureInfo.GetCultureInfo("en-GB")), lxMessageBox.Buttons.OK, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
                string cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

                while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$")) {
                    if (cedula == "Cancel") break;
                    MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                }
                if (cedula != "Cancel") AuthUser(cedula);

                string res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                string contrasena = res.Split('[', ']')[1];
                string usuario = res.Split('(', ')')[1];
                while ((res.Length < 9 && res.Length > 0)) {
                    if (usuario == "Cancel") break;
                    res = lxMessageInputBox.ShowDialog("Ingresa tus credenciales", "Ingresar Usuario", false, true, "Ingresa Contraseña");
                    contrasena = res.Split('[', ']')[1];
                    usuario = res.Split('(', ')')[1];
                }
                if (usuario != "Cancel") AuthMoodle(usuario, contrasena);

                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
            var aTimer = new System.Timers.Timer(1000 * 30);
            int lastHour1 = DateTime.Now.Hour;
            int lastHour2 = DateTime.Now.Hour;
            aTimer.Elapsed += new ElapsedEventHandler(TriggerNotif);
            aTimer.Start();
        }

        private void moodleButton_MouseHover(object sender, EventArgs e) {
            ToolTip1.SetToolTip(moodleButton, "Ver Asignaciones de Moodle");
        }

        private void moodleButton_Click(object sender, EventArgs e) {
            bool exist = false;
            foreach (Form frm in fc) {
                if (frm.Name == "AssigmentWindow") {
                    exist = true;
                }
            }
            if (!exist) { AssigmentWindow assigment = new AssigmentWindow(); assigment.Show(); }
        }
    }
}
