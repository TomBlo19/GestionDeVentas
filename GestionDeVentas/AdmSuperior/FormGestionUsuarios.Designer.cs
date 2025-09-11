namespace GestionDeVentas.AdmSuperior
{
    partial class FormGestionarUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cmbFiltroRol;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Button btnResetClave;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblTitulo;

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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmbFiltroRol = new System.Windows.Forms.ComboBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnResetClave = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(190, 25);
            this.lblTitulo.Text = "Gestionar Usuarios";

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(610, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // dgvUsuarios
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.Add("Id", "ID");
            this.dgvUsuarios.Columns.Add("Nombre", "Nombre");
            this.dgvUsuarios.Columns.Add("Rol", "Rol");
            this.dgvUsuarios.Columns.Add("Estado", "Estado");
            this.dgvUsuarios.Columns.Add("UltimoAcceso", "Último acceso");
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 80);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(600, 250);

            // txtBusqueda
            this.txtBusqueda.Location = new System.Drawing.Point(20, 50);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(180, 23);
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);

            // cmbFiltroRol
            this.cmbFiltroRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroRol.Items.AddRange(new object[] { "Todos", "Vendedor", "Gerente", "Administrador", "Admin Superior" });
            this.cmbFiltroRol.Location = new System.Drawing.Point(220, 50);
            this.cmbFiltroRol.Name = "cmbFiltroRol";
            this.cmbFiltroRol.Size = new System.Drawing.Size(150, 23);
            this.cmbFiltroRol.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroRol_SelectedIndexChanged);

            // cmbFiltroEstado
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Activo", "Inactivo" });
            this.cmbFiltroEstado.Location = new System.Drawing.Point(390, 50);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(150, 23);
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);

            // Botones
            this.btnAgregar.Location = new System.Drawing.Point(20, 350);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 30);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            this.btnEditar.Location = new System.Drawing.Point(140, 350);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Location = new System.Drawing.Point(260, 350);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnEstado.Location = new System.Drawing.Point(380, 350);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(120, 30);
            this.btnEstado.Text = "Activar/Inactivar";
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);

            this.btnResetClave.Location = new System.Drawing.Point(520, 350);
            this.btnResetClave.Name = "btnResetClave";
            this.btnResetClave.Size = new System.Drawing.Size(120, 30);
            this.btnResetClave.Text = "Resetear Clave";
            this.btnResetClave.Click += new System.EventHandler(this.btnResetClave_Click);

            // FormGestionarUsuarios
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.cmbFiltroRol);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnResetClave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // para que el botón "X" sea tuyo
            this.Name = "FormGestionarUsuarios";
            this.Text = "Gestionar Usuarios";

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
