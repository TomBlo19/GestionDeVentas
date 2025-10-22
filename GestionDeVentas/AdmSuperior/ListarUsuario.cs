using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GestionDeVentas.Modelos;

namespace GestionDeVentas.Admin
{
    public partial class ListarUsuario : Form
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();
        private List<Usuario> _listaMaestraUsuarios;

        public ListarUsuario()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ListarUsuario_Load(object sender, EventArgs e)
        {
            _listaMaestraUsuarios = _usuarioDatos.ObtenerUsuarios();

            ConfigurarDataGridView();
            CargarFiltros();
            ConectarEventosDeFiltro();
            AplicarFiltros();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewUsuarios.AutoGenerateColumns = false;
            dataGridViewUsuarios.Columns.Clear();

            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "DNI", DataPropertyName = "DNI", HeaderText = "DNI" });
            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Apellido", DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Rol", DataPropertyName = "Rol", HeaderText = "Rol" });
            dataGridViewUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", DataPropertyName = "ActivoTexto", HeaderText = "Estado" });
        }

        private void CargarFiltros()
        {
            cboBuscarPor.Items.Clear();
            cboBuscarPor.Items.Add("Apellido");
            cboBuscarPor.Items.Add("DNI");
            cboBuscarPor.SelectedIndex = 0;

            var roles = _listaMaestraUsuarios.Select(u => u.Rol).Distinct().ToList();
            roles.Sort();
            cmbFiltrarRol.Items.Clear();
            cmbFiltrarRol.Items.Add("Todos");
            cmbFiltrarRol.Items.AddRange(roles.ToArray());
            cmbFiltrarRol.SelectedIndex = 0;

            cmbFiltrarEstado.Items.Clear();
            cmbFiltrarEstado.Items.Add("Todos");
            cmbFiltrarEstado.Items.Add("Activo");
            cmbFiltrarEstado.Items.Add("Inactivo");
            cmbFiltrarEstado.SelectedIndex = 0;
        }

        private void ConectarEventosDeFiltro()
        {
            txtFiltro.TextChanged += (s, e) => AplicarFiltros();
            cboBuscarPor.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbFiltrarRol.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbFiltrarEstado.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (_listaMaestraUsuarios == null) return;

            string filtroTexto = txtFiltro.Text.Trim().ToLower();
            string criterioBusqueda = cboBuscarPor.SelectedItem?.ToString();
            string filtroRol = cmbFiltrarRol.SelectedItem?.ToString();
            string filtroEstado = cmbFiltrarEstado.SelectedItem?.ToString();

            IEnumerable<Usuario> usuariosFiltrados = _listaMaestraUsuarios;

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                if (criterioBusqueda == "DNI")
                {
                    usuariosFiltrados = usuariosFiltrados.Where(u => u.DNI.Contains(filtroTexto));
                }
                else // Apellido
                {
                    usuariosFiltrados = usuariosFiltrados.Where(u => u.Apellido.ToLower().Contains(filtroTexto));
                }
            }
            if (filtroRol != "Todos")
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.Rol == filtroRol);
            }
            if (filtroEstado != "Todos")
            {
                usuariosFiltrados = usuariosFiltrados.Where(u => u.ActivoTexto == filtroEstado);
            }

            dataGridViewUsuarios.DataSource = usuariosFiltrados.ToList();
        }

        private void dataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var usuario = dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem as Usuario;
            if (usuario != null)
            {
                if (!usuario.Activo)
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = SystemColors.Window;
                    e.CellStyle.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}