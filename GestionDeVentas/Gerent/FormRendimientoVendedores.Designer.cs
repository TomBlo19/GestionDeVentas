namespace GestionDeVentas.Gerent
{
    partial class FormRendimientoVendedores
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.panelKPIs = new System.Windows.Forms.Panel();
            this.panelVentasUnidades = new System.Windows.Forms.Panel();
            this.lblVentasUnidadesValor = new System.Windows.Forms.Label();
            this.lblVentasUnidades = new System.Windows.Forms.Label();
            this.panelIngresos = new System.Windows.Forms.Panel();
            this.lblIngresosValor = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.panelGraficos = new System.Windows.Forms.Panel();
            this.chartVentasPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartIngresosMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelFiltros.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelVentasUnidades.SuspendLayout();
            this.panelIngresos.SuspendLayout();
            this.panelGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.btnAplicar);
            this.panelFiltros.Controls.Add(this.cbVendedor);
            this.panelFiltros.Controls.Add(this.lblVendedor);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(20, 12, 67, 12);
            this.panelFiltros.Size = new System.Drawing.Size(1200, 62);
            this.panelFiltros.TabIndex = 1002;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(899, 12);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(133, 37);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(653, 20);
            this.cbVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(212, 24);
            this.cbVendedor.TabIndex = 5;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(560, 23);
            this.lblVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(70, 16);
            this.lblVendedor.TabIndex = 8;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(373, 20);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(159, 22);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(309, 23);
            this.lblHasta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(46, 16);
            this.lblHasta.TabIndex = 9;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(93, 20);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(159, 22);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(20, 23);
            this.lblDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(51, 16);
            this.lblDesde.TabIndex = 10;
            this.lblDesde.Text = "Desde:";
            // 
            // panelKPIs
            // 
            this.panelKPIs.Controls.Add(this.panelVentasUnidades);
            this.panelKPIs.Controls.Add(this.panelIngresos);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 62);
            this.panelKPIs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Padding = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.panelKPIs.Size = new System.Drawing.Size(1200, 105);
            this.panelKPIs.TabIndex = 1001;
            // 
            // panelVentasUnidades
            // 
            this.panelVentasUnidades.Controls.Add(this.lblVentasUnidadesValor);
            this.panelVentasUnidades.Controls.Add(this.lblVentasUnidades);
            this.panelVentasUnidades.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVentasUnidades.Location = new System.Drawing.Point(600, 6);
            this.panelVentasUnidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelVentasUnidades.Name = "panelVentasUnidades";
            this.panelVentasUnidades.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelVentasUnidades.Size = new System.Drawing.Size(573, 93);
            this.panelVentasUnidades.TabIndex = 1;
            // 
            // lblVentasUnidadesValor
            // 
            this.lblVentasUnidadesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVentasUnidadesValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasUnidadesValor.Location = new System.Drawing.Point(7, 31);
            this.lblVentasUnidadesValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasUnidadesValor.Name = "lblVentasUnidadesValor";
            this.lblVentasUnidadesValor.Size = new System.Drawing.Size(559, 56);
            this.lblVentasUnidadesValor.TabIndex = 0;
            this.lblVentasUnidadesValor.Text = "0";
            this.lblVentasUnidadesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVentasUnidades
            // 
            this.lblVentasUnidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasUnidades.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasUnidades.Location = new System.Drawing.Point(7, 6);
            this.lblVentasUnidades.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVentasUnidades.Name = "lblVentasUnidades";
            this.lblVentasUnidades.Size = new System.Drawing.Size(559, 25);
            this.lblVentasUnidades.TabIndex = 1;
            this.lblVentasUnidades.Text = "Ventas (unidades)";
            this.lblVentasUnidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIngresos
            // 
            this.panelIngresos.Controls.Add(this.lblIngresosValor);
            this.panelIngresos.Controls.Add(this.lblIngresos);
            this.panelIngresos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIngresos.Location = new System.Drawing.Point(13, 6);
            this.panelIngresos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelIngresos.Name = "panelIngresos";
            this.panelIngresos.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelIngresos.Size = new System.Drawing.Size(587, 93);
            this.panelIngresos.TabIndex = 0;
            // 
            // lblIngresosValor
            // 
            this.lblIngresosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIngresosValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosValor.Location = new System.Drawing.Point(7, 31);
            this.lblIngresosValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngresosValor.Name = "lblIngresosValor";
            this.lblIngresosValor.Size = new System.Drawing.Size(573, 56);
            this.lblIngresosValor.TabIndex = 0;
            this.lblIngresosValor.Text = "$ 0.00";
            this.lblIngresosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresos
            // 
            this.lblIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIngresos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(7, 6);
            this.lblIngresos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(573, 25);
            this.lblIngresos.TabIndex = 1;
            this.lblIngresos.Text = "Ingresos (mes)";
            this.lblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGraficos
            // 
            this.panelGraficos.Controls.Add(this.chartVentasPorProducto);
            this.panelGraficos.Controls.Add(this.chartIngresosMensuales);
            this.panelGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraficos.Location = new System.Drawing.Point(0, 167);
            this.panelGraficos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGraficos.Name = "panelGraficos";
            this.panelGraficos.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelGraficos.Size = new System.Drawing.Size(1200, 571);
            this.panelGraficos.TabIndex = 1000;
            // 
            // chartVentasPorProducto
            // 
            chartArea1.Name = "MainArea";
            this.chartVentasPorProducto.ChartAreas.Add(chartArea1);
            this.chartVentasPorProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartVentasPorProducto.Legends.Add(legend1);
            this.chartVentasPorProducto.Location = new System.Drawing.Point(600, 12);
            this.chartVentasPorProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartVentasPorProducto.Name = "chartVentasPorProducto";
            series1.ChartArea = "MainArea";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVentasPorProducto.Series.Add(series1);
            this.chartVentasPorProducto.Size = new System.Drawing.Size(587, 547);
            this.chartVentasPorProducto.TabIndex = 0;
            // 
            // chartIngresosMensuales
            // 
            chartArea2.Name = "MainArea";
            this.chartIngresosMensuales.ChartAreas.Add(chartArea2);
            this.chartIngresosMensuales.Dock = System.Windows.Forms.DockStyle.Left;
            legend2.Name = "Legend1";
            this.chartIngresosMensuales.Legends.Add(legend2);
            this.chartIngresosMensuales.Location = new System.Drawing.Point(13, 12);
            this.chartIngresosMensuales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartIngresosMensuales.Name = "chartIngresosMensuales";
            series2.ChartArea = "MainArea";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartIngresosMensuales.Series.Add(series2);
            this.chartIngresosMensuales.Size = new System.Drawing.Size(587, 547);
            this.chartIngresosMensuales.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(1147, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(53, 49);
            this.btnCerrar.TabIndex = 999;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormRendimientoVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1200, 738);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelGraficos);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelFiltros);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormRendimientoVendedores";
            this.Text = "Rendimiento de Vendedores";
            this.Load += new System.EventHandler(this.FormRendimientoVendedores_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelVentasUnidades.ResumeLayout(false);
            this.panelIngresos.ResumeLayout(false);
            this.panelGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Panel panelKPIs;
        private System.Windows.Forms.Panel panelIngresos;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Panel panelVentasUnidades;
        private System.Windows.Forms.Label lblVentasUnidadesValor;
        private System.Windows.Forms.Label lblVentasUnidades;
        private System.Windows.Forms.Label lblIngresosValor;
        private System.Windows.Forms.Panel panelGraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPorProducto;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresosMensuales;
        private System.Windows.Forms.Button btnCerrar;
    }
}