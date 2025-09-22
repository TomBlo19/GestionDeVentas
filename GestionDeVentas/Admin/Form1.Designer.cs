namespace GestionDeVentas.Admin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.iconCerrarSesion = new System.Windows.Forms.PictureBox();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.iconRegistrarProveedor = new System.Windows.Forms.PictureBox();
            this.lblRegistrarProveedor = new System.Windows.Forms.Label();
            this.iconGestionarPrendas = new System.Windows.Forms.PictureBox();
            this.lblGestionarPrendas = new System.Windows.Forms.Label();
            this.iconRegistrarPrenda = new System.Windows.Forms.PictureBox();
            this.lblRegistrarPrenda = new System.Windows.Forms.Label();
            this.iconListarProductos = new System.Windows.Forms.PictureBox();
            this.lblListarProductos = new System.Windows.Forms.Label();
            this.iconInicio = new System.Windows.Forms.PictureBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGestionarPrendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarPrenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.lblAdminPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 80);
            this.logoPanel.TabIndex = 12;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdminPanel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdminPanel.Location = new System.Drawing.Point(0, 0);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(250, 80);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Admin Panel";
            this.lblAdminPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdminPanel.Click += new System.EventHandler(this.lblAdminPanel_Click_2);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.sidePanel.Controls.Add(this.iconCerrarSesion);
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.iconRegistrarProveedor);
            this.sidePanel.Controls.Add(this.lblRegistrarProveedor);
            this.sidePanel.Controls.Add(this.iconGestionarPrendas);
            this.sidePanel.Controls.Add(this.lblGestionarPrendas);
            this.sidePanel.Controls.Add(this.iconRegistrarPrenda);
            this.sidePanel.Controls.Add(this.lblRegistrarPrenda);
            this.sidePanel.Controls.Add(this.iconListarProductos);
            this.sidePanel.Controls.Add(this.lblListarProductos);
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
            this.iconCerrarSesion.Location = new System.Drawing.Point(15, 300);
            this.iconCerrarSesion.Name = "iconCerrarSesion";
            this.iconCerrarSesion.Size = new System.Drawing.Size(24, 24);
            this.iconCerrarSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconCerrarSesion.TabIndex = 0;
            this.iconCerrarSesion.TabStop = false;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCerrarSesion.Location = new System.Drawing.Point(50, 300);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(100, 23);
            this.lblCerrarSesion.TabIndex = 1;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // iconRegistrarProveedor
            // 
            this.iconRegistrarProveedor.Image = global::GestionDeVentas.Properties.Resources.icon_client;
            this.iconRegistrarProveedor.Location = new System.Drawing.Point(15, 260);
            this.iconRegistrarProveedor.Name = "iconRegistrarProveedor";
            this.iconRegistrarProveedor.Size = new System.Drawing.Size(24, 24);
            this.iconRegistrarProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRegistrarProveedor.TabIndex = 2;
            this.iconRegistrarProveedor.TabStop = false;
            // 
            // lblRegistrarProveedor
            // 
            this.lblRegistrarProveedor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRegistrarProveedor.Location = new System.Drawing.Point(50, 260);
            this.lblRegistrarProveedor.Name = "lblRegistrarProveedor";
            this.lblRegistrarProveedor.Size = new System.Drawing.Size(194, 23);
            this.lblRegistrarProveedor.TabIndex = 3;
            this.lblRegistrarProveedor.Text = "Registrar Proveedor";
            this.lblRegistrarProveedor.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // iconGestionarPrendas
            // 
            this.iconGestionarPrendas.Image = ((System.Drawing.Image)(resources.GetObject("iconGestionarPrendas.Image")));
            this.iconGestionarPrendas.Location = new System.Drawing.Point(15, 220);
            this.iconGestionarPrendas.Name = "iconGestionarPrendas";
            this.iconGestionarPrendas.Size = new System.Drawing.Size(24, 24);
            this.iconGestionarPrendas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconGestionarPrendas.TabIndex = 4;
            this.iconGestionarPrendas.TabStop = false;
            // 
            // lblGestionarPrendas
            // 
            this.lblGestionarPrendas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblGestionarPrendas.Location = new System.Drawing.Point(50, 220);
            this.lblGestionarPrendas.Name = "lblGestionarPrendas";
            this.lblGestionarPrendas.Size = new System.Drawing.Size(171, 23);
            this.lblGestionarPrendas.TabIndex = 5;
            this.lblGestionarPrendas.Text = "Gestionar Prendas";
            this.lblGestionarPrendas.Click += new System.EventHandler(this.lblGestionarPrendas_Click);
            // 
            // iconRegistrarPrenda
            // 
            this.iconRegistrarPrenda.Image = ((System.Drawing.Image)(resources.GetObject("iconRegistrarPrenda.Image")));
            this.iconRegistrarPrenda.Location = new System.Drawing.Point(15, 180);
            this.iconRegistrarPrenda.Name = "iconRegistrarPrenda";
            this.iconRegistrarPrenda.Size = new System.Drawing.Size(24, 24);
            this.iconRegistrarPrenda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconRegistrarPrenda.TabIndex = 6;
            this.iconRegistrarPrenda.TabStop = false;
            this.iconRegistrarPrenda.Click += new System.EventHandler(this.iconRegistrarPrenda_Click);
            // 
            // lblRegistrarPrenda
            // 
            this.lblRegistrarPrenda.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRegistrarPrenda.Location = new System.Drawing.Point(50, 180);
            this.lblRegistrarPrenda.Name = "lblRegistrarPrenda";
            this.lblRegistrarPrenda.Size = new System.Drawing.Size(158, 23);
            this.lblRegistrarPrenda.TabIndex = 7;
            this.lblRegistrarPrenda.Text = "Registrar Prenda";
            this.lblRegistrarPrenda.Click += new System.EventHandler(this.lblRegistrarPrenda_Click);
            // 
            // iconListarProductos
            // 
            this.iconListarProductos.Image = global::GestionDeVentas.Properties.Resources.icon_sales;
            this.iconListarProductos.Location = new System.Drawing.Point(15, 140);
            this.iconListarProductos.Name = "iconListarProductos";
            this.iconListarProductos.Size = new System.Drawing.Size(24, 24);
            this.iconListarProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconListarProductos.TabIndex = 8;
            this.iconListarProductos.TabStop = false;
            // 
            // lblListarProductos
            // 
            this.lblListarProductos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblListarProductos.Location = new System.Drawing.Point(50, 140);
            this.lblListarProductos.Name = "lblListarProductos";
            this.lblListarProductos.Size = new System.Drawing.Size(171, 23);
            this.lblListarProductos.TabIndex = 9;
            this.lblListarProductos.Text = "Listar Productos";
            this.lblListarProductos.Click += new System.EventHandler(this.lblListarProductos_Click);
            // 
            // iconInicio
            // 
            this.iconInicio.Image = global::GestionDeVentas.Properties.Resources.icon_home;
            this.iconInicio.Location = new System.Drawing.Point(15, 100);
            this.iconInicio.Name = "iconInicio";
            this.iconInicio.Size = new System.Drawing.Size(24, 24);
            this.iconInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconInicio.TabIndex = 10;
            this.iconInicio.TabStop = false;
            this.iconInicio.Click += new System.EventHandler(this.iconInicio_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInicio.Location = new System.Drawing.Point(50, 100);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(100, 23);
            this.lblInicio.TabIndex = 11;
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
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(800, 520);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblAdminWelcome);
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
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdminWelcome.ForeColor = System.Drawing.Color.White;
            this.lblAdminWelcome.Location = new System.Drawing.Point(656, 28);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(141, 25);
            this.lblAdminWelcome.TabIndex = 1;
            this.lblAdminWelcome.Text = "Administrador";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.Name = "Form1";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconGestionarPrendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconRegistrarPrenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarProductos)).EndInit();
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
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;

        private System.Windows.Forms.PictureBox iconInicio;
        private System.Windows.Forms.PictureBox iconListarProductos;
        private System.Windows.Forms.PictureBox iconRegistrarPrenda;
        private System.Windows.Forms.PictureBox iconGestionarPrendas;
        private System.Windows.Forms.PictureBox iconRegistrarProveedor;
        private System.Windows.Forms.PictureBox iconCerrarSesion;

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblListarProductos;
        private System.Windows.Forms.Label lblRegistrarPrenda;
        private System.Windows.Forms.Label lblGestionarPrendas;
        private System.Windows.Forms.Label lblRegistrarProveedor;
        private System.Windows.Forms.Label lblCerrarSesion;
    }
}
