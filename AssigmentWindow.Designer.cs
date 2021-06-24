
namespace lxMeets {
    partial class AssigmentWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssigmentWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.cargandoPicture = new System.Windows.Forms.PictureBox();
            this.materiasBox = new System.Windows.Forms.ComboBox();
            this.assigmentLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.recargarButton = new System.Windows.Forms.Button();
            this.TabsControl = new System.Windows.Forms.TabControl();
            this.asignacionTab = new System.Windows.Forms.TabPage();
            this.quizTab = new System.Windows.Forms.TabPage();
            this.quizzLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.profilePicture = new System.Windows.Forms.PictureBox();
            this.delayAsignCheck = new System.Windows.Forms.CheckBox();
            this.compAsignCheck = new System.Windows.Forms.CheckBox();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPicture)).BeginInit();
            this.TabsControl.SuspendLayout();
            this.asignacionTab.SuspendLayout();
            this.quizTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.Gray;
            this.BarraTitulo.Controls.Add(this.closeButton);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(884, 25);
            this.BarraTitulo.TabIndex = 7;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.Gray;
            this.closeButton.Location = new System.Drawing.Point(855, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 25);
            this.closeButton.TabIndex = 7;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cargandoPicture
            // 
            this.cargandoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cargandoPicture.Image = ((System.Drawing.Image)(resources.GetObject("cargandoPicture.Image")));
            this.cargandoPicture.Location = new System.Drawing.Point(391, 72);
            this.cargandoPicture.Name = "cargandoPicture";
            this.cargandoPicture.Size = new System.Drawing.Size(128, 43);
            this.cargandoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cargandoPicture.TabIndex = 8;
            this.cargandoPicture.TabStop = false;
            // 
            // materiasBox
            // 
            this.materiasBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.materiasBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materiasBox.ForeColor = System.Drawing.Color.White;
            this.materiasBox.FormattingEnabled = true;
            this.materiasBox.Location = new System.Drawing.Point(332, 43);
            this.materiasBox.Name = "materiasBox";
            this.materiasBox.Size = new System.Drawing.Size(219, 23);
            this.materiasBox.TabIndex = 9;
            this.materiasBox.SelectedIndexChanged += new System.EventHandler(this.materiasBox_SelectedIndexChanged);
            // 
            // assigmentLayout
            // 
            this.assigmentLayout.AutoScroll = true;
            this.assigmentLayout.BackColor = System.Drawing.Color.Transparent;
            this.assigmentLayout.Location = new System.Drawing.Point(3, 3);
            this.assigmentLayout.Name = "assigmentLayout";
            this.assigmentLayout.Size = new System.Drawing.Size(846, 234);
            this.assigmentLayout.TabIndex = 10;
            // 
            // recargarButton
            // 
            this.recargarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.recargarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.recargarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recargarButton.ForeColor = System.Drawing.Color.White;
            this.recargarButton.Location = new System.Drawing.Point(557, 43);
            this.recargarButton.Name = "recargarButton";
            this.recargarButton.Size = new System.Drawing.Size(24, 22);
            this.recargarButton.TabIndex = 11;
            this.recargarButton.Text = "↻";
            this.recargarButton.UseVisualStyleBackColor = true;
            this.recargarButton.Click += new System.EventHandler(this.recargarButton_Click);
            // 
            // TabsControl
            // 
            this.TabsControl.Controls.Add(this.asignacionTab);
            this.TabsControl.Controls.Add(this.quizTab);
            this.TabsControl.Location = new System.Drawing.Point(12, 171);
            this.TabsControl.Name = "TabsControl";
            this.TabsControl.SelectedIndex = 0;
            this.TabsControl.Size = new System.Drawing.Size(860, 295);
            this.TabsControl.TabIndex = 12;
            // 
            // asignacionTab
            // 
            this.asignacionTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.asignacionTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.asignacionTab.Controls.Add(this.assigmentLayout);
            this.asignacionTab.Location = new System.Drawing.Point(4, 24);
            this.asignacionTab.Name = "asignacionTab";
            this.asignacionTab.Padding = new System.Windows.Forms.Padding(3);
            this.asignacionTab.Size = new System.Drawing.Size(852, 267);
            this.asignacionTab.TabIndex = 0;
            this.asignacionTab.Text = "Asignaciones";
            // 
            // quizTab
            // 
            this.quizTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.quizTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quizTab.Controls.Add(this.quizzLayout);
            this.quizTab.Location = new System.Drawing.Point(4, 24);
            this.quizTab.Name = "quizTab";
            this.quizTab.Padding = new System.Windows.Forms.Padding(3);
            this.quizTab.Size = new System.Drawing.Size(852, 267);
            this.quizTab.TabIndex = 1;
            this.quizTab.Text = "Quizzes";
            // 
            // quizzLayout
            // 
            this.quizzLayout.AutoScroll = true;
            this.quizzLayout.BackColor = System.Drawing.Color.Transparent;
            this.quizzLayout.Location = new System.Drawing.Point(3, 3);
            this.quizzLayout.Name = "quizzLayout";
            this.quizzLayout.Size = new System.Drawing.Size(846, 234);
            this.quizzLayout.TabIndex = 11;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nombreLabel.ForeColor = System.Drawing.Color.White;
            this.nombreLabel.Location = new System.Drawing.Point(12, 72);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(0, 21);
            this.nombreLabel.TabIndex = 13;
            this.nombreLabel.Visible = false;
            // 
            // profilePicture
            // 
            this.profilePicture.Location = new System.Drawing.Point(788, 35);
            this.profilePicture.Name = "profilePicture";
            this.profilePicture.Size = new System.Drawing.Size(80, 80);
            this.profilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilePicture.TabIndex = 14;
            this.profilePicture.TabStop = false;
            // 
            // delayAsignCheck
            // 
            this.delayAsignCheck.AutoSize = true;
            this.delayAsignCheck.Enabled = false;
            this.delayAsignCheck.ForeColor = System.Drawing.Color.White;
            this.delayAsignCheck.Location = new System.Drawing.Point(673, 121);
            this.delayAsignCheck.Name = "delayAsignCheck";
            this.delayAsignCheck.Size = new System.Drawing.Size(195, 19);
            this.delayAsignCheck.TabIndex = 15;
            this.delayAsignCheck.Text = "Ocultar Asignaciones Anteriores";
            this.delayAsignCheck.UseVisualStyleBackColor = true;
            this.delayAsignCheck.CheckedChanged += new System.EventHandler(this.delayAsignCheck_CheckedChanged);
            // 
            // compAsignCheck
            // 
            this.compAsignCheck.AutoSize = true;
            this.compAsignCheck.Enabled = false;
            this.compAsignCheck.ForeColor = System.Drawing.Color.White;
            this.compAsignCheck.Location = new System.Drawing.Point(673, 146);
            this.compAsignCheck.Name = "compAsignCheck";
            this.compAsignCheck.Size = new System.Drawing.Size(211, 19);
            this.compAsignCheck.TabIndex = 16;
            this.compAsignCheck.Text = "Ocultar Asignaciones Completadas";
            this.compAsignCheck.UseVisualStyleBackColor = true;
            this.compAsignCheck.CheckedChanged += new System.EventHandler(this.compAsignCheck_CheckedChanged);
            // 
            // AssigmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(884, 478);
            this.Controls.Add(this.compAsignCheck);
            this.Controls.Add(this.delayAsignCheck);
            this.Controls.Add(this.profilePicture);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.TabsControl);
            this.Controls.Add(this.recargarButton);
            this.Controls.Add(this.materiasBox);
            this.Controls.Add(this.cargandoPicture);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssigmentWindow";
            this.Opacity = 0.85D;
            this.Text = "lxAssigments";
            this.Shown += new System.EventHandler(this.AssigmentWindow_Shown);
            this.BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPicture)).EndInit();
            this.TabsControl.ResumeLayout(false);
            this.asignacionTab.ResumeLayout(false);
            this.quizTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox cargandoPicture;
        private System.Windows.Forms.ComboBox materiasBox;
        private System.Windows.Forms.FlowLayoutPanel assigmentLayout;
        private System.Windows.Forms.Button recargarButton;
        private System.Windows.Forms.TabControl TabsControl;
        private System.Windows.Forms.TabPage asignacionTab;
        private System.Windows.Forms.TabPage quizTab;
        private System.Windows.Forms.FlowLayoutPanel quizzLayout;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.PictureBox profilePicture;
        private System.Windows.Forms.CheckBox delayAsignCheck;
        private System.Windows.Forms.CheckBox compAsignCheck;
    }
}