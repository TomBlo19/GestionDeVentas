using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    public partial class FormRegistrarProveedor : Form
    {
        private ProveedorDatos proveedorDatos = new ProveedorDatos();
        private int? proveedorSeleccionadoId = null;

        public FormRegistrarProveedor()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            // Validaciones KeyPress
            this.txtNombre.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtEmpresa.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDni.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);

            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
        }

        private void FormRegistrarProveedor_Load(object sender, EventArgs e)
        {
            btnCerrar.BringToFront();
            ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToResizeRows = false;
            dgvProveedores.AllowUserToResizeColumns = true;
            dgvProveedores.Columns.Clear();

            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", DataPropertyName = "Nombre", HeaderText = "Nombre", Width = 140 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmpresa", DataPropertyName = "Empresa", HeaderText = "Empresa", Width = 160 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCuit", DataPropertyName = "Cuit", HeaderText = "CUIT", Width = 130 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTelefono", DataPropertyName = "Telefono", HeaderText = "Teléfono", Width = 110 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDireccion", DataPropertyName = "Direccion", HeaderText = "Dirección", Width = 160 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCiudad", DataPropertyName = "Ciudad", HeaderText = "Ciudad", Width = 120 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPais", DataPropertyName = "Pais", HeaderText = "País", Width = 100 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCorreo", DataPropertyName = "Correo", HeaderText = "Correo", Width = 170 });
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstado", DataPropertyName = "ActivoTexto", HeaderText = "Estado", Width = 100 });

            dgvProveedores.RowPrePaint += dgvProveedores_RowPrePaint;
        }

        private void dgvProveedores_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var prov = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;
            if (prov == null) return;

            dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.ForeColor = prov.Activo ? Color.Black : Color.Red;
        }

        private void ActualizarDataGridView()
        {
            dgvProveedores.DataSource = proveedorDatos.ObtenerProveedores();
        }

        private bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(false)) return;

            var nuevoProveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Empresa = txtEmpresa.Text.Trim(),
                Cuit = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Pais = txtPais.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Activo = true
            };

            // Validaciones duplicados antes de confirmar
            if (proveedorDatos.ExisteCuit(nuevoProveedor.Cuit))
            {
                lblErrorDni.Text = "El CUIT ya existe.";
                return;
            }
            if (proveedorDatos.ExisteCorreo(nuevoProveedor.Correo))
            {
                lblErrorCorreo.Text = "El correo ya existe.";
                return;
            }

            if (!Confirmar("¿Deseas registrar este proveedor?")) return;

            proveedorDatos.InsertarProveedor(nuevoProveedor);
            MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarDataGridView();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(proveedorSeleccionadoId.HasValue && ValidarCampos(true))) return;

            var proveedorAEditar = new Proveedor
            {
                Id = proveedorSeleccionadoId.Value,
                Nombre = txtNombre.Text.Trim(),
                Empresa = txtEmpresa.Text.Trim(),
                Cuit = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Pais = txtPais.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            if (proveedorDatos.ExisteCuit(proveedorAEditar.Cuit, proveedorAEditar.Id))
            {
                lblErrorDni.Text = "El CUIT ya está en uso.";
                return;
            }
            if (proveedorDatos.ExisteCorreo(proveedorAEditar.Correo, proveedorAEditar.Id))
            {
                lblErrorCorreo.Text = "El correo ya está en uso.";
                return;
            }

            if (!Confirmar($"¿Guardar cambios para {proveedorAEditar.Empresa}?")) return;

            proveedorDatos.EditarProveedor(proveedorAEditar);
            MessageBox.Show("Proveedor editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarDataGridView();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (!Confirmar("¿Deseas limpiar los campos?")) return;
            LimpiarCampos();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (!proveedorSeleccionadoId.HasValue) return;

            if (!Confirmar("¿Deseas ACTIVAR este proveedor?")) return;

            proveedorDatos.CambiarEstado(proveedorSeleccionadoId.Value, true);
            ActualizarDataGridView();
            btnActivar.Visible = false;
            btnDesactivar.Visible = true;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!proveedorSeleccionadoId.HasValue) return;

            if (!Confirmar("¿Deseas DESACTIVAR este proveedor?")) return;

            proveedorDatos.CambiarEstado(proveedorSeleccionadoId.Value, false);
            ActualizarDataGridView();
            btnActivar.Visible = true;
            btnDesactivar.Visible = false;
        }

        private bool ValidarCampos(bool esEdicion)
        {
            bool esValido = true;

            lblErrorNombre.Text = " ";
            lblErrorEmpresa.Text = " ";
            lblErrorDni.Text = " ";
            lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " ";
            lblErrorPais.Text = " ";
            lblErrorCiudad.Text = " ";
            lblErrorCorreo.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtEmpresa.Text)) { lblErrorEmpresa.Text = "La empresa es obligatoria."; esValido = false; }

            // CUIT: formato 20-12345678-9
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { lblErrorDni.Text = "El CUIT es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtDni.Text, @"^\d{2}-\d{8}-\d{1}$")) { lblErrorDni.Text = "Formato inválido. Ej: 20-12345678-9"; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9\s-]+$")) { lblErrorTelefono.Text = "Solo números y guiones."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) { lblErrorCorreo.Text = "El correo es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { lblErrorCorreo.Text = "Correo inválido."; esValido = false; }

            return esValido;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmpresa.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtPais.Clear();
            txtCiudad.Clear();
            txtCorreo.Clear();
            txtNombre.Focus();

            proveedorSeleccionadoId = null;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var prov = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;
            if (prov == null) return;

            proveedorSeleccionadoId = prov.Id;

            txtNombre.Text = prov.Nombre;
            txtEmpresa.Text = prov.Empresa;
            txtDni.Text = prov.Cuit;
            txtTelefono.Text = prov.Telefono;
            txtDireccion.Text = prov.Direccion;
            txtPais.Text = prov.Pais;
            txtCiudad.Text = prov.Ciudad;
            txtCorreo.Text = prov.Correo;

            btnRegistrar.Visible = false;
            btnEditar.Visible = true;
            btnActivar.Visible = !prov.Activo;
            btnDesactivar.Visible = prov.Activo;
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Confirmar("¿Seguro que deseas cerrar esta ventana?", "Cerrar"))
                this.Close();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
