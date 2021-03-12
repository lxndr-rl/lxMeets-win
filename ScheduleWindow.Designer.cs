namespace lxMeets
{
    partial class ScheduleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleWindow));
            this.horarioPicture = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.horarioPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // horarioPicture
            // 
            this.horarioPicture.Image = ((System.Drawing.Image)(resources.GetObject("horarioPicture.Image")));
            this.horarioPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("horarioPicture.InitialImage")));
            this.horarioPicture.Location = new System.Drawing.Point(1, 1);
            this.horarioPicture.Name = "horarioPicture";
            this.horarioPicture.Size = new System.Drawing.Size(891, 546);
            this.horarioPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.horarioPicture.TabIndex = 0;
            this.horarioPicture.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(386, 558);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(110, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(902, 596);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.horarioPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleWindow";
            this.CenterToScreen();
            this.Opacity = 0.85D;
            this.Text = "lxMSettings";
            ((System.ComponentModel.ISupportInitialize)(this.horarioPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox horarioPicture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button closeButton;
    }
}

