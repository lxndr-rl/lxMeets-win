using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace lxMeets
{
    public static class lxMessageInputBox
    {
        public static string ShowDialog(string title, string body)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GradeWindow));
            Form prompt = new Form();
            prompt.Width = 280;
            prompt.Height = 160;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = body };
            textLabel.ForeColor = Color.White;
            TextBox textBox = new TextBox() { Left = 16, Top = 45, Width = 240, TabIndex = 0, TabStop = true };
            Button confirmation = new Button() { Text = "Consultar", Left = 16, Width = 80, Top = 88, TabIndex = 1, TabStop = true };
            confirmation.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            confirmation.FlatAppearance.MouseOverBackColor = Color.Gray;
            confirmation.FlatStyle = FlatStyle.Flat;
            confirmation.ForeColor = Color.White;
            confirmation.Click += (sender, e) => { prompt.Close(); };
            Button cancelation = new Button() { Text = "Cancelar", Left = 130, Width = 80, Top = 88, TabIndex = 1, TabStop = true };
            cancelation.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            cancelation.FlatAppearance.MouseOverBackColor = Color.Gray;
            cancelation.FlatStyle = FlatStyle.Flat;
            cancelation.ForeColor = Color.White;
            cancelation.Click += (sender, e) => { textBox.Text = "Cancel"; prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            prompt.Controls.Add(textBox);
            prompt.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            prompt.FormBorderStyle = FormBorderStyle.None;
            prompt.Controls.Add(confirmation);
            prompt.Opacity = 0.85D;
            prompt.AcceptButton = confirmation;
            prompt.Controls.Add(cancelation);
            prompt.CancelButton = cancelation;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();
            return textBox.Text;
        }
    }

}
