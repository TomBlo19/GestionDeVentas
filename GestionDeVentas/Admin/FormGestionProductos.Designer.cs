using System.Windows.Forms;
using System.Drawing;

namespace GestionDeVentas.Admin
{
    partial class FormGestionProductos
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Button btnCerrar;
        private Panel panelAlertas;
        private Label lblTituloAlertas;
        private Panel panelHistorial;
        private Label lblTituloHistorial;
        private DataGridView dgvHistorial;
        private Label lblTituloPrincipal;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label lblDesde;
        private Label lblHasta;
        private ComboBox cmbMovimiento;
        private Label lblFiltroMovimiento;
        private Button btnFiltrar;
        private ToolTip toolTip1;

        // 🔹 Panel Actividad Reciente e Inventario
        private Panel panelActividad;
        private Label lblTituloActividad;
        private Label lblUltimaActualizacion;
        private Label lblResumenDia;
        private Label lblMovimientosDia;
        private Label lblAltasNuevas;
        private Label lblModificaciones;
        private Label lblInactivaciones;
        private Label lblEstadoInventario;
        private Label lblActivos;
        private Label lblInactivos;
        private Label lblStockBajo;
        private Label lblSinStock;
        private Timer timerAnimacion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.panelAlertas = new System.Windows.Forms.Panel();
            this.lblTituloAlertas = new System.Windows.Forms.Label();
            this.panelActividad = new System.Windows.Forms.Panel();
            this.lblTituloActividad = new System.Windows.Forms.Label();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.lblResumenDia = new System.Windows.Forms.Label();
            this.lblMovimientosDia = new System.Windows.Forms.Label();
            this.lblAltasNuevas = new System.Windows.Forms.Label();
            this.lblModificaciones = new System.Windows.Forms.Label();
            this.lblInactivaciones = new System.Windows.Forms.Label();
            this.lblEstadoInventario = new System.Windows.Forms.Label();
            this.lblActivos = new System.Windows.Forms.Label();
            this.lblInactivos = new System.Windows.Forms.Label();
            this.lblStockBajo = new System.Windows.Forms.Label();
            this.lblSinStock = new System.Windows.Forms.Label();
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.cmbMovimiento = new System.Windows.Forms.ComboBox();
            this.lblFiltroMovimiento = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timerAnimacion = new System.Windows.Forms.Timer(this.components);
            this.mainPanel.SuspendLayout();
            this.panelAlertas.SuspendLayout();
            this.panelActividad.SuspendLayout();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.mainPanel.Controls.Add(this.btnCerrar);
            this.mainPanel.Controls.Add(this.lblTituloPrincipal);
            this.mainPanel.Controls.Add(this.panelAlertas);
            this.mainPanel.Controls.Add(this.panelActividad);
            this.mainPanel.Controls.Add(this.panelHistorial);
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
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(58)))), ((int)(((byte)(41)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(60)))), ((int)(((byte)(45)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(1135, 25);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "X";
            this.toolTip1.SetToolTip(this.btnCerrar, "Cerrar ventana");
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(58)))), ((int)(((byte)(41)))));
            this.lblTituloPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrincipal.Location = new System.Drawing.Point(20, 20);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1160, 50);
            this.lblTituloPrincipal.TabIndex = 1;
            this.lblTituloPrincipal.Text = "GESTIÓN Y ANÁLISIS DE PRODUCTOS";
            this.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAlertas
            // 
            this.panelAlertas.BackColor = System.Drawing.Color.White;
            this.panelAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlertas.Controls.Add(this.lblTituloAlertas);
            this.panelAlertas.Location = new System.Drawing.Point(20, 90);
            this.panelAlertas.Name = "panelAlertas";
            this.panelAlertas.Size = new System.Drawing.Size(350, 220);
            this.panelAlertas.TabIndex = 2;
            // 
            // lblTituloAlertas
            // 
            this.lblTituloAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(58)))), ((int)(((byte)(41)))));
            this.lblTituloAlertas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloAlertas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloAlertas.ForeColor = System.Drawing.Color.White;
            this.lblTituloAlertas.Location = new System.Drawing.Point(0, 0);
            this.lblTituloAlertas.Name = "lblTituloAlertas";
            this.lblTituloAlertas.Size = new System.Drawing.Size(348, 40);
            this.lblTituloAlertas.TabIndex = 0;
            this.lblTituloAlertas.Text = "Alertas de Stock Bajo";
            this.lblTituloAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelActividad
            // 
            this.panelActividad.BackColor = System.Drawing.Color.White;
            this.panelActividad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActividad.Controls.Add(this.lblTituloActividad);
            this.panelActividad.Controls.Add(this.lblUltimaActualizacion);
            this.panelActividad.Controls.Add(this.lblResumenDia);
            this.panelActividad.Controls.Add(this.lblMovimientosDia);
            this.panelActividad.Controls.Add(this.lblAltasNuevas);
            this.panelActividad.Controls.Add(this.lblModificaciones);
            this.panelActividad.Controls.Add(this.lblInactivaciones);
            this.panelActividad.Controls.Add(this.lblEstadoInventario);
            this.panelActividad.Controls.Add(this.lblActivos);
            this.panelActividad.Controls.Add(this.lblInactivos);
            this.panelActividad.Controls.Add(this.lblStockBajo);
            this.panelActividad.Controls.Add(this.lblSinStock);
            this.panelActividad.Location = new System.Drawing.Point(400, 90);
            this.panelActividad.Name = "panelActividad";
            this.panelActividad.Size = new System.Drawing.Size(770, 220);
            this.panelActividad.TabIndex = 3;
            // 
            // lblTituloActividad
            // 
            this.lblTituloActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(58)))), ((int)(((byte)(41)))));
            this.lblTituloActividad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloActividad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloActividad.ForeColor = System.Drawing.Color.White;
            this.lblTituloActividad.Location = new System.Drawing.Point(0, 0);
            this.lblTituloActividad.Name = "lblTituloActividad";
            this.lblTituloActividad.Size = new System.Drawing.Size(768, 40);
            this.lblTituloActividad.TabIndex = 0;
            this.lblTituloActividad.Text = "Actividad Reciente y Estado del Inventario";
            this.lblTituloActividad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblUltimaActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(20, 45);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(156, 20);
            this.lblUltimaActualizacion.TabIndex = 1;
            this.lblUltimaActualizacion.Text = "Última actualización: -";
            // 
            // lblResumenDia
            // 
            this.lblResumenDia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResumenDia.Location = new System.Drawing.Point(20, 70);
            this.lblResumenDia.Name = "lblResumenDia";
            this.lblResumenDia.Size = new System.Drawing.Size(195, 23);
            this.lblResumenDia.TabIndex = 2;
            this.lblResumenDia.Text = "Resumen del día:";
            // 
            // lblMovimientosDia
            // 
            this.lblMovimientosDia.Location = new System.Drawing.Point(40, 95);
            this.lblMovimientosDia.Name = "lblMovimientosDia";
            this.lblMovimientosDia.Size = new System.Drawing.Size(190, 20);
            this.lblMovimientosDia.TabIndex = 3;
            this.lblMovimientosDia.Text = "• Movimientos del día: 0";
            // 
            // lblAltasNuevas
            // 
            this.lblAltasNuevas.Location = new System.Drawing.Point(40, 115);
            this.lblAltasNuevas.Name = "lblAltasNuevas";
            this.lblAltasNuevas.Size = new System.Drawing.Size(190, 20);
            this.lblAltasNuevas.TabIndex = 4;
            this.lblAltasNuevas.Text = "• Altas nuevas: 0";
            // 
            // lblModificaciones
            // 
            this.lblModificaciones.Location = new System.Drawing.Point(40, 135);
            this.lblModificaciones.Name = "lblModificaciones";
            this.lblModificaciones.Size = new System.Drawing.Size(190, 23);
            this.lblModificaciones.TabIndex = 5;
            this.lblModificaciones.Text = "• Modificaciones: 0";
            // 
            // lblInactivaciones
            // 
            this.lblInactivaciones.Location = new System.Drawing.Point(40, 158);
            this.lblInactivaciones.Name = "lblInactivaciones";
            this.lblInactivaciones.Size = new System.Drawing.Size(164, 23);
            this.lblInactivaciones.TabIndex = 6;
            this.lblInactivaciones.Text = "• Inactivaciones: 0";
            // 
            // lblEstadoInventario
            // 
            this.lblEstadoInventario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoInventario.Location = new System.Drawing.Point(400, 70);
            this.lblEstadoInventario.Name = "lblEstadoInventario";
            this.lblEstadoInventario.Size = new System.Drawing.Size(228, 23);
            this.lblEstadoInventario.TabIndex = 7;
            this.lblEstadoInventario.Text = "Estado del inventario:";
            // 
            // lblActivos
            // 
            this.lblActivos.Location = new System.Drawing.Point(420, 95);
            this.lblActivos.Name = "lblActivos";
            this.lblActivos.Size = new System.Drawing.Size(295, 20);
            this.lblActivos.TabIndex = 8;
            this.lblActivos.Text = "• Productos activos: 0";
            // 
            // lblInactivos
            // 
            this.lblInactivos.Location = new System.Drawing.Point(420, 115);
            this.lblInactivos.Name = "lblInactivos";
            this.lblInactivos.Size = new System.Drawing.Size(259, 20);
            this.lblInactivos.TabIndex = 9;
            this.lblInactivos.Text = "• Productos inactivos: 0";
            this.lblInactivos.Click += new System.EventHandler(this.lblInactivos_Click);
            // 
            // lblStockBajo
            // 
            this.lblStockBajo.Location = new System.Drawing.Point(420, 135);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(158, 23);
            this.lblStockBajo.TabIndex = 10;
            this.lblStockBajo.Text = "• Con stock bajo: 0";
            // 
            // lblSinStock
            // 
            this.lblSinStock.Location = new System.Drawing.Point(420, 158);
            this.lblSinStock.Name = "lblSinStock";
            this.lblSinStock.Size = new System.Drawing.Size(100, 23);
            this.lblSinStock.TabIndex = 11;
            this.lblSinStock.Text = "• Sin stock: 0";
            // 
            // panelHistorial
            // 
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorial.Controls.Add(this.dgvHistorial);
            this.panelHistorial.Controls.Add(this.lblTituloHistorial);
            this.panelHistorial.Location = new System.Drawing.Point(20, 390);
            this.panelHistorial.Name = "panelHistorial";
            this.panelHistorial.Size = new System.Drawing.Size(1150, 330);
            this.panelHistorial.TabIndex = 4;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.ColumnHeadersHeight = 29;
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 40);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.Size = new System.Drawing.Size(1148, 288);
            this.dgvHistorial.TabIndex = 0;
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(58)))), ((int)(((byte)(41)))));
            this.lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.White;
            this.lblTituloHistorial.Location = new System.Drawing.Point(0, 0);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(1148, 40);
            this.lblTituloHistorial.TabIndex = 1;
            this.lblTituloHistorial.Text = "Historial de Movimientos";
            this.lblTituloHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpHasta.TabIndex = 0;
            // 
            // lblDesde
            // 
            this.lblDesde.Location = new System.Drawing.Point(0, 0);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(100, 23);
            this.lblDesde.TabIndex = 0;
            // 
            // lblHasta
            // 
            this.lblHasta.Location = new System.Drawing.Point(0, 0);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(100, 23);
            this.lblHasta.TabIndex = 0;
            // 
            // cmbMovimiento
            // 
            this.cmbMovimiento.Location = new System.Drawing.Point(0, 0);
            this.cmbMovimiento.Name = "cmbMovimiento";
            this.cmbMovimiento.Size = new System.Drawing.Size(121, 24);
            this.cmbMovimiento.TabIndex = 0;
            // 
            // lblFiltroMovimiento
            // 
            this.lblFiltroMovimiento.Location = new System.Drawing.Point(0, 0);
            this.lblFiltroMovimiento.Name = "lblFiltroMovimiento";
            this.lblFiltroMovimiento.Size = new System.Drawing.Size(100, 23);
            this.lblFiltroMovimiento.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(0, 0);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 0;
            // 
            // timerAnimacion
            // 
            this.timerAnimacion.Interval = 15;
            this.timerAnimacion.Tick += new System.EventHandler(this.timerAnimacion_Tick);
            // 
            // FormGestionProductos
            // 
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGestionProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.FormGestionProductos_Load);
            this.mainPanel.ResumeLayout(false);
            this.panelAlertas.ResumeLayout(false);
            this.panelActividad.ResumeLayout(false);
            this.panelActividad.PerformLayout();
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
