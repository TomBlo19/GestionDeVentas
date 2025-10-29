namespace GestionDeVentas.Gerente
{
    partial class FormRegistrarCliente
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
            // Definición de la Paleta de Colores (Coherente)
            System.Drawing.Color marronOscuro = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(40)))));
            System.Drawing.Color marronMedio = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(120)))), ((int)(((byte)(100)))));
            System.Drawing.Color cremaFondo = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            System.Drawing.Color textoOscuro = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvDefaultStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAlternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblErrorApellido = new System.Windows.Forms.Label();
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
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblErrorCorreo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.cboBuscarPor = new System.Windows.Forms.ComboBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1067, 62);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registrar Cliente";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblNombre.ForeColor = textoOscuro;
            this.lblNombre.Location = new System.Drawing.Point(67, 98);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(83, 22);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(71, 123);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(265, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.lblErrorNombre.Location = new System.Drawing.Point(71, 151);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(10, 16);
            this.lblErrorNombre.TabIndex = 3;
            this.lblErrorNombre.Text = " ";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblApellido.ForeColor = textoOscuro;
            this.lblApellido.Location = new System.Drawing.Point(400, 98);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(84, 22);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(404, 123);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(265, 22);
            this.txtApellido.TabIndex = 5;
            // 
            // lblErrorApellido
            // 
            this.lblErrorApellido.AutoSize = true;
            this.lblErrorApellido.ForeColor = System.Drawing.Color.Red;
            this.lblErrorApellido.Location = new System.Drawing.Point(404, 151);
            this.lblErrorApellido.Name = "lblErrorApellido";
            this.lblErrorApellido.Size = new System.Drawing.Size(10, 16);
            this.lblErrorApellido.TabIndex = 6;
            this.lblErrorApellido.Text = " ";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblDni.ForeColor = textoOscuro;
            this.lblDni.Location = new System.Drawing.Point(67, 172);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(48, 22);
            this.lblDni.TabIndex = 7;
            this.lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(71, 197);
            this.txtDni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(265, 22);
            this.txtDni.TabIndex = 8;
            // 
            // lblErrorDni
            // 
            this.lblErrorDni.AutoSize = true;
            this.lblErrorDni.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDni.Location = new System.Drawing.Point(71, 225);
            this.lblErrorDni.Name = "lblErrorDni";
            this.lblErrorDni.Size = new System.Drawing.Size(10, 16);
            this.lblErrorDni.TabIndex = 9;
            this.lblErrorDni.Text = " ";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblTelefono.ForeColor = textoOscuro;
            this.lblTelefono.Location = new System.Drawing.Point(400, 172);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(89, 22);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(404, 197);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(265, 22);
            this.txtTelefono.TabIndex = 11;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTelefono.Location = new System.Drawing.Point(404, 225);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(10, 16);
            this.lblErrorTelefono.TabIndex = 12;
            this.lblErrorTelefono.Text = " ";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblDireccion.ForeColor = textoOscuro;
            this.lblDireccion.Location = new System.Drawing.Point(67, 246);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(95, 22);
            this.lblDireccion.TabIndex = 13;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(71, 271);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(599, 22);
            this.txtDireccion.TabIndex = 14;
            // 
            // lblErrorDireccion
            // 
            this.lblErrorDireccion.AutoSize = true;
            this.lblErrorDireccion.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDireccion.Location = new System.Drawing.Point(71, 299);
            this.lblErrorDireccion.Name = "lblErrorDireccion";
            this.lblErrorDireccion.Size = new System.Drawing.Size(10, 16);
            this.lblErrorDireccion.TabIndex = 15;
            this.lblErrorDireccion.Text = " ";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblPais.ForeColor = textoOscuro;
            this.lblPais.Location = new System.Drawing.Point(67, 320);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(54, 22);
            this.lblPais.TabIndex = 16;
            this.lblPais.Text = "País:";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(71, 345);
            this.txtPais.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(265, 22);
            this.txtPais.TabIndex = 17;
            // 
            // lblErrorPais
            // 
            this.lblErrorPais.AutoSize = true;
            this.lblErrorPais.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPais.Location = new System.Drawing.Point(71, 373);
            this.lblErrorPais.Name = "lblErrorPais";
            this.lblErrorPais.Size = new System.Drawing.Size(10, 16);
            this.lblErrorPais.TabIndex = 18;
            this.lblErrorPais.Text = " ";
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblCiudad.ForeColor = textoOscuro;
            this.lblCiudad.Location = new System.Drawing.Point(400, 320);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(75, 22);
            this.lblCiudad.TabIndex = 19;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(404, 345);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(265, 22);
            this.txtCiudad.TabIndex = 20;
            // 
            // lblErrorCiudad
            // 
            this.lblErrorCiudad.AutoSize = true;
            this.lblErrorCiudad.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCiudad.Location = new System.Drawing.Point(404, 373);
            this.lblErrorCiudad.Name = "lblErrorCiudad";
            this.lblErrorCiudad.Size = new System.Drawing.Size(10, 16);
            this.lblErrorCiudad.TabIndex = 21;
            this.lblErrorCiudad.Text = " ";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold); // CAMBIO: Negrita para etiquetas
            this.lblCorreo.ForeColor = textoOscuro;
            this.lblCorreo.Location = new System.Drawing.Point(67, 394);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(167, 22);
            this.lblCorreo.TabIndex = 22;
            this.lblCorreo.Text = "Correo Electrónico:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(71, 418);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(265, 22);
            this.txtCorreo.TabIndex = 23;
            // 
            // lblErrorCorreo
            // 
            this.lblErrorCorreo.AutoSize = true;
            this.lblErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.lblErrorCorreo.Location = new System.Drawing.Point(71, 447);
            this.lblErrorCorreo.Name = "lblErrorCorreo";
            this.lblErrorCorreo.Size = new System.Drawing.Size(10, 16);
            this.lblErrorCorreo.TabIndex = 24;
            this.lblErrorCorreo.Text = " ";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro (Principal)
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(71, 480);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(200, 49);
            this.btnRegistrar.TabIndex = 25;
            this.btnRegistrar.Text = "Registrar Cliente";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White; // CAMBIO: Blanco (el fondo del form es Crema)
            this.dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // Estilo de la Cabecera (DataGridView)
            dgvHeaderStyle.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro
            dgvHeaderStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White; // Texto Blanco
            dgvHeaderStyle.SelectionBackColor = marronMedio;
            this.dgvClientes.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvClientes.EnableHeadersVisualStyles = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colApellido,
            this.colDni,
            this.colTelefono,
            this.colDireccion,
            this.colPais,
            this.colCiudad,
            this.colCorreo,
            this.colEstado});

            // Estilo de las filas
            dgvDefaultStyle.BackColor = System.Drawing.Color.White; // Fila impar: Blanco
            dgvDefaultStyle.ForeColor = textoOscuro; // Texto Oscuro
            dgvDefaultStyle.SelectionBackColor = marronMedio; // Selección Marrón Medio
            dgvDefaultStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientes.DefaultCellStyle = dgvDefaultStyle;

            dgvAlternatingStyle.BackColor = cremaFondo; // Fila alterna: Crema
            this.dgvClientes.AlternatingRowsDefaultCellStyle = dgvAlternatingStyle;

            this.dgvClientes.Location = new System.Drawing.Point(13, 589);
            this.dgvClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(1040, 188);
            this.dgvClientes.TabIndex = 26;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
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
            // colApellido
            // 
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.MinimumWidth = 6;
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI";
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
            // colCorreo
            // 
            this.colCorreo.HeaderText = "Correo Electrónico";
            this.colCorreo.MinimumWidth = 6;
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
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
            this.btnEditar.BackColor = marronMedio; // CAMBIO: Marrón Medio (Acción Secundaria)
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(284, 480);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(200, 49);
            this.btnEditar.TabIndex = 27;
            this.btnEditar.Text = "Guardar Cambios";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = marronMedio; // CAMBIO: Marrón Medio (Acción Secundaria)
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(509, 480);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(200, 49);
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
            this.btnCerrar.Location = new System.Drawing.Point(1027, 0); // CORRECCIÓN: Y=0 para integrarse
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 62); // Altura igual al título
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblBuscarPor.ForeColor = textoOscuro;
            this.lblBuscarPor.Location = new System.Drawing.Point(13, 555);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(108, 22);
            this.lblBuscarPor.TabIndex = 31;
            this.lblBuscarPor.Text = "Buscar por:";
            // 
            // cboBuscarPor
            // 
            this.cboBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarPor.FormattingEnabled = true;
            this.cboBuscarPor.Location = new System.Drawing.Point(127, 555);
            this.cboBuscarPor.Name = "cboBuscarPor";
            this.cboBuscarPor.Size = new System.Drawing.Size(180, 24);
            this.cboBuscarPor.TabIndex = 32;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(313, 556);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(250, 22);
            this.txtBusqueda.TabIndex = 33;
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = marronOscuro; // CAMBIO: Marrón Oscuro (Botón de acción de filtro)
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(569, 552);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.BackColor = marronMedio; // CAMBIO: Marrón Medio (Acción secundaria de filtro)
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(665, 552);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiarBusqueda.TabIndex = 35;
            this.btnLimpiarBusqueda.Text = "Limpiar";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // FormRegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = cremaFondo; // CAMBIO: Fondo principal Crema
            this.ClientSize = new System.Drawing.Size(1067, 788);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimpiarBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cboBuscarPor);
            this.Controls.Add(this.lblBuscarPor);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvClientes);
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
            this.Controls.Add(this.lblErrorDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblErrorApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormRegistrarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Cliente";
            this.Load += new System.EventHandler(this.FormRegistrarCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblErrorApellido;
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
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblErrorCorreo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.ComboBox cboBuscarPor;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
    }
}