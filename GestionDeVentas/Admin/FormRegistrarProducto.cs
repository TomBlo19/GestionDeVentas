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

        // [TRACK] bandera para saber si hay cambios sin guardar en el formulario de edición/alta
        private bool hayCambios = false;

        // Lista estática para almacenar los productos. Usamos un tipo anónimo para simular la estructura del objeto.
        private static List<dynamic> productos = new List<dynamic>();
        private int nextId = 1;

        public FormRegistrarProducto()
        {
            InitializeComponent();
            btnCancelarEdicion.Visible = false;

            // [TRACK] aviso de cierre con cambios sin guardar
            this.FormClosing += FormRegistrarProducto_FormClosing;

            // [TRACK] enganchar eventos que marcan cambios
            WireChangeTracking();
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
                productos.Add(new { Id = nextId++, Nombre = "Remera Básica", Codigo = "REM001", Descripcion = "Remera de algodón", Talle = "M", Categoria = "Remeras", Color = "Azul", Marca = "MarcaX", Precio = 15.00m, Stock = 10, Estado = "Activo", Proveedor = "Proveedor A" });
                productos.Add(new { Id = nextId++, Nombre = "Pantalón Cargo", Codigo = "PAN002", Descripcion = "Pantalón con varios bolsillos", Talle = "L", Categoria = "Pantalones", Color = "Negro", Marca = "MarcaY", Precio = 30.00m, Stock = 5, Estado = "Activo", Proveedor = "Proveedor B" });
                productos.Add(new { Id = nextId++, Nombre = "Sudadera con Capucha", Codigo = "SUD003", Descripcion = "Sudadera de lana para invierno", Talle = "XL", Categoria = "Hobbies", Color = "Gris", Marca = "MarcaZ", Precio = 45.00m, Stock = 2, Estado = "Inactivo", Proveedor = "Proveedor A" });
                productos.Add(new { Id = nextId++, Nombre = "Campera de Cuero", Codigo = "CAM004", Descripcion = "Campera de cuero sintético", Talle = "S", Categoria = "Camperas", Color = "Marrón", Marca = "MarcaX", Precio = 80.00m, Stock = 8, Estado = "Activo", Proveedor = "Proveedor C" });
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
                    prod.Estado,
                    prod.Proveedor
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
            txtProveedor.Clear();

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
            lblErrorProveedor.Text = "";
        }

        private bool ValidarCampos()
        {
            bool isValid = true;
            // Validaciones de los campos
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                lblErrorNombre.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorNombre.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                lblErrorCodigo.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorCodigo.Text = "";
            }

            // Validación de código duplicado solo si no estamos en modo edición o si el código ha cambiado
            if (!isEditing || productos.FirstOrDefault(p => p.Id == currentProductId).Codigo != txtCodigo.Text)
            {
                if (productos.Any(p => p.Codigo == txtCodigo.Text))
                {
                    lblErrorCodigo.Text = "Este código ya existe";
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                lblErrorDescripcion.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorDescripcion.Text = "";
            }

            if (cmbTalle.SelectedIndex == -1)
            {
                lblErrorTalle.Text = "Seleccione un talle";
                isValid = false;
            }
            else
            {
                lblErrorTalle.Text = "";
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                lblErrorCategoria.Text = "Seleccione una categoría";
                isValid = false;
            }
            else
            {
                lblErrorCategoria.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                lblErrorColor.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorColor.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                lblErrorMarca.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorMarca.Text = "";
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                lblErrorPrecio.Text = "Precio inválido";
                isValid = false;
            }
            else
            {
                lblErrorPrecio.Text = "";
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                lblErrorStock.Text = "Stock inválido";
                isValid = false;
            }
            else
            {
                lblErrorStock.Text = "";
            }

            if (string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                lblErrorProveedor.Text = "Campo obligatorio";
                isValid = false;
            }
            else
            {
                lblErrorProveedor.Text = "";
            }

            return isValid;
        }

        private void AplicarFiltros()
        {
            string filtroBusqueda = txtFiltroBusqueda.Text.ToLower();
            string filtroCategoria = cmbFiltroCategoria.SelectedItem?.ToString();
            string filtroEstado = cmbFiltroEstado.SelectedItem?.ToString();

            // Filtrar la lista de productos
            var productosFiltrados = productos.Where(p =>
                (string.IsNullOrWhiteSpace(filtroBusqueda) || p.Nombre.ToLower().Contains(filtroBusqueda) || p.Codigo.ToLower().Contains(filtroBusqueda) || p.Proveedor.ToLower().Contains(filtroBusqueda)) &&
                (filtroCategoria == "Todos" || p.Categoria == filtroCategoria) &&
                (filtroEstado == "Todos" || p.Estado == filtroEstado)
            ).ToList();

            // Cargar los productos filtrados en el DataGridView
            CargarProductosEnDGV(productosFiltrados);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // [CONFIRM] si hay cambios sin guardar, advertir al cerrar por el botón propio
            if (hayCambios && !Confirm("Hay cambios sin guardar. ¿Deseas salir igualmente?", "Salir"))
                return;

            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // [CONFIRM] limpiar descarta cambios
            if (hayCambios)
            {
                if (!Confirm("Vas a descartar los cambios realizados. ¿Continuar?", "Limpiar"))
                    return;
            }

            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;

            // [TRACK]
            hayCambios = false;
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, corrige los errores en el formulario.");
                return;
            }

            // [CONFIRM] confirmar alta o guardado de edición
            string accion = isEditing ? "guardar los cambios del producto" : "registrar este nuevo producto";
            if (!Confirm($"¿Estás seguro que deseas {accion}?", "Confirmación"))
                return;

            if (isEditing)
            {
                // Lógica de edición
                var productoAEditar = productos.FirstOrDefault(p => p.Id == currentProductId);
                if (productoAEditar != null)
                {
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
                        Estado = productoAEditar.Estado,
                        Proveedor = txtProveedor.Text
                    };
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
                    Estado = "Activo",
                    Proveedor = txtProveedor.Text
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

            // [TRACK]
            hayCambios = false;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            // Lógica para cambiar el estado del producto
            var productoAfectado = productos.FirstOrDefault(p => p.Id == currentProductId);
            if (productoAfectado != null)
            {
                string nuevoEstado = productoAfectado.Estado == "Activo" ? "Inactivo" : "Activo";

                // [CONFIRM] activar/desactivar
                string accion = nuevoEstado == "Inactivo" ? "desactivar" : "activar";
                if (!Confirm($"¿Seguro que deseas {accion} el producto \"{productoAfectado.Nombre}\"?", "Confirmación"))
                    return;

                var updatedProduct = new
                {
                    productoAfectado.Id,
                    productoAfectado.Nombre,
                    productoAfectado.Codigo,
                    productoAfectado.Descripcion,
                    productoAfectado.Talle,
                    productoAfectado.Categoria,
                    productoAfectado.Color,
                    productoAfectado.Marca,
                    productoAfectado.Precio,
                    productoAfectado.Stock,
                    Estado = nuevoEstado,
                    productoAfectado.Proveedor
                };
                productos[productos.IndexOf(productoAfectado)] = updatedProduct;
                MessageBox.Show($"Producto {nuevoEstado.ToLower()} exitosamente.");
            }

            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
            AplicarFiltros();

            // [TRACK]
            hayCambios = false;
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            // [CONFIRM] cancelar edición descarta cambios
            if (hayCambios)
            {
                if (!Confirm("Se perderán los cambios no guardados. ¿Cancelar la edición?", "Cancelar edición"))
                    return;
            }

            LimpiarCampos();
            isEditing = false;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;

            // [TRACK]
            hayCambios = false;
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
                    txtProveedor.Text = productoSeleccionado.Proveedor;

                    isEditing = true;
                    btnRegistrarProducto.Text = "Guardar Cambios";
                    btnCancelarEdicion.Visible = true;
                    btnDesactivar.Visible = true;

                    // Cambiar texto del botón de estado según el estado actual del producto
                    if (productoSeleccionado.Estado == "Activo")
                    {
                        btnDesactivar.Text = "Desactivar Producto";
                    }
                    else
                    {
                        btnDesactivar.Text = "Activar Producto";
                    }

                    // [TRACK] cargar un producto no implica cambios aún
                    hayCambios = false;
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

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            // Este evento está vacío, no hay problema.
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        // =======================
        // Helpers de confirmación y tracking
        // =======================

        // [CONFIRM] helper genérico
        private bool Confirm(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(
                mensaje,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) == DialogResult.Yes;
        }

        // [TRACK] engancha eventos de cambio a los controles de edición (no a los filtros)
        private void WireChangeTracking()
        {
            // TextBox de edición
            txtNombreProducto.TextChanged += MarcarCambio;
            txtCodigo.TextChanged += MarcarCambio;
            txtDescripcion.TextChanged += MarcarCambio;
            txtColor.TextChanged += MarcarCambio;
            txtMarca.TextChanged += MarcarCambio;
            txtPrecio.TextChanged += MarcarCambio;
            txtStock.TextChanged += MarcarCambio;
            txtProveedor.TextChanged += MarcarCambio;

            // ComboBox de edición
            cmbTalle.SelectedIndexChanged += MarcarCambio;
            cmbCategoria.SelectedIndexChanged += MarcarCambio;

            // (No marcamos filtros: txtFiltroBusqueda/cmbFiltroCategoria/cmbFiltroEstado)
        }

        private void MarcarCambio(object sender, EventArgs e)
        {
            hayCambios = true;
        }

        // [CONFIRM] aviso si se cierra la ventana con cambios sin guardar
        private void FormRegistrarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hayCambios)
            {
                if (!Confirm("Hay cambios sin guardar. ¿Deseas cerrar igualmente?", "Salir"))
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
