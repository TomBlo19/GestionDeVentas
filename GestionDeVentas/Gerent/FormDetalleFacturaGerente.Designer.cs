namespace GestionDeVentas.Gerente
{
    partial class FormDetalleFacturaGerente
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
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
            this.lblMontoEntregado = new System.Windows.Forms.Label();
            this.txtMontoEntregado = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.txtVuelto = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(317, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Detalle de Factura";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(760, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.Location = new System.Drawing.Point(20, 60);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(132, 23);
            this.lblNroFactura.TabIndex = 2;
            this.lblNroFactura.Text = "N° Factura: 000001";
            this.lblNroFactura.Click += new System.EventHandler(this.lblNroFactura_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(200, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(203, 23);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha: 19/09/2025";
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(20, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(192, 23);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente: Valentina Barbero";
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(20, 110);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(100, 23);
            this.lblDni.TabIndex = 5;
            this.lblDni.Text = "DNI: 35123456";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(20, 130);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(250, 23);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección: Av. Siempre Viva 742";
            // 
            // lblContacto
            // 
            this.lblContacto.Location = new System.Drawing.Point(20, 150);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(280, 23);
            this.lblContacto.TabIndex = 7;
            this.lblContacto.Text = "Contacto: valentina@example.com";
            // 
            // lblVendedor
            // 
            this.lblVendedor.Location = new System.Drawing.Point(20, 170);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(171, 23);
            this.lblVendedor.TabIndex = 8;
            this.lblVendedor.Text = "Vendedor: Tomás Bolo";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Location = new System.Drawing.Point(20, 190);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(239, 23);
            this.lblMetodoPago.TabIndex = 9;
            this.lblMetodoPago.Text = "Método de Pago: Efectivo";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeight = 29;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigo,
            this.colProducto,
            this.colTalle,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            this.dgvProductos.Location = new System.Drawing.Point(20, 230);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(780, 200);
            this.dgvProductos.TabIndex = 10;
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
            // lblSubtotal
            // 
            this.lblSubtotal.Location = new System.Drawing.Point(500, 450);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(100, 23);
            this.lblSubtotal.TabIndex = 11;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(570, 450);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(100, 22);
            this.txtSubtotal.TabIndex = 12;
            // 
            // lblIVA
            // 
            this.lblIVA.Location = new System.Drawing.Point(500, 480);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(100, 23);
            this.lblIVA.TabIndex = 13;
            this.lblIVA.Text = "IVA (21%):";
            // 
            // txtIVA
            // 
            this.txtIVA.Location = new System.Drawing.Point(570, 480);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(100, 22);
            this.txtIVA.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(500, 510);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(100, 23);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(570, 510);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 30);
            this.txtTotal.TabIndex = 16;
            // 
            // lblMontoEntregado
            // 
            this.lblMontoEntregado.Location = new System.Drawing.Point(20, 450);
            this.lblMontoEntregado.Name = "lblMontoEntregado";
            this.lblMontoEntregado.Size = new System.Drawing.Size(100, 23);
            this.lblMontoEntregado.TabIndex = 17;
            this.lblMontoEntregado.Text = "Monto entregado:";
            // 
            // txtMontoEntregado
            // 
            this.txtMontoEntregado.Location = new System.Drawing.Point(140, 450);
            this.txtMontoEntregado.Name = "txtMontoEntregado";
            this.txtMontoEntregado.ReadOnly = true;
            this.txtMontoEntregado.Size = new System.Drawing.Size(100, 22);
            this.txtMontoEntregado.TabIndex = 18;
            // 
            // lblVuelto
            // 
            this.lblVuelto.Location = new System.Drawing.Point(20, 480);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(100, 23);
            this.lblVuelto.TabIndex = 19;
            this.lblVuelto.Text = "Vuelto:";
            // 
            // txtVuelto
            // 
            this.txtVuelto.Location = new System.Drawing.Point(140, 480);
            this.txtVuelto.Name = "txtVuelto";
            this.txtVuelto.ReadOnly = true;
            this.txtVuelto.Size = new System.Drawing.Size(100, 22);
            this.txtVuelto.TabIndex = 20;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(20, 520);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "Imprimir Factura";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FormDetalleFacturaGerente
            // 
            this.ClientSize = new System.Drawing.Size(820, 570);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblMontoEntregado);
            this.Controls.Add(this.txtMontoEntregado);
            this.Controls.Add(this.lblVuelto);
            this.Controls.Add(this.txtVuelto);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblNroFactura);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblDireccion);
            this.Name = "FormDetalleFacturaGerente";
            this.Text = "Detalle de Factura";
            this.Load += new System.EventHandler(this.FormDetalleFacturaGerente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo, lblNroFactura, lblFecha, lblCliente, lblDni, lblDireccion, lblContacto,
            lblVendedor, lblMetodoPago, lblSubtotal, lblIVA, lblTotal, lblMontoEntregado, lblVuelto;
        private System.Windows.Forms.Button btnCerrar, btnImprimir;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo, colProducto, colTalle, colCantidad, colPrecio, colSubtotal;
        private System.Windows.Forms.TextBox txtSubtotal, txtIVA, txtTotal, txtMontoEntregado, txtVuelto;
    }
}
