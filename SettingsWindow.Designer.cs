namespace lxMeets
{
    partial class SettingsWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.autoRunCheck = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyboardShortCutText = new System.Windows.Forms.TextBox();
            this.useKeyboardCheck = new System.Windows.Forms.CheckBox();
            this.sendNotificationsCheck = new System.Windows.Forms.CheckBox();
            this.useCedulaCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cambiarCedula = new System.Windows.Forms.Button();
            this.cedDefault = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoRunCheck
            // 
            this.autoRunCheck.AutoSize = true;
            this.autoRunCheck.ForeColor = System.Drawing.Color.White;
            this.autoRunCheck.Location = new System.Drawing.Point(34, 23);
            this.autoRunCheck.Name = "autoRunCheck";
            this.autoRunCheck.Size = new System.Drawing.Size(87, 19);
            this.autoRunCheck.TabIndex = 1;
            this.autoRunCheck.Text = "Auto Iniciar";
            this.autoRunCheck.UseVisualStyleBackColor = true;
            this.autoRunCheck.CheckedChanged += new System.EventHandler(this.AutoRunCheck_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(164, 184);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 25);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Cerrar";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keyboardShortCutText);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(260, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 47);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atajo";
            // 
            // keyboardShortCutText
            // 
            this.keyboardShortCutText.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.keyboardShortCutText.Enabled = false;
            this.keyboardShortCutText.ForeColor = System.Drawing.Color.Transparent;
            this.keyboardShortCutText.Location = new System.Drawing.Point(36, 18);
            this.keyboardShortCutText.Name = "keyboardShortCutText";
            this.keyboardShortCutText.Size = new System.Drawing.Size(132, 23);
            this.keyboardShortCutText.TabIndex = 3;
            // 
            // useKeyboardCheck
            // 
            this.useKeyboardCheck.AutoSize = true;
            this.useKeyboardCheck.ForeColor = System.Drawing.Color.White;
            this.useKeyboardCheck.Location = new System.Drawing.Point(260, 23);
            this.useKeyboardCheck.Name = "useKeyboardCheck";
            this.useKeyboardCheck.Size = new System.Drawing.Size(144, 19);
            this.useKeyboardCheck.TabIndex = 1;
            this.useKeyboardCheck.Text = "Usar Atajos de Teclado";
            this.useKeyboardCheck.UseVisualStyleBackColor = true;
            this.useKeyboardCheck.CheckedChanged += new System.EventHandler(this.UseKeyboardCheck_CheckedChanged);
            // 
            // sendNotificationsCheck
            // 
            this.sendNotificationsCheck.AutoSize = true;
            this.sendNotificationsCheck.ForeColor = System.Drawing.Color.White;
            this.sendNotificationsCheck.Location = new System.Drawing.Point(34, 97);
            this.sendNotificationsCheck.Name = "sendNotificationsCheck";
            this.sendNotificationsCheck.Size = new System.Drawing.Size(102, 19);
            this.sendNotificationsCheck.TabIndex = 1;
            this.sendNotificationsCheck.Text = "Notificaciones";
            this.sendNotificationsCheck.UseVisualStyleBackColor = true;
            this.sendNotificationsCheck.CheckedChanged += new System.EventHandler(this.SendNotificationsCheck_CheckedChanged);
            // 
            // useCedulaCheck
            // 
            this.useCedulaCheck.AutoSize = true;
            this.useCedulaCheck.ForeColor = System.Drawing.Color.White;
            this.useCedulaCheck.Location = new System.Drawing.Point(34, 147);
            this.useCedulaCheck.Name = "useCedulaCheck";
            this.useCedulaCheck.Size = new System.Drawing.Size(128, 19);
            this.useCedulaCheck.TabIndex = 4;
            this.useCedulaCheck.Text = "Cédula Por Defecto";
            this.useCedulaCheck.UseVisualStyleBackColor = true;
            this.useCedulaCheck.CheckedChanged += new System.EventHandler(this.useCedulaCheck_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cambiarCedula);
            this.groupBox2.Controls.Add(this.cedDefault);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(260, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 54);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cédula";
            // 
            // cambiarCedula
            // 
            this.cambiarCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cambiarCedula.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cambiarCedula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cambiarCedula.ForeColor = System.Drawing.Color.White;
            this.cambiarCedula.Location = new System.Drawing.Point(150, 18);
            this.cambiarCedula.Name = "cambiarCedula";
            this.cambiarCedula.Size = new System.Drawing.Size(36, 27);
            this.cambiarCedula.TabIndex = 6;
            this.cambiarCedula.Text = "⇆";
            this.cambiarCedula.UseVisualStyleBackColor = false;
            this.cambiarCedula.Click += new System.EventHandler(this.cambiarCedula_Click);
            // 
            // cedDefault
            // 
            this.cedDefault.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cedDefault.Enabled = false;
            this.cedDefault.ForeColor = System.Drawing.Color.Transparent;
            this.cedDefault.Location = new System.Drawing.Point(12, 21);
            this.cedDefault.Name = "cedDefault";
            this.cedDefault.Size = new System.Drawing.Size(132, 23);
            this.cedDefault.TabIndex = 3;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.Controls.Add(this.useCedulaCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sendNotificationsCheck);
            this.Controls.Add(this.useKeyboardCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.autoRunCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.Opacity = 0.85D;
            this.Text = "lxMSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoRunCheck;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox keyboardShortCutText;
        private System.Windows.Forms.CheckBox useKeyboardCheck;
        private System.Windows.Forms.CheckBox sendNotificationsCheck;
        private System.Windows.Forms.CheckBox useCedulaCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox cedDefault;
        private System.Windows.Forms.Button cambiarCedula;
    }
}

