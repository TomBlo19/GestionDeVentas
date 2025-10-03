using GestionDeVentas.Modelos;
using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormGestionarUsuarios : Form
    {
        private readonly ClienteDatos clienteDatos = new ClienteDatos();
        private List<Cliente> clientes = new List<Cliente>();

        private const string PLACEHOLDER = "Buscar por DNI o Apellido...";

        public FormGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            txtBusqueda.Text = PLACEHOLDER;
            txtBusqueda.ForeColor = Color.Gray;
            cmbFiltroEstado.SelectedIndex = 0;

            ConfigurarColumnas();
            CargarClientes();
            AplicarFiltros();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                Visible = false
            };
            dgvUsuarios.Columns.Add(colId);

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dni", HeaderText = "DNI" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", HeaderText = "Apellido" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Correo", HeaderText = "Correo" });
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado" });
        }

        private void CargarClientes()
        {
            clientes = clienteDatos.ObtenerClientes();
        }

        private void AplicarFiltros()
        {
            string texto = txtBusqueda.Text.Trim().ToLower();
            if (texto == PLACEHOLDER.ToLower()) texto = string.Empty;

            string estadoFiltro = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

            var filtrados = clientes.Where(u =>
                (string.IsNullOrEmpty(texto) ||
                    u.Dni.ToLower().Contains(texto) ||
                    u.Apellido.ToLower().Contains(texto)) &&
                (estadoFiltro == "Todos" ||
                 (estadoFiltro == "Activo" && u.Activo) ||
                 (estadoFiltro == "Inactivo" && !u.Activo))
            ).ToList();

            CargarEnGrid(filtrados);
        }

        private void CargarEnGrid(List<Cliente> lista)
        {
            dgvUsuarios.Rows.Clear();
            foreach (var u in lista)
            {
                string estado = u.Activo ? "Activo" : "Inactivo";
                dgvUsuarios.Rows.Add(u.Id, u.Dni, u.Nombre, u.Apellido, u.Telefono, u.CorreoElectronico, estado);
            }
            dgvUsuarios.ClearSelection();
            ActualizarBotonAccion();
        }

        // ===================== Eventos UI =====================

        private void txtBusqueda_TextChanged(object sender, EventArgs e) => AplicarFiltros();

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

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e) => ActualizarBotonAccion();

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
            var user = clientes.FirstOrDefault(x => x.Id == id);
            if (user == null) return;

            if (user.Activo)
            {
                var ok = MessageBox.Show(
                    $"¿Deseas DESACTIVAR al cliente {user.Apellido}, {user.Nombre} (DNI {user.Dni})?",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (ok == DialogResult.Yes)
                {
                    clienteDatos.CambiarEstado(user.Id, false);
                    user.Activo = false;
                    AplicarFiltros();
                    MessageBox.Show("Cliente desactivado.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                var ok = MessageBox.Show(
                    $"¿Deseas ACTIVAR nuevamente al cliente {user.Apellido}, {user.Nombre} (DNI {user.Dni})?",
                    "Confirmar activación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    clienteDatos.CambiarEstado(user.Id, true);
                    user.Activo = true;
                    AplicarFiltros();
                    MessageBox.Show("Cliente activado.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                if (string.Equals(e.Value.ToString(), "Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // letras blancas sobre fondo rojo
                }
                else
                {
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        // ===================== Helpers =====================

        private void ActualizarBotonAccion()
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                btnAccion.Enabled = false;
                btnAccion.Text = "Desactivar/Activar";
                btnAccion.BackColor = Color.Gray;
                return;
            }

            btnAccion.Enabled = true;
            var estado = dgvUsuarios.SelectedRows[0].Cells["Estado"].Value?.ToString();
            if (estado == "Inactivo")
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
    }
}
