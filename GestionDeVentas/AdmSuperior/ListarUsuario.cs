using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class ListarUsuario : Form
    {
        private DataTable dataTableUsuarios = new DataTable();

        public ListarUsuario()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ListarUsuario_Load(object sender, EventArgs e)
        {
            CargarColumnas();
            CargarDatosDeEjemplo();
            CargarFiltros();
            dataGridViewUsuarios.Dock = DockStyle.Fill;
            dataGridViewUsuarios.BringToFront();
        }

        private void CargarColumnas()
        {
            dataTableUsuarios.Columns.Add("DNI", typeof(string));
            dataTableUsuarios.Columns.Add("Nombre", typeof(string));
            dataTableUsuarios.Columns.Add("Apellido", typeof(string));
            dataTableUsuarios.Columns.Add("Telefono", typeof(string));
            dataTableUsuarios.Columns.Add("Rol", typeof(string));
            dataTableUsuarios.Columns.Add("Estado", typeof(string));

            dataGridViewUsuarios.DataSource = dataTableUsuarios;
        }

        private void CargarDatosDeEjemplo()
        {
            dataTableUsuarios.Rows.Clear();
            dataTableUsuarios.Rows.Add("12345678", "Ana", "Torres", "1122334455", "Vendedor", "Activo");
            dataTableUsuarios.Rows.Add("87654321", "Juan", "Pérez", "2233445566", "Vendedor", "Activo");
            dataTableUsuarios.Rows.Add("33445566", "Sofía", "García", "3344556677", "Vendedor", "Activo");
            dataTableUsuarios.Rows.Add("44556677", "Carlos", "López", "4455667788", "Gerente", "Inactivo");
            dataTableUsuarios.Rows.Add("55667788", "María", "González", "5566778899", "Cliente", "Activo");
            dataTableUsuarios.Rows.Add("66778899", "Pedro", "Rodríguez", "6677889900", "Cliente", "Activo");
            dataTableUsuarios.Rows.Add("77889900", "Luis", "Martínez", "7788990011", "Administrador", "Inactivo");
        }

        private void CargarFiltros()
        {
            var roles = dataTableUsuarios.AsEnumerable()
                                         .Select(row => row.Field<string>("Rol"))
                                         .Distinct()
                                         .ToList();
            roles.Sort();

            cmbTipoUsuario.Items.Clear();
            cmbTipoUsuario.Items.Add("Todos");
            cmbTipoUsuario.Items.AddRange(roles.ToArray());
            cmbTipoUsuario.SelectedIndex = 0;
        }

        private void AplicarFiltros()
        {
            string filtroNombre = txtBuscarNombre.Text.Trim();
            string filtroRol = cmbTipoUsuario.SelectedItem?.ToString();

            StringBuilder rowFilter = new StringBuilder();

            if (!string.IsNullOrEmpty(filtroNombre))
            {
                rowFilter.Append($"Nombre LIKE '%{filtroNombre.Replace("'", "''")}%' OR Apellido LIKE '%{filtroNombre.Replace("'", "''")}%'");
            }

            if (filtroRol != "Todos" && !string.IsNullOrEmpty(filtroRol))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Rol = '{filtroRol.Replace("'", "''")}'");
            }

            dataTableUsuarios.DefaultView.RowFilter = rowFilter.Length > 0 ? rowFilter.ToString() : string.Empty;
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].DataPropertyName == "Estado")
            {
                var estado = e.Value?.ToString()?.Trim();

                if (string.Equals(estado, "Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
