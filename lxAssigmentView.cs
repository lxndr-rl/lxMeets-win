using System;
using System.Drawing;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace lxMeets {
#pragma warning disable IDE1006 // Estilos de nombres
    public static class lxAssigmentView
#pragma warning restore IDE1006 // Estilos de nombres
    {

        public static void ShowDialog(string title, dynamic attachment, string duedate = "", string description = "", bool quiz = false, string desde = "", string hasta = "", string limit = "") {
            Form prompt = new Form();
            HtmlPanel _lblMessage = new HtmlPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lxMeets));
            prompt.Width = 700;
            prompt.Height = 300;
            prompt.BackColor = Color.FromArgb(45, 45, 48);
            _lblMessage.Left = 16;

            if (quiz) {
                _lblMessage.Text = "<p style='color: white'>Habilitado desde: " + desde + "<br>Hasta: " + hasta + "<br>Tiempo Límite: " + limit + " </p>" + "<br>" + description;
            } else {
                _lblMessage.Text = "<p style='color: white'>Entrega hasta: " + duedate + " </p>" + "<br>" + description;
            }
            foreach (var s in attachment) {
                try {
                    _lblMessage.Text += "<br> <a href='" + s.fileurltoken.ToString() + "'>" + s.filename.ToString() + " ⤓</a> <p style='color: white'>" + Convert.ToInt32(s.filesize) + " KB </p>";
                } catch { }
            }
            _lblMessage.Top = 100;
            _lblMessage.Width = 80;
            _lblMessage.TabIndex = 1;
            _lblMessage.TabStop = true;
            _lblMessage.ForeColor = Color.White;
            _lblMessage.BackColor = prompt.BackColor;
            _lblMessage.Font = new Font("Segoe UI", 10);
            _lblMessage.Dock = DockStyle.Fill;
            prompt.Name = title;
            prompt.AutoSize = true;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            prompt.Text = title;
            prompt.Controls.Add(_lblMessage);
            prompt.ShowDialog();
        }
    }

}
