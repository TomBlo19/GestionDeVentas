using System;
using System.Windows.Forms;

namespace GestionDeVentas.Gerent
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;

        // Título
        private Label lblTitulo;

        // Filtros
        private Panel panelFiltros;
        private Label lblDesde;
        private Label lblHasta;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label lblVendedor;
        private ComboBox cboVendedor;
        private Button btnAplicar;

        // KPIs
        private Panel panelKpis;
        private Panel panelMonto;
        private Panel panelUnidades;
        private Panel panelPedidos;
        private Label lblMonto;
        private Label lblMontoValor;
        private Label lblUnidades;
        private Label lblUnidadesValor;
        private Label lblPedidos;
        private Label lblPedidosValor;

        // Gráficos
        private Panel panelGraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPorDia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPorProducto;

        // Detalle + export
        private Panel panelDetalle;
        private DataGridView dgvDetalle;
        private Panel panelExport;
        private Button btnExportarCsv;
        private Button btnExportarPng;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.btnAplicar = new System.Windows.Forms.Button();

            this.panelKpis = new System.Windows.Forms.Panel();
            this.panelMonto = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblMontoValor = new System.Windows.Forms.Label();
            this.panelUnidades = new System.Windows.Forms.Panel();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.lblUnidadesValor = new System.Windows.Forms.Label();
            this.panelPedidos = new System.Windows.Forms.Panel();
            this.lblPedidos = new System.Windows.Forms.Label();
            this.lblPedidosValor = new System.Windows.Forms.Label();

            this.panelGraficos = new System.Windows.Forms.Panel();
            this.chartPorDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.panelDetalle = new System.Windows.Forms.Panel();
            this.panelExport = new System.Windows.Forms.Panel();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.btnExportarPng = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.chartPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPorProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();

            this.SuspendLayout();

            // ===== Form =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Reportes - Gerente";
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(980, 640);
            this.Load += new System.EventHandler(this.FormReportes_Load);

            // ===== lblTitulo =====
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Height = 44;
            this.lblTitulo.Text = "Reportes de Ventas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);

            // ===== panelFiltros =====
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 48;
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;

            this.lblDesde.AutoSize = true;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Location = new System.Drawing.Point(12, 15);

            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 12);
            this.dtpDesde.Width = 95;

            this.lblHasta.AutoSize = true;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Location = new System.Drawing.Point(170, 15);

            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(218, 12);
            this.dtpHasta.Width = 95;

            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Text = "Vendedor:";
            this.lblVendedor.Location = new System.Drawing.Point(330, 15);

            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.Location = new System.Drawing.Point(400, 12);
            this.cboVendedor.Width = 140;

            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Location = new System.Drawing.Point(560, 10);
            this.btnAplicar.Size = new System.Drawing.Size(80, 26);
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblVendedor);
            this.panelFiltros.Controls.Add(this.cboVendedor);
            this.panelFiltros.Controls.Add(this.btnAplicar);

            // ===== panelKpis =====
            this.panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpis.Height = 92;
            this.panelKpis.Padding = new System.Windows.Forms.Padding(10);

            // panelMonto
            this.panelMonto.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMonto.Width = 300;
            this.panelMonto.BackColor = System.Drawing.Color.LightCoral;
            this.panelMonto.Padding = new System.Windows.Forms.Padding(6);

            this.lblMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonto.Text = "Ventas ($)";
            this.lblMonto.ForeColor = System.Drawing.Color.White;
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblMontoValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMontoValor.Text = "$ 0";
            this.lblMontoValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblMontoValor.ForeColor = System.Drawing.Color.White;
            this.lblMontoValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelMonto.Controls.Add(this.lblMontoValor);
            this.panelMonto.Controls.Add(this.lblMonto);

            // panelUnidades
            this.panelUnidades.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelUnidades.Width = 300;
            this.panelUnidades.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panelUnidades.Padding = new System.Windows.Forms.Padding(6);

            this.lblUnidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUnidades.Text = "Productos Vendidos";
            this.lblUnidades.ForeColor = System.Drawing.Color.White;
            this.lblUnidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblUnidadesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnidadesValor.Text = "0";
            this.lblUnidadesValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblUnidadesValor.ForeColor = System.Drawing.Color.White;
            this.lblUnidadesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelUnidades.Controls.Add(this.lblUnidadesValor);
            this.panelUnidades.Controls.Add(this.lblUnidades);

            // panelPedidos
            this.panelPedidos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPedidos.Width = 300;
            this.panelPedidos.BackColor = System.Drawing.Color.SteelBlue;
            this.panelPedidos.Padding = new System.Windows.Forms.Padding(6);

            this.lblPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPedidos.Text = "Pedidos";
            this.lblPedidos.ForeColor = System.Drawing.Color.White;
            this.lblPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblPedidosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPedidosValor.Text = "0";
            this.lblPedidosValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblPedidosValor.ForeColor = System.Drawing.Color.White;
            this.lblPedidosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelPedidos.Controls.Add(this.lblPedidosValor);
            this.panelPedidos.Controls.Add(this.lblPedidos);

            this.panelKpis.Controls.Add(this.panelPedidos);
            this.panelKpis.Controls.Add(this.panelUnidades);
            this.panelKpis.Controls.Add(this.panelMonto);

            // ===== panelGraficos =====
            this.panelGraficos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGraficos.Height = 240;
            this.panelGraficos.Padding = new System.Windows.Forms.Padding(10);
            this.panelGraficos.BackColor = System.Drawing.Color.White;

            // chartPorDia
            var ca1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            ca1.Name = "ChartArea1";
            ca1.AxisX.MajorGrid.Enabled = false;
            this.chartPorDia.ChartAreas.Add(ca1);
            var lg1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            lg1.Name = "Legend1";
            this.chartPorDia.Legends.Add(lg1);
            this.chartPorDia.Location = new System.Drawing.Point(10, 10);
            this.chartPorDia.Name = "chartPorDia";
            this.chartPorDia.Size = new System.Drawing.Size(450, 220);
            this.chartPorDia.TabIndex = 0;

            // chartPorProducto
            var ca2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            ca2.Name = "ChartArea2";
            this.chartPorProducto.ChartAreas.Add(ca2);
            var lg2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            lg2.Name = "Legend2";
            this.chartPorProducto.Legends.Add(lg2);
            this.chartPorProducto.Location = new System.Drawing.Point(480, 10);
            this.chartPorProducto.Name = "chartPorProducto";
            this.chartPorProducto.Size = new System.Drawing.Size(470, 220);
            this.chartPorProducto.TabIndex = 1;

            this.panelGraficos.Controls.Add(this.chartPorDia);
            this.panelGraficos.Controls.Add(this.chartPorProducto);

            // ===== panelDetalle =====
            this.panelDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);

            // panelExport
            this.panelExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExport.Height = 40;
            this.panelExport.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);

            this.btnExportarCsv.Text = "Exportar CSV";
            this.btnExportarCsv.Width = 120;
            this.btnExportarCsv.Location = new System.Drawing.Point(10, 6);
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);

            this.btnExportarPng.Text = "Exportar Gráficos (PNG)";
            this.btnExportarPng.Width = 180;
            this.btnExportarPng.Location = new System.Drawing.Point(140, 6);
            this.btnExportarPng.Click += new System.EventHandler(this.btnExportarPng_Click);

            this.panelExport.Controls.Add(this.btnExportarCsv);
            this.panelExport.Controls.Add(this.btnExportarPng);

            // dgvDetalle
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;

            this.panelDetalle.Controls.Add(this.dgvDetalle);
            this.panelDetalle.Controls.Add(this.panelExport);

            // ===== Orden de agregado al Form =====
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.panelGraficos);
            this.Controls.Add(this.panelKpis);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.lblTitulo);

            ((System.ComponentModel.ISupportInitialize)(this.chartPorDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPorProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

