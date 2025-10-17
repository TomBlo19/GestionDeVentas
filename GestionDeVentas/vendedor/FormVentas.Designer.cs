namespace GestionDeVentas.Vendedor
{
    partial class FormVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.txtBusquedaCliente = new System.Windows.Forms.TextBox();
            this.lblBuscarNroFactura = new System.Windows.Forms.Label();
            this.txtBuscarNroFactura = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.colNroFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cboClienteCriterio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Listado de Ventas";
            // 
            // lblFiltros
            // 
            this.lblFiltros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblFiltros.Location = new System.Drawing.Point(20, 80);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(200, 23);
            this.lblFiltros.TabIndex = 1;
            this.lblFiltros.Text = "Filtros de Búsqueda";
            // 
            // lblBuscarCliente
            // 
            this.lblBuscarCliente.Location = new System.Drawing.Point(20, 120);
            this.lblBuscarCliente.Name = "lblBuscarCliente";
            this.lblBuscarCliente.Size = new System.Drawing.Size(120, 23);
            this.lblBuscarCliente.TabIndex = 2;
            this.lblBuscarCliente.Text = "Buscar Cliente por:";
            // 
            // cboClienteCriterio
            // 
            this.cboClienteCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClienteCriterio.FormattingEnabled = true;
            this.cboClienteCriterio.Location = new System.Drawing.Point(140, 119);
            this.cboClienteCriterio.Name = "cboClienteCriterio";
            this.cboClienteCriterio.Size = new System.Drawing.Size(100, 24);
            this.cboClienteCriterio.TabIndex = 3;
            // 
            // txtBusquedaCliente
            // 
            this.txtBusquedaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusquedaCliente.Location = new System.Drawing.Point(246, 120);
            this.txtBusquedaCliente.Name = "txtBusquedaCliente";
            this.txtBusquedaCliente.Size = new System.Drawing.Size(180, 22);
            this.txtBusquedaCliente.TabIndex = 4;
            // 
            // lblBuscarNroFactura
            // 
            this.lblBuscarNroFactura.Location = new System.Drawing.Point(20, 150);
            this.lblBuscarNroFactura.Name = "lblBuscarNroFactura";
            this.lblBuscarNroFactura.Size = new System.Drawing.Size(120, 23);
            this.lblBuscarNroFactura.TabIndex = 5;
            this.lblBuscarNroFactura.Text = "Nº de Factura:";
            // 
            // txtBuscarNroFactura
            // 
            this.txtBuscarNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarNroFactura.Location = new System.Drawing.Point(140, 150);
            this.txtBuscarNroFactura.Name = "txtBuscarNroFactura";
            this.txtBuscarNroFactura.Size = new System.Drawing.Size(286, 22);
            this.txtBuscarNroFactura.TabIndex = 6;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(20, 180);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(120, 23);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Rango de Fecha:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(140, 180);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.ShowCheckBox = true;
            this.dtpFechaInicio.Size = new System.Drawing.Size(130, 22);
            this.dtpFechaInicio.TabIndex = 8;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(276, 180);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(150, 22);
            this.dtpFechaFin.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(450, 120);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 40);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(560, 120);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(100, 40);
            this.btnLimpiarFiltros.TabIndex = 11;
            this.btnLimpiarFiltros.Text = "Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNroFactura,
            this.colFecha,
            this.colCliente,
            this.colMetodoPago,
            this.colTotal,
            this.colVer});
            this.dgvVentas.Location = new System.Drawing.Point(20, 230);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 24;
            this.dgvVentas.Size = new System.Drawing.Size(944, 529);
            this.dgvVentas.TabIndex = 12;
            this.dgvVentas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellContentClick);
            this.dgvVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVentas_CellDoubleClick);
            // 
            // colNroFactura
            // 
            this.colNroFactura.HeaderText = "Nº Factura";
            this.colNroFactura.MinimumWidth = 6;
            this.colNroFactura.Name = "colNroFactura";
            this.colNroFactura.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.MinimumWidth = 6;
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colMetodoPago
            // 
            this.colMetodoPago.HeaderText = "Método de Pago";
            this.colMetodoPago.MinimumWidth = 6;
            this.colMetodoPago.Name = "colMetodoPago";
            this.colMetodoPago.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colVer
            // 
            this.colVer.HeaderText = "";
            this.colVer.MinimumWidth = 6;
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Text = "Ver factura";
            this.colVer.UseColumnTextForButtonValue = true;
            this.colVer.Width = 120;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(924, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(50, 30);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 781);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtBuscarNroFactura);
            this.Controls.Add(this.lblBuscarNroFactura);
            this.Controls.Add(this.txtBusquedaCliente);
            this.Controls.Add(this.cboClienteCriterio);
            this.Controls.Add(this.lblBuscarCliente);
            this.Controls.Add(this.lblFiltros);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormVentas";
            this.Text = "Listado de Ventas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.TextBox txtBusquedaCliente;
        private System.Windows.Forms.Label lblBuscarNroFactura;
        private System.Windows.Forms.TextBox txtBuscarNroFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colVer;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cboClienteCriterio;
    }
}