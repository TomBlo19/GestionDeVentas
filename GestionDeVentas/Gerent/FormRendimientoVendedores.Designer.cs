using System;
using System.Windows.Forms;

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
            this.btnExportar = new System.Windows.Forms.Button();
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
            this.chartIngresosMensuales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVentasPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            // >>> NUEVO: botón cerrar
            this.btnCerrar = new System.Windows.Forms.Button();

            this.panelFiltros.SuspendLayout();
            this.panelKPIs.SuspendLayout();
            this.panelVentasUnidades.SuspendLayout();
            this.panelIngresos.SuspendLayout();
            this.panelGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.btnExportar);
            this.panelFiltros.Controls.Add(this.btnAplicar);
            this.panelFiltros.Controls.Add(this.cbVendedor);
            this.panelFiltros.Controls.Add(this.lblVendedor);
            this.panelFiltros.Controls.Add(this.dtpHasta);
            this.panelFiltros.Controls.Add(this.lblHasta);
            this.panelFiltros.Controls.Add(this.dtpDesde);
            this.panelFiltros.Controls.Add(this.lblDesde);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltros.Size = new System.Drawing.Size(800, 50);
            this.panelFiltros.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(680, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 30);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAplicar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(574, 10);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 30);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            // 
            // cbVendedor
            // 
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(420, 16);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(148, 21);
            this.cbVendedor.TabIndex = 5;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(362, 19);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(56, 13);
            this.lblVendedor.TabIndex = 4;
            this.lblVendedor.Text = "Vendedor:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(232, 16);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(190, 19);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(59, 16);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 20);
            this.dtpDesde.TabIndex = 1;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(13, 19);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // panelKPIs
            // 
            this.panelKPIs.Controls.Add(this.panelVentasUnidades);
            this.panelKPIs.Controls.Add(this.panelIngresos);
            this.panelKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKPIs.Location = new System.Drawing.Point(0, 50);
            this.panelKPIs.Name = "panelKPIs";
            this.panelKPIs.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelKPIs.Size = new System.Drawing.Size(800, 80);
            this.panelKPIs.TabIndex = 1;
            // 
            // panelVentasUnidades
            // 
            this.panelVentasUnidades.BackColor = System.Drawing.Color.White;
            this.panelVentasUnidades.Controls.Add(this.lblVentasUnidadesValor);
            this.panelVentasUnidades.Controls.Add(this.lblVentasUnidades);
            this.panelVentasUnidades.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVentasUnidades.Location = new System.Drawing.Point(395, 5);
            this.panelVentasUnidades.Name = "panelVentasUnidades";
            this.panelVentasUnidades.Padding = new System.Windows.Forms.Padding(5);
            this.panelVentasUnidades.Size = new System.Drawing.Size(385, 70);
            this.panelVentasUnidades.TabIndex = 1;
            // 
            // lblVentasUnidadesValor
            // 
            this.lblVentasUnidadesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVentasUnidadesValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasUnidadesValor.Location = new System.Drawing.Point(5, 25);
            this.lblVentasUnidadesValor.Name = "lblVentasUnidadesValor";
            this.lblVentasUnidadesValor.Size = new System.Drawing.Size(375, 40);
            this.lblVentasUnidadesValor.TabIndex = 1;
            this.lblVentasUnidadesValor.Text = "0";
            this.lblVentasUnidadesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVentasUnidades
            // 
            this.lblVentasUnidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasUnidades.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasUnidades.Location = new System.Drawing.Point(5, 5);
            this.lblVentasUnidades.Name = "lblVentasUnidades";
            this.lblVentasUnidades.Size = new System.Drawing.Size(375, 20);
            this.lblVentasUnidades.TabIndex = 0;
            this.lblVentasUnidades.Text = "Ventas (unidades)";
            this.lblVentasUnidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIngresos
            // 
            this.panelIngresos.BackColor = System.Drawing.Color.White;
            this.panelIngresos.Controls.Add(this.lblIngresosValor);
            this.panelIngresos.Controls.Add(this.lblIngresos);
            this.panelIngresos.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIngresos.Location = new System.Drawing.Point(10, 5);
            this.panelIngresos.Name = "panelIngresos";
            this.panelIngresos.Padding = new System.Windows.Forms.Padding(5);
            this.panelIngresos.Size = new System.Drawing.Size(385, 70);
            this.panelIngresos.TabIndex = 0;
            // 
            // lblIngresosValor
            // 
            this.lblIngresosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIngresosValor.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosValor.Location = new System.Drawing.Point(5, 25);
            this.lblIngresosValor.Name = "lblIngresosValor";
            this.lblIngresosValor.Size = new System.Drawing.Size(375, 40);
            this.lblIngresosValor.TabIndex = 1;
            this.lblIngresosValor.Text = "$ 0.00";
            this.lblIngresosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIngresos
            // 
            this.lblIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIngresos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(5, 5);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(375, 20);
            this.lblIngresos.TabIndex = 0;
            this.lblIngresos.Text = "Ingresos (mes)";
            this.lblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGraficos
            // 
            this.panelGraficos.Controls.Add(this.chartVentasPorProducto);
            this.panelGraficos.Controls.Add(this.chartIngresosMensuales);
            this.panelGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraficos.Location = new System.Drawing.Point(0, 130);
            this.panelGraficos.Name = "panelGraficos";
            this.panelGraficos.Padding = new System.Windows.Forms.Padding(10);
            this.panelGraficos.Size = new System.Drawing.Size(800, 470);
            this.panelGraficos.TabIndex = 2;
            // 
            // chartIngresosMensuales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartIngresosMensuales.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartIngresosMensuales.Legends.Add(legend1);
            this.chartIngresosMensuales.Location = new System.Drawing.Point(10, 10);
            this.chartIngresosMensuales.Name = "chartIngresosMensuales";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartIngresosMensuales.Series.Add(series1);
            this.chartIngresosMensuales.Size = new System.Drawing.Size(385, 450);
            this.chartIngresosMensuales.TabIndex = 0;
            this.chartIngresosMensuales.Text = "chart1";
            // 
            // chartVentasPorProducto
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentasPorProducto.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentasPorProducto.Legends.Add(legend2);
            this.chartVentasPorProducto.Location = new System.Drawing.Point(405, 10);
            this.chartVentasPorProducto.Name = "chartVentasPorProducto";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVentasPorProducto.Series.Add(series2);
            this.chartVentasPorProducto.Size = new System.Drawing.Size(385, 450);
            this.chartVentasPorProducto.TabIndex = 1;
            this.chartVentasPorProducto.Text = "chart2";
            // 
            // >>> NUEVO: btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(760, 0); // 800 - 40
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 40);
            this.btnCerrar.TabIndex = 999;
            this.btnCerrar.Text = "✕";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // 
            // FormRendimientoVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCerrar);                 // agregado arriba
            this.Controls.Add(this.panelGraficos);
            this.Controls.Add(this.panelKPIs);
            this.Controls.Add(this.panelFiltros);
            this.Name = "FormRendimientoVendedores";
            this.Text = "Rendimiento de Vendedores";
            this.Load += new System.EventHandler(this.FormRendimientoVendedores_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.panelKPIs.ResumeLayout(false);
            this.panelVentasUnidades.ResumeLayout(false);
            this.panelIngresos.ResumeLayout(false);
            this.panelGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresosMensuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorProducto)).EndInit();
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
        private System.Windows.Forms.Button btnExportar;
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
        // >>> NUEVO:
        private System.Windows.Forms.Button btnCerrar;
    }
}
