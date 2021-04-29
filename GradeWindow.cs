using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lxMeets
{
    public partial class GradeWindow : Form
    {
        WebClient client = new WebClient();
        string cedula = "";
        string anioLectivo = "";
        public GradeWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Cedula.Length > 2) { cedula = Properties.Settings.Default.Cedula; }

            else
            {
                cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula", true);
                anioLectivo = cedula.Split('[', ']')[1];
                cedula = cedula.Split('(', ')')[1];
                while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
                {

                    if (cedula == "Cancel") break;
                    MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                }
            }
            if (cedula != "Cancel") fetchAPI(cedula, anioLectivo);


        }

        private async void fetchAPI(string cedula, string anioLect)
        {
            try
            {
                carreraLabel.Visible = false;
                nombresLabel.Visible = false;
                label1.Visible = false;
                facultadLabel.Visible = false;
                label2.Visible = false;
                tablaParcial.Visible = false;
                tablaPromedio.Visible = false;
                string url = @"https://api.lxndr.dev/uae/notas/?ced=" + cedula + "&alectivo=" + anioLect;
                if (cedula.Length == 0) this.Close();
                var json = await client.DownloadStringTaskAsync(url);
                dynamic stuff = JsonConvert.DeserializeObject(json);
                if ((bool)stuff.error) { MessageBox.Show(stuff.message.ToString()); this.Close(); }
                otraCButton.Visible = true;
                nombresLabel.Text = stuff.apellidos + " " + stuff.nombres;
                carreraLabel.Text = stuff.carrera;
                facultadLabel.Text = stuff.facultad;
                GenerateTable(stuff.parciales.Count, stuff.parciales[0].Count, tablaParcial, stuff, "parciales");
                GenerateTable(stuff.promedios.Count, stuff.promedios[0].Count, tablaPromedio, stuff, "promedios");
                label1.Visible = true;
                label2.Visible = true;
                tablaParcial.Visible = true;
                carreraLabel.Visible = true;
                nombresLabel.Visible = true;
                facultadLabel.Visible = true;
                tablaPromedio.Visible = true;
                cargandoPicture.Visible = false;
            }
            catch (Exception e) { }
        }

        private void GenerateTable(int rowCount, int columnCount, TableLayoutPanel tableController, dynamic stuff, string tipo)
        {
            tableController.Controls.Clear();
            tableController.ColumnStyles.Clear();
            tableController.RowStyles.Clear();
            tableController.AutoScroll = true;
            tableController.ColumnCount = columnCount;
            tableController.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                tableController.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int y = 0; y < rowCount; y++)
                {
                    if (x == 0)
                    {
                        tableController.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }

                    Label cmd = new Label();
                    cmd.AutoSize = true;
                    if (y == 0)
                    {
                        cmd.AutoSize = false;
                        cmd.TextAlign = ContentAlignment.MiddleCenter;
                        cmd.Font = new Font(cmd.Font, FontStyle.Bold);
                        cmd.Dock = DockStyle.None;
                    }

                    cmd.ForeColor = Color.White;
                    cmd.Text = stuff[tipo][y][x].ToString();
                    tableController.Controls.Add(cmd, x, y);
                }
            }
        }

        private void otraCButton_Click(object sender, EventArgs e)
        {
            cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula", true);
            anioLectivo = cedula.Split('[', ']')[1];
            cedula = cedula.Split('(', ')')[1];
            while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
            {
                if (cedula == "Cancel") break;
                MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
            }
            if (cedula == "Cancel") return;
            cargandoPicture.Visible = true;
            otraCButton.Visible = false;

            fetchAPI(cedula, anioLectivo);
        }

        private void GradeWindow_Shown(object sender, EventArgs e)
        {
            if (cedula == "Cancel") this.Close();
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

        private void cerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
