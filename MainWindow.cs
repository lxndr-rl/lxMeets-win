using System;
using System.Drawing;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using lxMsgBox;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NHotkey.WindowsForms;
using NHotkey;
using System.Timers;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace lxMeets
{
    public partial class lxMeets : Form
    {
        private static int lastHour1;
        private static int lastHour2;
        FormCollection fc = Application.OpenForms;
        ToolTip ToolTip1 = new ToolTip();
        WebClient client = new WebClient();

        public lxMeets()
        {
            try
            {
                string processName = Process.GetCurrentProcess().ProcessName;
                Process[] instances = Process.GetProcessesByName(processName);
                if (instances.Length > 1) return; else this.Show();
                InitializeComponent();
                fetchLatestVer();
                fetchAPI();
            }
            catch { }
            DateTime dt = DateTime.Now;
            String dayName = dt.DayOfWeek.ToString();
            comboBox1.SelectedItem = getDay(dayName);
            label2.Text = getDay(dayName);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            if (Properties.Settings.Default.UseKeyboard)
            {
                HotkeyManager.Current.AddOrReplace("AbrirClase", Keys.Control | Keys.Alt | Keys.Shift, fromKeyboard);
            }
            RegisterInStartup(Properties.Settings.Default.FirstRun);
            if (Properties.Settings.Default.FirstRun)
            {
                lxMessageBox.Show("La aplicación corre en segundo plano incluso cuando se presiona X\n\nPuede usar el atajo (Ctrl Alt -) para abrir la clase actual.\n\nLas alertas se muestran 5 minutos antes de una clase y al empezar la clase.\n\nLa aplicación se abre al iniciar windows", "lxMeets " + Properties.Settings.Default.Version, lxMessageBox.Buttons.OK, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
                string cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

                while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
                {
                    if (cedula == "Cancel") break;
                    MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                }
                if (cedula != "Cancel") authUser(cedula);
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
            var aTimer = new System.Timers.Timer(1000 * 30);
            int lastHour1 = DateTime.Now.Hour;
            int lastHour2 = DateTime.Now.Hour;
            aTimer.Elapsed += new ElapsedEventHandler(TriggerNotif);
            aTimer.Start();

        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("lxMeets", Process.GetCurrentProcess().MainModule.FileName.ToString());
            }
        }

        private void TriggerNotif(object source, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour < 12)
            {
                if (lastHour1 < DateTime.Now.Hour || (lastHour1 == 23 && DateTime.Now.Hour == 0))
                {
                    if (DateTime.Now.Minute == 55)
                    {
                        lastHour1 = DateTime.Now.Hour;
                        FiveMinutes();
                    }
                }
                if (lastHour2 < DateTime.Now.Hour || (lastHour2 == 23 && DateTime.Now.Hour == 0))
                {
                    if (DateTime.Now.Minute == 00)
                    {
                        lastHour2 = DateTime.Now.Hour;
                        InstantAlert();
                    }
                }
            }
            else
            {
                if (lastHour1 < DateTime.Now.Hour || (lastHour1 == 23 && DateTime.Now.Hour == 0))
                {
                    if (DateTime.Now.Minute == 25)
                    {
                        lastHour1 = DateTime.Now.Hour;
                        FiveMinutes();
                    }
                }
                if (lastHour2 < DateTime.Now.Hour || (lastHour2 == 23 && DateTime.Now.Hour == 0))
                {
                    if (DateTime.Now.Minute == 30)
                    {
                        lastHour2 = DateTime.Now.Hour;
                        InstantAlert();
                    }
                }
            }
        }

        public async void fetchLatestVer()
        {
            try
            {
                string url = @"https://lxmeets.lxndr.dev/latest.php";
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.examen) horarioexamButton.Visible = true;
                if ((bool)stuff.notas) notasButton.Visible = true;
                if (stuff.latest > Properties.Settings.Default.Version)
                {
                    string seleccion = lxMessageBox.Show(stuff.cambios.ToString(), stuff.type.ToString(), lxMessageBox.Buttons.OKCancel, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
                    if (seleccion == "OK")
                    {
                        OpenUrl1("https://lxmeets.lxndr.dev/lxmeets.exe");
                        Properties.Settings.Default.Version = stuff.latest;
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch { }
        }

        public async void authUser(string cedula)
        {
            try
            {
                string url = @"https://api.lxndr.dev/uae/estudiantes/?cedula=" + cedula;
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error)
                {
                    MessageBox.Show(stuff.message.ToString());
                }
                else
                {
                    Properties.Settings.Default.Cedula = cedula;
                    Properties.Settings.Default.Save();
                }
            }
            catch { }
        }

        public async void fromKeyboard(object sender, HotkeyEventArgs e)
        {
            e.Handled = true;
            try
            {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php";
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if (stuff.materia.ToString() == "No hay nada por ahora")
                {
                    notifyIcon1.Icon = Icon;
                    notifyIcon1.BalloonTipTitle = "lxMeets";
                    notifyIcon1.BalloonTipText = stuff.materia.ToString();
                    notifyIcon1.ShowBalloonTip(1000);
                    return;
                }
                OpenUrl1("https://www.apps.lxndr.dev/lxmeets/redirecter.php");
            }
            catch { }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchAPI();
            label2.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        public string getDay(string dayName)
        {
            if (dayName == "Monday" || dayName == "Lunes")
            {
                return "Lunes";
            }
            else if (dayName == "Tuesday" || dayName == "Martes")
            {
                return "Martes";
            }
            else if (dayName == "Wednesday" || dayName == "Miércoles")
            {
                return "Miercoles";
            }
            else if (dayName == "Thursday" || dayName == "Jueves")
            {
                return "Jueves";
            }
            else if (dayName == "Friday" || dayName == "Viernes")
            {
                return "Viernes";
            }
            else if (dayName == "Saturday" || dayName == "Sábado")
            {
                return "Sabado";
            }
            else if (dayName == "Sunday" || dayName == "Domingo")
            {
                return "Domingo";
            }
            else
            {
                return "";
            }
        }


        private void OpenFromIcon(object sender, EventArgs e)
        {
            this.Show();
        }

        private void CloseFromIcon(object sender, EventArgs e)
        {
            notifyIcon1.Icon = null;
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Application.Exit();
            Environment.Exit(0);

        }

        private async void fetchAPI()
        {
            cargandoAPI.Visible = true;
            try
            {
                flowLayoutPanel1.Controls.Clear();
                string url = @"https://api.lxndr.dev/uae/meets/?dia=" + comboBox1.GetItemText(comboBox1.SelectedItem);
                var client = new WebClient();
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);

                foreach (var s in stuff)
                {
                    if (s.materia.ToString() == "No hay nada por ahora") { cargandoAPI.Visible = false; return; }
                    Button l = addButton(s.materia.ToString(), s.hora.ToString());
                    flowLayoutPanel1.Controls.Add(l);
                    l.Click += delegate (object sender, EventArgs e) { ShowAlert(sender, e, s.materia.ToString(), s.hora.ToString(), s.url.ToString()); };

                }
            }
            catch { }
            cargandoAPI.Visible = false;
        }

        private void OpenUrl1(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void OpenUrl2(object sender, EventArgs e, string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void ShowAlert(object sender, EventArgs e, string materia, string horas, string url)
        {
            string seleccion = lxMessageBox.Show(horas, materia, lxMessageBox.Buttons.YesNoCancel, lxMessageBox.Icon.Warning, lxMessageBox.AnimateStyle.FadeIn).ToString();
            if (seleccion == "No")
            {
                Clipboard.SetText(url);
            }
            else if (seleccion == "Yes")
            {
                OpenUrl1(url);
            }

        }
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        private async void FiveMinutes()
        {
            try
            {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php?hora=" + RoundUp(DateTime.Parse(DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm") + ":00"), TimeSpan.FromMinutes(15)).ToShortTimeString();

                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if (stuff.materia.ToString() == "No hay nada por ahora" || !Properties.Settings.Default.Notifications) return;
                notifyIcon1.Icon = Icon;
                notifyIcon1.BalloonTipTitle = "lxMeets";
                notifyIcon1.BalloonTipText = "Dentro de 5 minutos: " + stuff.materia.ToString();
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.BalloonTipClicked += delegate (object sender, EventArgs e) { OpenUrl2(sender, e, stuff.url.ToString()); };
            }
            catch { }
        }
        private async void InstantAlert()
        {
            try
            {
                string url = @"https://api.lxndr.dev/uae/meets/exacto.php";
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if (stuff.materia.ToString() == "No hay nada por ahora" || !Properties.Settings.Default.Notifications) return;
                notifyIcon1.Icon = Icon;
                notifyIcon1.BalloonTipTitle = stuff.materia.ToString();
                notifyIcon1.BalloonTipText = stuff.hora.ToString();
                notifyIcon1.ShowBalloonTip(1000);
                notifyIcon1.BalloonTipClicked += delegate (object sender, EventArgs e) { OpenUrl2(sender, e, stuff.url.ToString()); };
            }
            catch { }
        }

        Button addButton(string materia, string hora)
        {
            Button lx = new Button();
            lx.Name = materia;
            lx.Text = materia + "\n" + hora;
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

        private void button1_Click(object sender, EventArgs e)
        {
            fetchAPI();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            this.Hide();
            notifyIcon1.Icon = Icon;
            notifyIcon1.DoubleClick += OpenFromIcon;
        }
        private void settings_Click(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "SettingsWindow")
                {
                    exist = true;
                }
            }
            if (!exist) { SettingsWindow Settings = new SettingsWindow(); Settings.Show(); }
        }

        private void settingsButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.settingsButton, "Configuración de lxMeets");
        }

        private void horarioexamButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.horarioexamButton, "Ver horario de examenes");
        }

        private void horarioButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.horarioButton, "Ver Horario de Clases");
        }

        private void horarioexamButton_Click(object sender, EventArgs e)
        {
            bool exist = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "ScheduleWindow")
                {
                    exist = true;
                }
            }
            if (!exist) { ScheduleWindow horarioEx = new ScheduleWindow("Examen"); horarioEx.Show(); }

        }

        private void horarioButton_Click(object sender, EventArgs e)
        {

            bool exist = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "ScheduleWindow")
                {
                    exist = true;
                }
            }
            if (!exist) { ScheduleWindow horarioEx = new ScheduleWindow("Clase"); horarioEx.Show(); }
        }

        private void openlxndrButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.openlxndrButton, "Abrir sitio web");
        }

        private void openlxndrButton_Click(object sender, EventArgs e)
        {
            OpenUrl1("https://lxmeets.lxndr.dev");
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            OpenUrl1("https://github.com/lxndr-rl/lxMeets-win");
        }

        private void githubButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.githubButton, "Ver código fuente");
        }

        private void notasButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.SetToolTip(this.notasButton, "Consulta calificaciones");
        }

        private void notasButton_Click(object sender, EventArgs e)
        {


            bool exist = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "GradeWindow")
                {
                    exist = true;
                }
            }
            if (!exist) { GradeWindow notas = new GradeWindow(); notas.Show(); }

        }
    }
}
