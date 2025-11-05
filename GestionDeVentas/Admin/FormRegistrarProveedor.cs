using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GestionDeVentas.Gerente
{
    public partial class FormRegistrarProveedor : Form
    {
        private readonly ProveedorDatos _proveedorDatos = new ProveedorDatos();
        private int? _proveedorSeleccionadoId = null;

        public FormRegistrarProveedor()
        {
            InitializeComponent();

            // ✅ LA SOLUCIÓN PRINCIPAL: Con esta línea, el DataGridView NUNCA más
            // va a ignorar las columnas que definiste en el diseñador.
            dgvProveedores.AutoGenerateColumns = false;

            ConfigurarControlesIniciales();
            AsignarValidaciones();

            this.dgvProveedores.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvProveedores_RowPrePaint);
        }

        private void FormRegistrarProveedor_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            ConectarEventosDeFiltro();
            AplicarFiltros();
        }

        #region CONFIGURACIÓN INICIAL Y FILTROS

        private void ConfigurarControlesIniciales()
        {
            this.lblCuit.Text = "CUIT:";
            btnEditar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;

            dgvProveedores.Columns["colDireccion"].Visible = false;
            dgvProveedores.Columns["colPais"].Visible = false;
            dgvProveedores.Columns["colCiudad"].Visible = false;
            dgvProveedores.Columns["colCorreo"].Visible = false;
        }

        private void AsignarValidaciones()
        {
            this.txtNombre.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtEmpresa.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCuit.KeyPress += new KeyPressEventHandler(txt_SoloNumerosYGuiones_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
        }

        private void CargarFiltros()
        {
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Nombre");
            cboBuscarPor.Items.Add("Empresa");
            cboBuscarPor.Items.Add("CUIT");
            cboBuscarPor.SelectedIndex = 0;

            cboFiltrarEstado.Items.Clear();
            cboFiltrarEstado.Items.Add("Todos");
            cboFiltrarEstado.Items.Add("Activos");
            cboFiltrarEstado.Items.Add("Inactivos");

            cboFiltrarEstado.SelectedIndex = 0;
        }

        private void ConectarEventosDeFiltro()
        {
            txtBusqueda.TextChanged += (s, e) => AplicarFiltros();
            cboBuscarPor.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cboFiltrarEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string criterio = cboBuscarPor.SelectedItem?.ToString();
            string valorBusqueda = txtBusqueda.Text;
            string estadoSeleccionado = cboFiltrarEstado.SelectedItem?.ToString();

            string cuitFiltro = null, nombreFiltro = null, empresaFiltro = null, estadoFiltro = null;

            if (!string.IsNullOrEmpty(criterio))
            {
                switch (criterio)
                {
                    case "CUIT": cuitFiltro = valorBusqueda; break;
                    case "Nombre": nombreFiltro = valorBusqueda; break;
                    case "Empresa": empresaFiltro = valorBusqueda; break;
                }
            }

            if (estadoSeleccionado == "Activos") estadoFiltro = "activo";
            else if (estadoSeleccionado == "Inactivos") estadoFiltro = "desactivado";

            List<Proveedor> proveedores = _proveedorDatos.ObtenerProveedores(cuitFiltro, nombreFiltro, empresaFiltro, estadoFiltro);
            CargarGrilla(proveedores);
        }

        private void CargarGrilla(List<Proveedor> lista)
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = lista;
            dgvProveedores.ClearSelection();
        }

        // ✅ SEGUNDA SOLUCIÓN: Usamos el evento RowPrePaint para colorear. Es más eficiente
        // y nos aseguramos de que los colores se apliquen correctamente siempre.
        private void dgvProveedores_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var proveedor = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;
            if (proveedor != null)
            {
                if (!proveedor.Activo)
                {
                    // Fila completa de rojo, con texto en blanco para que se lea bien.
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    // Si no está inactivo, nos aseguramos que tenga los colores por defecto.
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }


        #endregion

        #region LÓGICA DE BOTONES (CRUD)

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(false)) return;

            var nuevoProveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Empresa = txtEmpresa.Text.Trim(),
                Cuit = txtCuit.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Pais = txtPais.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Activo = true
            };

            if (_proveedorDatos.ExisteCuit(nuevoProveedor.Cuit)) { lblErrorCuit.Text = "El CUIT ya existe."; return; }
            if (_proveedorDatos.ExisteCorreo(nuevoProveedor.Correo)) { lblErrorCorreo.Text = "El correo ya existe."; return; }

            if (!Confirmar("¿Deseas registrar este proveedor?")) return;

            _proveedorDatos.InsertarProveedor(nuevoProveedor);
            MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            AplicarFiltros();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(_proveedorSeleccionadoId.HasValue && ValidarCampos(true))) return;

            var proveedorAEditar = new Proveedor
            {
                Id = _proveedorSeleccionadoId.Value,
                Nombre = txtNombre.Text.Trim(),
                Empresa = txtEmpresa.Text.Trim(),
                Cuit = txtCuit.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Pais = txtPais.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            if (_proveedorDatos.ExisteCuit(proveedorAEditar.Cuit, proveedorAEditar.Id)) { lblErrorCuit.Text = "El CUIT ya está en uso."; return; }
            if (_proveedorDatos.ExisteCorreo(proveedorAEditar.Correo, proveedorAEditar.Id)) { lblErrorCorreo.Text = "El correo ya está en uso."; return; }

            if (!Confirmar($"¿Guardar cambios para {proveedorAEditar.Empresa}?")) return;

            _proveedorDatos.EditarProveedor(proveedorAEditar);
            MessageBox.Show("Proveedor editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            AplicarFiltros();
        }

        private void btnActivar_Click(object sender, EventArgs e) => CambiarEstadoProveedor(true);
        private void btnDesactivar_Click(object sender, EventArgs e) => CambiarEstadoProveedor(false);

        private void CambiarEstadoProveedor(bool activar)
        {
            if (!_proveedorSeleccionadoId.HasValue) return;

            string accion = activar ? "ACTIVAR" : "DESACTIVAR";
            if (!Confirmar($"¿Deseas {accion} este proveedor?")) return;

            _proveedorDatos.CambiarEstado(_proveedorSeleccionadoId.Value, activar);
            AplicarFiltros();

            var proveedorSeleccionado = dgvProveedores.Rows.Cast<DataGridViewRow>()
                .FirstOrDefault(r => (r.DataBoundItem as Proveedor)?.Id == _proveedorSeleccionadoId.Value);

            if (proveedorSeleccionado != null)
            {
                proveedorSeleccionado.Selected = true;
                ActualizarVisibilidadBotones(activar);
            }
            else LimpiarCampos();
        }

        #endregion

        #region VALIDACIONES Y UTILIDADES

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void LimpiarCampos()
        {
            txtNombre.Clear(); txtEmpresa.Clear(); txtCuit.Clear();
            txtTelefono.Clear(); txtDireccion.Clear(); txtPais.Clear();
            txtCiudad.Clear(); txtCorreo.Clear();

            lblErrorNombre.Text = " "; lblErrorEmpresa.Text = " "; lblErrorCuit.Text = " "; lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " "; lblErrorPais.Text = " "; lblErrorCiudad.Text = " "; lblErrorCorreo.Text = " ";

            txtNombre.Focus();
            _proveedorSeleccionadoId = null;

            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;

            dgvProveedores.ClearSelection();
        }

        private bool ValidarCampos(bool esEdicion)
        {
            bool esValido = true;

            lblErrorNombre.Text = " "; lblErrorEmpresa.Text = " "; lblErrorCuit.Text = " "; lblErrorTelefono.Text = " ";
            lblErrorDireccion.Text = " "; lblErrorPais.Text = " "; lblErrorCiudad.Text = " "; lblErrorCorreo.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtEmpresa.Text)) { lblErrorEmpresa.Text = "La empresa es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCuit.Text)) { lblErrorCuit.Text = "El CUIT es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtCuit.Text, @"^\d{2}-\d{8}-\d{1}$")) { lblErrorCuit.Text = "Formato inválido. Ej: 20-12345678-9"; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9\s-]+$")) { lblErrorTelefono.Text = "Solo números y guiones."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) { lblErrorCorreo.Text = "El correo es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { lblErrorCorreo.Text = "Correo inválido."; esValido = false; }

            return esValido;
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var prov = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;
            if (prov == null) return;

            _proveedorSeleccionadoId = prov.Id;
            txtNombre.Text = prov.Nombre;
            txtEmpresa.Text = prov.Empresa;
            txtCuit.Text = prov.Cuit;
            txtTelefono.Text = prov.Telefono;
            txtDireccion.Text = prov.Direccion;
            txtPais.Text = prov.Pais;
            txtCiudad.Text = prov.Ciudad;
            txtCorreo.Text = prov.Correo;

            ActualizarVisibilidadBotones(prov.Activo);
        }

        private void ActualizarVisibilidadBotones(bool estaActivo)
        {
            btnRegistrar.Visible = false;
            btnEditar.Visible = true;
            btnActivar.Visible = !estaActivo;
            btnDesactivar.Visible = estaActivo;
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txt_SoloNumerosYGuiones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-')) e.Handled = true;
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}