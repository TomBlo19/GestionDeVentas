namespace GestionDeVentas.Gerent
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        // NUEVOS CONTROLES (filtros)
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnAplicar;

        // EXISTENTES
        private System.Windows.Forms.Panel panelKpis;
        private System.Windows.Forms.Panel panelClientesNuevos;
        private System.Windows.Forms.Label lblClientesNuevosValor;
        private System.Windows.Forms.Label lblClientesNuevos;
        private System.Windows.Forms.Panel panelProductosVendidos;
        private System.Windows.Forms.Label lblProductosVendidosValor;
        private System.Windows.Forms.Label lblProductosVendidos;
        private System.Windows.Forms.Panel panelVentasTotales;
        private System.Windows.Forms.Label lblVentasTotalesValor;
        private System.Windows.Forms.Label lblVentasTotales;
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelKpis = new System.Windows.Forms.Panel();
            this.panelClientesNuevos = new System.Windows.Forms.Panel();
            this.lblClientesNuevosValor = new System.Windows.Forms.Label();
            this.lblClientesNuevos = new System.Windows.Forms.Label();
            this.panelProductosVendidos = new System.Windows.Forms.Panel();
            this.lblProductosVendidosValor = new System.Windows.Forms.Label();
            this.lblProductosVendidos = new System.Windows.Forms.Label();
            this.panelVentasTotales = new System.Windows.Forms.Panel();
            this.lblVentasTotalesValor = new System.Windows.Forms.Label();
            this.lblVentasTotales = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.chartIngresosMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVentasPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.dgvTopProductos = new System.Windows.Forms.DataGridView();
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.lblTituloDashboard = new System.Windows.Forms.Label();

            // ===== NUEVO: panelFiltros y controles =====
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnAplicar = new System.Windows.Forms.Button();

            // 
            // lblTituloDashboard
            // 
            this.lblTituloDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloDashboard.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloDashboard.Location = new System.Drawing.Point(0, 0);
            this.lblTituloDashboard.Name = "lblTituloDashboard";
            this.lblTituloDashboard.Size = new System.Drawing.Size(800, 50);
            this.lblTituloDashboard.TabIndex = 3;
            this.lblTituloDashboard.Text = "Dashboard Gerencial";
            this.lblTituloDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // panelFiltros
            // 
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Height = 42;
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;

            // lbl Desde
            this.lblDesde.AutoSize = true;
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Location = new System.Drawing.Point(15, 13);

            // dtp Desde
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(65, 10);
            this.dtpDesde.Width = 100;

            // lbl Hasta
            this.lblHasta.AutoSize = true;
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Location = new System.Drawing.Point(185, 13);

            // dtp Hasta
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(235, 10);
            this.dtpHasta.Width = 100;

            // btn Aplicar
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Location = new System.Drawing.Point(355, 9);
            this.btnAplicar.Size = new System.Drawing.Size(75, 24);
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);

            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.btnAplicar);

            // 
            // panelKpis
            // 
            this.panelKpis.Controls.Add(this.panelClientesNuevos);
            this.panelKpis.Controls.Add(this.panelProductosVendidos);
            this.panelKpis.Controls.Add(this.panelVentasTotales);
            this.panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKpis.Location = new System.Drawing.Point(0, 92); // 50 título + 42 filtros
            this.panelKpis.Name = "panelKpis";
            this.panelKpis.Padding = new System.Windows.Forms.Padding(10);
            this.panelKpis.Size = new System.Drawing.Size(800, 100);
            this.panelKpis.TabIndex = 0;

            // panel Clientes Nuevos
            this.panelClientesNuevos.BackColor = System.Drawing.Color.SteelBlue;
            this.panelClientesNuevos.Controls.Add(this.lblClientesNuevosValor);
            this.panelClientesNuevos.Controls.Add(this.lblClientesNuevos);
            this.panelClientesNuevos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelClientesNuevos.Location = new System.Drawing.Point(510, 10);
            this.panelClientesNuevos.Name = "panelClientesNuevos";
            this.panelClientesNuevos.Padding = new System.Windows.Forms.Padding(5);
            this.panelClientesNuevos.Size = new System.Drawing.Size(250, 80);
            this.panelClientesNuevos.TabIndex = 2;

            this.lblClientesNuevosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientesNuevosValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblClientesNuevosValor.ForeColor = System.Drawing.Color.White;
            this.lblClientesNuevosValor.Text = "85";
            this.lblClientesNuevosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblClientesNuevos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClientesNuevos.Font = new System.Drawing.Font("Arial", 10F);
            this.lblClientesNuevos.ForeColor = System.Drawing.Color.White;
            this.lblClientesNuevos.Text = "Clientes Nuevos";
            this.lblClientesNuevos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panel Productos Vendidos
            this.panelProductosVendidos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panelProductosVendidos.Controls.Add(this.lblProductosVendidosValor);
            this.panelProductosVendidos.Controls.Add(this.lblProductosVendidos);
            this.panelProductosVendidos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelProductosVendidos.Location = new System.Drawing.Point(260, 10);
            this.panelProductosVendidos.Name = "panelProductosVendidos";
            this.panelProductosVendidos.Padding = new System.Windows.Forms.Padding(5);
            this.panelProductosVendidos.Size = new System.Drawing.Size(250, 80);
            this.panelProductosVendidos.TabIndex = 1;

            this.lblProductosVendidosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductosVendidosValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblProductosVendidosValor.ForeColor = System.Drawing.Color.White;
            this.lblProductosVendidosValor.Text = "2,500";
            this.lblProductosVendidosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblProductosVendidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductosVendidos.Font = new System.Drawing.Font("Arial", 10F);
            this.lblProductosVendidos.ForeColor = System.Drawing.Color.White;
            this.lblProductosVendidos.Text = "Productos Vendidos";
            this.lblProductosVendidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panel Ventas Totales
            this.panelVentasTotales.BackColor = System.Drawing.Color.LightCoral;
            this.panelVentasTotales.Controls.Add(this.lblVentasTotalesValor);
            this.panelVentasTotales.Controls.Add(this.lblVentasTotales);
            this.panelVentasTotales.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVentasTotales.Location = new System.Drawing.Point(10, 10);
            this.panelVentasTotales.Name = "panelVentasTotales";
            this.panelVentasTotales.Padding = new System.Windows.Forms.Padding(5);
            this.panelVentasTotales.Size = new System.Drawing.Size(250, 80);
            this.panelVentasTotales.TabIndex = 0;

            this.lblVentasTotalesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVentasTotalesValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblVentasTotalesValor.ForeColor = System.Drawing.Color.White;
            this.lblVentasTotalesValor.Text = "$ 150,000";
            this.lblVentasTotalesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblVentasTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasTotales.Font = new System.Drawing.Font("Arial", 10F);
            this.lblVentasTotales.ForeColor = System.Drawing.Color.White;
            this.lblVentasTotales.Text = "Ventas Totales";
            this.lblVentasTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // panel Gráfico
            this.panelGrafico.BackColor = System.Drawing.Color.White;
            this.panelGrafico.Controls.Add(this.chartIngresosMensuales);
            this.panelGrafico.Controls.Add(this.chartVentasPorProducto);
            this.panelGrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGrafico.Location = new System.Drawing.Point(0, 192);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Padding = new System.Windows.Forms.Padding(10);
            this.panelGrafico.Size = new System.Drawing.Size(800, 200);
            this.panelGrafico.TabIndex = 1;

            // chart Ingresos Mensuales
            chartArea1.Name = "ChartArea1";
            this.chartIngresosMensuales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartIngresosMensuales.Legends.Add(legend1);
            this.chartIngresosMensuales.Location = new System.Drawing.Point(10, 10);
            this.chartIngresosMensuales.Name = "chartIngresosMensuales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ingresos";
            this.chartIngresosMensuales.Series.Add(series1);
            this.chartIngresosMensuales.Size = new System.Drawing.Size(385, 180);
            this.chartIngresosMensuales.TabIndex = 0;
            this.chartIngresosMensuales.Text = "chart1";

            // chart Ventas por Producto
            chartArea2.Name = "ChartArea1";
            this.chartVentasPorProducto.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentasPorProducto.Legends.Add(legend2);
            this.chartVentasPorProducto.Location = new System.Drawing.Point(405, 10);
            this.chartVentasPorProducto.Name = "chartVentasPorProducto";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Ventas";
            this.chartVentasPorProducto.Series.Add(series2);
            this.chartVentasPorProducto.Size = new System.Drawing.Size(385, 180);
            this.chartVentasPorProducto.TabIndex = 1;
            this.chartVentasPorProducto.Text = "chart2";
            this.chartVentasPorProducto.Click += new System.EventHandler(this.chartVentasPorProducto_Click);

            // panel Productos (grid)
            this.panelProductos.Controls.Add(this.dgvTopProductos);
            this.panelProductos.Controls.Add(this.lblTituloProductos);
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(0, 392);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panelProductos.Size = new System.Drawing.Size(800, 208);
            this.panelProductos.TabIndex = 2;

            this.dgvTopProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProductos.Location = new System.Drawing.Point(10, 35);
            this.dgvTopProductos.Name = "dgvTopProductos";
            this.dgvTopProductos.Size = new System.Drawing.Size(780, 173);
            this.dgvTopProductos.TabIndex = 1;

            this.lblTituloProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloProductos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloProductos.Location = new System.Drawing.Point(10, 0);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Size = new System.Drawing.Size(780, 35);
            this.lblTituloProductos.TabIndex = 0;
            this.lblTituloProductos.Text = "Top 5 Productos Más Vendidos";
            this.lblTituloProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ===== Form =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.panelGrafico);
            this.Controls.Add(this.panelKpis);
            this.Controls.Add(this.panelFiltros);     // nuevo
            this.Controls.Add(this.lblTituloDashboard);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
        }

        #endregion
    }
}
