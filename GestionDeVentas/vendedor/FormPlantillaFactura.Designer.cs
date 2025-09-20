namespace GestionDeVentas.Vendedor
{
    partial class FormFactura
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblBuscarVendedor = new System.Windows.Forms.Label();
            this.txtBuscarVendedor = new System.Windows.Forms.TextBox();
            this.btnBuscarVendedor = new System.Windows.Forms.Button();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(200, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(205, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Factura - TYV CLOTHES";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(20, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 60);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.Location = new System.Drawing.Point(600, 20);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(100, 23);
            this.lblNroFactura.TabIndex = 2;
            this.lblNroFactura.Text = "000012";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(600, 50);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 23);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(650, 50);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 4;
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.Location = new System.Drawing.Point(20, 90);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(100, 23);
            this.lblBuscarCliente.TabIndex = 5;
            this.lblBuscarCliente.Text = "Cliente:";
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(120, 90);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(200, 22);
            this.txtBuscarCliente.TabIndex = 6;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(330, 90);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarCliente.TabIndex = 7;
            this.btnBuscarCliente.Text = "🔍";
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(20, 120);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(100, 23);
            this.lblDni.TabIndex = 8;
            this.lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(120, 120);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(100, 22);
            this.txtDni.TabIndex = 9;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 150);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 150);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 11;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(20, 180);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 23);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(120, 180);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(100, 22);
            this.txtDireccion.TabIndex = 13;
            // 
            // lblContacto
            // 
            this.lblContacto.Location = new System.Drawing.Point(20, 210);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(111, 23);
            this.lblContacto.TabIndex = 14;
            this.lblContacto.Text = "Teléfono/Correo:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(131, 209);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.ReadOnly = true;
            this.txtContacto.Size = new System.Drawing.Size(285, 22);
            this.txtContacto.TabIndex = 15;
            // 
            // lblBuscarVendedor
            // 
            this.lblBuscarVendedor.Location = new System.Drawing.Point(20, 240);
            this.lblBuscarVendedor.Name = "lblBuscarVendedor";
            this.lblBuscarVendedor.Size = new System.Drawing.Size(100, 23);
            this.lblBuscarVendedor.TabIndex = 16;
            this.lblBuscarVendedor.Text = "Vendedor:";
            // 
            // txtBuscarVendedor
            // 
            this.txtBuscarVendedor.Location = new System.Drawing.Point(120, 240);
            this.txtBuscarVendedor.Name = "txtBuscarVendedor";
            this.txtBuscarVendedor.Size = new System.Drawing.Size(200, 22);
            this.txtBuscarVendedor.TabIndex = 17;
            // 
            // btnBuscarVendedor
            // 
            this.btnBuscarVendedor.Location = new System.Drawing.Point(330, 240);
            this.btnBuscarVendedor.Name = "btnBuscarVendedor";
            this.btnBuscarVendedor.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarVendedor.TabIndex = 18;
            this.btnBuscarVendedor.Text = "🔍";
            this.btnBuscarVendedor.Click += new System.EventHandler(this.btnBuscarVendedor_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.Location = new System.Drawing.Point(20, 270);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 23);
            this.lblVendedor.TabIndex = 19;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.Location = new System.Drawing.Point(20, 300);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(83, 23);
            this.lblBuscarProducto.TabIndex = 20;
            this.lblBuscarProducto.Text = "Producto:";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(120, 300);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(200, 22);
            this.txtBuscarProducto.TabIndex = 21;
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(330, 300);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarProducto.TabIndex = 22;
            this.btnBuscarProducto.Text = "🔍";
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.ColumnHeadersHeight = 29;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProducto,
            this.colTalle,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal,
            this.colEliminar});
            this.dgvDetalle.Location = new System.Drawing.Point(20, 330);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.Size = new System.Drawing.Size(760, 200);
            this.dgvDetalle.TabIndex = 23;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.MinimumWidth = 6;
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.Width = 125;
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            this.colProducto.Width = 125;
            // 
            // colTalle
            // 
            this.colTalle.HeaderText = "Talle";
            this.colTalle.MinimumWidth = 6;
            this.colTalle.Name = "colTalle";
            this.colTalle.Width = 125;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 125;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Width = 125;
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.MinimumWidth = 6;
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.Width = 125;
            // 
            // colEliminar
            // 
            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.MinimumWidth = 6;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.Text = "❌";
            this.colEliminar.UseColumnTextForButtonValue = true;
            this.colEliminar.Width = 125;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(600, 540);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 23);
            this.lblSubtotal.TabIndex = 24;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(680, 540);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(100, 22);
            this.txtSubtotal.TabIndex = 25;
            // 
            // lblIVA
            // 
            this.lblIVA.Location = new System.Drawing.Point(600, 570);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(100, 23);
            this.lblIVA.TabIndex = 26;
            this.lblIVA.Text = "IVA (21%):";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(680, 570);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(100, 22);
            this.txtIVA.TabIndex = 27;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(600, 600);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(680, 600);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 30);
            this.txtTotal.TabIndex = 29;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Location = new System.Drawing.Point(20, 540);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(100, 23);
            this.lblMetodoPago.TabIndex = 30;
            this.lblMetodoPago.Text = "Método pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.Location = new System.Drawing.Point(120, 540);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(121, 24);
            this.cmbMetodoPago.TabIndex = 31;
            this.cmbMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoPago_SelectedIndexChanged);
            // 
            // lblMontoEntregado
            // 
            this.lblMontoEntregado.Location = new System.Drawing.Point(20, 570);
            this.lblMontoEntregado.Name = "lblMontoEntregado";
            this.lblMontoEntregado.Size = new System.Drawing.Size(100, 23);
            this.lblMontoEntregado.TabIndex = 32;
            this.lblMontoEntregado.Text = "Monto entregado:";
            // 
            // txtMontoEntregado
            // 
            this.txtMontoEntregado.Location = new System.Drawing.Point(120, 570);
            this.txtMontoEntregado.Name = "txtMontoEntregado";
            this.txtMontoEntregado.Size = new System.Drawing.Size(100, 22);
            this.txtMontoEntregado.TabIndex = 33;
            this.txtMontoEntregado.TextChanged += new System.EventHandler(this.txtMontoEntregado_TextChanged);
            // 
            // lblVuelto
            // 
            this.lblVuelto.Location = new System.Drawing.Point(20, 600);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(100, 23);
            this.lblVuelto.TabIndex = 34;
            this.lblVuelto.Text = "Vuelto:";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Location = new System.Drawing.Point(120, 600);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(100, 22);
            this.txtVuelto.TabIndex = 35;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(250, 630);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 36;
            this.btnGenerar.Text = "Guardar factura";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(380, 630);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Location = new System.Drawing.Point(760, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 38;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormFactura
            // 
            this.ClientSize = new System.Drawing.Size(820, 670);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblBuscarCliente);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.txtContacto);
            this.Controls.Add(this.lblBuscarVendedor);
            this.Controls.Add(this.txtBuscarVendedor);
            this.Controls.Add(this.btnBuscarVendedor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblBuscarProducto);
            this.Controls.Add(this.txtBuscarProducto);
            this.Controls.Add(this.btnBuscarProducto);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.cmbMetodoPago);
            this.Controls.Add(this.lblMontoEntregado);
            this.Controls.Add(this.txtMontoEntregado);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.lblTotal);
            this.Name = "FormFactura";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FormFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo, lblNroFactura, lblFecha,
            lblBuscarCliente, lblDni, lblNombre, lblDireccion, lblContacto,
            lblSubtotal, lblIVA, lblTotal, lblMetodoPago, lblMontoEntregado, lblVuelto,
            lblBuscarVendedor, lblVendedor, lblBuscarProducto;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtBuscarCliente, txtDni, txtNombre, txtDireccion, txtContacto,
            txtSubtotal, txtIVA, txtTotal, txtMontoEntregado, txtVuelto,
            txtBuscarVendedor, txtBuscarProducto;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo, colProducto, colTalle, colCantidad, colPrecio, colSubtotal;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
        private System.Windows.Forms.Button btnBuscarCliente, btnBuscarVendedor, btnBuscarProducto,
            btnGenerar, btnCancelar, btnCerrar;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
    }
}
