using System;
using System.Windows.Forms;

namespace lxMeets
{
    public partial class ScheduleWindow : Form
    {
        public ScheduleWindow(string tipo)
        {
            InitializeComponent();
            if (tipo == "Clase")
            {
                tipo = "horario.png";
            }
            else if (tipo == "Examen")
            {
                tipo = "horarioex.png";
            }
            else tipo = "nicki-loop.gif";
            horarioPicture.LoadAsync("https://lxndr.dev/uae/res/" + tipo);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
