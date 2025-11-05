using GestionDeVentas.Properties;

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
            this.iconCerrarSesion = new System.Windows.Forms.PictureBox();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.iconRendimientoVendedores = new System.Windows.Forms.PictureBox();
            this.lblRendimientoVendedores = new System.Windows.Forms.Label();
            this.iconDashboard = new System.Windows.Forms.PictureBox();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.iconInicio = new System.Windows.Forms.PictureBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblGerenteWelcome = new System.Windows.Forms.Label();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRendimientoVendedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).BeginInit();
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
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 80);
            this.logoPanel.TabIndex = 12;
            // 
            // lblGerentePanel
            // 
            this.lblGerentePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(190)))), ((int)(((byte)(170)))));
            this.lblGerentePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGerentePanel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGerentePanel.Location = new System.Drawing.Point(0, 0);
            this.lblGerentePanel.Name = "lblGerentePanel";
            this.lblGerentePanel.Size = new System.Drawing.Size(250, 80);
            this.lblGerentePanel.TabIndex = 0;
            this.lblGerentePanel.Text = "Gerente Panel";
            this.lblGerentePanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.sidePanel.Controls.Add(this.iconCerrarSesion);
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.iconRendimientoVendedores);
            this.sidePanel.Controls.Add(this.lblRendimientoVendedores);
            this.sidePanel.Controls.Add(this.iconDashboard);
            this.sidePanel.Controls.Add(this.lblDashboard);
            this.sidePanel.Controls.Add(this.iconInicio);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(250, 600);
            this.sidePanel.TabIndex = 2;
            // 
            // iconCerrarSesion
            // 
            this.iconCerrarSesion.Image = global::GestionDeVentas.Properties.Resources.icon_logout;
            this.iconCerrarSesion.Location = new System.Drawing.Point(15, 260);
            this.iconCerrarSesion.Name = "iconCerrarSesion";
            this.iconCerrarSesion.Size = new System.Drawing.Size(24, 24);
            this.iconCerrarSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconCerrarSesion.TabIndex = 0;
            this.iconCerrarSesion.TabStop = false;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCerrarSesion.Location = new System.Drawing.Point(50, 260);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(100, 23);
            this.lblCerrarSesion.TabIndex = 1;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // iconRendimientoVendedores
            // 
            this.iconRendimientoVendedores.Image = global::GestionDeVentas.Properties.Resources.icon_client;
            this.iconRendimientoVendedores.Location = new System.Drawing.Point(15, 181);
            this.iconRendimientoVendedores.Name = "iconRendimientoVendedores";
            this.iconRendimientoVendedores.Size = new System.Drawing.Size(24, 24);
            this.iconRendimientoVendedores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRendimientoVendedores.TabIndex = 2;
            this.iconRendimientoVendedores.TabStop = false;
            // 
            // lblRendimientoVendedores
            // 
            this.lblRendimientoVendedores.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRendimientoVendedores.Location = new System.Drawing.Point(50, 182);
            this.lblRendimientoVendedores.Name = "lblRendimientoVendedores";
            this.lblRendimientoVendedores.Size = new System.Drawing.Size(194, 23);
            this.lblRendimientoVendedores.TabIndex = 3;
            this.lblRendimientoVendedores.Text = "Rendimiento Vendedores";
            this.lblRendimientoVendedores.Click += new System.EventHandler(this.lblRendimientoVendedores_Click);
            // 
            // iconDashboard
            // 
            this.iconDashboard.Image = global::GestionDeVentas.Properties.Resources.icon_manage;
            this.iconDashboard.Location = new System.Drawing.Point(15, 140);
            this.iconDashboard.Name = "iconDashboard";
            this.iconDashboard.Size = new System.Drawing.Size(24, 24);
            this.iconDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconDashboard.TabIndex = 6;
            this.iconDashboard.TabStop = false;
            // 
            // lblDashboard
            // 
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDashboard.Location = new System.Drawing.Point(50, 140);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(171, 23);
            this.lblDashboard.TabIndex = 7;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            // 
            // iconInicio
            // 
            this.iconInicio.Image = global::GestionDeVentas.Properties.Resources.icon_home;
            this.iconInicio.Location = new System.Drawing.Point(15, 100);
            this.iconInicio.Name = "iconInicio";
            this.iconInicio.Size = new System.Drawing.Size(24, 24);
            this.iconInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconInicio.TabIndex = 8;
            this.iconInicio.TabStop = false;
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInicio.Location = new System.Drawing.Point(50, 100);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(100, 23);
            this.lblInicio.TabIndex = 9;
            this.lblInicio.Text = "Inicio";
            this.lblInicio.Click += new System.EventHandler(this.lblInicio_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.pictureBoxWelcome);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(250, 80);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 520);
            this.mainPanel.TabIndex = 0;
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.BackColor = System.Drawing.Color.White;
            this.pictureBoxWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWelcome.Image = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(800, 520);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            this.pictureBoxWelcome.Click += new System.EventHandler(this.pictureBoxWelcome_Click);
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblGerenteWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(250, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(800, 80);
            this.topBarPanel.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logo_empresa;
            this.pictureBoxLogo.Location = new System.Drawing.Point(350, 10);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(80, 60);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblGerenteWelcome
            // 
            this.lblGerenteWelcome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblGerenteWelcome.AutoSize = true;
            this.lblGerenteWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGerenteWelcome.ForeColor = System.Drawing.Color.White;
            this.lblGerenteWelcome.Location = new System.Drawing.Point(705, 30);
            this.lblGerenteWelcome.Name = "lblGerenteWelcome";
            this.lblGerenteWelcome.Size = new System.Drawing.Size(65, 20);
            this.lblGerenteWelcome.TabIndex = 1;
            this.lblGerenteWelcome.Text = "Gerente";
            this.lblGerenteWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormGerentePanel
            // 
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.Name = "FormGerentePanel";
            this.Text = "Gerente Panel";
            this.Load += new System.EventHandler(this.FormGerentePanel_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRendimientoVendedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).EndInit();
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
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblGerenteWelcome;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;

        private System.Windows.Forms.PictureBox iconInicio;
        private System.Windows.Forms.PictureBox iconDashboard;
        private System.Windows.Forms.PictureBox iconRendimientoVendedores;
        private System.Windows.Forms.PictureBox iconCerrarSesion;

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblRendimientoVendedores;
        private System.Windows.Forms.Label lblCerrarSesion;
    }
}