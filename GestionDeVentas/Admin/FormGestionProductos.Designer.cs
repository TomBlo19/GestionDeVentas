using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Admin
{
    partial class FormReportes
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Button btnCerrar;
        private Panel panelAlertas;
        private Label lblAlertasStock;
        private Label lblTituloAlertas;
        private Panel panelHistorial;
        private Label lblTituloHistorial;
        private DataGridView dgvHistorial;
        private Chart chartVentas;
        private Label lblTituloGrafico;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label lblDesde;
        private Label lblHasta;
        private ComboBox cmbMovimiento;
        private Label lblFiltroMovimiento;
        private Button btnFiltrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloGrafico = new System.Windows.Forms.Label();
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.panelAlertas = new System.Windows.Forms.Panel();
            this.lblAlertasStock = new System.Windows.Forms.Label();
            this.lblTituloAlertas = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.lblFiltroMovimiento = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelAlertas.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.mainPanel.Controls.Add(this.panelHistorial);
            this.mainPanel.Controls.Add(this.btnCerrar);
            this.mainPanel.Controls.Add(this.chartVentas);
            this.mainPanel.Controls.Add(this.lblTituloGrafico);
            this.mainPanel.Controls.Add(this.panelAlertas);
            this.mainPanel.Controls.Add(this.dtpDesde);
            this.mainPanel.Controls.Add(this.dtpHasta);
            this.mainPanel.Controls.Add(this.lblHasta);
            this.mainPanel.Controls.Add(this.cmbMovimiento);
            this.mainPanel.Controls.Add(this.lblFiltroMovimiento);
            this.mainPanel.Controls.Add(this.btnFiltrar);
            this.mainPanel.Controls.Add(this.lblDesde);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1200, 750);
            this.mainPanel.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1140, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 30);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chartVentas
            // 
            this.chartVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            chartArea1.Name = "Main";
            this.chartVentas.ChartAreas.Add(chartArea1);
            this.chartVentas.Location = new System.Drawing.Point(400, 60);
            this.chartVentas.Name = "chartVentas";
            this.chartVentas.Size = new System.Drawing.Size(770, 250);
            this.chartVentas.TabIndex = 1;
            // 
            // lblTituloGrafico
            // 
            this.lblTituloGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(32)))), ((int)(((byte)(0)))));
            this.lblTituloGrafico.Location = new System.Drawing.Point(400, 30);
            this.lblTituloGrafico.Name = "lblTituloGrafico";
            this.lblTituloGrafico.Size = new System.Drawing.Size(400, 30);
            this.lblTituloGrafico.TabIndex = 2;
            this.lblTituloGrafico.Text = "Productos más vendidos";
            // 
            // panelHistorial
            // 
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorial.Controls.Add(this.dgvHistorial);
            this.panelHistorial.Controls.Add(this.lblTituloHistorial);
            this.panelHistorial.Location = new System.Drawing.Point(20, 360);
            this.panelHistorial.Name = "panelHistorial";
            this.panelHistorial.Size = new System.Drawing.Size(1150, 360);
            this.panelHistorial.TabIndex = 3;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorial.ColumnHeadersHeight = 29;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.EnableHeadersVisualStyles = false;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 0);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(240, 150);
            this.dgvHistorial.TabIndex = 0;
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.White;
            this.lblTituloHistorial.Location = new System.Drawing.Point(0, 0);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(100, 40);
            this.lblTituloHistorial.TabIndex = 1;
            this.lblTituloHistorial.Text = "Historial de Movimientos";
            this.lblTituloHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAlertas
            // 
            this.panelAlertas.BackColor = System.Drawing.Color.White;
            this.panelAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlertas.Controls.Add(this.lblAlertasStock);
            this.panelAlertas.Controls.Add(this.lblTituloAlertas);
            this.panelAlertas.Location = new System.Drawing.Point(20, 60);
            this.panelAlertas.Name = "panelAlertas";
            this.panelAlertas.Size = new System.Drawing.Size(350, 200);
            this.panelAlertas.TabIndex = 4;
            // 
            // lblAlertasStock
            // 
            this.lblAlertasStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlertasStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertasStock.Location = new System.Drawing.Point(0, 0);
            this.lblAlertasStock.Name = "lblAlertasStock";
            this.lblAlertasStock.Padding = new System.Windows.Forms.Padding(10);
            this.lblAlertasStock.Size = new System.Drawing.Size(100, 23);
            this.lblAlertasStock.TabIndex = 0;
            this.lblAlertasStock.Text = "Cargando...";
            // 
            // lblTituloAlertas
            // 
            this.lblTituloAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTituloAlertas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloAlertas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloAlertas.ForeColor = System.Drawing.Color.White;
            this.lblTituloAlertas.Location = new System.Drawing.Point(0, 0);
            this.lblTituloAlertas.Name = "lblTituloAlertas";
            this.lblTituloAlertas.Size = new System.Drawing.Size(100, 40);
            this.lblTituloAlertas.TabIndex = 1;
            this.lblTituloAlertas.Text = "Alertas de Stock Bajo";
            this.lblTituloAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(387, 318);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpDesde.TabIndex = 5;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(650, 318);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpHasta.TabIndex = 6;
            // 
            // lblDesde
            // 
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(328, 318);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(100, 23);
            this.lblDesde.TabIndex = 7;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHasta.Location = new System.Drawing.Point(593, 318);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(100, 23);
            this.lblHasta.TabIndex = 8;
            this.lblHasta.Text = "Hasta:";
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.Items.AddRange(new object[] {
            "Todos",
            "Entrada",
            "Venta",
            "Ajuste"});
            this.cmbMovimiento.Location = new System.Drawing.Point(962, 315);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(100, 24);
            this.cmbMovimiento.TabIndex = 9;
            // 
            // lblFiltroMovimiento
            // 
            this.lblFiltroMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFiltroMovimiento.Location = new System.Drawing.Point(856, 318);
            this.lblFiltroMovimiento.Name = "lblFiltroMovimiento";
            this.lblFiltroMovimiento.Size = new System.Drawing.Size(100, 23);
            this.lblFiltroMovimiento.TabIndex = 10;
            this.lblFiltroMovimiento.Text = "Movimiento:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(1085, 316);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 11;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // FormReportes
            // 
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes y Stock";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelAlertas.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
