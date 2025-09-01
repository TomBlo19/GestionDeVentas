namespace GestionDeVentas.Gerente
{
    partial class FormGerente
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
            this.lblVendedorPanel = new System.Windows.Forms.Label();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.lblCerrarSesion = new System.Windows.Forms.Label();
            this.lblAñadirCliente = new System.Windows.Forms.Label();
            this.lblFacturacion = new System.Windows.Forms.Label();
            this.lblListarVentas = new System.Windows.Forms.Label();
            this.lblListarProductos = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.lblVendedorWelcome = new System.Windows.Forms.Label();
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
            this.logoPanel.Controls.Add(this.lblVendedorPanel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(200, 75);
            this.logoPanel.TabIndex = 9;
            // 
            // lblVendedorPanel
            // 
            this.lblVendedorPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVendedorPanel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedorPanel.Location = new System.Drawing.Point(0, 0);
            this.lblVendedorPanel.Name = "lblVendedorPanel";
            this.lblVendedorPanel.Size = new System.Drawing.Size(200, 75);
            this.lblVendedorPanel.TabIndex = 0;
            this.lblVendedorPanel.Text = "Panel de Ventas";
            this.lblVendedorPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(224)))), ((int)(((byte)(215)))));
            this.sidePanel.Controls.Add(this.lblCerrarSesion);
            this.sidePanel.Controls.Add(this.lblAñadirCliente);
            this.sidePanel.Controls.Add(this.lblFacturacion);
            this.sidePanel.Controls.Add(this.lblListarVentas);
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
            this.lblCerrarSesion.TabIndex = 8;
            this.lblCerrarSesion.Text = "Cerrar sesión";
            this.lblCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCerrarSesion.Click += new System.EventHandler(this.lblCerrarSesion_Click);
            // 
            // lblAñadirCliente
            // 
            this.lblAñadirCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblAñadirCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAñadirCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAñadirCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAñadirCliente.ForeColor = System.Drawing.Color.Black;
            this.lblAñadirCliente.Location = new System.Drawing.Point(0, 198);
            this.lblAñadirCliente.Name = "lblAñadirCliente";
            this.lblAñadirCliente.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblAñadirCliente.Size = new System.Drawing.Size(200, 30);
            this.lblAñadirCliente.TabIndex = 12;
            this.lblAñadirCliente.Text = "Añadir Cliente";
            this.lblAñadirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAñadirCliente.Click += new System.EventHandler(this.lblAñadirCliente_Click);
            // 
            // lblFacturacion
            // 
            this.lblFacturacion.BackColor = System.Drawing.Color.Transparent;
            this.lblFacturacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFacturacion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFacturacion.ForeColor = System.Drawing.Color.Black;
            this.lblFacturacion.Location = new System.Drawing.Point(0, 168);
            this.lblFacturacion.Name = "lblFacturacion";
            this.lblFacturacion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblFacturacion.Size = new System.Drawing.Size(200, 30);
            this.lblFacturacion.TabIndex = 11;
            this.lblFacturacion.Text = "Facturación";
            this.lblFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFacturacion.Click += new System.EventHandler(this.lblFacturacion_Click);
            // 
            // lblListarVentas
            // 
            this.lblListarVentas.BackColor = System.Drawing.Color.Transparent;
            this.lblListarVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListarVentas.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListarVentas.ForeColor = System.Drawing.Color.Black;
            this.lblListarVentas.Location = new System.Drawing.Point(0, 138);
            this.lblListarVentas.Name = "lblListarVentas";
            this.lblListarVentas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblListarVentas.Size = new System.Drawing.Size(200, 30);
            this.lblListarVentas.TabIndex = 10;
            this.lblListarVentas.Text = "Listar Ventas";
            this.lblListarVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblListarVentas.Click += new System.EventHandler(this.lblListarVentas_Click);
            // 
            // lblListarProductos
            // 
            this.lblListarProductos.BackColor = System.Drawing.Color.Transparent;
            this.lblListarProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblListarProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListarProductos.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListarProductos.ForeColor = System.Drawing.Color.Black;
            this.lblListarProductos.Location = new System.Drawing.Point(0, 108);
            this.lblListarProductos.Name = "lblListarProductos";
            this.lblListarProductos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblListarProductos.Size = new System.Drawing.Size(200, 30);
            this.lblListarProductos.TabIndex = 2;
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
            this.lblInicio.Location = new System.Drawing.Point(0, 75);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblInicio.Size = new System.Drawing.Size(200, 33);
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
            this.pictureBoxWelcome.Click += new System.EventHandler(this.pictureBoxWelcome_Click);
            // 
            // lblVendedorWelcome
            // 
            this.lblVendedorWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendedorWelcome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedorWelcome.ForeColor = System.Drawing.Color.White;
            this.lblVendedorWelcome.Location = new System.Drawing.Point(394, 27);
            this.lblVendedorWelcome.Name = "lblVendedorWelcome";
            this.lblVendedorWelcome.Size = new System.Drawing.Size(194, 23);
            this.lblVendedorWelcome.TabIndex = 0;
            this.lblVendedorWelcome.Text = "Vendedor";
            this.lblVendedorWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // topBarPanel
            // 
            this.topBarPanel.AutoScroll = true;
            this.topBarPanel.BackColor = System.Drawing.Color.Black;
            this.topBarPanel.Controls.Add(this.pictureBoxLogo);
            this.topBarPanel.Controls.Add(this.lblVendedorWelcome);
            this.topBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarPanel.Location = new System.Drawing.Point(200, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(600, 75);
            this.topBarPanel.TabIndex = 1;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(262, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.sidePanel);
            this.IsMdiContainer = true;
            this.Name = "FormVendedor";
            this.Text = "Panel de Ventas";
            this.Load += new System.EventHandler(this.FormVendedor_Load);
            this.logoPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            this.topBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label lblVendedorPanel;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label lblCerrarSesion;
        private System.Windows.Forms.Label lblAñadirCliente;
        private System.Windows.Forms.Label lblFacturacion;
        private System.Windows.Forms.Label lblListarVentas;
        private System.Windows.Forms.Label lblListarProductos;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label lblVendedorWelcome;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}