using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.AdmSuperior
{
    public partial class FormGestionarUsuarios : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private int nextId = 1;

        public FormGestionarUsuarios()
        {
            InitializeComponent();

            // ✅ Placeholder manual
            txtBusqueda.Text = "Buscar usuario...";
            txtBusqueda.ForeColor = Color.Gray;

            txtBusqueda.Enter += (s, e) =>
            {
                if (txtBusqueda.Text == "Buscar usuario...")
                {
                    txtBusqueda.Text = "";
                    txtBusqueda.ForeColor = Color.Black;
                }
            };

            txtBusqueda.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
                {
                    txtBusqueda.Text = "Buscar usuario...";
                    txtBusqueda.ForeColor = Color.Gray;
                }
            };

            CargarDatosDePrueba();
            CargarUsuariosEnDGV(usuarios);
            cmbFiltroRol.SelectedIndex = 0;
            cmbFiltroEstado.SelectedIndex = 0;
        }

        private void CargarDatosDePrueba()
        {
            if (usuarios.Count == 0)
            {
                usuarios.Add(new Usuario { Id = nextId++, Nombre = "maria", Rol = "Vendedor", Estado = "Activo", UltimoAcceso = DateTime.Now.AddDays(-1) });
                usuarios.Add(new Usuario { Id = nextId++, Nombre = "carlos", Rol = "Gerente", Estado = "Activo", UltimoAcceso = DateTime.Now.AddDays(-2) });
                usuarios.Add(new Usuario { Id = nextId++, Nombre = "admin", Rol = "Administrador", Estado = "Activo", UltimoAcceso = DateTime.Now });
                usuarios.Add(new Usuario { Id = nextId++, Nombre = "super", Rol = "Admin Superior", Estado = "Inactivo", UltimoAcceso = DateTime.Now.AddMonths(-1) });
            }
        }

        private void CargarUsuariosEnDGV(List<Usuario> lista)
        {
            dgvUsuarios.Rows.Clear();
            foreach (var u in lista)
            {
                dgvUsuarios.Rows.Add(u.Id, u.Nombre, u.Rol, u.Estado, u.UltimoAcceso);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBusqueda.Text.ToLower();
            string rol = cmbFiltroRol.SelectedItem?.ToString();
            string estado = cmbFiltroEstado.SelectedItem?.ToString();

            var filtrados = usuarios.Where(u =>
                (string.IsNullOrWhiteSpace(busqueda) || u.Nombre.ToLower().Contains(busqueda)) &&
                (rol == "Todos" || u.Rol == rol) &&
                (estado == "Todos" || u.Estado == estado)
            ).ToList();

            CargarUsuariosEnDGV(filtrados);
        }

        private bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ConfirmarAccion("¿Seguro que deseas agregar un nuevo usuario?")) return;

            usuarios.Add(new Usuario { Id = nextId++, Nombre = "nuevoUser", Rol = "Vendedor", Estado = "Activo", UltimoAcceso = DateTime.Now });
            CargarUsuariosEnDGV(usuarios);
            MessageBox.Show("Usuario agregado.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
                var user = usuarios.FirstOrDefault(x => x.Id == id);

                if (user != null && ConfirmarAccion($"¿Seguro que deseas editar al usuario {user.Nombre}?"))
                {
                    MessageBox.Show($"Aquí deberías abrir el formulario de edición para: {user.Nombre}");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
                var user = usuarios.FirstOrDefault(x => x.Id == id);

                if (user != null && ConfirmarAccion($"¿Seguro que deseas eliminar al usuario {user.Nombre}?"))
                {
                    usuarios.Remove(user);
                    CargarUsuariosEnDGV(usuarios);
                    MessageBox.Show("Usuario eliminado.");
                }
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
                var user = usuarios.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    string nuevoEstado = user.Estado == "Activo" ? "Inactivo" : "Activo";
                    if (ConfirmarAccion($"¿Seguro que deseas cambiar el estado de {user.Nombre} a {nuevoEstado}?"))
                    {
                        user.Estado = nuevoEstado;
                        CargarUsuariosEnDGV(usuarios);
                    }
                }
            }
        }

        private void btnResetClave_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsuarios.SelectedRows[0].Cells["Id"].Value;
                var user = usuarios.FirstOrDefault(x => x.Id == id);

                if (user != null && ConfirmarAccion($"¿Seguro que deseas resetear la contraseña de {user.Nombre}?"))
                {
                    MessageBox.Show("Contraseña reseteada (clave temporal asignada).");
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e) => AplicarFiltros();
        private void cmbFiltroRol_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e) => AplicarFiltros();
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public DateTime UltimoAcceso { get; set; }
    }
}
