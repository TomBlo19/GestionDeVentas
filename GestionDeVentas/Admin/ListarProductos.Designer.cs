namespace GestionDeVentas.Admin
{
    partial class ListarProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblTalle = new System.Windows.Forms.Label();
            this.lblBuscarNombre = new System.Windows.Forms.Label();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.cmbTalle = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.topPanel.SuspendLayout();
            this.tableLayoutPanelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.topPanel.Controls.Add(this.tableLayoutPanelFiltros);
            this.topPanel.Controls.Add(this.lblTitulo);
            this.topPanel.Controls.Add(this.btnCerrar);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 80);
            this.topPanel.TabIndex = 0;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            // 
            // tableLayoutPanelFiltros
            // 
            this.tableLayoutPanelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelFiltros.ColumnCount = 6;
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelFiltros.Controls.Add(this.lblCategoria, 4, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblTalle, 2, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.lblBuscarNombre, 0, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.txtBuscarNombre, 1, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbTalle, 3, 0);
            this.tableLayoutPanelFiltros.Controls.Add(this.cmbCategoria, 5, 0);
            this.tableLayoutPanelFiltros.Location = new System.Drawing.Point(120, 40);
            this.tableLayoutPanelFiltros.Name = "tableLayoutPanelFiltros";
            this.tableLayoutPanelFiltros.RowCount = 1;
            this.tableLayoutPanelFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFiltros.Size = new System.Drawing.Size(630, 30);
            this.tableLayoutPanelFiltros.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategoria.Font = new System.Drawing.Font("Arial", 10F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategoria.Location = new System.Drawing.Point(409, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(74, 30);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTalle
            // 
            this.lblTalle.AutoSize = true;
            this.lblTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTalle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTalle.Location = new System.Drawing.Point(216, 0);
            this.lblTalle.Name = "lblTalle";
            this.lblTalle.Size = new System.Drawing.Size(44, 30);
            this.lblTalle.TabIndex = 3;
            this.lblTalle.Text = "Talle:";
            this.lblTalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBuscarNombre
            // 
            this.lblBuscarNombre.AutoSize = true;
            this.lblBuscarNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuscarNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.lblBuscarNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBuscarNombre.Location = new System.Drawing.Point(3, 0);
            this.lblBuscarNombre.Name = "lblBuscarNombre";
            this.lblBuscarNombre.Size = new System.Drawing.Size(64, 30);
            this.lblBuscarNombre.TabIndex = 1;
            this.lblBuscarNombre.Text = "Nombre:";
            this.lblBuscarNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuscarNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuscarNombre.Location = new System.Drawing.Point(73, 3);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(137, 23);
            this.txtBuscarNombre.TabIndex = 2;
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.txtBuscarNombre_TextChanged);
            // 
            // cmbTalle
            // 
            this.cmbTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTalle.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbTalle.FormattingEnabled = true;
            this.cmbTalle.Location = new System.Drawing.Point(266, 3);
            this.cmbTalle.Name = "cmbTalle";
            this.cmbTalle.Size = new System.Drawing.Size(137, 24);
            this.cmbTalle.TabIndex = 4;
            this.cmbTalle.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoria.Font = new System.Drawing.Font("Arial", 10F);
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(489, 3);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(138, 24);
            this.cmbCategoria.TabIndex = 6;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(238, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "LISTAR PRODUCTOS";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(760, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProductos.Location = new System.Drawing.Point(20, 100);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            this.dataGridViewProductos.RowHeadersVisible = false;
            this.dataGridViewProductos.RowHeadersWidth = 51;
            this.dataGridViewProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductos.Size = new System.Drawing.Size(760, 330);
            this.dataGridViewProductos.TabIndex = 1;
            this.dataGridViewProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProductos_CellContentClick);
            // 
            // ListarProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewProductos);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListarProductos";
            this.Text = "ListarProductos";
            this.Load += new System.EventHandler(this.ListarProductos_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.tableLayoutPanelFiltros.ResumeLayout(false);
            this.tableLayoutPanelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFiltros;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblTalle;
        private System.Windows.Forms.Label lblBuscarNombre;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.ComboBox cmbTalle;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
    }
}