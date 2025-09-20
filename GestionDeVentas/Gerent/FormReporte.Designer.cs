using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    partial class FormReportesGerente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.colNroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblResultados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(378, 47);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes de Facturas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(760, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.Location = new System.Drawing.Point(20, 60);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(100, 23);
            this.lblFechaDesde.TabIndex = 2;
            this.lblFechaDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(80, 60);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpDesde.TabIndex = 3;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.Location = new System.Drawing.Point(288, 62);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(100, 23);
            this.lblFechaHasta.TabIndex = 4;
            this.lblFechaHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(336, 60);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpHasta.TabIndex = 5;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(20, 90);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(100, 23);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.Location = new System.Drawing.Point(80, 90);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(150, 24);
            this.cmbCliente.TabIndex = 7;
            // 
            // lblVendedor
            // 
            this.lblVendedor.Location = new System.Drawing.Point(250, 90);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(100, 23);
            this.lblVendedor.TabIndex = 8;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Location = new System.Drawing.Point(320, 90);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(150, 24);
            this.cmbVendedor.TabIndex = 9;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.Location = new System.Drawing.Point(485, 93);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(123, 23);
            this.lblMetodoPago.TabIndex = 10;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.Location = new System.Drawing.Point(610, 90);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(120, 24);
            this.cmbMetodoPago.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(740, 88);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 28);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(740, 58);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 28);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Restablecer";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFacturas.ColumnHeadersHeight = 29;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNroFactura,
            this.colFecha,
            this.colCliente,
            this.colVendedor,
            this.colMetodoPago,
            this.colTotal,
            this.colVerDetalle});
            this.dgvFacturas.Location = new System.Drawing.Point(20, 130);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.Size = new System.Drawing.Size(808, 350);
            this.dgvFacturas.TabIndex = 14;
            this.dgvFacturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            // 
            // colNroFactura
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNroFactura.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNroFactura.HeaderText = "N° Factura";
            this.colNroFactura.MinimumWidth = 6;
            this.colNroFactura.Name = "colNroFactura";
            this.colNroFactura.Width = 125;
            // 
            // colFecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.Width = 125;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.MinimumWidth = 6;
            this.colCliente.Name = "colCliente";
            this.colCliente.Width = 125;
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.MinimumWidth = 6;
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.Width = 125;
            // 
            // colMetodoPago
            // 
            this.colMetodoPago.HeaderText = "Método Pago";
            this.colMetodoPago.MinimumWidth = 6;
            this.colMetodoPago.Name = "colMetodoPago";
            this.colMetodoPago.Width = 125;
            // 
            // colTotal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 125;
            // 
            // colVerDetalle
            // 
            this.colVerDetalle.HeaderText = "Detalle";
            this.colVerDetalle.MinimumWidth = 6;
            this.colVerDetalle.Name = "colVerDetalle";
            this.colVerDetalle.Text = "Ver Detalle";
            this.colVerDetalle.UseColumnTextForButtonValue = true;
            this.colVerDetalle.Width = 125;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(20, 500);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(100, 30);
            this.btnExportarPDF.TabIndex = 15;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(140, 500);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(120, 30);
            this.btnExportarExcel.TabIndex = 16;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblResultados
            // 
            this.lblResultados.Location = new System.Drawing.Point(600, 500);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(200, 30);
            this.lblResultados.TabIndex = 17;
            this.lblResultados.Text = "0 facturas encontradas";
            // 
            // FormReportesGerente
            // 
            this.ClientSize = new System.Drawing.Size(840, 550);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.cmbMetodoPago);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.lblFechaDesde);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblFechaHasta);
            this.Name = "FormReportesGerente";
            this.Text = "Reportes de Facturas";
            this.Load += new System.EventHandler(this.FormReportesGerente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo, lblFechaDesde, lblFechaHasta, lblCliente, lblVendedor, lblMetodoPago, lblResultados;
        private System.Windows.Forms.Button btnCerrar, btnBuscar, btnReset, btnExportarPDF, btnExportarExcel;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.ComboBox cmbCliente, cmbVendedor, cmbMetodoPago;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroFactura, colFecha, colCliente, colVendedor, colMetodoPago, colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colVerDetalle;
    }
}
