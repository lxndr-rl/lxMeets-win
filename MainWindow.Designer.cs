using System.Drawing;

namespace lxMeets
{
    partial class lxMeets
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lxMeets));
            this.reloadButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.notasButton = new System.Windows.Forms.Button();
            this.githubButton = new System.Windows.Forms.Button();
            this.openlxndrButton = new System.Windows.Forms.Button();
            this.horarioexamButton = new System.Windows.Forms.Button();
            this.horarioButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.cargandoAPI = new System.Windows.Forms.PictureBox();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargandoAPI)).BeginInit();
            this.SuspendLayout();
            // 
            // reloadButton
            // 
            this.reloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.reloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.reloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reloadButton.ForeColor = System.Drawing.Color.White;
            this.reloadButton.Location = new System.Drawing.Point(377, 71);
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(143, 39);
            this.reloadButton.TabIndex = 0;
            this.reloadButton.Text = "Recargar";
            this.reloadButton.UseVisualStyleBackColor = false;
            this.reloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "lxMeets";
            this.notifyIcon1.Visible = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(406, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione Día";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes"});
            this.comboBox1.Location = new System.Drawing.Point(377, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 23);
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(391, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 30);
            this.label2.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 197);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(821, 363);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.Gray;
            this.BarraTitulo.Controls.Add(this.notasButton);
            this.BarraTitulo.Controls.Add(this.githubButton);
            this.BarraTitulo.Controls.Add(this.openlxndrButton);
            this.BarraTitulo.Controls.Add(this.horarioexamButton);
            this.BarraTitulo.Controls.Add(this.horarioButton);
            this.BarraTitulo.Controls.Add(this.settingsButton);
            this.BarraTitulo.Controls.Add(this.closeButton);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(845, 25);
            this.BarraTitulo.TabIndex = 6;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // notasButton
            // 
            this.notasButton.BackColor = System.Drawing.Color.Transparent;
            this.notasButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("notasButton.BackgroundImage")));
            this.notasButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.notasButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.notasButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notasButton.ForeColor = System.Drawing.Color.Gray;
            this.notasButton.Location = new System.Drawing.Point(331, 0);
            this.notasButton.Name = "notasButton";
            this.notasButton.Size = new System.Drawing.Size(29, 25);
            this.notasButton.TabIndex = 7;
            this.notasButton.UseVisualStyleBackColor = false;
            this.notasButton.Visible = false;
            this.notasButton.Click += new System.EventHandler(this.notasButton_Click);
            this.notasButton.MouseHover += new System.EventHandler(this.notasButton_MouseHover);
            // 
            // githubButton
            // 
            this.githubButton.BackColor = System.Drawing.Color.Transparent;
            this.githubButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("githubButton.BackgroundImage")));
            this.githubButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.githubButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.githubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubButton.ForeColor = System.Drawing.Color.Gray;
            this.githubButton.Location = new System.Drawing.Point(35, 0);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(29, 25);
            this.githubButton.TabIndex = 7;
            this.githubButton.UseVisualStyleBackColor = false;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            this.githubButton.MouseHover += new System.EventHandler(this.githubButton_MouseHover);
            // 
            // openlxndrButton
            // 
            this.openlxndrButton.BackColor = System.Drawing.Color.Transparent;
            this.openlxndrButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("openlxndrButton.BackgroundImage")));
            this.openlxndrButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openlxndrButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.openlxndrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openlxndrButton.ForeColor = System.Drawing.Color.Gray;
            this.openlxndrButton.Location = new System.Drawing.Point(0, 0);
            this.openlxndrButton.Name = "openlxndrButton";
            this.openlxndrButton.Size = new System.Drawing.Size(29, 25);
            this.openlxndrButton.TabIndex = 7;
            this.openlxndrButton.UseVisualStyleBackColor = false;
            this.openlxndrButton.Click += new System.EventHandler(this.openlxndrButton_Click);
            this.openlxndrButton.MouseHover += new System.EventHandler(this.openlxndrButton_MouseHover);
            // 
            // horarioexamButton
            // 
            this.horarioexamButton.BackColor = System.Drawing.Color.Transparent;
            this.horarioexamButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("horarioexamButton.BackgroundImage")));
            this.horarioexamButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.horarioexamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.horarioexamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.horarioexamButton.ForeColor = System.Drawing.Color.Gray;
            this.horarioexamButton.Location = new System.Drawing.Point(491, 0);
            this.horarioexamButton.Name = "horarioexamButton";
            this.horarioexamButton.Size = new System.Drawing.Size(29, 25);
            this.horarioexamButton.TabIndex = 7;
            this.horarioexamButton.UseVisualStyleBackColor = false;
            this.horarioexamButton.Visible = false;
            this.horarioexamButton.Click += new System.EventHandler(this.horarioexamButton_Click);
            this.horarioexamButton.MouseHover += new System.EventHandler(this.horarioexamButton_MouseHover);
            // 
            // horarioButton
            // 
            this.horarioButton.BackColor = System.Drawing.Color.Transparent;
            this.horarioButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("horarioButton.BackgroundImage")));
            this.horarioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.horarioButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.horarioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.horarioButton.ForeColor = System.Drawing.Color.Gray;
            this.horarioButton.Location = new System.Drawing.Point(436, 0);
            this.horarioButton.Name = "horarioButton";
            this.horarioButton.Size = new System.Drawing.Size(29, 25);
            this.horarioButton.TabIndex = 7;
            this.horarioButton.UseVisualStyleBackColor = false;
            this.horarioButton.Click += new System.EventHandler(this.horarioButton_Click);
            this.horarioButton.MouseHover += new System.EventHandler(this.horarioButton_MouseHover);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            this.settingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsButton.BackgroundImage")));
            this.settingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.Gray;
            this.settingsButton.Location = new System.Drawing.Point(377, 0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(29, 25);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settings_Click);
            this.settingsButton.MouseHover += new System.EventHandler(this.settingsButton_MouseHover);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.Gray;
            this.closeButton.Location = new System.Drawing.Point(816, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 25);
            this.closeButton.TabIndex = 7;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cargandoAPI
            // 
            this.cargandoAPI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cargandoAPI.BackgroundImage")));
            this.cargandoAPI.Image = ((System.Drawing.Image)(resources.GetObject("cargandoAPI.Image")));
            this.cargandoAPI.Location = new System.Drawing.Point(377, 146);
            this.cargandoAPI.Name = "cargandoAPI";
            this.cargandoAPI.Size = new System.Drawing.Size(93, 56);
            this.cargandoAPI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cargandoAPI.TabIndex = 0;
            this.cargandoAPI.TabStop = false;
            this.cargandoAPI.Visible = false;
            // 
            // lxMeets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(845, 572);
            this.ControlBox = false;
            this.Controls.Add(this.cargandoAPI);
            this.CenterToScreen();
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reloadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "lxMeets";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "lxMeets";
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cargandoAPI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reloadButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button horarioButton;
        private System.Windows.Forms.Button horarioexamButton;
        private System.Windows.Forms.Button openlxndrButton;
        private System.Windows.Forms.Button githubButton;
        private System.Windows.Forms.Button notasButton;
        private System.Windows.Forms.PictureBox cargandoAPI;
    }
}

