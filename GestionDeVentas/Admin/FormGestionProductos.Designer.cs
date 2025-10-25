using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionDeVentas.Admin
{
    partial class FormGestionProductos
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
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            this.mainPanel = new Panel();
            this.btnCerrar = new Button();
            this.chartVentas = new Chart();
            this.lblTituloGrafico = new Label();
            this.panelHistorial = new Panel();
            this.dgvHistorial = new DataGridView();
            this.lblTituloHistorial = new Label();
            this.panelAlertas = new Panel();
            this.lblAlertasStock = new Label();
            this.lblTituloAlertas = new Label();
            this.dtpDesde = new DateTimePicker();
            this.dtpHasta = new DateTimePicker();
            this.lblDesde = new Label();
            this.lblHasta = new Label();
            this.cmbMovimiento = new ComboBox();
            this.lblFiltroMovimiento = new Label();
            this.btnFiltrar = new Button();

            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelAlertas.SuspendLayout();
            this.SuspendLayout();

            // mainPanel
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(245, 240, 230);
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Padding = new Padding(20);
            this.mainPanel.Controls.AddRange(new Control[] {
                this.btnCerrar, this.chartVentas, this.lblTituloGrafico,
                this.panelAlertas, this.dtpDesde, this.dtpHasta, this.lblDesde, this.lblHasta,
                this.cmbMovimiento, this.lblFiltroMovimiento, this.btnFiltrar, this.panelHistorial
            });

            // btnCerrar
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Size = new System.Drawing.Size(35, 30);
            this.btnCerrar.Location = new System.Drawing.Point(1140, 15);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // chartVentas
            this.chartVentas.BackColor = System.Drawing.Color.FromArgb(245, 240, 230);
            chartArea1.BackColor = System.Drawing.Color.FromArgb(245, 240, 230);
            chartArea1.Name = "Main";
            this.chartVentas.ChartAreas.Add(chartArea1);
            this.chartVentas.Location = new System.Drawing.Point(400, 60);
            this.chartVentas.Size = new System.Drawing.Size(770, 250);

            // lblTituloGrafico
            this.lblTituloGrafico.Text = "Productos más vendidos";
            this.lblTituloGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrafico.ForeColor = System.Drawing.Color.FromArgb(64, 32, 0);
            this.lblTituloGrafico.Location = new System.Drawing.Point(400, 30);
            this.lblTituloGrafico.Size = new System.Drawing.Size(400, 30);

            // panelAlertas
            this.panelAlertas.BackColor = System.Drawing.Color.White;
            this.panelAlertas.BorderStyle = BorderStyle.FixedSingle;
            this.panelAlertas.Controls.Add(this.lblAlertasStock);
            this.panelAlertas.Controls.Add(this.lblTituloAlertas);
            this.panelAlertas.Location = new System.Drawing.Point(20, 60);
            this.panelAlertas.Size = new System.Drawing.Size(350, 200);

            this.lblTituloAlertas.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
            this.lblTituloAlertas.Dock = DockStyle.Top;
            this.lblTituloAlertas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloAlertas.ForeColor = System.Drawing.Color.White;
            this.lblTituloAlertas.Height = 40;
            this.lblTituloAlertas.Text = "Alertas de Stock Bajo";
            this.lblTituloAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblAlertasStock.Dock = DockStyle.Fill;
            this.lblAlertasStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertasStock.Text = "Cargando...";
            this.lblAlertasStock.Padding = new Padding(10);

            // panelHistorial
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.BorderStyle = BorderStyle.FixedSingle;
            this.panelHistorial.Controls.Add(this.dgvHistorial);
            this.panelHistorial.Controls.Add(this.lblTituloHistorial);
            this.panelHistorial.Location = new System.Drawing.Point(20, 360);
            this.panelHistorial.Size = new System.Drawing.Size(1150, 360);

            this.lblTituloHistorial.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
            this.lblTituloHistorial.Dock = DockStyle.Top;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.White;
            this.lblTituloHistorial.Height = 40;
            this.lblTituloHistorial.Text = "Historial de Movimientos";
            this.lblTituloHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.dgvHistorial.Dock = DockStyle.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Filtros
            this.lblDesde.Text = "Desde:";
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.Location = new System.Drawing.Point(328, 318);

            this.dtpDesde.Format = DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(387, 318);

            this.lblHasta.Text = "Hasta:";
            this.lblHasta.Font = this.lblDesde.Font;
            this.lblHasta.Location = new System.Drawing.Point(593, 318);

            this.dtpHasta.Format = DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(650, 318);

            this.lblFiltroMovimiento.Text = "Movimiento:";
            this.lblFiltroMovimiento.Font = this.lblDesde.Font;
            this.lblFiltroMovimiento.Location = new System.Drawing.Point(856, 318);

            this.cmbMovimiento.Location = new System.Drawing.Point(962, 315);
            this.cmbMovimiento.Width = 100;
            this.cmbMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(128, 64, 0);
            this.btnFiltrar.FlatStyle = FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(1085, 316);
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // FormGestionProductos
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.FormGestionProductos_Load);

            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelAlertas.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
