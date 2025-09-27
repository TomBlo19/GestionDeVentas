namespace GestionDeVentas.Gerente
{
    partial class FormRegistrarProveedor
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblErrorEmpresa = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblErrorDni = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblErrorDireccion = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.lblErrorPais = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.lblErrorCiudad = new System.Windows.Forms.Label();
            this.lblFechaInicioRelacion = new System.Windows.Forms.Label();
            this.dtpFechaInicioRelacion = new System.Windows.Forms.DateTimePicker();
            this.lblErrorFechaInicioRelacion = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaInicioRelacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Blue;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(800, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Proveedor";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblNombre.Location = new System.Drawing.Point(50, 80);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 100);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(53, 123);
            this.lblErrorNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(10, 13);
            this.lblErrorNombre.TabIndex = 3;
            this.lblErrorNombre.Text = " ";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblEmpresa.Location = new System.Drawing.Point(300, 80);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 17);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(303, 100);
            this.txtEmpresa.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(200, 20);
            this.txtEmpresa.TabIndex = 5;
            // 
            // lblErrorEmpresa
            // 
            this.lblErrorEmpresa.AutoSize = true;
            this.lblErrorEmpresa.ForeColor = System.Drawing.Color.Red;
            this.lblErrorEmpresa.Location = new System.Drawing.Point(303, 123);
            this.lblErrorEmpresa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorEmpresa.Name = "lblErrorEmpresa";
            this.lblErrorEmpresa.Size = new System.Drawing.Size(10, 13);
            this.lblErrorEmpresa.TabIndex = 6;
            this.lblErrorEmpresa.Text = " ";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblDni.Location = new System.Drawing.Point(50, 140);
            this.lblDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(43, 17);
            this.lblDni.TabIndex = 7;
            this.lblDni.Text = "CUIT:";
            this.lblDni.Click += new System.EventHandler(this.lblDni_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(53, 160);
            this.txtDni.Margin = new System.Windows.Forms.Padding(2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(200, 20);
            this.txtDni.TabIndex = 8;
            // 
            // lblErrorDni
            // 
            this.lblErrorDni.AutoSize = true;
            this.lblErrorDni.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDni.Location = new System.Drawing.Point(53, 183);
            this.lblErrorDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorDni.Name = "lblErrorDni";
            this.lblErrorDni.Size = new System.Drawing.Size(10, 13);
            this.lblErrorDni.TabIndex = 9;
            this.lblErrorDni.Text = " ";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblTelefono.Location = new System.Drawing.Point(300, 140);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 17);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(303, 160);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 20);
            this.txtTelefono.TabIndex = 11;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTelefono.Location = new System.Drawing.Point(303, 183);
            this.lblErrorTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(10, 13);
            this.lblErrorTelefono.TabIndex = 12;
            this.lblErrorTelefono.Text = " ";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblDireccion.Location = new System.Drawing.Point(50, 200);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(74, 17);
            this.lblDireccion.TabIndex = 13;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(53, 220);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(450, 20);
            this.txtDireccion.TabIndex = 14;
            // 
            // lblErrorDireccion
            // 
            this.lblErrorDireccion.AutoSize = true;
            this.lblErrorDireccion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDireccion.Location = new System.Drawing.Point(53, 243);
            this.lblErrorDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorDireccion.Name = "lblErrorDireccion";
            this.lblErrorDireccion.Size = new System.Drawing.Size(10, 13);
            this.lblErrorDireccion.TabIndex = 15;
            this.lblErrorDireccion.Text = " ";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblPais.Location = new System.Drawing.Point(50, 260);
            this.lblPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(41, 17);
            this.lblPais.TabIndex = 16;
            this.lblPais.Text = "País:";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(53, 280);
            this.txtPais.Margin = new System.Windows.Forms.Padding(2);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(200, 20);
            this.txtPais.TabIndex = 17;
            // 
            // lblErrorPais
            // 
            this.lblErrorPais.AutoSize = true;
            this.lblErrorPais.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPais.Location = new System.Drawing.Point(53, 303);
            this.lblErrorPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorPais.Name = "lblErrorPais";
            this.lblErrorPais.Size = new System.Drawing.Size(10, 13);
            this.lblErrorPais.TabIndex = 18;
            this.lblErrorPais.Text = " ";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCiudad.Location = new System.Drawing.Point(300, 260);
            this.lblCiudad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(58, 17);
            this.lblCiudad.TabIndex = 19;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(303, 280);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(200, 20);
            this.txtCiudad.TabIndex = 20;
            // 
            // lblErrorCiudad
            // 
            this.lblErrorCiudad.AutoSize = true;
            this.lblErrorCiudad.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCiudad.Location = new System.Drawing.Point(303, 303);
            this.lblErrorCiudad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorCiudad.Name = "lblErrorCiudad";
            this.lblErrorCiudad.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCiudad.TabIndex = 21;
            this.lblErrorCiudad.Text = " ";
            // 
            // lblFechaInicioRelacion
            // 
            this.lblFechaInicioRelacion.AutoSize = true;
            this.lblFechaInicioRelacion.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblFechaInicioRelacion.Location = new System.Drawing.Point(50, 320);
            this.lblFechaInicioRelacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaInicioRelacion.Name = "lblFechaInicioRelacion";
            this.lblFechaInicioRelacion.Size = new System.Drawing.Size(191, 17);
            this.lblFechaInicioRelacion.TabIndex = 22;
            this.lblFechaInicioRelacion.Text = "Fecha de Inicio de Relación:";
            // 
            // dtpFechaInicioRelacion
            // 
            this.dtpFechaInicioRelacion.Location = new System.Drawing.Point(53, 340);
            this.dtpFechaInicioRelacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaInicioRelacion.Name = "dtpFechaInicioRelacion";
            this.dtpFechaInicioRelacion.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicioRelacion.TabIndex = 23;
            // 
            // lblErrorFechaInicioRelacion
            // 
            this.lblErrorFechaInicioRelacion.AutoSize = true;
            this.lblErrorFechaInicioRelacion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorFechaInicioRelacion.Location = new System.Drawing.Point(53, 363);
            this.lblErrorFechaInicioRelacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorFechaInicioRelacion.Name = "lblErrorFechaInicioRelacion";
            this.lblErrorFechaInicioRelacion.Size = new System.Drawing.Size(10, 13);
            this.lblErrorFechaInicioRelacion.TabIndex = 24;
            this.lblErrorFechaInicioRelacion.Text = " ";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(53, 390);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(150, 40);
            this.btnRegistrar.TabIndex = 25;
            this.btnRegistrar.Text = "Registrar Proveedor";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AllowUserToResizeRows = false;
            this.dgvProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colEmpresa,
            this.colDni,
            this.colTelefono,
            this.colDireccion,
            this.colPais,
            this.colCiudad,
            this.colFechaInicioRelacion,
            this.colEstado});
            this.dgvProveedores.Location = new System.Drawing.Point(10, 450);
            this.dgvProveedores.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.RowHeadersWidth = 51;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(780, 190);
            this.dgvProveedores.TabIndex = 26;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colEmpresa
            // 
            this.colEmpresa.HeaderText = "Empresa";
            this.colEmpresa.MinimumWidth = 6;
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.ReadOnly = true;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI/CUIT";
            this.colDni.MinimumWidth = 6;
            this.colDni.Name = "colDni";
            this.colDni.ReadOnly = true;
            // 
            // colTelefono
            // 
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 6;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // colDireccion
            // 
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.MinimumWidth = 6;
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            // 
            // colPais
            // 
            this.colPais.HeaderText = "País";
            this.colPais.MinimumWidth = 6;
            this.colPais.Name = "colPais";
            this.colPais.ReadOnly = true;
            // 
            // colCiudad
            // 
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.MinimumWidth = 6;
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.ReadOnly = true;
            // 
            // colFechaInicioRelacion
            // 
            this.colFechaInicioRelacion.HeaderText = "Fecha de Inicio de Relación";
            this.colFechaInicioRelacion.MinimumWidth = 6;
            this.colFechaInicioRelacion.Name = "colFechaInicioRelacion";
            this.colFechaInicioRelacion.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(213, 390);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 40);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "Editar Proveedor";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(382, 390);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 40);
            this.btnLimpiar.TabIndex = 29;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Blue;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(761, 10);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 26);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Location = new System.Drawing.Point(541, 390);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(150, 40);
            this.btnActivar.TabIndex = 31;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackColor = System.Drawing.Color.Red;
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(695, 390);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(150, 40);
            this.btnDesactivar.TabIndex = 32;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // FormRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 640);
            this.ControlBox = false;
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblErrorFechaInicioRelacion);
            this.Controls.Add(this.dtpFechaInicioRelacion);
            this.Controls.Add(this.lblFechaInicioRelacion);
            this.Controls.Add(this.lblErrorCiudad);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.lblErrorPais);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.lblErrorDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblErrorTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblErrorDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblErrorEmpresa);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRegistrarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Proveedor";
            this.Load += new System.EventHandler(this.FormRegistrarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblErrorEmpresa;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblErrorDni;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblErrorTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblErrorDireccion;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label lblErrorPais;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label lblErrorCiudad;
        private System.Windows.Forms.Label lblFechaInicioRelacion;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioRelacion;
        private System.Windows.Forms.Label lblErrorFechaInicioRelacion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInicioRelacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
    }
}