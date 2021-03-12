namespace lxMeets
{
    partial class GradeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GradeWindow));
            this.closeButton = new System.Windows.Forms.Button();
            this.tablaParcial = new System.Windows.Forms.TableLayoutPanel();
            this.tablaPromedio = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombresLabel = new System.Windows.Forms.Label();
            this.facultadLabel = new System.Windows.Forms.Label();
            this.carreraLabel = new System.Windows.Forms.Label();
            this.cargandoPicture = new System.Windows.Forms.PictureBox();
            this.otraCButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(745, 676);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(110, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // tablaParcial
            // 
            this.tablaParcial.AutoSize = true;
            this.tablaParcial.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablaParcial.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablaParcial.ColumnCount = 2;
            this.tablaParcial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaParcial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaParcial.Location = new System.Drawing.Point(12, 107);
            this.tablaParcial.Name = "tablaParcial";
            this.tablaParcial.RowCount = 2;
            this.tablaParcial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaParcial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaParcial.Size = new System.Drawing.Size(3, 3);
            this.tablaParcial.TabIndex = 1;
            // 
            // tablaPromedio
            // 
            this.tablaPromedio.AutoSize = true;
            this.tablaPromedio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablaPromedio.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tablaPromedio.ColumnCount = 2;
            this.tablaPromedio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaPromedio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaPromedio.Location = new System.Drawing.Point(12, 400);
            this.tablaPromedio.Name = "tablaPromedio";
            this.tablaPromedio.RowCount = 2;
            this.tablaPromedio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaPromedio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablaPromedio.Size = new System.Drawing.Size(3, 3);
            this.tablaPromedio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Promedios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notas Parciales";
            // 
            // nombresLabel
            // 
            this.nombresLabel.AutoSize = true;
            this.nombresLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nombresLabel.ForeColor = System.Drawing.Color.White;
            this.nombresLabel.Location = new System.Drawing.Point(30, 9);
            this.nombresLabel.Name = "nombresLabel";
            this.nombresLabel.Size = new System.Drawing.Size(0, 30);
            this.nombresLabel.TabIndex = 2;
            // 
            // facultadLabel
            // 
            this.facultadLabel.AutoSize = true;
            this.facultadLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.facultadLabel.ForeColor = System.Drawing.Color.White;
            this.facultadLabel.Location = new System.Drawing.Point(455, 74);
            this.facultadLabel.Name = "facultadLabel";
            this.facultadLabel.Size = new System.Drawing.Size(0, 30);
            this.facultadLabel.TabIndex = 2;
            // 
            // carreraLabel
            // 
            this.carreraLabel.AutoSize = true;
            this.carreraLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carreraLabel.ForeColor = System.Drawing.Color.White;
            this.carreraLabel.Location = new System.Drawing.Point(30, 39);
            this.carreraLabel.Name = "carreraLabel";
            this.carreraLabel.Size = new System.Drawing.Size(0, 30);
            this.carreraLabel.TabIndex = 2;
            // 
            // cargandoPicture
            // 
            this.cargandoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cargandoPicture.Image = ((System.Drawing.Image)(resources.GetObject("cargandoPicture.Image")));
            this.cargandoPicture.Location = new System.Drawing.Point(2, -1);
            this.cargandoPicture.Name = "cargandoPicture";
            this.cargandoPicture.Size = new System.Drawing.Size(905, 627);
            this.cargandoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cargandoPicture.TabIndex = 3;
            this.cargandoPicture.TabStop = false;
            // 
            // otraCButton
            // 
            this.otraCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.otraCButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.otraCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otraCButton.ForeColor = System.Drawing.Color.White;
            this.otraCButton.Location = new System.Drawing.Point(353, 676);
            this.otraCButton.Name = "otraCButton";
            this.otraCButton.Size = new System.Drawing.Size(161, 26);
            this.otraCButton.TabIndex = 0;
            this.otraCButton.Text = "Consultar otro número";
            this.otraCButton.UseVisualStyleBackColor = false;
            this.otraCButton.Visible = false;
            this.otraCButton.Click += new System.EventHandler(this.otraCButton_Click);
            // 
            // GradeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(912, 714);
            this.Controls.Add(this.otraCButton);
            this.Controls.Add(this.cargandoPicture);
            this.Controls.Add(this.carreraLabel);
            this.Controls.Add(this.facultadLabel);
            this.Controls.Add(this.nombresLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaPromedio);
            this.CenterToScreen();
            this.Controls.Add(this.tablaParcial);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GradeWindow";
            this.Opacity = 0.85D;
            this.Text = "lxMGrade";
            this.Shown += new System.EventHandler(this.GradeWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.cargandoPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button otraCButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tablaPromedio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nombresLabel;
        private System.Windows.Forms.Label facultadLabel;
        private System.Windows.Forms.TableLayoutPanel tablaParcial;
        private System.Windows.Forms.Label carreraLabel;
        private System.Windows.Forms.PictureBox cargandoPicture;
    }
}

