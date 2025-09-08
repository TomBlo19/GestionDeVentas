using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        private bool isEditing = false;
        private int currentProductId;

        // Lista estática para almacenar los productos. Usamos un tipo anónimo para simular la estructura del objeto.
        private static List<dynamic> productos = new List<dynamic>();
        private int nextId = 1;

        public FormRegistrarProducto()
        {
            InitializeComponent();
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            // Inicializar los ComboBox con datos manuales.
            var talles = new[] { "XS", "S", "M", "L", "XL", "XXL" };
            cmbTalle.Items.AddRange(talles);

            var categorias = new[] { "Remeras", "Pantalones", "Hobbies", "Camperas" };
            cmbCategoria.Items.AddRange(categorias);

            // Configurar los ComboBox de filtros
            cmbFiltroCategoria.Items.Add("Todos");
            cmbFiltroCategoria.Items.AddRange(categorias);
            cmbFiltroCategoria.SelectedIndex = 0;

            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");
            cmbFiltroEstado.SelectedIndex = 0;

            CargarDatosDePrueba();
        }

        private void CargarDatosDePrueba()
        {
            // Llenar la lista con datos de prueba si está vacía.
            if (productos.Count == 0)
            {
                productos.Add(new { Id = nextId++, Nombre = "Remera Básica", Codigo = "REM001", Descripcion = "", Talle = "M", Categoria = "Remeras", Color = "Azul", Marca = "", Precio = 15.00m, Stock = 10, Estado = "Activo" });
                productos.Add(new { Id = nextId++, Nombre = "Pantalón Cargo", Codigo = "PAN002", Descripcion = "", Talle = "L", Categoria = "Pantalones", Color = "Negro", Marca = "", Precio = 30.00m, Stock = 5, Estado = "Activo" });
                productos.Add(new { Id = nextId++, Nombre = "Sudadera con Capucha", Codigo = "SUD003", Descripcion = "", Talle = "XL", Categoria = "Hobbies", Color = "Gris", Marca = "", Precio = 45.00m, Stock = 2, Estado = "Inactivo" });
                productos.Add(new { Id = nextId++, Nombre = "Campera de Cuero", Codigo = "CAM004", Descripcion = "", Talle = "S", Categoria = "Camperas", Color = "Marrón", Marca = "", Precio = 80.00m, Stock = 8, Estado = "Activo" });
            }

            // Llamar al método para mostrar los productos en el DataGridView
            CargarProductosEnDGV(productos);
        }

        private void CargarProductosEnDGV(List<dynamic> listaProductos)
        {
            dgvProductos.Rows.Clear();
            foreach (var prod in listaProductos)
            {
                dgvProductos.Rows.Add(
                    prod.Id,
                    prod.Nombre,
                    prod.Talle,
                    prod.Color,
                    prod.Precio,
                    prod.Stock,
                    prod.Codigo,
                    prod.Estado
                );
            }
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cmbTalle.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            txtColor.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            // Limpiar errores
            lblErrorNombre.Text = "";
            lblErrorCodigo.Text = "";
            lblErrorDescripcion.Text = "";
            lblErrorTalle.Text = "";
            lblErrorCategoria.Text = "";
            lblErrorColor.Text = "";
            lblErrorMarca.Text = "";
            lblErrorPrecio.Text = "";
            lblErrorStock.Text = "";
        }

        private bool ValidarCampos()
        {
            bool isValid = true;
            // Validaciones básicas, puedes personalizarlas
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text)) { lblErrorNombre.Text = "Campo obligatorio"; isValid = false; } else { lblErrorNombre.Text = ""; }
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) { lblErrorCodigo.Text = "Campo obligatorio"; isValid = false; } else { lblErrorCodigo.Text = ""; }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) { lblErrorDescripcion.Text = "Campo obligatorio"; isValid = false; } else { lblErrorDescripcion.Text = ""; }
            if (cmbTalle.SelectedIndex == -1) { lblErrorTalle.Text = "Seleccione un talle"; isValid = false; } else { lblErrorTalle.Text = ""; }
            if (cmbCategoria.SelectedIndex == -1) { lblErrorCategoria.Text = "Seleccione una categoría"; isValid = false; } else { lblErrorCategoria.Text = ""; }
            if (string.IsNullOrWhiteSpace(txtColor.Text)) { lblErrorColor.Text = "Campo obligatorio"; isValid = false; } else { lblErrorColor.Text = ""; }
            if (string.IsNullOrWhiteSpace(txtMarca.Text)) { lblErrorMarca.Text = "Campo obligatorio"; isValid = false; } else { lblErrorMarca.Text = ""; }
            if (!decimal.TryParse(txtPrecio.Text, out _) || decimal.Parse(txtPrecio.Text) <= 0) { lblErrorPrecio.Text = "Precio inválido"; isValid = false; } else { lblErrorPrecio.Text = ""; }
            if (!int.TryParse(txtStock.Text, out _) || int.Parse(txtStock.Text) < 0) { lblErrorStock.Text = "Stock inválido"; isValid = false; } else { lblErrorStock.Text = ""; }

            return isValid;
        }

        private void AplicarFiltros()
        {
            string filtroBusqueda = txtFiltroBusqueda.Text.ToLower();
            string filtroCategoria = cmbFiltroCategoria.SelectedItem?.ToString();
            string filtroEstado = cmbFiltroEstado.SelectedItem?.ToString();

            // Filtrar la lista de productos
            var productosFiltrados = productos.Where(p =>
                (string.IsNullOrWhiteSpace(filtroBusqueda) || p.Nombre.ToLower().Contains(filtroBusqueda) || p.Codigo.ToLower().Contains(filtroBusqueda)) &&
                (filtroCategoria == "Todos" || p.Categoria == filtroCategoria) &&
                (filtroEstado == "Todos" || p.Estado == filtroEstado)
            ).ToList();

            // Cargar los productos filtrados en el DataGridView
            CargarProductosEnDGV(productosFiltrados);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, corrige los errores en el formulario.");
                return;
            }

            if (isEditing)
            {
                // Lógica de edición
                var productoAEditar = productos.FirstOrDefault(p => p.Id == currentProductId);
                if (productoAEditar != null)
                {
                    // Usa reflexión para actualizar las propiedades de forma dinámica
                    var newProduct = new
                    {
                        Id = currentProductId,
                        Nombre = txtNombreProducto.Text,
                        Codigo = txtCodigo.Text,
                        Descripcion = txtDescripcion.Text,
                        Talle = cmbTalle.SelectedItem.ToString(),
                        Categoria = cmbCategoria.SelectedItem.ToString(),
                        Color = txtColor.Text,
                        Marca = txtMarca.Text,
                        Precio = decimal.Parse(txtPrecio.Text),
                        Stock = int.Parse(txtStock.Text),
                        Estado = productoAEditar.Estado
                    };
                    // Reemplaza el objeto anónimo en la lista.
                    productos[productos.IndexOf(productoAEditar)] = newProduct;
                }
                MessageBox.Show("Producto editado exitosamente.");
            }
            else
            {
                // Lógica para registrar
                var nuevoProducto = new
                {
                    Id = nextId++,
                    Nombre = txtNombreProducto.Text,
                    Codigo = txtCodigo.Text,
                    Descripcion = txtDescripcion.Text,
                    Talle = cmbTalle.SelectedItem.ToString(),
                    Categoria = cmbCategoria.SelectedItem.ToString(),
                    Color = txtColor.Text,
                    Marca = txtMarca.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Estado = "Activo"
                };
                productos.Add(nuevoProducto);
                MessageBox.Show("Producto registrado exitosamente.");
            }
            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
            AplicarFiltros();
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            // Lógica para desactivar un producto.
            var productoADesactivar = productos.FirstOrDefault(p => p.Id == currentProductId);
            if (productoADesactivar != null)
            {
                // Para los objetos anónimos, no se pueden cambiar propiedades directamente.
                // La solución es crear un nuevo objeto con el estado actualizado y reemplazarlo.
                var updatedProduct = new
                {
                    productoADesactivar.Id,
                    productoADesactivar.Nombre,
                    productoADesactivar.Codigo,
                    productoADesactivar.Descripcion,
                    productoADesactivar.Talle,
                    productoADesactivar.Categoria,
                    productoADesactivar.Color,
                    productoADesactivar.Marca,
                    productoADesactivar.Precio,
                    productoADesactivar.Stock,
                    Estado = "Inactivo"
                };
                productos[productos.IndexOf(productoADesactivar)] = updatedProduct;
                MessageBox.Show("Producto desactivado exitosamente.");
            }

            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
            AplicarFiltros();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                currentProductId = Convert.ToInt32(row.Cells["Id"].Value);

                var productoSeleccionado = productos.FirstOrDefault(p => p.Id == currentProductId);
                if (productoSeleccionado != null)
                {
                    txtNombreProducto.Text = productoSeleccionado.Nombre;
                    txtCodigo.Text = productoSeleccionado.Codigo;
                    txtDescripcion.Text = productoSeleccionado.Descripcion;
                    cmbTalle.SelectedItem = productoSeleccionado.Talle;
                    cmbCategoria.SelectedItem = productoSeleccionado.Categoria;
                    txtColor.Text = productoSeleccionado.Color;
                    txtMarca.Text = productoSeleccionado.Marca;
                    txtPrecio.Text = productoSeleccionado.Precio.ToString();
                    txtStock.Text = productoSeleccionado.Stock.ToString();

                    isEditing = true;
                    btnRegistrarProducto.Text = "Guardar Cambios";
                    btnCancelarEdicion.Visible = true;
                    btnDesactivar.Visible = true;
                }
            }
        }

        private void txtFiltroBusqueda_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }
    }
}