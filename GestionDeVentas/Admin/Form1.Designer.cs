namespace GestionDeVentas.Admin
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblAdminPanel;
        private System.Windows.Forms.Label lblListarProductos;
        private System.Windows.Forms.Label lblRegistrarPrenda;
        private System.Windows.Forms.Label lblGestionarPrendas;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblAdminWelcome;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.logoPanel = new System.Windows.Forms.Panel();
            this.lblAdminPanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.lblGestionarPrendas = new System.Windows.Forms.Label();
            this.lblRegistrarPrenda = new System.Windows.Forms.Label();
            this.lblListarProductos = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.lblAdminWelcome = new System.Windows.Forms.Label();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
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
            this.logoPanel.Controls.Add(this.lblAdminPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(200, 75);
            this.logoPanel.TabIndex = 9;
            // 
            // lblAdminPanel
            // 
            this.lblAdminPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdminPanel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminPanel.Location = new System.Drawing.Point(0, 0);
            this.lblAdminPanel.Name = "lblAdminPanel";
            this.lblAdminPanel.Size = new System.Drawing.Size(200, 75);
            this.lblAdminPanel.TabIndex = 0;
            this.lblAdminPanel.Text = "Admin Panel";
            this.lblAdminPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.lblGestionarPrendas);
            this.sidePanel.Controls.Add(this.lblRegistrarPrenda);
            this.sidePanel.Controls.Add(this.lblListarProductos);
            this.sidePanel.Controls.Add(this.lblInicio);
            this.sidePanel.Controls.Add(this.logoPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(200, 450);
            this.sidePanel.TabIndex = 0;
            // 
            // lblCerrarSesion
            // 
            this.lblCerrarSesion.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCerrarSesion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.lblCerrarSesion.Location = new System.Drawing.Point(0, 228);
            this.lblCerrarSesion.Name = "lblCerrarSesion";
            this.lblCerrarSesion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblCerrarSesion.Size = new System.Drawing.Size(200, 30);
            this.lblCerrarSesion.TabIndex = 10;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblGestionarPrendas
            // 
            this.lblGestionarPrendas.BackColor = System.Drawing.Color.Transparent;
            this.lblGestionarPrendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGestionarPrendas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGestionarPrendas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestionarPrendas.ForeColor = System.Drawing.Color.Black;
            this.lblGestionarPrendas.Location = new System.Drawing.Point(0, 198);
            this.lblGestionarPrendas.Name = "lblGestionarPrendas";
            this.lblGestionarPrendas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblGestionarPrendas.Size = new System.Drawing.Size(200, 30);
            this.lblGestionarPrendas.TabIndex = 3;
            this.lblGestionarPrendas.Text = "Gestionar Prendas";
            this.lblGestionarPrendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGestionarPrendas.Click += new System.EventHandler(this.lblGestionarPrendas_Click);
            // 
            // lblRegistrarPrenda
            // 
            this.lblRegistrarPrenda.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrarPrenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegistrarPrenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrarPrenda.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrarPrenda.ForeColor = System.Drawing.Color.Black;
            this.lblRegistrarPrenda.Location = new System.Drawing.Point(0, 168);
            this.lblRegistrarPrenda.Name = "lblRegistrarPrenda";
            this.lblRegistrarPrenda.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblRegistrarPrenda.Size = new System.Drawing.Size(200, 30);
            this.lblRegistrarPrenda.TabIndex = 2;
            this.lblRegistrarPrenda.Text = "Registrar Prenda";
            this.lblRegistrarPrenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRegistrarPrenda.Click += new System.EventHandler(this.lblRegistrarPrenda_Click);
            // 
            // lblListarProductos
            // 
            this.lblListarProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblListarProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListarProductos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListarProductos.ForeColor = System.Drawing.Color.Black;
            this.lblListarProductos.Location = new System.Drawing.Point(0, 138);
            this.lblListarProductos.Name = "lblListarProductos";
            this.lblListarProductos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblListarProductos.Size = new System.Drawing.Size(200, 30);
            this.lblListarProductos.TabIndex = 1;
            this.lblListarProductos.Text = "Listar Productos";
            this.lblListarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblListarProductos.Click += new System.EventHandler(this.lblListarProductos_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInicio.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.Black;
            this.lblInicio.Location = new System.Drawing.Point(0, 108);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblInicio.Size = new System.Drawing.Size(200, 30);
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
            this.mainPanel.Location = new System.Drawing.Point(200, 75);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(600, 375);
            this.mainPanel.TabIndex = 2;
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(600, 375);
            this.pictureBoxWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWelcome.TabIndex = 0;
            this.pictureBoxWelcome.TabStop = false;
            this.pictureBoxWelcome.Click += new System.EventHandler(this.pictureBoxWelcome_Click_1);
            // 
            // lblAdminWelcome
            // 
            this.lblAdminWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminWelcome.AutoSize = true;
            this.lblAdminWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.lblAdminWelcome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblAdminWelcome.Location = new System.Drawing.Point(489, 27);
            this.lblAdminWelcome.Name = "lblAdminWelcome";
            this.lblAdminWelcome.Size = new System.Drawing.Size(98, 17);
            this.lblAdminWelcome.TabIndex = 0;
            this.lblAdminWelcome.Text = "Administrador";
            this.lblAdminWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAdminWelcome.Click += new System.EventHandler(this.lblAdminWelcome_Click_1);
            // 
            // topBarPanel
            // 
            this.topBarPanel.AutoScroll = true;
            this.topBarPanel.BackColor = System.Drawing.Color.Black;
            this.topBarPanel.BackgroundImage = global::GestionDeVentas.Properties.Resources.fondo;
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblAdminWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(200, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(600, 75);
            this.topBarPanel.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.ErrorImage = null;
            this.pictureBoxLogo.Image = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.pictureBoxLogo.Location = new System.Drawing.Point(262, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(67, 59);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.topBarPanel.ResumeLayout(false);
            this.topBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
