namespace GestionDeVentas.Vendedor
{
    partial class FormFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblVendedorActual = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.pnlSeleccionProducto = new System.Windows.Forms.Panel();
            this.btnAgregarAlDetalle = new System.Windows.Forms.Button();
            this.txtCantidadSeleccionada = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMontoEntregado = new System.Windows.Forms.Label();
            this.txtMontoEntregado = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.lblInfoPago = new System.Windows.Forms.Label();
            this.txtInfoPago = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSeleccionProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(200, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Factura de Venta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::GestionDeVentas.Properties.Resources.logoFactura1;
            this.picLogo.Location = new System.Drawing.Point(14, 16);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(147, 72);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.Location = new System.Drawing.Point(525, 50);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(112, 19);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha: --/--/----";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(15, 89);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(75, 19);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente";
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(15, 114);
            this.txtBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.ReadOnly = true;
            this.txtBuscarCliente.Size = new System.Drawing.Size(225, 20);
            this.txtBuscarCliente.TabIndex = 5;
            this.txtBuscarCliente.Text = "[Cliente seleccionado]";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(245, 112);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(30, 23);
            this.btnBuscarCliente.TabIndex = 6;
            this.btnBuscarCliente.Text = "🔍";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(15, 148);
            this.lblDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(75, 19);
            this.lblDni.TabIndex = 7;
            this.lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(90, 148);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(185, 20);
            this.txtDni.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(11, 181);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(75, 19);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(90, 178);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(185, 20);
            this.txtNombre.TabIndex = 10;
            // 
            // lblContacto
            // 
            this.lblContacto.Location = new System.Drawing.Point(11, 212);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(75, 19);
            this.lblContacto.TabIndex = 13;
            this.lblContacto.Text = "Contacto:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(90, 211);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(2);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.ReadOnly = true;
            this.txtContacto.Size = new System.Drawing.Size(185, 20);
            this.txtContacto.TabIndex = 14;
            // 
            // lblVendedorActual
            // 
            this.lblVendedorActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendedorActual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedorActual.Location = new System.Drawing.Point(369, 69);
            this.lblVendedorActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendedorActual.Name = "lblVendedorActual";
            this.lblVendedorActual.Size = new System.Drawing.Size(312, 19);
            this.lblVendedorActual.TabIndex = 15;
            this.lblVendedorActual.Text = "Vendedor: [Nombre]";
            this.lblVendedorActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVendedorActual.Click += new System.EventHandler(this.lblVendedorActual_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(15, 258);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(75, 19);
            this.lblProducto.TabIndex = 16;
            this.lblProducto.Text = "Producto";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(15, 282);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.ReadOnly = true;
            this.txtBuscarProducto.Size = new System.Drawing.Size(666, 20);
            this.txtBuscarProducto.TabIndex = 17;
            this.txtBuscarProducto.Text = "Buscar por código o nombre";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarProducto.Location = new System.Drawing.Point(685, 280);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(30, 23);
            this.btnBuscarProducto.TabIndex = 18;
            this.btnBuscarProducto.Text = "🔍";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // pnlSeleccionProducto
            // 
            this.pnlSeleccionProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSeleccionProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeleccionProducto.Controls.Add(this.btnAgregarAlDetalle);
            this.pnlSeleccionProducto.Controls.Add(this.txtCantidadSeleccionada);
            this.pnlSeleccionProducto.Controls.Add(this.lblCantidad);
            this.pnlSeleccionProducto.Location = new System.Drawing.Point(15, 315);
            this.pnlSeleccionProducto.Name = "pnlSeleccionProducto";
            this.pnlSeleccionProducto.Size = new System.Drawing.Size(700, 40);
            this.pnlSeleccionProducto.TabIndex = 19;
            this.pnlSeleccionProducto.Visible = false;
            // 
            // btnAgregarAlDetalle
            // 
            this.btnAgregarAlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarAlDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlDetalle.Location = new System.Drawing.Point(575, 5);
            this.btnAgregarAlDetalle.Name = "btnAgregarAlDetalle";
            this.btnAgregarAlDetalle.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarAlDetalle.TabIndex = 3;
            this.btnAgregarAlDetalle.Text = "➕ Agregar";
            this.btnAgregarAlDetalle.UseVisualStyleBackColor = true;
            this.btnAgregarAlDetalle.Click += new System.EventHandler(this.btnAgregarAlDetalle_Click);
            // 
            // txtCantidadSeleccionada
            // 
            this.txtCantidadSeleccionada.Location = new System.Drawing.Point(90, 10);
            this.txtCantidadSeleccionada.Name = "txtCantidadSeleccionada";
            this.txtCantidadSeleccionada.Size = new System.Drawing.Size(50, 20);
            this.txtCantidadSeleccionada.TabIndex = 2;
            this.txtCantidadSeleccionada.Text = "1";
            this.txtCantidadSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(15, 10);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(69, 19);
            this.lblCantidad.TabIndex = 1;
            this.lblCantidad.Text = "Cantidad:";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProducto,
            this.colTalle,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal,
            this.colEliminar});
            this.dgvDetalle.Location = new System.Drawing.Point(15, 365);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.Size = new System.Drawing.Size(698, 140);
            this.dgvDetalle.TabIndex = 20;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
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
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.MinimumWidth = 6;
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.MinimumWidth = 6;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "❌";
            this.colEliminar.UseColumnTextForButtonValue = true;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.Location = new System.Drawing.Point(562, 512);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(75, 19);
            this.lblSubtotal.TabIndex = 21;
            this.lblSubtotal.Text = "Subtotal:";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubtotal.Location = new System.Drawing.Point(638, 512);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(76, 20);
            this.txtSubtotal.TabIndex = 22;
            // 
            // lblIVA
            // 
            this.lblIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIVA.Location = new System.Drawing.Point(562, 536);
            this.lblIVA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(75, 19);
            this.lblIVA.TabIndex = 23;
            this.lblIVA.Text = "IVA (21%):";
            this.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIVA
            // 
            this.txtIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIVA.Location = new System.Drawing.Point(638, 536);
            this.txtIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(76, 20);
            this.txtIVA.TabIndex = 24;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(562, 561);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(638, 561);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(76, 29);
            this.txtTotal.TabIndex = 26;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 512);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(90, 19);
            this.lblMetodoPago.TabIndex = 27;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(112, 512);
            this.cmbMetodoPago.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(150, 21);
            this.cmbMetodoPago.TabIndex = 28;
            this.cmbMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoPago_SelectedIndexChanged);
            // 
            // lblMontoEntregado
            // 
            this.lblMontoEntregado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMontoEntregado.Location = new System.Drawing.Point(15, 536);
            this.lblMontoEntregado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMontoEntregado.Name = "lblMontoEntregado";
            this.lblMontoEntregado.Size = new System.Drawing.Size(90, 19);
            this.lblMontoEntregado.TabIndex = 29;
            this.lblMontoEntregado.Text = "Monto Entregado:";
            // 
            // txtMontoEntregado
            // 
            this.txtMontoEntregado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMontoEntregado.Location = new System.Drawing.Point(112, 536);
            this.txtMontoEntregado.Margin = new System.Windows.Forms.Padding(2);
            this.txtMontoEntregado.Name = "txtMontoEntregado";
            this.txtMontoEntregado.Size = new System.Drawing.Size(150, 20);
            this.txtMontoEntregado.TabIndex = 30;
            this.txtMontoEntregado.TextChanged += new System.EventHandler(this.txtMontoEntregado_TextChanged);
            // 
            // lblVuelto
            // 
            this.lblVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVuelto.Location = new System.Drawing.Point(15, 561);
            this.lblVuelto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(90, 19);
            this.lblVuelto.TabIndex = 31;
            this.lblVuelto.Text = "Vuelto:";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVuelto.Location = new System.Drawing.Point(112, 561);
            this.txtVuelto.Margin = new System.Windows.Forms.Padding(2);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(150, 20);
            this.txtVuelto.TabIndex = 32;
            // 
            // lblInfoPago
            // 
            this.lblInfoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoPago.Location = new System.Drawing.Point(15, 536);
            this.lblInfoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfoPago.Name = "lblInfoPago";
            this.lblInfoPago.Size = new System.Drawing.Size(90, 19);
            this.lblInfoPago.TabIndex = 33;
            this.lblInfoPago.Text = "Datos de Pago:";
            this.lblInfoPago.Visible = false;
            // 
            // txtInfoPago
            // 
            this.txtInfoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInfoPago.Location = new System.Drawing.Point(112, 536);
            this.txtInfoPago.Margin = new System.Windows.Forms.Padding(2);
            this.txtInfoPago.Name = "txtInfoPago";
            this.txtInfoPago.Size = new System.Drawing.Size(188, 20);
            this.txtInfoPago.TabIndex = 34;
            this.txtInfoPago.Visible = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(340, 566);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(112, 32);
            this.btnGenerar.TabIndex = 35;
            this.btnGenerar.Text = "Generar Factura";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.Location = new System.Drawing.Point(460, 566);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 32);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(690, 8);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 32);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.Text = "❌";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 609);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtInfoPago);
            this.Controls.Add(this.lblInfoPago);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.txtMontoEntregado);
            this.Controls.Add(this.lblMontoEntregado);
            this.Controls.Add(this.cmbMetodoPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.pnlSeleccionProducto);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblVendedorActual);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.picLogo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFactura";
            this.Text = "Factura de Venta";
            this.Load += new System.EventHandler(this.FormFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSeleccionProducto.ResumeLayout(false);
            this.pnlSeleccionProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblVendedorActual;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Panel pnlSeleccionProducto;
        private System.Windows.Forms.Button btnAgregarAlDetalle;
        private System.Windows.Forms.TextBox txtCantidadSeleccionada;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMontoEntregado;
        private System.Windows.Forms.TextBox txtMontoEntregado;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.TextBox txtVuelto;
        private System.Windows.Forms.Label lblInfoPago;
        private System.Windows.Forms.TextBox txtInfoPago;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCerrar;
    }
}