using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormGestionarUsuarios : Form
    {
        private readonly List<ClienteDemo> usuarios = new List<ClienteDemo>();
        private int nextId = 1;

        private const string PLACEHOLDER = "Buscar por DNI o Apellido...";

        public FormGestionarUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionarUsuarios_Load(object sender, EventArgs e)
        {
            // Placeholder manual
            txtBusqueda.Text = PLACEHOLDER;
            txtBusqueda.ForeColor = Color.Gray;

            // Estado por defecto
            cmbFiltroEstado.SelectedIndex = 0;

            // Columnas
            ConfigurarColumnas();

            // Datos demo
            CargarDatosDemo();

            // Pintar
            AplicarFiltros();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.Columns.Clear();

            // Columna ID (oculta)
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

        private void CargarDatosDemo()
        {
            usuarios.Clear();
            usuarios.Add(new ClienteDemo { Id = nextId++, Dni = "12345678", Nombre = "María", Apellido = "González", Telefono = "11223344", Correo = "maria@mail.com", Estado = "Activo" });
            usuarios.Add(new ClienteDemo { Id = nextId++, Dni = "87654321", Nombre = "Carlos", Apellido = "López", Telefono = "22334455", Correo = "carlos@mail.com", Estado = "Inactivo" });
            usuarios.Add(new ClienteDemo { Id = nextId++, Dni = "45678912", Nombre = "Ana", Apellido = "Martínez", Telefono = "33445566", Correo = "ana@mail.com", Estado = "Activo" });
            usuarios.Add(new ClienteDemo { Id = nextId++, Dni = "11223344", Nombre = "Pedro", Apellido = "Suárez", Telefono = "44556677", Correo = "pedro@mail.com", Estado = "Activo" });
        }

        private void AplicarFiltros()
        {
            string texto = txtBusqueda.Text.Trim().ToLower();
            if (texto == PLACEHOLDER.ToLower()) texto = string.Empty;

            string estado = cmbFiltroEstado.SelectedItem?.ToString() ?? "Todos";

            var filtrados = usuarios.Where(u =>
                (string.IsNullOrEmpty(texto) ||
                    u.Dni.ToLower().Contains(texto) ||
                    u.Apellido.ToLower().Contains(texto)) &&
                (estado == "Todos" || u.Estado == estado)
            ).ToList();

            CargarEnGrid(filtrados);
        }

        private void CargarEnGrid(List<ClienteDemo> lista)
        {
            dgvUsuarios.Rows.Clear();
            foreach (var u in lista)
            {
                dgvUsuarios.Rows.Add(u.Id, u.Dni, u.Nombre, u.Apellido, u.Telefono, u.Correo, u.Estado);
            }

            // Actualizar botón según selección actual
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
            var user = usuarios.FirstOrDefault(x => x.Id == id);
            if (user == null) return;

            if (user.Estado == "Activo")
            {
                // Confirmación para DESACTIVAR
                var ok = MessageBox.Show(
                    $"¿Estás seguro de DESACTIVAR al cliente {user.Apellido}, {user.Nombre} (DNI {user.Dni})?",
                    "Confirmar desactivación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (ok == DialogResult.Yes)
                {
                    user.Estado = "Inactivo";
                    AplicarFiltros();
                    MessageBox.Show("Cliente desactivado.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Confirmación para ACTIVAR
                var ok = MessageBox.Show(
                    $"¿Activar nuevamente al cliente {user.Apellido}, {user.Nombre} (DNI {user.Dni})?",
                    "Confirmar activación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    user.Estado = "Activo";
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
                    dgvUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
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

        private void panelFiltros_Paint(object sender, PaintEventArgs e) { }
        private void panelTop_Paint(object sender, PaintEventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    // 🔹 Clase auxiliar SOLO para este formulario
    public class ClienteDemo
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }   // "Activo" | "Inactivo"
    }
}
