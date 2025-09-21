namespace GestionDeVentas.vendedor
{
    partial class FormVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendedor));
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblVendedorPanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.lblAñadirCliente = new System.Windows.Forms.Label();
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.lblListarVentas = new System.Windows.Forms.Label();
            this.lblListarProductos = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.lblVendedorWelcome = new System.Windows.Forms.Label();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.iconCerrarSesion = new System.Windows.Forms.PictureBox();
            this.iconAñadirCliente = new System.Windows.Forms.PictureBox();
            this.iconFacturacion = new System.Windows.Forms.PictureBox();
            this.iconListarVentas = new System.Windows.Forms.PictureBox();
            this.iconListarProductos = new System.Windows.Forms.PictureBox();
            this.iconInicio = new System.Windows.Forms.PictureBox();
            this.logoPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAñadirCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFacturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.lblVendedorPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 80);
            this.logoPanel.TabIndex = 0;
            // 
            // lblVendedorPanel
            // 
            this.lblVendedorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVendedorPanel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblVendedorPanel.Location = new System.Drawing.Point(0, 0);
            this.lblVendedorPanel.Name = "lblVendedorPanel";
            this.lblVendedorPanel.Size = new System.Drawing.Size(250, 80);
            this.lblVendedorPanel.TabIndex = 0;
            this.lblVendedorPanel.Text = "Panel de Ventas";
            this.lblVendedorPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.sidePanel.Controls.Add(this.iconCerrarSesion);
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.iconAñadirCliente);
            this.sidePanel.Controls.Add(this.lblAñadirCliente);
            this.sidePanel.Controls.Add(this.iconFacturacion);
            this.sidePanel.Controls.Add(this.lblFacturacion);
            this.sidePanel.Controls.Add(this.iconListarVentas);
            this.sidePanel.Controls.Add(this.lblListarVentas);
            this.sidePanel.Controls.Add(this.iconListarProductos);
            this.sidePanel.Controls.Add(this.lblListarProductos);
            this.sidePanel.Controls.Add(this.iconInicio);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(250, 600);
            this.sidePanel.TabIndex = 1;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCerrarSesion.Location = new System.Drawing.Point(50, 305);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Size = new System.Drawing.Size(200, 24);
            this.lblCerrarSesion.TabIndex = 1;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblAñadirCliente
            // 
            this.lblAñadirCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAñadirCliente.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAñadirCliente.Location = new System.Drawing.Point(50, 262);
            this.lblAñadirCliente.Name = "lblAñadirCliente";
            this.lblAñadirCliente.Size = new System.Drawing.Size(200, 24);
            this.lblAñadirCliente.TabIndex = 3;
            this.lblAñadirCliente.Text = "Añadir Cliente";
            this.lblAñadirCliente.Click += new System.EventHandler(this.lblAñadirCliente_Click);
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFacturacion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFacturacion.Location = new System.Drawing.Point(50, 223);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Size = new System.Drawing.Size(200, 24);
            this.lblFacturacion.TabIndex = 5;
            this.lblFacturacion.Text = "Facturación";
            this.lblFacturacion.Click += new System.EventHandler(this.lblFacturacion_Click);
            // 
            // lblListarVentas
            // 
            this.lblListarVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarVentas.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblListarVentas.Location = new System.Drawing.Point(47, 184);
            this.lblListarVentas.Name = "lblListarVentas";
            this.lblListarVentas.Size = new System.Drawing.Size(200, 24);
            this.lblListarVentas.TabIndex = 7;
            this.lblListarVentas.Text = "Listar Ventas";
            this.lblListarVentas.Click += new System.EventHandler(this.lblListarVentas_Click);
            // 
            // lblListarProductos
            // 
            this.lblListarProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarProductos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblListarProductos.Location = new System.Drawing.Point(45, 145);
            this.lblListarProductos.Name = "lblListarProductos";
            this.lblListarProductos.Size = new System.Drawing.Size(200, 24);
            this.lblListarProductos.TabIndex = 9;
            this.lblListarProductos.Text = "Listar Productos";
            this.lblListarProductos.Click += new System.EventHandler(this.lblListarProductos_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInicio.Location = new System.Drawing.Point(50, 104);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(200, 24);
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
            this.mainPanel.TabIndex = 2;
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblVendedorWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(250, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(800, 80);
            this.topBarPanel.TabIndex = 3;
            // 
            // lblVendedorWelcome
            // 
            this.lblVendedorWelcome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVendedorWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVendedorWelcome.ForeColor = System.Drawing.Color.White;
            this.lblVendedorWelcome.Location = new System.Drawing.Point(680, 30);
            this.lblVendedorWelcome.Name = "lblVendedorWelcome";
            this.lblVendedorWelcome.Size = new System.Drawing.Size(100, 23);
            this.lblVendedorWelcome.TabIndex = 1;
            this.lblVendedorWelcome.Text = "Vendedor";
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
            // iconCerrarSesion
            // 
            this.iconCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("iconCerrarSesion.Image")));
            this.iconCerrarSesion.Location = new System.Drawing.Point(17, 306);
            this.iconCerrarSesion.Name = "iconCerrarSesion";
            this.iconCerrarSesion.Size = new System.Drawing.Size(29, 24);
            this.iconCerrarSesion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconCerrarSesion.TabIndex = 0;
            this.iconCerrarSesion.TabStop = false;
            // 
            // iconAñadirCliente
            // 
            this.iconAñadirCliente.Image = ((System.Drawing.Image)(resources.GetObject("iconAñadirCliente.Image")));
            this.iconAñadirCliente.Location = new System.Drawing.Point(15, 263);
            this.iconAñadirCliente.Name = "iconAñadirCliente";
            this.iconAñadirCliente.Size = new System.Drawing.Size(29, 24);
            this.iconAñadirCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconAñadirCliente.TabIndex = 2;
            this.iconAñadirCliente.TabStop = false;
            // 
            // iconFacturacion
            // 
            this.iconFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("iconFacturacion.Image")));
            this.iconFacturacion.Location = new System.Drawing.Point(15, 224);
            this.iconFacturacion.Name = "iconFacturacion";
            this.iconFacturacion.Size = new System.Drawing.Size(29, 24);
            this.iconFacturacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconFacturacion.TabIndex = 4;
            this.iconFacturacion.TabStop = false;
            // 
            // iconListarVentas
            // 
            this.iconListarVentas.Image = ((System.Drawing.Image)(resources.GetObject("iconListarVentas.Image")));
            this.iconListarVentas.Location = new System.Drawing.Point(15, 180);
            this.iconListarVentas.Name = "iconListarVentas";
            this.iconListarVentas.Size = new System.Drawing.Size(29, 34);
            this.iconListarVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconListarVentas.TabIndex = 6;
            this.iconListarVentas.TabStop = false;
            // 
            // iconListarProductos
            // 
            this.iconListarProductos.Image = ((System.Drawing.Image)(resources.GetObject("iconListarProductos.Image")));
            this.iconListarProductos.Location = new System.Drawing.Point(15, 140);
            this.iconListarProductos.Name = "iconListarProductos";
            this.iconListarProductos.Size = new System.Drawing.Size(29, 34);
            this.iconListarProductos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconListarProductos.TabIndex = 8;
            this.iconListarProductos.TabStop = false;
            // 
            // iconInicio
            // 
            this.iconInicio.Image = ((System.Drawing.Image)(resources.GetObject("iconInicio.Image")));
            this.iconInicio.Location = new System.Drawing.Point(15, 100);
            this.iconInicio.Name = "iconInicio";
            this.iconInicio.Size = new System.Drawing.Size(29, 30);
            this.iconInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconInicio.TabIndex = 10;
            this.iconInicio.TabStop = false;
            // 
            // FormVendedor
            // 
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.Name = "FormVendedor";
            this.Text = "Panel de Ventas";
            this.Load += new System.EventHandler(this.FormVendedor_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.topBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrarSesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAñadirCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconFacturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconListarProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblVendedorPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblVendedorWelcome;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;

        private System.Windows.Forms.PictureBox iconInicio;
        private System.Windows.Forms.PictureBox iconListarProductos;
        private System.Windows.Forms.PictureBox iconListarVentas;
        private System.Windows.Forms.PictureBox iconFacturacion;
        private System.Windows.Forms.PictureBox iconAñadirCliente;
        private System.Windows.Forms.PictureBox iconCerrarSesion;

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblListarProductos;
        private System.Windows.Forms.Label lblListarVentas;
        private System.Windows.Forms.Label lblFacturacion;
        private System.Windows.Forms.Label lblAñadirCliente;
        private System.Windows.Forms.Label lblCerrarSesion;
    }
}
