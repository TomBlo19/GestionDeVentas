namespace GestionDeVentas.Admin
{
    partial class FormRegistrarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.formPanel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRegistrarProducto = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblErrorDescripcion = new System.Windows.Forms.Label();
            this.lblTalle = new System.Windows.Forms.Label();
            this.cmbTalle = new System.Windows.Forms.ComboBox();
            this.lblErrorTalle = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.lblErrorColor = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblErrorPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblErrorStock = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblErrorCategoria = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblErrorMarca = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblErrorCodigo = new System.Windows.Forms.Label();
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
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(900, 749);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.LightGray;
            this.dgvProductos.Location = new System.Drawing.Point(20, 512);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(860, 217);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // formPanel
            // 
            this.formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formPanel.Controls.Add(this.lblTitulo);
            this.formPanel.Controls.Add(this.btnRegistrarProducto);
            this.formPanel.Controls.Add(this.tableLayoutPanel);
            this.formPanel.Location = new System.Drawing.Point(20, 20);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(860, 486);
            this.formPanel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(860, 50);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Registrar nuevo producto";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRegistrarProducto
            // 
            this.btnRegistrarProducto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRegistrarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRegistrarProducto.FlatAppearance.BorderSize = 0;
            this.btnRegistrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProducto.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProducto.Location = new System.Drawing.Point(293, 438);
            this.btnRegistrarProducto.Name = "btnRegistrarProducto";
            this.btnRegistrarProducto.Size = new System.Drawing.Size(300, 45);
            this.btnRegistrarProducto.TabIndex = 1;
            this.btnRegistrarProducto.Text = "Registrar Producto";
            this.btnRegistrarProducto.UseVisualStyleBackColor = false;
            this.btnRegistrarProducto.Click += new System.EventHandler(this.btnRegistrarProducto_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.lblNombreProducto, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.txtNombreProducto, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblErrorNombre, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lblDescripcion, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblErrorDescripcion, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblTalle, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.cmbTalle, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.lblErrorTalle, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.lblColor, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.txtColor, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.lblErrorColor, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.lblPrecio, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.txtPrecio, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.lblErrorPrecio, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.lblStock, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.txtStock, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.lblErrorStock, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.lblCategoria, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.cmbCategoria, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.lblErrorCategoria, 0, 11);
            this.tableLayoutPanel.Controls.Add(this.lblMarca, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.txtMarca, 1, 10);
            this.tableLayoutPanel.Controls.Add(this.lblErrorMarca, 1, 11);
            this.tableLayoutPanel.Controls.Add(this.lblCodigo, 0, 12);
            this.tableLayoutPanel.Controls.Add(this.txtCodigo, 0, 13);
            this.tableLayoutPanel.Controls.Add(this.lblErrorCodigo, 0, 14);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel.RowCount = 15;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(854, 372);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.AutoSize = true;
            this.lblNombreProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNombreProducto.Location = new System.Drawing.Point(13, 10);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(411, 25);
            this.lblNombreProducto.TabIndex = 0;
            this.lblNombreProducto.Text = "Nombre del producto";
            this.lblNombreProducto.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombreProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProducto.Location = new System.Drawing.Point(13, 38);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(411, 25);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorNombre.Location = new System.Drawing.Point(13, 65);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(411, 18);
            this.lblErrorNombre.TabIndex = 2;
            this.lblErrorNombre.Text = " ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescripcion.Location = new System.Drawing.Point(430, 10);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(411, 25);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(430, 38);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(411, 24);
            this.txtDescripcion.TabIndex = 4;
            // 
            // lblErrorDescripcion
            // 
            this.lblErrorDescripcion.AutoSize = true;
            this.lblErrorDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDescripcion.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorDescripcion.Location = new System.Drawing.Point(430, 65);
            this.lblErrorDescripcion.Name = "lblErrorDescripcion";
            this.lblErrorDescripcion.Size = new System.Drawing.Size(411, 18);
            this.lblErrorDescripcion.TabIndex = 5;
            this.lblErrorDescripcion.Text = " ";
            // 
            // lblTalle
            // 
            this.lblTalle.AutoSize = true;
            this.lblTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTalle.Location = new System.Drawing.Point(13, 83);
            this.lblTalle.Name = "lblTalle";
            this.lblTalle.Size = new System.Drawing.Size(411, 25);
            this.lblTalle.TabIndex = 6;
            this.lblTalle.Text = "Talle";
            this.lblTalle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbTalle
            // 
            this.cmbTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTalle.FormattingEnabled = true;
            this.cmbTalle.Location = new System.Drawing.Point(13, 111);
            this.cmbTalle.Name = "cmbTalle";
            this.cmbTalle.Size = new System.Drawing.Size(411, 25);
            this.cmbTalle.TabIndex = 7;
            this.cmbTalle.Text = "Seleccione un talle";
            // 
            // lblErrorTalle
            // 
            this.lblErrorTalle.AutoSize = true;
            this.lblErrorTalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorTalle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorTalle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorTalle.Location = new System.Drawing.Point(13, 138);
            this.lblErrorTalle.Name = "lblErrorTalle";
            this.lblErrorTalle.Size = new System.Drawing.Size(411, 18);
            this.lblErrorTalle.TabIndex = 8;
            this.lblErrorTalle.Text = " ";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblColor.Location = new System.Drawing.Point(430, 83);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(411, 25);
            this.lblColor.TabIndex = 9;
            this.lblColor.Text = "Color";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtColor
            // 
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(430, 111);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(411, 25);
            this.txtColor.TabIndex = 10;
            // 
            // lblErrorColor
            // 
            this.lblErrorColor.AutoSize = true;
            this.lblErrorColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorColor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorColor.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorColor.Location = new System.Drawing.Point(430, 138);
            this.lblErrorColor.Name = "lblErrorColor";
            this.lblErrorColor.Size = new System.Drawing.Size(411, 18);
            this.lblErrorColor.TabIndex = 11;
            this.lblErrorColor.Text = " ";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrecio.Location = new System.Drawing.Point(13, 156);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(411, 26);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(13, 185);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(411, 25);
            this.txtPrecio.TabIndex = 13;
            // 
            // lblErrorPrecio
            // 
            this.lblErrorPrecio.AutoSize = true;
            this.lblErrorPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorPrecio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorPrecio.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorPrecio.Location = new System.Drawing.Point(13, 211);
            this.lblErrorPrecio.Name = "lblErrorPrecio";
            this.lblErrorPrecio.Size = new System.Drawing.Size(411, 18);
            this.lblErrorPrecio.TabIndex = 14;
            this.lblErrorPrecio.Text = " ";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStock.Location = new System.Drawing.Point(430, 156);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(411, 26);
            this.lblStock.TabIndex = 15;
            this.lblStock.Text = "Stock";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(430, 185);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(411, 25);
            this.txtStock.TabIndex = 16;
            // 
            // lblErrorStock
            // 
            this.lblErrorStock.AutoSize = true;
            this.lblErrorStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorStock.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorStock.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorStock.Location = new System.Drawing.Point(430, 211);
            this.lblErrorStock.Name = "lblErrorStock";
            this.lblErrorStock.Size = new System.Drawing.Size(411, 18);
            this.lblErrorStock.TabIndex = 17;
            this.lblErrorStock.Text = " ";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCategoria.Location = new System.Drawing.Point(13, 229);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(411, 25);
            this.lblCategoria.TabIndex = 18;
            this.lblCategoria.Text = "Categoría";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(13, 257);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(411, 25);
            this.cmbCategoria.TabIndex = 19;
            this.cmbCategoria.Text = "Seleccione una categoría";
            // 
            // lblErrorCategoria
            // 
            this.lblErrorCategoria.AutoSize = true;
            this.lblErrorCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCategoria.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorCategoria.Location = new System.Drawing.Point(13, 284);
            this.lblErrorCategoria.Name = "lblErrorCategoria";
            this.lblErrorCategoria.Size = new System.Drawing.Size(411, 18);
            this.lblErrorCategoria.TabIndex = 20;
            this.lblErrorCategoria.Text = " ";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMarca.Location = new System.Drawing.Point(430, 229);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(411, 25);
            this.lblMarca.TabIndex = 21;
            this.lblMarca.Text = "Marca";
            this.lblMarca.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtMarca
            // 
            this.txtMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(430, 257);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(411, 25);
            this.txtMarca.TabIndex = 22;
            // 
            // lblErrorMarca
            // 
            this.lblErrorMarca.AutoSize = true;
            this.lblErrorMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMarca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMarca.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorMarca.Location = new System.Drawing.Point(430, 284);
            this.lblErrorMarca.Name = "lblErrorMarca";
            this.lblErrorMarca.Size = new System.Drawing.Size(411, 18);
            this.lblErrorMarca.TabIndex = 23;
            this.lblErrorMarca.Text = " ";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCodigo.Location = new System.Drawing.Point(13, 302);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(411, 25);
            this.lblCodigo.TabIndex = 24;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(13, 330);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(411, 25);
            this.txtCodigo.TabIndex = 25;
            // 
            // lblErrorCodigo
            // 
            this.lblErrorCodigo.AutoSize = true;
            this.lblErrorCodigo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorCodigo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorCodigo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorCodigo.Location = new System.Drawing.Point(13, 357);
            this.lblErrorCodigo.Name = "lblErrorCodigo";
            this.lblErrorCodigo.Size = new System.Drawing.Size(411, 18);
            this.lblErrorCodigo.TabIndex = 26;
            this.lblErrorCodigo.Text = " ";
            // 
            // FormRegistrarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 749);
            this.Controls.Add(this.mainPanel);
            this.Name = "FormRegistrarProducto";
            this.Text = "Registrar Producto";
            this.Load += new System.EventHandler(this.FormRegistrarProducto_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.formPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
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
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRegistrarProducto;
        private System.Windows.Forms.DataGridView dgvProductos;
    }
}