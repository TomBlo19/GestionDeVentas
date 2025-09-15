using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionDeVentas.Modelos;   




namespace GestionDeVentas.Admin
{
    public partial class ListarUsuario : Form
    {
        private DataTable dataTableUsuarios = new DataTable();
        private UsuarioDatos usuarioDatos = new UsuarioDatos();

        public ListarUsuario()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ListarUsuario_Load(object sender, EventArgs e)
        {
            CargarColumnas();
            CargarDatosDesdeBD(); // 👈 ahora traemos datos reales
            CargarFiltros();
            dataGridViewUsuarios.Dock = DockStyle.Fill;
            dataGridViewUsuarios.BringToFront();
        }

        private void CargarColumnas()
        {
            dataTableUsuarios.Columns.Clear();
            dataTableUsuarios.Columns.Add("DNI", typeof(string));
            dataTableUsuarios.Columns.Add("Nombre", typeof(string));
            dataTableUsuarios.Columns.Add("Apellido", typeof(string));
            dataTableUsuarios.Columns.Add("Telefono", typeof(string));
            dataTableUsuarios.Columns.Add("Rol", typeof(string));
            dataTableUsuarios.Columns.Add("Estado", typeof(string));

            dataGridViewUsuarios.DataSource = dataTableUsuarios;
        }

        private void CargarDatosDesdeBD()
        {
            dataTableUsuarios.Rows.Clear();

            List<Usuario> usuarios = usuarioDatos.ObtenerUsuarios();

            foreach (var u in usuarios)
            {
                dataTableUsuarios.Rows.Add(
                    u.DNI,
                    u.Nombre,
                    u.Apellido,
                    u.Telefono,
                    u.Rol,
                    u.ActivoTexto
                );
            }
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

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].DataPropertyName == "Estado")
            {
                var estado = e.Value?.ToString()?.Trim();

                if (string.Equals(estado, "Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridViewUsuarios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
