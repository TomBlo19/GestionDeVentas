using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Modelos;

namespace GestionDeVentas.Admin
{
    public partial class FormGestionarUsuarios : Form
    {
        private readonly ClienteDatos clienteDatos = new ClienteDatos();
        private List<Cliente> _listaMaestraClientes;

        private const string PLACEHOLDER = "Escriba para buscar...";

        public FormGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            txtBusqueda.Text = PLACEHOLDER;
            txtBusqueda.ForeColor = Color.Gray;

            // ✅ CORRECCIÓN EN EL ORDEN DE CARGA
            // 1. Cargar los datos PRIMERO para que la lista maestra no sea nula.
            _listaMaestraClientes = clienteDatos.ObtenerClientes();

            // 2. Configurar todos los controles.
            ConfigurarColumnas();
            CargarFiltros();

            // 3. Conectar los eventos DESPUÉS de que los combos ya tienen un valor.
            ConectarEventosDeFiltro();

            // 4. Aplicar el filtro inicial con los datos ya cargados.
            AplicarFiltros();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", HeaderText = "ID", Visible = false });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dni", DataPropertyName = "Dni", HeaderText = "DNI" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Correo", DataPropertyName = "CorreoElectronico", HeaderText = "Correo" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", DataPropertyName = "ActivoTexto", HeaderText = "Estado" });
        }

        private void CargarFiltros()
        {
            cboBuscarPor.Items.Add("Apellido");
            cboBuscarPor.Items.Add("DNI");
            cboBuscarPor.SelectedIndex = 0;

            cmbFiltroEstado.SelectedIndex = 0;
        }

        private void ConectarEventosDeFiltro()
        {
            txtBusqueda.TextChanged += (s, e) => AplicarFiltros();
            cboBuscarPor.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbFiltroEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            // ✅ GUARDA DE SEGURIDAD: Si por alguna razón este método se llama antes de
            // que la lista esté cargada, simplemente no hace nada y evita el error.
            if (_listaMaestraClientes == null) return;

            string textoBusqueda = (txtBusqueda.Text == PLACEHOLDER) ? string.Empty : txtBusqueda.Text.Trim();
            string estadoFiltro = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";
            string criterioBusqueda = cboBuscarPor.SelectedItem?.ToString() ?? "Apellido";

            List<Cliente> clientesDesdeBD;

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                clientesDesdeBD = _listaMaestraClientes;
            }
            else
            {
                if (criterioBusqueda == "DNI")
                {
                    clientesDesdeBD = clienteDatos.BuscarClientesPorDni(textoBusqueda);
                }
                else
                {
                    clientesDesdeBD = clienteDatos.BuscarClientesPorApellido(textoBusqueda);
                }
            }

            IEnumerable<Cliente> clientesFiltrados = clientesDesdeBD;
            if (estadoFiltro != "Todos")
            {
                bool buscarActivos = (estadoFiltro == "Activo");
                clientesFiltrados = clientesFiltrados.Where(c => c.Activo == buscarActivos);
            }

            CargarEnGrid(clientesFiltrados.ToList());
        }

        private void CargarEnGrid(List<Cliente> lista)
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;
            dgvUsuarios.ClearSelection();
            ActualizarBotonAccion();
        }

        #region Eventos UI

        private void txtBusqueda_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == PLACEHOLDER)
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = Color.Black;
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = PLACEHOLDER;
                txtBusqueda.ForeColor = Color.Gray;
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e) => ActualizarBotonAccion();

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
            var user = _listaMaestraClientes.FirstOrDefault(x => x.Id == id);
            if (user == null) return;

            bool accionEsActivar = !user.Activo;
            string accionTexto = accionEsActivar ? "ACTIVAR" : "DESACTIVAR";
            string confirmacionMsg = $"¿Deseas {accionTexto} al cliente {user.Apellido}, {user.Nombre} (DNI {user.Dni})?";

            var result = MessageBox.Show(confirmacionMsg, $"Confirmar {accionTexto.ToLower()}",
                                         MessageBoxButtons.YesNo,
                                         accionEsActivar ? MessageBoxIcon.Question : MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                clienteDatos.CambiarEstado(user.Id, accionEsActivar);
                user.Activo = accionEsActivar;

                _listaMaestraClientes = clienteDatos.ObtenerClientes();
                AplicarFiltros();

                MessageBox.Show($"Cliente {(accionEsActivar ? "activado" : "desactivado")}.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cliente = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as Cliente;
            if (cliente != null)
            {
                e.CellStyle.BackColor = SystemColors.Window;
                e.CellStyle.ForeColor = SystemColors.ControlText;
                e.CellStyle.SelectionBackColor = SystemColors.Highlight;
                e.CellStyle.SelectionForeColor = SystemColors.HighlightText;

                if (!cliente.Activo)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.DarkRed;
                    e.CellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        #endregion

        #region Helpers

        private void ActualizarBotonAccion()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                btnAccion.Enabled = false;
                btnAccion.Text = "Seleccione un cliente";
                btnAccion.BackColor = Color.Gray;
                return;
            }

            btnAccion.Enabled = true;
            var clienteSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Cliente;
            if (clienteSeleccionado != null && !clienteSeleccionado.Activo)
            {
                btnAccion.Text = "Activar Cliente";
                btnAccion.BackColor = Color.FromArgb(0, 160, 60);
            }
            else
            {
                btnAccion.Text = "Desactivar Cliente";
                btnAccion.BackColor = Color.FromArgb(200, 0, 0);
            }
        }

        #endregion
    }
}