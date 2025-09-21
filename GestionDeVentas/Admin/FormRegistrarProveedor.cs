using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    public partial class FormRegistrarProveedor : Form
    {
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        private int? proveedorSeleccionadoId = null;

        public FormRegistrarProveedor()
        {
            InitializeComponent();
            ConfigurarDataGridView();

            // Validaciones de tipeo
            this.txtNombre.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtEmpresa.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtPais.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtCiudad.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
            this.txtDni.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtTelefono.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
        }

        private void FormRegistrarProveedor_Load(object sender, EventArgs e)
        {
            btnCerrar.BringToFront();

            // Datos de ejemplo
            listaProveedores.Add(new Proveedor { Nombre = "Juan", Empresa = "Tech Solutions", Dni = "20-12345678-9", Telefono = "1133445566", Direccion = "Calle Proveedor 101", Pais = "Argentina", Ciudad = "Córdoba", FechaInicioRelacion = new DateTime(2020, 1, 15), Activo = true });
            listaProveedores.Add(new Proveedor { Nombre = "Ana", Empresa = "Global Suministros", Dni = "30-98765432-1", Telefono = "1199887766", Direccion = "Avenida Industrial 500", Pais = "Brasil", Ciudad = "Sao Paulo", FechaInicioRelacion = new DateTime(2018, 5, 20), Activo = false });
            listaProveedores.Add(new Proveedor { Nombre = "Pedro", Empresa = "Materiales del Sur", Dni = "27-55443322-3", Telefono = "1122334455", Direccion = "Ruta 3 Sur", Pais = "Chile", Ciudad = "Valparaíso", FechaInicioRelacion = new DateTime(2022, 10, 30), Activo = true });

            ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.AllowUserToResizeRows = false;
            dgvProveedores.AllowUserToResizeColumns = true;
            dgvProveedores.ReadOnly = true;

            dgvProveedores.CellFormatting += dgvProveedores_CellFormatting;
        }

        private void ActualizarDataGridView()
        {
            dgvProveedores.Rows.Clear();
            foreach (var proveedor in listaProveedores)
            {
                string estado = proveedor.Activo ? "Activo" : "Inactivo";
                dgvProveedores.Rows.Add(proveedor.Id, proveedor.Nombre, proveedor.Empresa, proveedor.Dni,
                                         proveedor.Telefono, proveedor.Direccion, proveedor.Pais,
                                         proveedor.Ciudad, proveedor.FechaInicioRelacion.ToShortDateString(), estado);
            }
        }

        // 🔹 Helper confirmación
        private bool Confirmar(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(false)) return;
            if (!Confirmar("¿Deseas registrar este proveedor?")) return;

            var nuevoProveedor = new Proveedor
            {
                Nombre = txtNombre.Text,
                Empresa = txtEmpresa.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Pais = txtPais.Text,
                Ciudad = txtCiudad.Text,
                FechaInicioRelacion = dtpFechaInicioRelacion.Value
            };

            listaProveedores.Add(nuevoProveedor);
            MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            ActualizarDataGridView();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(proveedorSeleccionadoId.HasValue && ValidarCampos(true))) return;

            var proveedorAEditar = listaProveedores.FirstOrDefault(p => p.Id == proveedorSeleccionadoId.Value);
            if (proveedorAEditar == null) return;

            if (!Confirmar($"¿Guardar cambios para el proveedor {proveedorAEditar.Empresa}?")) return;

            proveedorAEditar.Nombre = txtNombre.Text;
            proveedorAEditar.Empresa = txtEmpresa.Text;
            proveedorAEditar.Dni = txtDni.Text;
            proveedorAEditar.Telefono = txtTelefono.Text;
            proveedorAEditar.Direccion = txtDireccion.Text;
            proveedorAEditar.Pais = txtPais.Text;
            proveedorAEditar.Ciudad = txtCiudad.Text;
            proveedorAEditar.FechaInicioRelacion = dtpFechaInicioRelacion.Value;

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
            if (proveedorSeleccionadoId.HasValue)
            {
                var proveedor = listaProveedores.FirstOrDefault(p => p.Id == proveedorSeleccionadoId.Value);
                if (proveedor != null)
                {
                    if (proveedor.Activo)
                    {
                        MessageBox.Show("El proveedor ya está activo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Confirmar($"¿Deseas activar al proveedor {proveedor.Empresa}?"))
                    {
                        proveedor.Activo = true;
                        MessageBox.Show("Proveedor activado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarDataGridView();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un proveedor para activar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionadoId.HasValue)
            {
                var proveedor = listaProveedores.FirstOrDefault(p => p.Id == proveedorSeleccionadoId.Value);
                if (proveedor != null)
                {
                    if (!proveedor.Activo)
                    {
                        MessageBox.Show("El proveedor ya está inactivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Confirmar($"¿Deseas desactivar al proveedor {proveedor.Empresa}?"))
                    {
                        proveedor.Activo = false;
                        MessageBox.Show("Proveedor desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarDataGridView();
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un proveedor para desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            lblErrorFechaInicioRelacion.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { lblErrorNombre.Text = "El nombre es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtEmpresa.Text)) { lblErrorEmpresa.Text = "El nombre de la empresa es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { lblErrorDni.Text = "El DNI/CUIT es obligatorio."; esValido = false; }
            else if (listaProveedores.Any(p => p.Dni == txtDni.Text && (!esEdicion || p.Id != proveedorSeleccionadoId)))
            { lblErrorDni.Text = "Este DNI/CUIT ya existe."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) { lblErrorTelefono.Text = "El teléfono es obligatorio."; esValido = false; }
            else if (!Regex.IsMatch(txtTelefono.Text, @"^\d+$")) { lblErrorTelefono.Text = "El teléfono solo puede contener números."; esValido = false; }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text)) { lblErrorDireccion.Text = "La dirección es obligatoria."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtPais.Text)) { lblErrorPais.Text = "El país es obligatorio."; esValido = false; }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text)) { lblErrorCiudad.Text = "La ciudad es obligatoria."; esValido = false; }
            if (dtpFechaInicioRelacion.Value > DateTime.Now) { lblErrorFechaInicioRelacion.Text = "La fecha no es válida."; esValido = false; }

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
            dtpFechaInicioRelacion.Value = DateTime.Now;
            txtNombre.Focus();

            proveedorSeleccionadoId = null;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaProveedores.Count)
            {
                var proveedorSeleccionado = listaProveedores[e.RowIndex];
                proveedorSeleccionadoId = proveedorSeleccionado.Id;

                txtNombre.Text = proveedorSeleccionado.Nombre;
                txtEmpresa.Text = proveedorSeleccionado.Empresa;
                txtDni.Text = proveedorSeleccionado.Dni;
                txtTelefono.Text = proveedorSeleccionado.Telefono;
                txtDireccion.Text = proveedorSeleccionado.Direccion;
                txtPais.Text = proveedorSeleccionado.Pais;
                txtCiudad.Text = proveedorSeleccionado.Ciudad;
                dtpFechaInicioRelacion.Value = proveedorSeleccionado.FechaInicioRelacion;

                btnRegistrar.Visible = false;
                btnEditar.Visible = true;
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void dgvProveedores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProveedores.Columns[e.ColumnIndex].Name == "colEstado" && e.Value != null)
            {
                if (e.Value.ToString() == "Inactivo")
                {
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgvProveedores.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-')) e.Handled = true;
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ') e.Handled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Confirmar("¿Seguro que deseas cerrar esta ventana?", "Cerrar"))
                this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }
    }

    public class Proveedor
    {
        private static int IdCounter = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaInicioRelacion { get; set; }
        public bool Activo { get; set; } = true;

        public Proveedor() { Id = ++IdCounter; }
    }
}