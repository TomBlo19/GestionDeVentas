namespace GestionDeVentas.Gerent
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicar;

        private System.Windows.Forms.Button btnUltimaSemana;
        private System.Windows.Forms.Button btnMesActual;
        private System.Windows.Forms.Button btnUltimoTrimestre;

        private System.Windows.Forms.Panel panelKpis;
        private System.Windows.Forms.Panel panelVentasTotales;
        private System.Windows.Forms.Label lblVentasTotales;
        private System.Windows.Forms.Label lblVentasTotalesValor;
        private System.Windows.Forms.Label lblTendenciaVentas;
        private System.Windows.Forms.Label lblTicketPromedio;

        private System.Windows.Forms.Panel panelProductosVendidos;
        private System.Windows.Forms.Label lblProductosVendidos;
        private System.Windows.Forms.Label lblProductosVendidosValor;
        private System.Windows.Forms.Label lblTendenciaProductos;

        private System.Windows.Forms.Panel panelClientesNuevos;
        private System.Windows.Forms.Label lblClientesNuevos;
        private System.Windows.Forms.Label lblClientesNuevosValor;
        private System.Windows.Forms.Label lblTendenciaClientes;

        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresosMensuales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPorProducto;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.DataGridView dgvTopProductos;
        private System.Windows.Forms.Label lblTituloProductos;
        private System.Windows.Forms.Label lblTituloDashboard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTituloDashboard = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnUltimoTrimestre = new System.Windows.Forms.Button();
            this.btnMesActual = new System.Windows.Forms.Button();
            this.btnUltimaSemana = new System.Windows.Forms.Button();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.panelKpis = new System.Windows.Forms.Panel();
            this.panelClientesNuevos = new System.Windows.Forms.Panel();
            this.lblTendenciaClientes = new System.Windows.Forms.Label();
            this.lblClientesNuevosValor = new System.Windows.Forms.Label();
            this.lblClientesNuevos = new System.Windows.Forms.Label();
            this.panelProductosVendidos = new System.Windows.Forms.Panel();
            this.lblTendenciaProductos = new System.Windows.Forms.Label();
            this.lblProductosVendidosValor = new System.Windows.Forms.Label();
            this.lblProductosVendidos = new System.Windows.Forms.Label();
            this.panelVentasTotales = new System.Windows.Forms.Panel();
            this.lblTicketPromedio = new System.Windows.Forms.Label();
            this.lblTendenciaVentas = new System.Windows.Forms.Label();
            this.lblVentasTotalesValor = new System.Windows.Forms.Label();
            this.lblVentasTotales = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.tableGraf = new System.Windows.Forms.TableLayoutPanel();
            this.chartIngresosMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVentasPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.dgvTopProductos = new System.Windows.Forms.DataGridView();
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelFiltros.SuspendLayout();
            this.panelKpis.SuspendLayout();
            this.panelClientesNuevos.SuspendLayout();
            this.panelProductosVendidos.SuspendLayout();
            this.panelVentasTotales.SuspendLayout();
            this.panelGrafico.SuspendLayout();
            this.tableGraf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).BeginInit();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloDashboard
            // 
            this.lblTituloDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTituloDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloDashboard.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTituloDashboard.ForeColor = System.Drawing.Color.White;
            this.lblTituloDashboard.Location = new System.Drawing.Point(0, 0);
            this.lblTituloDashboard.Name = "lblTituloDashboard";
            this.lblTituloDashboard.Size = new System.Drawing.Size(1000, 70);
            this.lblTituloDashboard.TabIndex = 5;
            this.lblTituloDashboard.Text = "Reportes Gerenciales";
            this.lblTituloDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(211)))), ((int)(((byte)(179)))));
            this.panelFiltros.Controls.Add(this.btnUltimoTrimestre);
            this.panelFiltros.Controls.Add(this.btnMesActual);
            this.panelFiltros.Controls.Add(this.btnUltimaSemana);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.btnAplicar);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 70);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelFiltros.Size = new System.Drawing.Size(1000, 55);
            this.panelFiltros.TabIndex = 4;
            // 
            // btnUltimoTrimestre
            // 
            this.btnUltimoTrimestre.Location = new System.Drawing.Point(783, 14);
            this.btnUltimoTrimestre.Name = "btnUltimoTrimestre";
            this.btnUltimoTrimestre.Size = new System.Drawing.Size(125, 26);
            this.btnUltimoTrimestre.TabIndex = 1;
            this.btnUltimoTrimestre.Text = "Último trimestre";
            // 
            // btnMesActual
            // 
            this.btnMesActual.Location = new System.Drawing.Point(677, 15);
            this.btnMesActual.Name = "btnMesActual";
            this.btnMesActual.Size = new System.Drawing.Size(100, 25);
            this.btnMesActual.TabIndex = 2;
            this.btnMesActual.Text = "Mes actual";
            // 
            // btnUltimaSemana
            // 
            this.btnUltimaSemana.Location = new System.Drawing.Point(557, 16);
            this.btnUltimaSemana.Name = "btnUltimaSemana";
            this.btnUltimaSemana.Size = new System.Drawing.Size(114, 24);
            this.btnUltimaSemana.TabIndex = 3;
            this.btnUltimaSemana.Text = "Última semana";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(3, 20);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 16);
            this.lblDesde.TabIndex = 4;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(60, 16);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(180, 22);
            this.dtpDesde.TabIndex = 5;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(246, 21);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(46, 16);
            this.lblHasta.TabIndex = 6;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(298, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(180, 22);
            this.dtpHasta.TabIndex = 7;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(484, 14);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(67, 30);
            this.btnAplicar.TabIndex = 8;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // panelKpis
            // 
            this.panelKpis.AutoScroll = true;
            this.panelKpis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(204)))));
            this.panelKpis.Controls.Add(this.panelClientesNuevos);
            this.panelKpis.Controls.Add(this.panelProductosVendidos);
            this.panelKpis.Controls.Add(this.panelVentasTotales);
            this.panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpis.Location = new System.Drawing.Point(0, 125);
            this.panelKpis.Name = "panelKpis";
            this.panelKpis.Size = new System.Drawing.Size(1000, 106);
            this.panelKpis.TabIndex = 3;
            // 
            // panelClientesNuevos
            // 
            this.panelClientesNuevos.Controls.Add(this.lblTendenciaClientes);
            this.panelClientesNuevos.Controls.Add(this.lblClientesNuevosValor);
            this.panelClientesNuevos.Controls.Add(this.lblClientesNuevos);
            this.panelClientesNuevos.Location = new System.Drawing.Point(665, 15);
            this.panelClientesNuevos.Name = "panelClientesNuevos";
            this.panelClientesNuevos.Size = new System.Drawing.Size(310, 90);
            this.panelClientesNuevos.TabIndex = 0;
            // 
            // lblTendenciaClientes
            // 
            this.lblTendenciaClientes.AutoSize = true;
            this.lblTendenciaClientes.Location = new System.Drawing.Point(275, 5);
            this.lblTendenciaClientes.Name = "lblTendenciaClientes";
            this.lblTendenciaClientes.Size = new System.Drawing.Size(37, 16);
            this.lblTendenciaClientes.TabIndex = 0;
            this.lblTendenciaClientes.Text = "▲ 0%";
            // 
            // lblClientesNuevosValor
            // 
            this.lblClientesNuevosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientesNuevosValor.Location = new System.Drawing.Point(0, 23);
            this.lblClientesNuevosValor.Name = "lblClientesNuevosValor";
            this.lblClientesNuevosValor.Size = new System.Drawing.Size(310, 67);
            this.lblClientesNuevosValor.TabIndex = 1;
            this.lblClientesNuevosValor.Text = "0";
            // 
            // lblClientesNuevos
            // 
            this.lblClientesNuevos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClientesNuevos.Location = new System.Drawing.Point(0, 0);
            this.lblClientesNuevos.Name = "lblClientesNuevos";
            this.lblClientesNuevos.Size = new System.Drawing.Size(310, 23);
            this.lblClientesNuevos.TabIndex = 2;
            this.lblClientesNuevos.Text = "Clientes Nuevos";
            // 
            // panelProductosVendidos
            // 
            this.panelProductosVendidos.Controls.Add(this.lblTendenciaProductos);
            this.panelProductosVendidos.Controls.Add(this.lblProductosVendidosValor);
            this.panelProductosVendidos.Controls.Add(this.lblProductosVendidos);
            this.panelProductosVendidos.Location = new System.Drawing.Point(340, 15);
            this.panelProductosVendidos.Name = "panelProductosVendidos";
            this.panelProductosVendidos.Size = new System.Drawing.Size(310, 90);
            this.panelProductosVendidos.TabIndex = 1;
            // 
            // lblTendenciaProductos
            // 
            this.lblTendenciaProductos.AutoSize = true;
            this.lblTendenciaProductos.Location = new System.Drawing.Point(275, 5);
            this.lblTendenciaProductos.Name = "lblTendenciaProductos";
            this.lblTendenciaProductos.Size = new System.Drawing.Size(37, 16);
            this.lblTendenciaProductos.TabIndex = 0;
            this.lblTendenciaProductos.Text = "▲ 0%";
            // 
            // lblProductosVendidosValor
            // 
            this.lblProductosVendidosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductosVendidosValor.Location = new System.Drawing.Point(0, 23);
            this.lblProductosVendidosValor.Name = "lblProductosVendidosValor";
            this.lblProductosVendidosValor.Size = new System.Drawing.Size(310, 67);
            this.lblProductosVendidosValor.TabIndex = 1;
            this.lblProductosVendidosValor.Text = "0";
            // 
            // lblProductosVendidos
            // 
            this.lblProductosVendidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductosVendidos.Location = new System.Drawing.Point(0, 0);
            this.lblProductosVendidos.Name = "lblProductosVendidos";
            this.lblProductosVendidos.Size = new System.Drawing.Size(310, 23);
            this.lblProductosVendidos.TabIndex = 2;
            this.lblProductosVendidos.Text = "Productos Vendidos";
            // 
            // panelVentasTotales
            // 
            this.panelVentasTotales.Controls.Add(this.lblTicketPromedio);
            this.panelVentasTotales.Controls.Add(this.lblTendenciaVentas);
            this.panelVentasTotales.Controls.Add(this.lblVentasTotalesValor);
            this.panelVentasTotales.Controls.Add(this.lblVentasTotales);
            this.panelVentasTotales.Location = new System.Drawing.Point(15, 15);
            this.panelVentasTotales.Name = "panelVentasTotales";
            this.panelVentasTotales.Size = new System.Drawing.Size(310, 90);
            this.panelVentasTotales.TabIndex = 2;
            // 
            // lblTicketPromedio
            // 
            this.lblTicketPromedio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTicketPromedio.Location = new System.Drawing.Point(0, 67);
            this.lblTicketPromedio.Name = "lblTicketPromedio";
            this.lblTicketPromedio.Size = new System.Drawing.Size(310, 23);
            this.lblTicketPromedio.TabIndex = 0;
            this.lblTicketPromedio.Text = "Ticket promedio: $ 0,00";
            // 
            // lblTendenciaVentas
            // 
            this.lblTendenciaVentas.AutoSize = true;
            this.lblTendenciaVentas.Location = new System.Drawing.Point(275, 5);
            this.lblTendenciaVentas.Name = "lblTendenciaVentas";
            this.lblTendenciaVentas.Size = new System.Drawing.Size(37, 16);
            this.lblTendenciaVentas.TabIndex = 1;
            this.lblTendenciaVentas.Text = "▲ 0%";
            // 
            // lblVentasTotalesValor
            // 
            this.lblVentasTotalesValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasTotalesValor.Location = new System.Drawing.Point(0, 23);
            this.lblVentasTotalesValor.Name = "lblVentasTotalesValor";
            this.lblVentasTotalesValor.Size = new System.Drawing.Size(310, 45);
            this.lblVentasTotalesValor.TabIndex = 2;
            this.lblVentasTotalesValor.Text = "$ 0,00";
            // 
            // lblVentasTotales
            // 
            this.lblVentasTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasTotales.Location = new System.Drawing.Point(0, 0);
            this.lblVentasTotales.Name = "lblVentasTotales";
            this.lblVentasTotales.Size = new System.Drawing.Size(310, 23);
            this.lblVentasTotales.TabIndex = 3;
            this.lblVentasTotales.Text = "Ventas Totales";
            // 
            // panelGrafico
            // 
            this.panelGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(204)))));
            this.panelGrafico.Controls.Add(this.tableGraf);
            this.panelGrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrafico.Location = new System.Drawing.Point(0, 231);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Padding = new System.Windows.Forms.Padding(10);
            this.panelGrafico.Size = new System.Drawing.Size(1000, 263);
            this.panelGrafico.TabIndex = 2;
            // 
            // tableGraf
            // 
            this.tableGraf.ColumnCount = 2;
            this.tableGraf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGraf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGraf.Controls.Add(this.chartIngresosMensuales, 0, 0);
            this.tableGraf.Controls.Add(this.chartVentasPorProducto, 1, 0);
            this.tableGraf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableGraf.Location = new System.Drawing.Point(10, 10);
            this.tableGraf.Margin = new System.Windows.Forms.Padding(0);
            this.tableGraf.Name = "tableGraf";
            this.tableGraf.RowCount = 1;
            this.tableGraf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableGraf.Size = new System.Drawing.Size(980, 243);
            this.tableGraf.TabIndex = 0;
            // 
            // chartIngresosMensuales
            // 
            chartArea1.Name = "MainArea";
            this.chartIngresosMensuales.ChartAreas.Add(chartArea1);
            this.chartIngresosMensuales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartIngresosMensuales.Legends.Add(legend1);
            this.chartIngresosMensuales.Location = new System.Drawing.Point(3, 3);
            this.chartIngresosMensuales.MinimumSize = new System.Drawing.Size(300, 250);
            this.chartIngresosMensuales.Name = "chartIngresosMensuales";
            series1.ChartArea = "MainArea";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartIngresosMensuales.Series.Add(series1);
            this.chartIngresosMensuales.Size = new System.Drawing.Size(484, 250);
            this.chartIngresosMensuales.TabIndex = 0;
            // 
            // chartVentasPorProducto
            // 
            chartArea2.Name = "MainArea";
            this.chartVentasPorProducto.ChartAreas.Add(chartArea2);
            this.chartVentasPorProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartVentasPorProducto.Legends.Add(legend2);
            this.chartVentasPorProducto.Location = new System.Drawing.Point(493, 3);
            this.chartVentasPorProducto.MinimumSize = new System.Drawing.Size(300, 250);
            this.chartVentasPorProducto.Name = "chartVentasPorProducto";
            series2.ChartArea = "MainArea";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVentasPorProducto.Series.Add(series2);
            this.chartVentasPorProducto.Size = new System.Drawing.Size(484, 250);
            this.chartVentasPorProducto.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(230)))), ((int)(((byte)(204)))));
            this.panelProductos.Controls.Add(this.dgvTopProductos);
            this.panelProductos.Controls.Add(this.lblTituloProductos);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(0, 494);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Padding = new System.Windows.Forms.Padding(10);
            this.panelProductos.Size = new System.Drawing.Size(1000, 206);
            this.panelProductos.TabIndex = 1;
            // 
            // dgvTopProductos
            // 
            this.dgvTopProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopProductos.ColumnHeadersHeight = 29;
            this.dgvTopProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProductos.Location = new System.Drawing.Point(10, 50);
            this.dgvTopProductos.Name = "dgvTopProductos";
            this.dgvTopProductos.ReadOnly = true;
            this.dgvTopProductos.RowHeadersWidth = 51;
            this.dgvTopProductos.Size = new System.Drawing.Size(980, 146);
            this.dgvTopProductos.TabIndex = 0;
            // 
            // lblTituloProductos
            // 
            this.lblTituloProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloProductos.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTituloProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.lblTituloProductos.Location = new System.Drawing.Point(10, 10);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Padding = new System.Windows.Forms.Padding(5);
            this.lblTituloProductos.Size = new System.Drawing.Size(980, 40);
            this.lblTituloProductos.TabIndex = 1;
            this.lblTituloProductos.Text = "Top 5 Productos Más Vendidos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(39)))), ((int)(((byte)(35)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(950, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(45, 35);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormDashboard
            // 
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelGrafico);
            this.Controls.Add(this.panelKpis);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.lblTituloDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "Dashboard Gerente";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelKpis.ResumeLayout(false);
            this.panelClientesNuevos.ResumeLayout(false);
            this.panelClientesNuevos.PerformLayout();
            this.panelProductosVendidos.ResumeLayout(false);
            this.panelProductosVendidos.PerformLayout();
            this.panelVentasTotales.ResumeLayout(false);
            this.panelVentasTotales.PerformLayout();
            this.panelGrafico.ResumeLayout(false);
            this.tableGraf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).EndInit();
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProductos)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel tableGraf;
    }
}
