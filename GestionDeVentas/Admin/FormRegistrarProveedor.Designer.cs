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
            // Definición de la Paleta de Colores
            System.Drawing.Color marronOscuro = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            System.Drawing.Color marronMedio = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            System.Drawing.Color cremaFondo = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            System.Drawing.Color textoOscuro = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            System.Drawing.Color cremaBordes = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(190)))));

            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvDefaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAlternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblErrorEmpresa = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblErrorCuit = new System.Windows.Forms.Label();
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
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblFiltrarEstado = new System.Windows.Forms.Label();
            this.cboFiltrarEstado = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(840, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Proveedor";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblNombre.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblNombre.Location = new System.Drawing.Point(50, 80);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtNombre.Location = new System.Drawing.Point(53, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorNombre.Location = new System.Drawing.Point(53, 125);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(10, 13);
            this.lblErrorNombre.TabIndex = 3;
            this.lblErrorNombre.Text = " ";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblEmpresa.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblEmpresa.Location = new System.Drawing.Point(300, 80);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 17);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtEmpresa.Location = new System.Drawing.Point(303, 100);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(200, 22);
            this.txtEmpresa.TabIndex = 5;
            // 
            // lblErrorEmpresa
            // 
            this.lblErrorEmpresa.AutoSize = true;
            this.lblErrorEmpresa.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorEmpresa.Location = new System.Drawing.Point(303, 125);
            this.lblErrorEmpresa.Name = "lblErrorEmpresa";
            this.lblErrorEmpresa.Size = new System.Drawing.Size(10, 13);
            this.lblErrorEmpresa.TabIndex = 6;
            this.lblErrorEmpresa.Text = " ";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCuit.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblCuit.Location = new System.Drawing.Point(50, 140);
            this.lblCuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(43, 17);
            this.lblCuit.TabIndex = 7;
            this.lblCuit.Text = "CUIT:";
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCuit.Location = new System.Drawing.Point(53, 160);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(200, 22);
            this.txtCuit.TabIndex = 8;
            // 
            // lblErrorCuit
            // 
            this.lblErrorCuit.AutoSize = true;
            this.lblErrorCuit.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorCuit.Location = new System.Drawing.Point(53, 185);
            this.lblErrorCuit.Name = "lblErrorCuit";
            this.lblErrorCuit.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCuit.TabIndex = 9;
            this.lblErrorCuit.Text = " ";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblTelefono.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblTelefono.Location = new System.Drawing.Point(300, 140);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(66, 17);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtTelefono.Location = new System.Drawing.Point(303, 160);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(200, 22);
            this.txtTelefono.TabIndex = 11;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorTelefono.Location = new System.Drawing.Point(303, 185);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(10, 13);
            this.lblErrorTelefono.TabIndex = 12;
            this.lblErrorTelefono.Text = " ";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblDireccion.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblDireccion.Location = new System.Drawing.Point(50, 200);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(74, 17);
            this.lblDireccion.TabIndex = 13;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtDireccion.Location = new System.Drawing.Point(53, 220);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 22); // Ajustado para coincidir con la fila
            this.txtDireccion.TabIndex = 14;
            // 
            // lblErrorDireccion
            // 
            this.lblErrorDireccion.AutoSize = true;
            this.lblErrorDireccion.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorDireccion.Location = new System.Drawing.Point(53, 245);
            this.lblErrorDireccion.Name = "lblErrorDireccion";
            this.lblErrorDireccion.Size = new System.Drawing.Size(10, 13);
            this.lblErrorDireccion.TabIndex = 15;
            this.lblErrorDireccion.Text = " ";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblPais.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblPais.Location = new System.Drawing.Point(300, 260); // Cambio de posición
            this.lblPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(41, 17);
            this.lblPais.TabIndex = 16;
            this.lblPais.Text = "País:";
            this.lblPais.Visible = false; // El ejemplo solo muestra 'Ciudad' dos veces, ocultamos País y usamos Ciudad en su lugar.
            // 
            // txtPais
            // 
            this.txtPais.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtPais.Location = new System.Drawing.Point(303, 280); // Cambio de posición
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(200, 22);
            this.txtPais.TabIndex = 17;
            this.txtPais.Visible = false;
            // 
            // lblErrorPais
            // 
            this.lblErrorPais.AutoSize = true;
            this.lblErrorPais.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPais.Location = new System.Drawing.Point(303, 305);
            this.lblErrorPais.Name = "lblErrorPais";
            this.lblErrorPais.Size = new System.Drawing.Size(10, 13);
            this.lblErrorPais.TabIndex = 18;
            this.lblErrorPais.Text = " ";
            this.lblErrorPais.Visible = false;
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCiudad.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblCiudad.Location = new System.Drawing.Point(300, 200); // Cambio de posición, moviendo el segundo campo de dirección a Ciudad
            this.lblCiudad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(58, 17);
            this.lblCiudad.TabIndex = 19;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCiudad.Location = new System.Drawing.Point(303, 220); // Cambio de posición
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(200, 22);
            this.txtCiudad.TabIndex = 20;
            // 
            // lblErrorCiudad
            // 
            this.lblErrorCiudad.AutoSize = true;
            this.lblErrorCiudad.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCiudad.Location = new System.Drawing.Point(303, 245);
            this.lblErrorCiudad.Name = "lblErrorCiudad";
            this.lblErrorCiudad.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCiudad.TabIndex = 21;
            this.lblErrorCiudad.Text = " ";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblCorreo.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblCorreo.Location = new System.Drawing.Point(550, 80);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(57, 17);
            this.lblCorreo.TabIndex = 22;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtCorreo.Location = new System.Drawing.Point(553, 100);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 22); // Ajustado para coincidir con la fila
            this.txtCorreo.TabIndex = 23;
            // 
            // lblErrorCorreo
            // 
            this.lblErrorCorreo.AutoSize = true;
            this.lblErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCorreo.Location = new System.Drawing.Point(553, 125);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(10, 13);
            this.lblErrorCorreo.TabIndex = 24;
            this.lblErrorCorreo.Text = " ";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = marronMedio; // CAMBIO: Marrón de acento
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(53, 330);
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
            this.dgvProveedores.BackgroundColor = cremaFondo; // CAMBIO: Fondo Crema
            this.dgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colEmpresa,
            this.colCuit,
            this.colTelefono,
            this.colDireccion,
            this.colPais,
            this.colCiudad,
            this.colCorreo,
            this.colEstado});
            // Estilos de la cabecera del DataGridView
            dgvHeaderStyle.BackColor = marronMedio; // CAMBIO: Marrón Medio
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.dgvProveedores.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvProveedores.EnableHeadersVisualStyles = false;

            // Estilos de las celdas (Rayado)
            dgvDefaultStyle.BackColor = System.Drawing.Color.White; // Fila principal
            dgvDefaultStyle.ForeColor = textoOscuro;
            dgvDefaultStyle.SelectionBackColor = marronMedio; // Color de selección
            dgvDefaultStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProveedores.DefaultCellStyle = dgvDefaultStyle;

            dgvAlternatingStyle.BackColor = cremaFondo; // Fila alterna (para simular el rayado)
            this.dgvProveedores.AlternatingRowsDefaultCellStyle = dgvAlternatingStyle;

            this.dgvProveedores.Location = new System.Drawing.Point(12, 436);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.RowHeadersVisible = false;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(816, 222);
            this.dgvProveedores.TabIndex = 26;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colEmpresa
            // 
            this.colEmpresa.DataPropertyName = "Empresa";
            this.colEmpresa.HeaderText = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.ReadOnly = true;
            // 
            // colCuit
            // 
            this.colCuit.DataPropertyName = "Cuit";
            this.colCuit.HeaderText = "CUIT";
            this.colCuit.Name = "colCuit";
            this.colCuit.ReadOnly = true;
            // 
            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            // 
            // colDireccion
            // 
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            this.colDireccion.Visible = false;
            // 
            // colPais
            // 
            this.colPais.DataPropertyName = "Pais";
            this.colPais.HeaderText = "País";
            this.colPais.Name = "colPais";
            this.colPais.ReadOnly = true;
            this.colPais.Visible = false;
            // 
            // colCiudad
            // 
            this.colCiudad.DataPropertyName = "Ciudad";
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.ReadOnly = true;
            this.colCiudad.Visible = false;
            // 
            // colCorreo
            // 
            this.colCorreo.DataPropertyName = "Correo";
            this.colCorreo.HeaderText = "Correo";
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            this.colCorreo.Visible = false;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "ActivoTexto";
            this.colEstado.FillWeight = 60F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro (Botón principal para guardar)
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(53, 330);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 40);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "Guardar Cambios";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = marronMedio; // CAMBIO: Marrón de acento (Botón secundario)
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(220, 330);
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
            this.btnCerrar.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro para integrarse al título
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(800, 0); // CORRECCIÓN: Y=0 para pegarlo al tope
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 50); // Ajustar tamaño para cubrir el alto del título
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.Color.ForestGreen; // Mantenemos el color de activación
            this.btnActivar.FlatAppearance.BorderSize = 0;
            this.btnActivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Location = new System.Drawing.Point(385, 330);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(150, 40);
            this.btnActivar.TabIndex = 31;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackColor = System.Drawing.Color.Red; // Mantenemos el color de desactivación/peligro
            this.btnDesactivar.FlatAppearance.BorderSize = 0;
            this.btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesactivar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDesactivar.ForeColor = System.Drawing.Color.White;
            this.btnDesactivar.Location = new System.Drawing.Point(550, 330);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(150, 40);
            this.btnDesactivar.TabIndex = 32;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = false;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFiltros.Controls.Add(this.lblFiltrarEstado);
            this.panelFiltros.Controls.Add(this.cboFiltrarEstado);
            this.panelFiltros.Controls.Add(this.txtBusqueda);
            this.panelFiltros.Controls.Add(this.cboBuscarPor);
            this.panelFiltros.Controls.Add(this.lblBuscar);
            this.panelFiltros.Location = new System.Drawing.Point(12, 381);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(816, 49);
            this.panelFiltros.TabIndex = 33;
            // 
            // lblFiltrarEstado
            // 
            this.lblFiltrarEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiltrarEstado.AutoSize = true;
            this.lblFiltrarEstado.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblFiltrarEstado.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblFiltrarEstado.Location = new System.Drawing.Point(593, 16);
            this.lblFiltrarEstado.Name = "lblFiltrarEstado";
            this.lblFiltrarEstado.Size = new System.Drawing.Size(58, 17);
            this.lblFiltrarEstado.TabIndex = 4;
            this.lblFiltrarEstado.Text = "Estado:";
            // 
            // cboFiltrarEstado
            // 
            this.cboFiltrarEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiltrarEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltrarEstado.Font = new System.Drawing.Font("Arial", 11.25F);
            this.cboFiltrarEstado.FormattingEnabled = true;
            this.cboFiltrarEstado.Location = new System.Drawing.Point(657, 12);
            this.cboFiltrarEstado.Name = "cboFiltrarEstado";
            this.cboFiltrarEstado.Size = new System.Drawing.Size(156, 25);
            this.cboFiltrarEstado.TabIndex = 3;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtBusqueda.Location = new System.Drawing.Point(232, 12);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(355, 25);
            this.txtBusqueda.TabIndex = 2;
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarPor.Font = new System.Drawing.Font("Arial", 11.25F);
            this.cboBuscarPor.FormattingEnabled = true;
            this.cboBuscarPor.Location = new System.Drawing.Point(95, 12);
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Size = new System.Drawing.Size(131, 25);
            this.cboBuscarPor.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblBuscar.ForeColor = textoOscuro; // CAMBIO: Texto Oscuro
            this.lblBuscar.Location = new System.Drawing.Point(3, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(86, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar por:";
            // 
            // FormRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = cremaFondo; // CAMBIO: Fondo principal Crema
            this.ClientSize = new System.Drawing.Size(840, 670);
            this.ControlBox = false;
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.lblErrorCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblCorreo);
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
            this.Controls.Add(this.lblErrorCuit);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblErrorEmpresa);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistrarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Proveedor";
            this.Load += new System.EventHandler(this.FormRegistrarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
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
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblErrorCuit;
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
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblFiltrarEstado;
        private System.Windows.Forms.ComboBox cboFiltrarEstado;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}