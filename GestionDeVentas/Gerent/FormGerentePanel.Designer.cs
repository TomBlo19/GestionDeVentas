namespace GestionDeVentas.Gerent
{
    partial class FormGerentePanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblGerentePanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.lblRendimientoVendedores = new System.Windows.Forms.Label();
            this.lblListarVentas = new System.Windows.Forms.Label();
            this.lblReportes = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblGerenteWelcome = new System.Windows.Forms.Label();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.lblGerentePanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(4);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(267, 92);
            this.logoPanel.TabIndex = 9;
            // 
            // lblGerentePanel
            // 
            this.lblGerentePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGerentePanel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGerentePanel.Location = new System.Drawing.Point(0, 0);
            this.lblGerentePanel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGerentePanel.Name = "lblGerentePanel";
            this.lblGerentePanel.Size = new System.Drawing.Size(267, 92);
            this.lblGerentePanel.TabIndex = 0;
            this.lblGerentePanel.Text = "Panel de Gerente";
            this.lblGerentePanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.lblRendimientoVendedores);
            this.sidePanel.Controls.Add(this.lblListarVentas);
            this.sidePanel.Controls.Add(this.lblReportes);
            this.sidePanel.Controls.Add(this.lblDashboard);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(267, 554);
            this.sidePanel.TabIndex = 0;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.lblCerrarSesion.Location = new System.Drawing.Point(0, 262);
            this.lblCerrarSesion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblCerrarSesion.Size = new System.Drawing.Size(267, 37);
            this.lblCerrarSesion.TabIndex = 8;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblRendimientoVendedores
            // 
            this.lblRendimientoVendedores.BackColor = System.Drawing.Color.Transparent;
            this.lblRendimientoVendedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRendimientoVendedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRendimientoVendedores.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRendimientoVendedores.ForeColor = System.Drawing.Color.Black;
            this.lblRendimientoVendedores.Location = new System.Drawing.Point(0, 207);
            this.lblRendimientoVendedores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRendimientoVendedores.Name = "lblRendimientoVendedores";
            this.lblRendimientoVendedores.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblRendimientoVendedores.Size = new System.Drawing.Size(267, 55);
            this.lblRendimientoVendedores.TabIndex = 12;
            this.lblRendimientoVendedores.Text = "Rendimiento de Vendedores";
            this.lblRendimientoVendedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRendimientoVendedores.Click += new System.EventHandler(this.lblRendimientoVendedores_Click);
            // 
            // lblListarVentas
            // 
            this.lblListarVentas.Location = new System.Drawing.Point(0, 0);
            this.lblListarVentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListarVentas.Name = "lblListarVentas";
            this.lblListarVentas.Size = new System.Drawing.Size(133, 28);
            this.lblListarVentas.TabIndex = 13;
            // 
            // lblReportes
            // 
            this.lblReportes.BackColor = System.Drawing.Color.Transparent;
            this.lblReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportes.ForeColor = System.Drawing.Color.Black;
            this.lblReportes.Location = new System.Drawing.Point(0, 170);
            this.lblReportes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblReportes.Size = new System.Drawing.Size(267, 37);
            this.lblReportes.TabIndex = 10;
            this.lblReportes.Text = "Reportes";
            this.lblReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReportes.Click += new System.EventHandler(this.lblReportes_Click);
            // 
            // lblDashboard
            // 
            this.lblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.lblDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDashboard.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.Black;
            this.lblDashboard.Location = new System.Drawing.Point(0, 133);
            this.lblDashboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblDashboard.Size = new System.Drawing.Size(267, 37);
            this.lblDashboard.TabIndex = 2;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInicio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.Black;
            this.lblInicio.Location = new System.Drawing.Point(0, 92);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblInicio.Size = new System.Drawing.Size(267, 41);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Inicio";
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(267, 92);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 462);
            this.mainPanel.TabIndex = 2;
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(1001, 462);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            this.pictureBoxWelcome.Click += new System.EventHandler(this.pictureBoxWelcome_Click);
            // 
            // topBarPanel
            // 
            this.topBarPanel.AutoScroll = true;
            this.topBarPanel.BackColor = System.Drawing.Color.Black;
            this.topBarPanel.BackgroundImage = global::GestionDeVentas.Properties.Resources.fondo;
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblGerenteWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(267, 0);
            this.topBarPanel.Margin = new System.Windows.Forms.Padding(4);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(800, 92);
            this.topBarPanel.TabIndex = 1;
            this.topBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topBarPanel_Paint);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.ErrorImage = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.pictureBoxLogo.Location = new System.Drawing.Point(349, 15);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(89, 69);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblGerenteWelcome
            // 
            this.lblGerenteWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGerenteWelcome.AutoSize = true;
            this.lblGerenteWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.lblGerenteWelcome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGerenteWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblGerenteWelcome.Location = new System.Drawing.Point(704, 33);
            this.lblGerenteWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGerenteWelcome.Name = "lblGerenteWelcome";
            this.lblGerenteWelcome.Size = new System.Drawing.Size(79, 22);
            this.lblGerenteWelcome.TabIndex = 0;
            this.lblGerenteWelcome.Text = "Gerente";
            this.lblGerenteWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGerenteWelcome.Click += new System.EventHandler(this.lblGerenteWelcome_Click);
            // 
            // FormGerentePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGerentePanel";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Panel de Gerente";
            this.Load += new System.EventHandler(this.FormGerentePanel_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblGerentePanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.Label lblRendimientoVendedores;
        private System.Windows.Forms.Label lblListarVentas;
        private System.Windows.Forms.Label lblReportes;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label lblGerenteWelcome;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}