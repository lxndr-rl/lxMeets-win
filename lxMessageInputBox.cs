using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lxMeets
{
#pragma warning disable IDE1006 // Estilos de nombres
    public static class lxMessageInputBox
#pragma warning restore IDE1006 // Estilos de nombres
    {

        public static string ShowDialog(string title, string body, bool anio = false)
        {
            List<String> anios = new List<String>();
            Form prompt = new Form();
            ComboBox aniosLect = new ComboBox() { Left = 16, Width = 80, Top = 80, TabIndex = 1, TabStop = true };
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GradeWindow));
            prompt.Width = 280;
            prompt.Text = title;
            Label textLabel = new Label() { Left = 16, Top = 20, Width = 240, Text = body };
            textLabel.ForeColor = Color.White;
            prompt.Controls.Add(textLabel);
            prompt.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            prompt.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            prompt.FormBorderStyle = FormBorderStyle.None;
            prompt.Opacity = 0.85D;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            if (!anio)
            {
                prompt.Height = 160;
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
                prompt.Controls.Add(textBox);
                prompt.AcceptButton = confirmation;
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancelation);
                prompt.CancelButton = cancelation;
                prompt.ShowDialog();
                return textBox.Text;
            }
            else
            {
                prompt.Height = 200;
                TextBox textBox = new TextBox() { Left = 16, Top = 45, Width = 220, TabIndex = 0, TabStop = true };
                Button getAnios = new Button() { Text = "↻", Left = 240, Top = 45, Width = 30, TabIndex = 0, TabStop = true };
                getAnios.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
                getAnios.FlatAppearance.MouseOverBackColor = Color.Gray;
                getAnios.FlatStyle = FlatStyle.Flat;
                getAnios.ForeColor = Color.White;
                getAnios.Click += (sender, e) => { fetchAnios(textBox.Text); };
                Button confirmation = new Button() { Text = "Consultar", Left = 16, Width = 80, Top = 150, TabIndex = 1, TabStop = true };
                confirmation.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
                confirmation.FlatAppearance.MouseOverBackColor = Color.Gray;
                confirmation.FlatStyle = FlatStyle.Flat;
                confirmation.ForeColor = Color.White;
                confirmation.Click += (sender, e) => { prompt.Close(); };
                Button cancelation = new Button() { Text = "Cancelar", Left = 130, Width = 80, Top = 150, TabIndex = 1, TabStop = true };
                cancelation.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
                cancelation.FlatAppearance.MouseOverBackColor = Color.Gray;
                cancelation.FlatStyle = FlatStyle.Flat;
                cancelation.ForeColor = Color.White;
                cancelation.Click += (sender, e) => { textBox.Text = "Cancel"; prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(getAnios);
                prompt.AcceptButton = confirmation;
                prompt.Controls.Add(cancelation);
                prompt.CancelButton = cancelation;
                prompt.ShowDialog();
                string final = "(" + textBox.Text + ")[" + aniosLect.SelectedItem + "]";
                return final;
            }
            async void fetchAnios(string cedula)
            {
                if (!Regex.IsMatch(cedula, @"^\d+$"))
                {
                    MessageBox.Show("Cédula inválida" + cedula);
                    return;
                }
                try
                {
                    string url = @"https://api.lxndr.dev/uae/notas/anioLect.php?ced=" + cedula;
                    var client = new WebClient();
                    var json = await client.DownloadStringTaskAsync(url);
                    dynamic stuff = JsonConvert.DeserializeObject(json);
                    if ((bool)stuff.error)
                    {
                        MessageBox.Show(stuff.message.ToString());
                        return;
                    }
                    foreach (var s in stuff.anioLect)
                    {
                        anios.Add(s.ToString());

                    }
                    aniosLect.DataSource = anios;
                    aniosLect.BackColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
                    aniosLect.DropDownStyle = ComboBoxStyle.DropDownList;
                    aniosLect.ForeColor = Color.White;
                    aniosLect.FormattingEnabled = true;
                    prompt.Controls.Add(aniosLect);
                    MessageBox.Show(stuff.apellidos.ToString() + " " + stuff.nombres.ToString() + "\nCarrera: " + stuff.carrera.ToString(), "Estudiante encontrado");

                    return;
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error conectando al servidor");
                    return;
                }

            }
        }

    }

}
