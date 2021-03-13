using System;
using System.Runtime.InteropServices;
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
            cargandoPic.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
