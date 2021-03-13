using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lxMeets
{
    public partial class GradeWindow : Form
    {
        WebClient client = new WebClient();
        string cedula = "";
        public GradeWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Cedula.Length > 2) { cedula = Properties.Settings.Default.Cedula; }

            else
            {
                cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

                while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
                {
                    if (cedula == "Cancel") break;
                    MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
                }
            }
            if (cedula != "Cancel") fetchAPI(cedula);


        }

        private async void fetchAPI(string cedula)
        {
            /*
             TODO
            Implementar selección de Año Lectivo
            API ya lista para consultar con año lectivo 
             */
            try
            {
                string url = @"https://api.lxndr.dev/uae/notas/?ced=" + cedula;
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void otraCButton_Click(object sender, EventArgs e)
        {
            cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");

            while ((cedula.Length < 9 && cedula.Length > 0) || !Regex.IsMatch(cedula, @"^\d+$"))
            {
                if (cedula == "Cancel") break;
                MessageBox.Show("Cédula Inválida"); cedula = lxMessageInputBox.ShowDialog("Ingresar número de cédula", "Ingresar número de cédula");
            }

            cargandoPicture.Visible = true;
            otraCButton.Visible = false;
            if (cedula == "Cancel") this.Close();

            fetchAPI(cedula);
        }

        private void GradeWindow_Shown(object sender, EventArgs e)
        {
            if (cedula == "Cancel") this.Close();
        }
    }
}
