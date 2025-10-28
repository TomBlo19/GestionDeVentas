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
        private Label lblTituloPrincipal;
        private ToolTip toolTip1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloGrafico = new System.Windows.Forms.Label();
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
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.panelAlertas.SuspendLayout();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            // --- PANEL PRINCIPAL ---
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(248, 244, 239);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(1200, 750);
            this.mainPanel.Name = "mainPanel";

            // --- BOTÓN CERRAR ---
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1135, 25);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(160, 60, 45);
            this.toolTip1.SetToolTip(this.btnCerrar, "Cerrar ventana");
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // --- TÍTULO PRINCIPAL ---
            this.lblTituloPrincipal.BackColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.lblTituloPrincipal.Dock = DockStyle.Top;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrincipal.Location = new System.Drawing.Point(20, 20);
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1160, 50);
            this.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTituloPrincipal.Text = "GESTIÓN Y ANÁLISIS DE PRODUCTOS";

            // --- GRÁFICO ---
            this.chartVentas.BackColor = System.Drawing.Color.FromArgb(248, 244, 239);
            chartArea1.BackColor = System.Drawing.Color.FromArgb(248, 244, 239);
            chartArea1.Name = "Main";
            this.chartVentas.ChartAreas.Add(chartArea1);
            this.chartVentas.Location = new System.Drawing.Point(400, 90);
            this.chartVentas.Size = new System.Drawing.Size(770, 220);
            this.chartVentas.Name = "chartVentas";

            // --- TÍTULO GRÁFICO ---
            this.lblTituloGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloGrafico.ForeColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.lblTituloGrafico.Location = new System.Drawing.Point(480, 65);
            this.lblTituloGrafico.Size = new System.Drawing.Size(250, 31);
            this.lblTituloGrafico.Text = "Productos más vendidos";

            // --- PANEL ALERTAS ---
            this.panelAlertas.BackColor = System.Drawing.Color.White;
            this.panelAlertas.BorderStyle = BorderStyle.FixedSingle;
            this.panelAlertas.Controls.Add(this.lblAlertasStock);
            this.panelAlertas.Controls.Add(this.lblTituloAlertas);
            this.panelAlertas.Location = new System.Drawing.Point(20, 90);
            this.panelAlertas.Size = new System.Drawing.Size(350, 220);
            this.panelAlertas.Name = "panelAlertas";

            // --- TÍTULO ALERTAS ---
            this.lblTituloAlertas.BackColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.lblTituloAlertas.Dock = DockStyle.Top;
            this.lblTituloAlertas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloAlertas.ForeColor = System.Drawing.Color.White;
            this.lblTituloAlertas.Size = new System.Drawing.Size(348, 40);
            this.lblTituloAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTituloAlertas.Text = "Alertas de Stock Bajo";

            // --- CONTENIDO ALERTAS ---
            this.lblAlertasStock.Dock = DockStyle.Fill;
            this.lblAlertasStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertasStock.Padding = new Padding(10);
            this.lblAlertasStock.Text = "Cargando...";

            // --- FILTROS ---
            this.dtpDesde.Format = DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(387, 348);
            this.dtpHasta.Format = DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(650, 348);
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.lblDesde.Location = new System.Drawing.Point(328, 348);
            this.lblDesde.Text = "Desde:";
            this.lblHasta.Font = this.lblDesde.Font;
            this.lblHasta.ForeColor = this.lblDesde.ForeColor;
            this.lblHasta.Location = new System.Drawing.Point(593, 348);
            this.lblHasta.Text = "Hasta:";
            this.cmbMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMovimiento.Location = new System.Drawing.Point(962, 345);
            this.lblFiltroMovimiento.Font = this.lblDesde.Font;
            this.lblFiltroMovimiento.ForeColor = this.lblDesde.ForeColor;
            this.lblFiltroMovimiento.Location = new System.Drawing.Point(856, 348);
            this.lblFiltroMovimiento.Text = "Movimiento:";
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.btnFiltrar.FlatStyle = FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(1085, 346);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);

            // --- PANEL HISTORIAL ---
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.BorderStyle = BorderStyle.FixedSingle;
            this.panelHistorial.Controls.Add(this.dgvHistorial);
            this.panelHistorial.Controls.Add(this.lblTituloHistorial);
            this.panelHistorial.Location = new System.Drawing.Point(20, 390);
            this.panelHistorial.Size = new System.Drawing.Size(1150, 330);
            this.panelHistorial.Name = "panelHistorial";

            // --- TÍTULO HISTORIAL ---
            this.lblTituloHistorial.BackColor = System.Drawing.Color.FromArgb(91, 58, 41);
            this.lblTituloHistorial.Dock = DockStyle.Top;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.White;
            this.lblTituloHistorial.Size = new System.Drawing.Size(1148, 40);
            this.lblTituloHistorial.Text = "Historial de Movimientos";
            this.lblTituloHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // --- TABLA HISTORIAL ---
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.Dock = DockStyle.Fill;
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;

            // --- ENSAMBLADO FINAL ---
            this.mainPanel.Controls.Add(this.btnCerrar);
            this.mainPanel.Controls.Add(this.lblTituloPrincipal);
            this.mainPanel.Controls.Add(this.chartVentas);
            this.mainPanel.Controls.Add(this.lblTituloGrafico);
            this.mainPanel.Controls.Add(this.panelAlertas);
            this.mainPanel.Controls.Add(this.dtpDesde);
            this.mainPanel.Controls.Add(this.dtpHasta);
            this.mainPanel.Controls.Add(this.lblDesde);
            this.mainPanel.Controls.Add(this.lblHasta);
            this.mainPanel.Controls.Add(this.cmbMovimiento);
            this.mainPanel.Controls.Add(this.lblFiltroMovimiento);
            this.mainPanel.Controls.Add(this.btnFiltrar);
            this.mainPanel.Controls.Add(this.panelHistorial);

            // --- FORMULARIO ---
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.FormGestionProductos_Load);

            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.panelAlertas.ResumeLayout(false);
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
