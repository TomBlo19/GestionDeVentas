namespace GestionDeVentas
{
    partial class BuscarProductoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Button btnSeleccionar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.tableLayoutPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.tableLayoutPanelFiltros.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Location = new System.Drawing.Point(16, 144);
            this.dataGridViewProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewProductos.MultiSelect = false;
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            this.dataGridViewProductos.RowHeadersVisible = false;
            this.dataGridViewProductos.RowHeadersWidth = 51;
            this.dataGridViewProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductos.Size = new System.Drawing.Size(1013, 315);
            this.dataGridViewProductos.TabIndex = 2;
            this.dataGridViewProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellDoubleClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Location = new System.Drawing.Point(829, 474);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(200, 49);
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.tableLayoutPanelFiltros);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Padding = new System.Windows.Forms.Padding(12, 11, 12, 0);
            this.pnlFiltros.Size = new System.Drawing.Size(1045, 101);
            this.pnlFiltros.TabIndex = 4;
            // 
            // tableLayoutPanelFiltros
            // 
            this.tableLayoutPanelFiltros.ColumnCount = 3;
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanelFiltros.Controls.Add(this.panelBusqueda, 0, 1);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblCategoria, 1, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblBuscar, 0, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbCategoria, 1, 1);
            this.tableLayoutPanelFiltros.Controls.Add(this.panelBotones, 2, 1);
            this.tableLayoutPanelFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFiltros.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanelFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            this.tableLayoutPanelFiltros.RowCount = 2;
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFiltros.Size = new System.Drawing.Size(1021, 90);
            this.tableLayoutPanelFiltros.TabIndex = 0;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.txtBusqueda);
            this.panelBusqueda.Controls.Add(this.cboBuscarPor);
            this.panelBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBusqueda.Location = new System.Drawing.Point(0, 25);
            this.panelBusqueda.Margin = new System.Windows.Forms.Padding(0);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(562, 65);
            this.panelBusqueda.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(165, 4);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(391, 29);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.filtros_Changed);
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarPor.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscarPor.FormattingEnabled = true;
            this.cboBuscarPor.Location = new System.Drawing.Point(4, 4);
            this.cboBuscarPor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Size = new System.Drawing.Size(152, 30);
            this.cboBuscarPor.TabIndex = 0;
            this.cboBuscarPor.SelectedIndexChanged += new System.EventHandler(this.filtros_Changed);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategoria.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCategoria.Location = new System.Drawing.Point(566, 0);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(295, 25);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuscar.Font = new System.Drawing.Font("Arial", 9F);
            this.lblBuscar.Location = new System.Drawing.Point(4, 0);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(554, 25);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por:";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Arial", 11.25F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(566, 29);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(295, 30);
            this.cmbCategoria.TabIndex = 6;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // panelBotones
            // 
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBotones.Location = new System.Drawing.Point(865, 25);
            this.panelBotones.Margin = new System.Windows.Forms.Padding(0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(156, 65);
            this.panelBotones.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(753, 105);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 34);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(881, 105);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 34);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // BuscarProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 530);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dataGridViewProductos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1061, 568);
            this.Name = "BuscarProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Producto";
            this.Load += new System.EventHandler(this.BuscarProductoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.tableLayoutPanelFiltros.ResumeLayout(false);
            this.tableLayoutPanelFiltros.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFiltros;
        private System.Windows.Forms.Label lblCategoria;
        // ✨ CAMBIO: Eliminada la declaración de 'lblMarca'
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        // ✨ CAMBIO: Eliminada la declaración de 'cmbMarca'
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiar;
    }
}