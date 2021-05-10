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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.horarioPicture = new System.Windows.Forms.PictureBox();
            this.cargandoPic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horarioPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gray;
            this.button1.Location = new System.Drawing.Point(873, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 25);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 25);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // horarioPicture
            // 
            this.horarioPicture.Location = new System.Drawing.Point(0, 38);
            this.horarioPicture.Name = "horarioPicture";
            this.horarioPicture.Size = new System.Drawing.Size(891, 546);
            this.horarioPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.horarioPicture.TabIndex = 0;
            this.horarioPicture.TabStop = false;
            // 
            // cargandoPic
            // 
            this.cargandoPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cargandoPic.BackgroundImage")));
            this.cargandoPic.Image = global::lxMeets.Properties.Resources.loading_icon_transparent_background_12;
            this.cargandoPic.Location = new System.Drawing.Point(384, 227);
            this.cargandoPic.Name = "cargandoPic";
            this.cargandoPic.Size = new System.Drawing.Size(136, 112);
            this.cargandoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cargandoPic.TabIndex = 7;
            this.cargandoPic.TabStop = false;
            // 
            // ScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(902, 596);
            this.Controls.Add(this.cargandoPic);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.horarioPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleWindow";
            this.Opacity = 0.85D;
            this.CenterToScreen();
            this.Text = "lxMSettings";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horarioPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox horarioPicture;
        private System.Windows.Forms.PictureBox cargandoPic;
    }
}

