namespace GestionDeVentas.Admin
{
    partial class FormGestionProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelPromociones = new System.Windows.Forms.Panel();
            this.lblPromociones = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTendencias = new System.Windows.Forms.Panel();
            this.lblTendencias = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAlertas = new System.Windows.Forms.Panel();
            this.lblAlertasStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.panelPromociones.SuspendLayout();
            this.panelHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panelTendencias.SuspendLayout();
            this.panelAlertas.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.btnCerrar);
            this.mainPanel.Controls.Add(this.panelPromociones);
            this.mainPanel.Controls.Add(this.panelHistorial);
            this.mainPanel.Controls.Add(this.panelTendencias);
            this.mainPanel.Controls.Add(this.panelAlertas);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(15);
            this.mainPanel.Size = new System.Drawing.Size(915, 625);
            this.mainPanel.TabIndex = 0;
            //this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(862, 18);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelPromociones
            // 
            this.panelPromociones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPromociones.BackColor = System.Drawing.Color.White;
            this.panelPromociones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPromociones.Controls.Add(this.lblPromociones);
            this.panelPromociones.Controls.Add(this.label4);
            this.panelPromociones.Location = new System.Drawing.Point(12, 450);
            this.panelPromociones.Name = "panelPromociones";
            this.panelPromociones.Size = new System.Drawing.Size(875, 150);
            this.panelPromociones.TabIndex = 5;
            // 
            // lblPromociones
            // 
            this.lblPromociones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPromociones.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPromociones.Location = new System.Drawing.Point(0, 30);
            this.lblPromociones.Name = "lblPromociones";
            this.lblPromociones.Padding = new System.Windows.Forms.Padding(10);
            this.lblPromociones.Size = new System.Drawing.Size(873, 118);
            this.lblPromociones.TabIndex = 1;
            this.lblPromociones.Text = "Cargando...";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(873, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gestión de Promociones";
            // 
            // panelHistorial
            // 
            this.panelHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorial.Controls.Add(this.dgvHistorial);
            this.panelHistorial.Controls.Add(this.label2);
            this.panelHistorial.Location = new System.Drawing.Point(12, 245);
            this.panelHistorial.Name = "panelHistorial";
            this.panelHistorial.Size = new System.Drawing.Size(875, 200);
            this.panelHistorial.TabIndex = 4;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.ProductoHistorial,
            this.Movimiento,
            this.CantidadHistorial});
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.GridColor = System.Drawing.Color.LightGray;
            this.dgvHistorial.Location = new System.Drawing.Point(0, 30);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowHeadersWidth = 51;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(873, 168);
            this.dgvHistorial.TabIndex = 1;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // ProductoHistorial
            // 
            this.ProductoHistorial.HeaderText = "Producto";
            this.ProductoHistorial.Name = "ProductoHistorial";
            this.ProductoHistorial.ReadOnly = true;
            // 
            // Movimiento
            // 
            this.Movimiento.HeaderText = "Movimiento";
            this.Movimiento.Name = "Movimiento";
            this.Movimiento.ReadOnly = true;
            // 
            // CantidadHistorial
            // 
            this.CantidadHistorial.HeaderText = "Cantidad";
            this.CantidadHistorial.Name = "CantidadHistorial";
            this.CantidadHistorial.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(873, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Historial de Movimientos";
            // 
            // panelTendencias
            // 
            this.panelTendencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTendencias.BackColor = System.Drawing.Color.White;
            this.panelTendencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTendencias.Controls.Add(this.lblTendencias);
            this.panelTendencias.Controls.Add(this.label3);
            this.panelTendencias.Location = new System.Drawing.Point(599, 61);
            this.panelTendencias.Name = "panelTendencias";
            this.panelTendencias.Size = new System.Drawing.Size(288, 150);
            this.panelTendencias.TabIndex = 5;
            // 
            // lblTendencias
            // 
            this.lblTendencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTendencias.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTendencias.Location = new System.Drawing.Point(0, 30);
            this.lblTendencias.Name = "lblTendencias";
            this.lblTendencias.Padding = new System.Windows.Forms.Padding(5);
            this.lblTendencias.Size = new System.Drawing.Size(286, 118);
            this.lblTendencias.TabIndex = 1;
            this.lblTendencias.Text = "Cargando...";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tendencias de Venta";
            // 
            // panelAlertas
            // 
            this.panelAlertas.BackColor = System.Drawing.Color.White;
            this.panelAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAlertas.Controls.Add(this.lblAlertasStock);
            this.panelAlertas.Controls.Add(this.label1);
            this.panelAlertas.Location = new System.Drawing.Point(12, 61);
            this.panelAlertas.Name = "panelAlertas";
            this.panelAlertas.Size = new System.Drawing.Size(275, 150);
            this.panelAlertas.TabIndex = 3;
            // 
            // lblAlertasStock
            // 
            this.lblAlertasStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlertasStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAlertasStock.Location = new System.Drawing.Point(0, 30);
            this.lblAlertasStock.Name = "lblAlertasStock";
            this.lblAlertasStock.Padding = new System.Windows.Forms.Padding(5);
            this.lblAlertasStock.Size = new System.Drawing.Size(273, 118);
            this.lblAlertasStock.TabIndex = 1;
            this.lblAlertasStock.Text = "Cargando...";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Firebrick;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alertas de Stock Bajo";
            // 
            // FormGestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 625);
            this.Controls.Add(this.mainPanel);
            this.Name = "FormGestionProductos";
            this.Text = "Dashboard y Análisis";
            this.mainPanel.ResumeLayout(false);
            this.panelPromociones.ResumeLayout(false);
            this.panelHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panelTendencias.ResumeLayout(false);
            this.panelAlertas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panelPromociones;
        private System.Windows.Forms.Label lblPromociones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadHistorial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTendencias;
        private System.Windows.Forms.Label lblTendencias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAlertas;
        private System.Windows.Forms.Label lblAlertasStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
    }
}