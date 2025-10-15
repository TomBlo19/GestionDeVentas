namespace GestionDeVentas.Vendedor
{
    partial class FormVisualizarFactura
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.lblClienteDni = new System.Windows.Forms.Label();
            this.txtClienteDni = new System.Windows.Forms.TextBox();
            this.lblClienteDireccion = new System.Windows.Forms.Label();
            this.txtClienteDireccion = new System.Windows.Forms.TextBox();
            this.lblClienteContacto = new System.Windows.Forms.Label();
            this.txtClienteContacto = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.txtMetodoPago = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlDatosEmpresa = new System.Windows.Forms.Panel();
            this.pboxLogoEmpresa = new System.Windows.Forms.PictureBox();
            this.lblEmpresaContacto = new System.Windows.Forms.Label();
            this.lblEmpresaCuit = new System.Windows.Forms.Label();
            this.lblEmpresaDireccion = new System.Windows.Forms.Label();
            this.lblEmpresaNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.pnlDatosEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(15, 120);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Factura Nº 000000";
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.Location = new System.Drawing.Point(562, 120);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(150, 19);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha: --/--/----";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendedor
            // 
            this.lblVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendedor.Location = new System.Drawing.Point(562, 145);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(150, 19);
            this.lblVendedor.TabIndex = 2;
            this.lblVendedor.Text = "Vendedor: [Nombre]";
            this.lblVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(15, 185);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(90, 19);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(105, 185);
            this.txtClienteNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.ReadOnly = true;
            this.txtClienteNombre.Size = new System.Drawing.Size(188, 20);
            this.txtClienteNombre.TabIndex = 4;
            // 
            // lblClienteDni
            // 
            this.lblClienteDni.Location = new System.Drawing.Point(15, 210);
            this.lblClienteDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClienteDni.Name = "lblClienteDni";
            this.lblClienteDni.Size = new System.Drawing.Size(90, 19);
            this.lblClienteDni.TabIndex = 5;
            this.lblClienteDni.Text = "DNI:";
            // 
            // txtClienteDni
            // 
            this.txtClienteDni.Location = new System.Drawing.Point(105, 210);
            this.txtClienteDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteDni.Name = "txtClienteDni";
            this.txtClienteDni.ReadOnly = true;
            this.txtClienteDni.Size = new System.Drawing.Size(188, 20);
            this.txtClienteDni.TabIndex = 6;
            // 
            // lblClienteDireccion
            // 
            this.lblClienteDireccion.Location = new System.Drawing.Point(15, 234);
            this.lblClienteDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClienteDireccion.Name = "lblClienteDireccion";
            this.lblClienteDireccion.Size = new System.Drawing.Size(90, 19);
            this.lblClienteDireccion.TabIndex = 7;
            this.lblClienteDireccion.Text = "Dirección:";
            // 
            // txtClienteDireccion
            // 
            this.txtClienteDireccion.Location = new System.Drawing.Point(105, 234);
            this.txtClienteDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteDireccion.Name = "txtClienteDireccion";
            this.txtClienteDireccion.ReadOnly = true;
            this.txtClienteDireccion.Size = new System.Drawing.Size(188, 20);
            this.txtClienteDireccion.TabIndex = 8;
            // 
            // lblClienteContacto
            // 
            this.lblClienteContacto.Location = new System.Drawing.Point(15, 258);
            this.lblClienteContacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClienteContacto.Name = "lblClienteContacto";
            this.lblClienteContacto.Size = new System.Drawing.Size(90, 19);
            this.lblClienteContacto.TabIndex = 9;
            this.lblClienteContacto.Text = "Contacto:";
            // 
            // txtClienteContacto
            // 
            this.txtClienteContacto.Location = new System.Drawing.Point(105, 258);
            this.txtClienteContacto.Margin = new System.Windows.Forms.Padding(2);
            this.txtClienteContacto.Name = "txtClienteContacto";
            this.txtClienteContacto.ReadOnly = true;
            this.txtClienteContacto.Size = new System.Drawing.Size(188, 20);
            this.txtClienteContacto.TabIndex = 10;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProducto,
            this.colTalle,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            this.dgvProductos.Location = new System.Drawing.Point(15, 295);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.Size = new System.Drawing.Size(698, 184);
            this.dgvProductos.TabIndex = 11;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.MinimumWidth = 6;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colTalle
            // 
            this.colTalle.HeaderText = "Talle";
            this.colTalle.MinimumWidth = 6;
            this.colTalle.Name = "colTalle";
            this.colTalle.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.MinimumWidth = 6;
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.Location = new System.Drawing.Point(562, 496);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(75, 19);
            this.lblSubtotal.TabIndex = 12;
            this.lblSubtotal.Text = "Subtotal:";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.Location = new System.Drawing.Point(638, 496);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(76, 20);
            this.txtSubtotal.TabIndex = 13;
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.Location = new System.Drawing.Point(562, 520);
            this.lblIVA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(75, 19);
            this.lblIVA.TabIndex = 14;
            this.lblIVA.Text = "IVA (21%):";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIVA
            // 
            this.txtIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIVA.Location = new System.Drawing.Point(638, 520);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(76, 20);
            this.txtIVA.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(549, 545);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(628, 544);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(86, 29);
            this.txtTotal.TabIndex = 17;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 496);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(90, 19);
            this.lblMetodoPago.TabIndex = 18;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // txtMetodoPago
            // 
            this.txtMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMetodoPago.Location = new System.Drawing.Point(105, 496);
            this.txtMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtMetodoPago.Name = "txtMetodoPago";
            this.txtMetodoPago.ReadOnly = true;
            this.txtMetodoPago.Size = new System.Drawing.Size(151, 20);
            this.txtMetodoPago.TabIndex = 19;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(615, 585);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(98, 32);
            this.btnCerrar.TabIndex = 24;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlDatosEmpresa
            // 
            this.pnlDatosEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatosEmpresa.BackColor = System.Drawing.Color.LightGray;
            this.pnlDatosEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatosEmpresa.Controls.Add(this.pboxLogoEmpresa);
            this.pnlDatosEmpresa.Controls.Add(this.lblEmpresaContacto);
            this.pnlDatosEmpresa.Controls.Add(this.lblEmpresaCuit);
            this.pnlDatosEmpresa.Controls.Add(this.lblEmpresaDireccion);
            this.pnlDatosEmpresa.Controls.Add(this.lblEmpresaNombre);
            this.pnlDatosEmpresa.Location = new System.Drawing.Point(15, 12);
            this.pnlDatosEmpresa.Name = "pnlDatosEmpresa";
            this.pnlDatosEmpresa.Size = new System.Drawing.Size(699, 90);
            this.pnlDatosEmpresa.TabIndex = 25;
            // 
            // pboxLogoEmpresa
            // 
            this.pboxLogoEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxLogoEmpresa.Image = global::GestionDeVentas.Properties.Resources.logoFac;
            this.pboxLogoEmpresa.Location = new System.Drawing.Point(608, -1);
            this.pboxLogoEmpresa.Name = "pboxLogoEmpresa";
            this.pboxLogoEmpresa.Size = new System.Drawing.Size(90, 70);
            this.pboxLogoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxLogoEmpresa.TabIndex = 4;
            this.pboxLogoEmpresa.TabStop = false;
            // 
            // lblEmpresaContacto
            // 
            this.lblEmpresaContacto.Location = new System.Drawing.Point(440, 69);
            this.lblEmpresaContacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresaContacto.Name = "lblEmpresaContacto";
            this.lblEmpresaContacto.Size = new System.Drawing.Size(258, 19);
            this.lblEmpresaContacto.TabIndex = 3;
            this.lblEmpresaContacto.Text = "Contacto: (011) 1234-5678 / info@miempresa.com";
            // 
            // lblEmpresaCuit
            // 
            this.lblEmpresaCuit.Location = new System.Drawing.Point(13, 69);
            this.lblEmpresaCuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresaCuit.Name = "lblEmpresaCuit";
            this.lblEmpresaCuit.Size = new System.Drawing.Size(300, 19);
            this.lblEmpresaCuit.TabIndex = 2;
            this.lblEmpresaCuit.Text = "CUIT: 30-12345678-9";
            // 
            // lblEmpresaDireccion
            // 
            this.lblEmpresaDireccion.Location = new System.Drawing.Point(13, 37);
            this.lblEmpresaDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresaDireccion.Name = "lblEmpresaDireccion";
            this.lblEmpresaDireccion.Size = new System.Drawing.Size(363, 19);
            this.lblEmpresaDireccion.TabIndex = 1;
            this.lblEmpresaDireccion.Text = "Dirección: Av. 3 de Abril , Ciudad:Corrientes, País:Aregentina";
            this.lblEmpresaDireccion.Click += new System.EventHandler(this.lblEmpresaDireccion_Click);
            // 
            // lblEmpresaNombre
            // 
            this.lblEmpresaNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresaNombre.Location = new System.Drawing.Point(12, 0);
            this.lblEmpresaNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresaNombre.Name = "lblEmpresaNombre";
            this.lblEmpresaNombre.Size = new System.Drawing.Size(343, 23);
            this.lblEmpresaNombre.TabIndex = 0;
            this.lblEmpresaNombre.Text = "T/V CLOTHES S.A.";
            this.lblEmpresaNombre.Click += new System.EventHandler(this.lblEmpresaNombre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::GestionDeVentas.Properties.Resources.logoTYV;
            this.label1.Location = new System.Drawing.Point(512, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(484, 585);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 32);
            this.button1.TabIndex = 26;
            this.button1.Text = "imprimir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormVisualizarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 628);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDatosEmpresa);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtMetodoPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.txtClienteContacto);
            this.Controls.Add(this.lblClienteContacto);
            this.Controls.Add(this.txtClienteDireccion);
            this.Controls.Add(this.lblClienteDireccion);
            this.Controls.Add(this.txtClienteDni);
            this.Controls.Add(this.lblClienteDni);
            this.Controls.Add(this.txtClienteNombre);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormVisualizarFactura";
            this.Text = "Detalle de Factura";
            this.Load += new System.EventHandler(this.FormVisualizarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlDatosEmpresa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Label lblClienteDni;
        private System.Windows.Forms.TextBox txtClienteDni;
        private System.Windows.Forms.Label lblClienteDireccion;
        private System.Windows.Forms.TextBox txtClienteDireccion;
        private System.Windows.Forms.Label lblClienteContacto;
        private System.Windows.Forms.TextBox txtClienteContacto;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.TextBox txtMetodoPago;
        private System.Windows.Forms.Button btnCerrar;

        private System.Windows.Forms.Panel pnlDatosEmpresa;
        private System.Windows.Forms.Label lblEmpresaContacto;
        private System.Windows.Forms.Label lblEmpresaCuit;
        private System.Windows.Forms.Label lblEmpresaDireccion;
        private System.Windows.Forms.Label lblEmpresaNombre;
        private System.Windows.Forms.Label label1;
        // 👇 AÑADIDO: Declaración de la PictureBox
        private System.Windows.Forms.PictureBox pboxLogoEmpresa;
        private System.Windows.Forms.Button button1;
    }
}