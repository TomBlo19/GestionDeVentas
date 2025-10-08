namespace GestionDeVentas.Admin
{
    partial class FormRegistrarProducto
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Talle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formPanel = new System.Windows.Forms.Panel();
            this.lblFiltroCategoria = new System.Windows.Forms.Label();
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.txtFiltroBusqueda = new System.Windows.Forms.TextBox();
            this.lblFiltroBusqueda = new System.Windows.Forms.Label();
            this.btnCancelarEdicion = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRegistrarProducto = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblErrorCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblErrorDescripcion = new System.Windows.Forms.Label();
            this.lblTalle = new System.Windows.Forms.Label();
            this.cmbTalle = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblErrorTalle = new System.Windows.Forms.Label();
            this.lblErrorCategoria = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblErrorColor = new System.Windows.Forms.Label();
            this.lblErrorMarca = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblErrorPrecio = new System.Windows.Forms.Label();
            this.lblErrorStock = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblErrorProveedor = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.formPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.dgvProductos);
            this.mainPanel.Controls.Add(this.formPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.mainPanel.Size = new System.Drawing.Size(900, 609);
            this.mainPanel.TabIndex = 0;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Talle,
            this.Color,
            this.Precio,
            this.Stock,
            this.Codigo,
            this.Estado,
            this.Proveedor});
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.LightGray;
            this.dgvProductos.Location = new System.Drawing.Point(15, 504);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(870, 88);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Talle
            // 
            this.Talle.HeaderText = "Talle";
            this.Talle.MinimumWidth = 6;
            this.Talle.Name = "Talle";
            this.Talle.ReadOnly = true;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.MinimumWidth = 6;
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.MinimumWidth = 6;
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.MinimumWidth = 6;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // formPanel
            // 
            this.formPanel.AutoScroll = true;
            this.formPanel.Controls.Add(this.lblFiltroCategoria);
            this.formPanel.Controls.Add(this.cmbFiltroCategoria);
            this.formPanel.Controls.Add(this.cmbFiltroEstado);
            this.formPanel.Controls.Add(this.lblFiltroEstado);
            this.formPanel.Controls.Add(this.txtFiltroBusqueda);
            this.formPanel.Controls.Add(this.lblFiltroBusqueda);
            this.formPanel.Controls.Add(this.btnCancelarEdicion);
            this.formPanel.Controls.Add(this.btnCerrar);
            this.formPanel.Controls.Add(this.lblTitulo);
            this.formPanel.Controls.Add(this.btnRegistrarProducto);
            this.formPanel.Controls.Add(this.btnLimpiar);
            this.formPanel.Controls.Add(this.btnDesactivar);
            this.formPanel.Controls.Add(this.tableLayoutPanel);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formPanel.Location = new System.Drawing.Point(15, 16);
            this.formPanel.Margin = new System.Windows.Forms.Padding(2);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(870, 471);
            this.formPanel.TabIndex = 0;
            // 
            // lblFiltroCategoria
            // 
            this.lblFiltroCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltroCategoria.AutoSize = true;
            this.lblFiltroCategoria.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCategoria.Location = new System.Drawing.Point(531, 452);
            this.lblFiltroCategoria.Name = "lblFiltroCategoria";
            this.lblFiltroCategoria.Size = new System.Drawing.Size(63, 15);
            this.lblFiltroCategoria.TabIndex = 9;
            this.lblFiltroCategoria.Text = "Categoría:";
            // 
            // cmbFiltroCategoria
            // 
            this.cmbFiltroCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.FormattingEnabled = true;
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(602, 449);
            this.cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            this.cmbFiltroCategoria.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltroCategoria.TabIndex = 10;
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(784, 449);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(83, 21);
            this.cmbFiltroEstado.TabIndex = 8;
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroEstado.Location = new System.Drawing.Point(732, 452);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(46, 15);
            this.lblFiltroEstado.TabIndex = 7;
            this.lblFiltroEstado.Text = "Estado:";
            // 
            // txtFiltroBusqueda
            // 
            this.txtFiltroBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroBusqueda.Location = new System.Drawing.Point(121, 449);
            this.txtFiltroBusqueda.Name = "txtFiltroBusqueda";
            this.txtFiltroBusqueda.Size = new System.Drawing.Size(404, 20);
            this.txtFiltroBusqueda.TabIndex = 6;
            // 
            // lblFiltroBusqueda
            // 
            this.lblFiltroBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFiltroBusqueda.AutoSize = true;
            this.lblFiltroBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroBusqueda.Location = new System.Drawing.Point(8, 452);
            this.lblFiltroBusqueda.Name = "lblFiltroBusqueda";
            this.lblFiltroBusqueda.Size = new System.Drawing.Size(107, 15);
            this.lblFiltroBusqueda.TabIndex = 5;
            this.lblFiltroBusqueda.Text = "Buscar producto...";
            // 
            // btnCancelarEdicion
            // 
            this.btnCancelarEdicion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelarEdicion.BackColor = System.Drawing.Color.Gray;
            this.btnCancelarEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarEdicion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarEdicion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarEdicion.Location = new System.Drawing.Point(448, 383);
            this.btnCancelarEdicion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarEdicion.Name = "btnCancelarEdicion";
            this.btnCancelarEdicion.Size = new System.Drawing.Size(188, 37);
            this.btnCancelarEdicion.TabIndex = 4;
            this.btnCancelarEdicion.Text = "Cancelar";
            this.btnCancelarEdicion.UseVisualStyleBackColor = false;
            this.btnCancelarEdicion.Click += new System.EventHandler(this.btnCancelarEdicion_Click_2);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Location = new System.Drawing.Point(840, 8);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(22, 24);
            this.btnCerrar.TabIndex = 999;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(870, 49);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Registrar nuevo producto";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRegistrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarProducto.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProducto.Location = new System.Drawing.Point(29, 382);
            this.btnRegistrarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.Size = new System.Drawing.Size(188, 37);
            this.btnRegistrarProducto.TabIndex = 1;
            this.btnRegistrarProducto.Text = "Registrar Producto";
            this.btnRegistrarProducto.UseVisualStyleBackColor = false;
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(243, 382);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(188, 37);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_2);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDesactivar.BackColor = System.Drawing.Color.Firebrick;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(663, 383);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(188, 37);
            this.btnDesactivar.TabIndex = 3;
            this.btnDesactivar.Text = "Desactivar Producto";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Visible = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel.Controls.Add(this.lblNombreProducto, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtNombreProducto, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblCodigo, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.txtCodigo, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.lblErrorNombre, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblErrorCodigo, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.lblDescripcion, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.txtDescripcion, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblErrorDescripcion, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.lblTalle, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.cmbTalle, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.lblCategoria, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.cmbCategoria, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.lblErrorTalle, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.lblErrorCategoria, 3, 5);
            this.tableLayoutPanel.Controls.Add(this.lblColor, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.txtColor, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.lblMarca, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.txtMarca, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.lblErrorColor, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.lblErrorMarca, 3, 7);
            this.tableLayoutPanel.Controls.Add(this.lblPrecio, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.txtPrecio, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.lblStock, 2, 8);
            this.tableLayoutPanel.Controls.Add(this.txtStock, 3, 8);
            this.tableLayoutPanel.Controls.Add(this.lblErrorPrecio, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.lblErrorStock, 3, 9);
            this.tableLayoutPanel.Controls.Add(this.lblProveedor, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.cmbProveedor, 1, 10);
            this.tableLayoutPanel.Controls.Add(this.lblErrorProveedor, 1, 11);
            this.tableLayoutPanel.Location = new System.Drawing.Point(15, 65);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel.RowCount = 12;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(816, 293);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNombreProducto.Location = new System.Drawing.Point(10, 8);
            this.lblNombreProducto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(65, 19);
            this.lblNombreProducto.TabIndex = 0;
            this.lblNombreProducto.Text = "Nombre";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombreProducto.Location = new System.Drawing.Point(130, 10);
            this.txtNombreProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(276, 25);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(410, 8);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(58, 19);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(530, 10);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(276, 25);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorNombre.Location = new System.Drawing.Point(130, 37);
            this.lblErrorNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(10, 13);
            this.lblErrorNombre.TabIndex = 4;
            this.lblErrorNombre.Text = " ";
            // 
            // lblErrorCodigo
            // 
            this.lblErrorCodigo.AutoSize = true;
            this.lblErrorCodigo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorCodigo.Location = new System.Drawing.Point(530, 37);
            this.lblErrorCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorCodigo.Name = "lblErrorCodigo";
            this.lblErrorCodigo.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCodigo.TabIndex = 5;
            this.lblErrorCodigo.Text = " ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(10, 50);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 19);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.tableLayoutPanel.SetColumnSpan(this.txtDescripcion, 3);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(130, 52);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.MinimumSize = new System.Drawing.Size(4, 50);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(676, 50);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblErrorDescripcion
            // 
            this.lblErrorDescripcion.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lblErrorDescripcion, 3);
            this.lblErrorDescripcion.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorDescripcion.Location = new System.Drawing.Point(130, 104);
            this.lblErrorDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorDescripcion.Name = "lblErrorDescripcion";
            this.lblErrorDescripcion.Size = new System.Drawing.Size(10, 13);
            this.lblErrorDescripcion.TabIndex = 8;
            this.lblErrorDescripcion.Text = " ";
            // 
            // lblTalle
            // 
            this.lblTalle.AutoSize = true;
            this.lblTalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTalle.Location = new System.Drawing.Point(10, 117);
            this.lblTalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTalle.Name = "lblTalle";
            this.lblTalle.Size = new System.Drawing.Size(40, 19);
            this.lblTalle.TabIndex = 9;
            this.lblTalle.Text = "Talle";
            // 
            // cmbTalle
            // 
            this.cmbTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTalle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTalle.Location = new System.Drawing.Point(130, 119);
            this.cmbTalle.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTalle.Name = "cmbTalle";
            this.cmbTalle.Size = new System.Drawing.Size(276, 25);
            this.cmbTalle.TabIndex = 10;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.Location = new System.Drawing.Point(410, 117);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(75, 19);
            this.lblCategoria.TabIndex = 11;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategoria.Location = new System.Drawing.Point(530, 119);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(276, 25);
            this.cmbCategoria.TabIndex = 12;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // lblErrorTalle
            // 
            this.lblErrorTalle.AutoSize = true;
            this.lblErrorTalle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorTalle.Location = new System.Drawing.Point(130, 146);
            this.lblErrorTalle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorTalle.Name = "lblErrorTalle";
            this.lblErrorTalle.Size = new System.Drawing.Size(10, 13);
            this.lblErrorTalle.TabIndex = 13;
            this.lblErrorTalle.Text = " ";
            // 
            // lblErrorCategoria
            // 
            this.lblErrorCategoria.AutoSize = true;
            this.lblErrorCategoria.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorCategoria.Location = new System.Drawing.Point(530, 146);
            this.lblErrorCategoria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorCategoria.Name = "lblErrorCategoria";
            this.lblErrorCategoria.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCategoria.TabIndex = 14;
            this.lblErrorCategoria.Text = " ";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblColor.Location = new System.Drawing.Point(10, 159);
            this.lblColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(46, 19);
            this.lblColor.TabIndex = 15;
            this.lblColor.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtColor.Location = new System.Drawing.Point(130, 161);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(276, 25);
            this.txtColor.TabIndex = 16;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarca.Location = new System.Drawing.Point(410, 159);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(51, 19);
            this.lblMarca.TabIndex = 17;
            this.lblMarca.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMarca.Location = new System.Drawing.Point(530, 161);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(276, 25);
            this.txtMarca.TabIndex = 18;
            // 
            // lblErrorColor
            // 
            this.lblErrorColor.AutoSize = true;
            this.lblErrorColor.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorColor.Location = new System.Drawing.Point(130, 188);
            this.lblErrorColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorColor.Name = "lblErrorColor";
            this.lblErrorColor.Size = new System.Drawing.Size(10, 13);
            this.lblErrorColor.TabIndex = 19;
            this.lblErrorColor.Text = " ";
            // 
            // lblErrorMarca
            // 
            this.lblErrorMarca.AutoSize = true;
            this.lblErrorMarca.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorMarca.Location = new System.Drawing.Point(530, 188);
            this.lblErrorMarca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorMarca.Name = "lblErrorMarca";
            this.lblErrorMarca.Size = new System.Drawing.Size(10, 13);
            this.lblErrorMarca.TabIndex = 20;
            this.lblErrorMarca.Text = " ";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.Location = new System.Drawing.Point(10, 201);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(52, 19);
            this.lblPrecio.TabIndex = 21;
            this.lblPrecio.Text = "Precio";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(130, 203);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(276, 25);
            this.txtPrecio.TabIndex = 22;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(410, 201);
            this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(46, 19);
            this.lblStock.TabIndex = 23;
            this.lblStock.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStock.Location = new System.Drawing.Point(530, 203);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(276, 25);
            this.txtStock.TabIndex = 24;
            // 
            // lblErrorPrecio
            // 
            this.lblErrorPrecio.AutoSize = true;
            this.lblErrorPrecio.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorPrecio.Location = new System.Drawing.Point(130, 230);
            this.lblErrorPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorPrecio.Name = "lblErrorPrecio";
            this.lblErrorPrecio.Size = new System.Drawing.Size(10, 13);
            this.lblErrorPrecio.TabIndex = 25;
            this.lblErrorPrecio.Text = " ";
            // 
            // lblErrorStock
            // 
            this.lblErrorStock.AutoSize = true;
            this.lblErrorStock.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorStock.Location = new System.Drawing.Point(530, 230);
            this.lblErrorStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorStock.Name = "lblErrorStock";
            this.lblErrorStock.Size = new System.Drawing.Size(10, 13);
            this.lblErrorStock.TabIndex = 26;
            this.lblErrorStock.Text = " ";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProveedor.Location = new System.Drawing.Point(10, 243);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(81, 19);
            this.lblProveedor.TabIndex = 27;
            this.lblProveedor.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProveedor.Location = new System.Drawing.Point(130, 245);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(276, 25);
            this.cmbProveedor.TabIndex = 28;
            // 
            // lblErrorProveedor
            // 
            this.lblErrorProveedor.AutoSize = true;
            this.lblErrorProveedor.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorProveedor.Location = new System.Drawing.Point(130, 272);
            this.lblErrorProveedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorProveedor.Name = "lblErrorProveedor";
            this.lblErrorProveedor.Size = new System.Drawing.Size(10, 13);
            this.lblErrorProveedor.TabIndex = 29;
            this.lblErrorProveedor.Text = " ";
            // 
            // FormRegistrarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 609);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRegistrarProducto";
            this.Text = "Registrar Producto";
            this.Load += new System.EventHandler(this.FormRegistrarProducto_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRegistrarProducto;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelarEdicion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblErrorDescripcion;
        private System.Windows.Forms.Label lblTalle;
        private System.Windows.Forms.ComboBox cmbTalle;
        private System.Windows.Forms.Label lblErrorTalle;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblErrorColor;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblErrorPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblErrorStock;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblErrorCategoria;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblErrorMarca;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblErrorCodigo;
        private System.Windows.Forms.TextBox txtFiltroBusqueda;
        private System.Windows.Forms.Label lblFiltroBusqueda;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Talle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor; // <-- CAMBIADO DE TextBox

        private System.Windows.Forms.Label lblErrorProveedor;
    }
}