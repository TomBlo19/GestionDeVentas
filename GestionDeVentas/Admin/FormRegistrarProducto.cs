using Datos;
using GestionDeVentas.Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        private bool isEditing = false;
        private int currentProductId;
        private bool hayCambios = false;

        private readonly ProductoDatos productoDatos = new ProductoDatos();

        private List<Producto> _todosLosProductos;

        public FormRegistrarProducto()
        {
            InitializeComponent();
            btnCancelarEdicion.Visible = false;
            this.FormClosing += FormRegistrarProducto_FormClosing;
            WireChangeTracking();
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProveedores();
            cmbTalle.Enabled = false;

            ConfigurarDataGridView();

            _todosLosProductos = productoDatos.ObtenerProductos();
            CargarProductosEnDGV(_todosLosProductos);

            CargarControlesDeFiltro();
            ConectarEventosDeFiltro();
        }

        // ========================
        // CONFIGURACIÓN VISUAL
        // ========================
        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.EnableHeadersVisualStyles = true;

            dgvProductos.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Control,
                ForeColor = SystemColors.ControlText,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgvProductos.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText
            };

            dgvProductos.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.ControlLight
            };
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Estado" && e.RowIndex >= 0)
            {
                string estado = dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();

                if (!string.IsNullOrEmpty(estado) && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = (e.RowIndex % 2 != 0) ? SystemColors.ControlLight : SystemColors.Window;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }

        // ===================================
        // LÓGICA DE FILTROS
        // ===================================

        private void CargarControlesDeFiltro()
        {
            cboFiltroBuscarPor.Items.Clear();
            cboFiltroBuscarPor.Items.Add("Nombre");
            cboFiltroBuscarPor.Items.Add("Código");
            cboFiltroBuscarPor.SelectedIndex = 0;

            cmbFiltroCategoria.Items.Clear();
            cmbFiltroCategoria.Items.Add(new ComboBoxItem("Todas", 0));
            var categorias = _todosLosProductos.Select(p => new { p.IdCategoria, p.CategoriaNombre }).Distinct().ToList();
            foreach (var cat in categorias)
            {
                cmbFiltroCategoria.Items.Add(new ComboBoxItem(cat.CategoriaNombre, cat.IdCategoria));
            }
            cmbFiltroCategoria.SelectedIndex = 0;

            CargarMarcasFiltro();
        }

        private void CargarMarcasFiltro()
        {
            cmbFiltroMarca.Items.Clear();
            cmbFiltroMarca.Items.Add("Todas");
            var marcas = _todosLosProductos
                .Select(p => p.Marca)
                .Where(m => !string.IsNullOrEmpty(m))
                .Distinct()
                .OrderBy(m => m)
                .ToList();
            cmbFiltroMarca.Items.AddRange(marcas.ToArray());
            cmbFiltroMarca.SelectedIndex = 0;
        }

        private void ConectarEventosDeFiltro()
        {
            txtFiltroBusqueda.TextChanged += (s, e) => AplicarFiltros();
            cboFiltroBuscarPor.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbFiltroMarca.SelectedIndexChanged += (s, e) => AplicarFiltros();
            cmbFiltroCategoria.SelectedIndexChanged += (s, e) => AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            IEnumerable<Producto> productosFiltrados = _todosLosProductos;

            var textoBusqueda = txtFiltroBusqueda.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                var campoBusqueda = cboFiltroBuscarPor.SelectedItem.ToString();
                switch (campoBusqueda)
                {
                    case "Nombre":
                        productosFiltrados = productosFiltrados.Where(p => p.Nombre.ToLower().Contains(textoBusqueda));
                        break;
                    case "Código":
                        productosFiltrados = productosFiltrados.Where(p => p.Codigo.ToLower().Contains(textoBusqueda));
                        break;
                }
            }

            var categoriaSeleccionada = cmbFiltroCategoria.SelectedItem as ComboBoxItem;
            if (categoriaSeleccionada != null && categoriaSeleccionada.Value != 0)
            {
                productosFiltrados = productosFiltrados.Where(p => p.IdCategoria == categoriaSeleccionada.Value);
            }

            var marcaSeleccionada = cmbFiltroMarca.SelectedItem?.ToString();
            if (marcaSeleccionada != "Todas" && !string.IsNullOrEmpty(marcaSeleccionada))
            {
                productosFiltrados = productosFiltrados.Where(p => p.Marca == marcaSeleccionada);
            }

            CargarProductosEnDGV(productosFiltrados.ToList());
        }

        // ========================
        // CARGA DE COMBOS Y DGV
        // ========================

        private void CargarProveedores()
        {
            cmbProveedor.Items.Clear();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_proveedor, nombre_proveedor FROM proveedor WHERE estado_proveedor = 'activo'", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbProveedor.Items.Add(new ComboBoxItem(
                        reader["nombre_proveedor"].ToString(),
                        (int)reader["id_proveedor"]
                    ));
                }
            }
            if (cmbProveedor.Items.Count > 0) cmbProveedor.SelectedIndex = -1;
            else { cmbProveedor.Items.Add("⚠ No hay proveedores activos"); cmbProveedor.SelectedIndex = 0; }
        }

        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_categoria, nombre_categoria FROM categoria", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategoria.Items.Add(new ComboBoxItem(reader["nombre_categoria"].ToString(), (int)reader["id_categoria"]));
                }
            }
        }

        private void CargarTallesPorCategoria(int idCategoria)
        {
            cmbTalle.Items.Clear();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_talle, nombre_talle FROM talle WHERE id_categoria = @id", conn);
                cmd.Parameters.AddWithValue("@id", idCategoria);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        cmbTalle.Enabled = false;
                        cmbTalle.Items.Add("⚠ No hay talles para esta categoría");
                        cmbTalle.SelectedIndex = 0;
                        return;
                    }
                    while (reader.Read())
                    {
                        cmbTalle.Items.Add(new ComboBoxItem(reader["nombre_talle"].ToString(), (int)reader["id_talle"]));
                    }
                }
            }
            cmbTalle.Enabled = true;
            cmbTalle.SelectedIndex = -1;
        }

        private void CargarProductosEnDGV(List<Producto> lista)
        {
            dgvProductos.Rows.Clear();
            foreach (var p in lista)
            {
                dgvProductos.Rows.Add(
                    p.Id, p.Nombre, p.TalleNombre, p.Color, p.Precio,
                    p.Stock, p.Codigo, p.Estado, p.ProveedorNombre
                );
            }
            if (dgvProductos.Columns.Contains("Id") && dgvProductos.Columns["Id"] != null)
                dgvProductos.Columns["Id"].Visible = false;
        }

        // ========================
        // EVENTOS Y VALIDACIONES
        // ========================
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarcarCambio(sender, e);
            if (cmbCategoria.SelectedItem is ComboBoxItem selectedItem)
            {
                int idCategoria = selectedItem.Value;
                CargarTallesPorCategoria(idCategoria);
            }
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear(); txtCodigo.Clear(); txtDescripcion.Clear();
            cmbTalle.Items.Clear(); cmbTalle.Enabled = false; cmbCategoria.SelectedIndex = -1;
            txtColor.Clear(); txtMarca.Clear(); txtPrecio.Clear();
            txtStock.Clear(); cmbProveedor.SelectedIndex = -1;
            lblErrorNombre.Text = ""; lblErrorCodigo.Text = ""; lblErrorDescripcion.Text = "";
            lblErrorTalle.Text = ""; lblErrorCategoria.Text = ""; lblErrorColor.Text = "";
            lblErrorMarca.Text = ""; lblErrorPrecio.Text = ""; lblErrorStock.Text = "";
            lblErrorProveedor.Text = "";
        }

        private bool ValidarCampos()
        {
            bool isValid = true;
            lblErrorNombre.Text = lblErrorCodigo.Text = lblErrorDescripcion.Text = lblErrorTalle.Text = lblErrorCategoria.Text = lblErrorColor.Text = lblErrorMarca.Text = lblErrorPrecio.Text = lblErrorStock.Text = lblErrorProveedor.Text = "";
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text)) { lblErrorNombre.Text = "Campo obligatorio"; isValid = false; }
            if (string.IsNullOrWhiteSpace(txtCodigo.Text)) { lblErrorCodigo.Text = "Campo obligatorio"; isValid = false; }
            else
            {
                if (productoDatos.ExisteCodigo(txtCodigo.Text.Trim(), isEditing ? currentProductId : (int?)null))
                {
                    lblErrorCodigo.Text = "Este código ya existe"; isValid = false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) { lblErrorDescripcion.Text = "Campo obligatorio"; isValid = false; }
            if (!(cmbCategoria.SelectedItem is ComboBoxItem)) { lblErrorCategoria.Text = "Seleccione una categoría"; isValid = false; }
            if (cmbTalle.Enabled && !(cmbTalle.SelectedItem is ComboBoxItem)) { lblErrorTalle.Text = "Seleccione un talle"; isValid = false; }
            if (string.IsNullOrWhiteSpace(txtColor.Text)) { lblErrorColor.Text = "Campo obligatorio"; isValid = false; }
            if (string.IsNullOrWhiteSpace(txtMarca.Text)) { lblErrorMarca.Text = "Campo obligatorio"; isValid = false; }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0) { lblErrorPrecio.Text = "Precio inválido"; isValid = false; }
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0) { lblErrorStock.Text = "Stock inválido"; isValid = false; }
            if (!(cmbProveedor.SelectedItem is ComboBoxItem)) { lblErrorProveedor.Text = "Seleccione un proveedor"; isValid = false; }
            return isValid;
        }

        // ========================
        // CRUD BOTONES
        // ========================
        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, corrige los errores en el formulario.");
                return;
            }
            if (!Confirm("¿Deseas continuar con esta acción?", "Confirmar acción")) return;
            var producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombreProducto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                IdTalle = (cmbTalle.SelectedItem as ComboBoxItem)?.Value ?? 0,
                Color = txtColor.Text.Trim(),
                Marca = txtMarca.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                IdCategoria = ((ComboBoxItem)cmbCategoria.SelectedItem).Value,
                IdProveedor = ((ComboBoxItem)cmbProveedor.SelectedItem).Value,
                Estado = "Activo"
            };
            try
            {
                if (isEditing)
                {
                    producto.Id = currentProductId;
                    productoDatos.EditarProducto(producto);
                    MessageBox.Show("Producto actualizado correctamente.");
                }
                else
                {
                    productoDatos.InsertarProducto(producto);
                    MessageBox.Show("Producto registrado correctamente.");
                }
                LimpiarCamposYEstado();
                _todosLosProductos = productoDatos.ObtenerProductos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (currentProductId == 0) return;
            bool activar = btnDesactivar.Text.Contains("Activar");
            string accion = activar ? "activar" : "desactivar";
            if (!Confirm($"¿Deseas {accion} este producto?", "Confirmar acción")) return;

            productoDatos.CambiarEstado(currentProductId, activar);
            MessageBox.Show($"Producto {(activar ? "activado" : "desactivado")} correctamente.");
            LimpiarCamposYEstado();
            _todosLosProductos = productoDatos.ObtenerProductos();
            AplicarFiltros();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            currentProductId = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Id"].Value);
            var producto = _todosLosProductos.FirstOrDefault(p => p.Id == currentProductId);
            if (producto == null) return;

            txtCodigo.Text = producto.Codigo;
            txtNombreProducto.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            txtColor.Text = producto.Color;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio.ToString("F2");
            txtStock.Text = producto.Stock.ToString();

            SeleccionarComboPorValor(cmbCategoria, producto.IdCategoria);
            CargarTallesPorCategoria(producto.IdCategoria);
            SeleccionarComboPorValor(cmbTalle, producto.IdTalle);
            SeleccionarComboPorValor(cmbProveedor, producto.IdProveedor);

            isEditing = true;
            btnRegistrarProducto.Text = "Guardar Cambios";
            btnCancelarEdicion.Visible = true;
            btnDesactivar.Visible = true;
            btnDesactivar.Text = producto.Estado == "Activo" ? "Desactivar Producto" : "Activar Producto";
            hayCambios = false;
        }

        // ========================
        // UTILIDADES Y CERRAR
        // ========================
        private void LimpiarCamposYEstado()
        {
            LimpiarCampos();
            isEditing = false;
            currentProductId = 0;
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
            hayCambios = false;
        }

        private void SeleccionarComboPorValor(ComboBox combo, int valor)
        {
            combo.SelectedItem = combo.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Value == valor);
        }

        private void WireChangeTracking()
        {
            txtNombreProducto.TextChanged += MarcarCambio;
            txtCodigo.TextChanged += MarcarCambio;
            txtDescripcion.TextChanged += MarcarCambio;
            txtColor.TextChanged += MarcarCambio;
            txtMarca.TextChanged += MarcarCambio;
            txtPrecio.TextChanged += MarcarCambio;
            txtStock.TextChanged += MarcarCambio;
            cmbCategoria.SelectedIndexChanged += MarcarCambio;
            cmbTalle.SelectedIndexChanged += MarcarCambio;
            cmbProveedor.SelectedIndexChanged += MarcarCambio;
        }

        private void MarcarCambio(object sender, EventArgs e) => hayCambios = true;

        private void FormRegistrarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hayCambios && !Confirm("Hay cambios sin guardar. ¿Deseas cerrar igualmente?", "Salir"))
                e.Cancel = true;
        }

        private bool Confirm(string mensaje, string titulo = "Confirmación")
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void btnLimpiar_Click_2(object sender, EventArgs e)
        {
            if (Confirm("¿Deseas limpiar todos los campos?", "Confirmar limpieza"))
            {
                LimpiarCamposYEstado();
            }
        }

        private void btnCancelarEdicion_Click_2(object sender, EventArgs e)
        {
            if (Confirm("¿Seguro que deseas cancelar la edición y limpiar el formulario?", "Confirmar cancelación"))
            {
                LimpiarCamposYEstado();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public ComboBoxItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }

        private void lblTitulo_Click_1(object sender, EventArgs e) { }
        private void cmbFiltroTalle_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}