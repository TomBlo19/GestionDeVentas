using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            dataTableUsuarios.Columns.Add("ID", typeof(int));
            dataTableUsuarios.Columns.Add("Nombre", typeof(string));
            dataTableUsuarios.Columns.Add("Apellido", typeof(string));
            dataTableUsuarios.Columns.Add("Email", typeof(string));
            dataTableUsuarios.Columns.Add("Tipo", typeof(string)); // Administrador, Vendedor, Cliente

            dataGridViewUsuarios.DataSource = dataTableUsuarios;
        }

        private void CargarDatosDeEjemplo()
        {
            dataTableUsuarios.Rows.Clear();
            dataTableUsuarios.Rows.Add(1, "Ana", "Torres", "ana.t@email.com", "Vendedor");
            dataTableUsuarios.Rows.Add(2, "Juan", "Pérez", "juan.p@email.com", "Vendedor");
            dataTableUsuarios.Rows.Add(3, "Sofía", "García", "sofia.g@email.com", "Vendedor");
            dataTableUsuarios.Rows.Add(4, "Carlos", "López", "carlos.l@email.com", "Cliente");
            dataTableUsuarios.Rows.Add(5, "María", "González", "maria.g@email.com", "Cliente");
            dataTableUsuarios.Rows.Add(6, "Pedro", "Rodríguez", "pedro.r@email.com", "Cliente");
            dataTableUsuarios.Rows.Add(7, "Luis", "Martínez", "luis.m@email.com", "Administrador");
        }

        private void CargarFiltros()
        {
            // Carga los tipos de usuario únicos (excluyendo Gerente)
            var tiposUsuario = dataTableUsuarios.AsEnumerable()
                                               .Select(row => row.Field<string>("Tipo"))
                                               .Distinct()
                                               .ToList();
            tiposUsuario.Sort();
            cmbTipoUsuario.Items.Clear();
            cmbTipoUsuario.Items.Add("Todos");
            cmbTipoUsuario.Items.AddRange(tiposUsuario.ToArray());
            cmbTipoUsuario.SelectedIndex = 0; // Selecciona "Todos" por defecto
        }

        private void AplicarFiltros()
        {
            string filtroNombre = txtBuscarNombre.Text.Trim();
            string filtroTipoUsuario = cmbTipoUsuario.SelectedItem?.ToString();

            StringBuilder rowFilter = new StringBuilder();

            // Filtro por nombre o apellido
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                rowFilter.Append($"Nombre LIKE '%{filtroNombre.Replace("'", "''")}%' OR Apellido LIKE '%{filtroNombre.Replace("'", "''")}%'");
            }

            // Filtro por tipo de usuario
            if (filtroTipoUsuario != "Todos" && !string.IsNullOrEmpty(filtroTipoUsuario))
            {
                if (rowFilter.Length > 0) rowFilter.Append(" AND ");
                rowFilter.Append($"Tipo = '{filtroTipoUsuario.Replace("'", "''")}'");
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
    }
}