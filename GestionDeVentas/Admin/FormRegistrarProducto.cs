using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing; // Necesario para usar Color.Red, Color.White, etc.
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        private bool isEditing = false;
        private int currentProductId;
        private bool hayCambios = false;

        private readonly ProductoDatos productoDatos = new ProductoDatos();

        public FormRegistrarProducto()
        {
            InitializeComponent();
            btnCancelarEdicion.Visible = false;
            this.FormClosing += FormRegistrarProducto_FormClosing;
            WireChangeTracking();
            // ✅ Conexión del evento para el formato condicional de las filas
            dgvProductos.CellFormatting += dgvProductos_CellFormatting;
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProveedores();
            ConfigurarDataGridView(); // Configuración visual del DGV
            CargarProductosEnDGV();
            cmbTalle.Enabled = false;
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

            // Establecer estilos universales (usando SystemColors para alternancia)
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
                BackColor = SystemColors.ControlLight // Gris claro para filas alternas
            };
        }

        // ========================
        // FORMATO CONDICIONAL (Para pintar Inactivos)
        // ========================
        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Solo necesitamos leer el valor de la columna 'Estado'
            if (dgvProductos.Columns[e.ColumnIndex].Name == "Estado" && e.RowIndex >= 0)
            {
                // Obtenemos el valor del estado de la fila
                string estado = dgvProductos.Rows[e.RowIndex].Cells["Estado"].Value?.ToString();

                // Si el producto está Inactivo, aplicamos el estilo de color seguro
                if (!string.IsNullOrEmpty(estado) && estado.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                {
                    // Fondo rojo (seguro) y texto blanco para alto contraste
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    // Restablecer estilos para filas activas, respetando la alternancia
                    if (e.RowIndex % 2 != 0) // Fila impar
                    {
                        dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.ControlLight;
                    }
                    else // Fila par
                    {
                        dgvProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                    }
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    dgvProductos.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                }
            }
        }

        // ========================
        // CARGA DE COMBOS Y DGV
        // ========================

        private void CargarProveedores()
        {
            cmbProveedor.Items.Clear();

            using (var conn = new SqlConnection(productoDatos.ConnectionString))
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

            if (cmbProveedor.Items.Count > 0)
            {
                cmbProveedor.SelectedIndex = -1; // nada seleccionado por defecto
            }
            else
            {
                cmbProveedor.Items.Add("⚠ No hay proveedores activos");
                cmbProveedor.SelectedIndex = 0;
            }
        }


        private void CargarCategorias()
        {
            cmbCategoria.Items.Clear();
            using (var conn = new SqlConnection(productoDatos.ConnectionString))
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

        private string ObtenerNombreTalle(int idTalle)
        {
            if (idTalle <= 0) return "-";
            using (var conn = new SqlConnection(productoDatos.ConnectionString))
            using (var cmd = new SqlCommand("SELECT nombre_talle FROM talle WHERE id_talle=@id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", idTalle);
                var r = cmd.ExecuteScalar();
                return r?.ToString() ?? "-";
            }
        }


        private void CargarTallesPorCategoria(int idCategoria)
        {
            cmbTalle.Items.Clear();

            using (var conn = new SqlConnection(productoDatos.ConnectionString))
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

        private void CargarProductosEnDGV()
        {
            dgvProductos.Rows.Clear();

            var lista = productoDatos.ObtenerProductos();

            using (var conn = new SqlConnection(productoDatos.ConnectionString))
            {
                conn.Open();
                foreach (var p in lista)
                {
                    // Obtener el nombre del talle
                    string nombreTalle = "-";
                    using (var cmd = new SqlCommand("SELECT nombre_talle FROM talle WHERE id_talle = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", p.IdTalle);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            nombreTalle = result.ToString();
                    }

                    // Obtener el nombre del proveedor
                    string nombreProveedor = "-";
                    using (var cmd2 = new SqlCommand("SELECT nombre_proveedor FROM proveedor WHERE id_proveedor = @id", conn))
                    {
                        cmd2.Parameters.AddWithValue("@id", p.IdProveedor);
                        var result2 = cmd2.ExecuteScalar();
                        if (result2 != null)
                            nombreProveedor = result2.ToString();
                    }

                    dgvProductos.Rows.Add(
                        p.Id,
                        p.Nombre,
                        nombreTalle,
                        p.Color,
                        p.Precio,
                        p.Stock,
                        p.Codigo,
                        p.Estado,
                        nombreProveedor
                    );
                }
            }

            // Ocultar ID (se repite por seguridad si la configuración inicial falló)
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
            txtNombreProducto.Clear();
            txtCodigo.Clear();
            txtDescripcion.Clear();
            cmbTalle.Items.Clear();
            cmbTalle.Enabled = false;
            cmbCategoria.SelectedIndex = -1;
            txtColor.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbProveedor.SelectedIndex = -1;

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

            // Resetear errores
            lblErrorNombre.Text = lblErrorCodigo.Text = lblErrorDescripcion.Text =
            lblErrorTalle.Text = lblErrorCategoria.Text = lblErrorColor.Text =
            lblErrorMarca.Text = lblErrorPrecio.Text = lblErrorStock.Text =
            lblErrorProveedor.Text = "";


            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            { lblErrorNombre.Text = "Campo obligatorio"; isValid = false; }

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            { lblErrorCodigo.Text = "Campo obligatorio"; isValid = false; }
            else
            {
                bool existe = productoDatos.ExisteCodigo(txtCodigo.Text.Trim(), isEditing ? currentProductId : (int?)null);
                if (existe)
                {
                    lblErrorCodigo.Text = "Este código ya existe";
                    isValid = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            { lblErrorDescripcion.Text = "Campo obligatorio"; isValid = false; }

            if (!(cmbCategoria.SelectedItem is ComboBoxItem))
            { lblErrorCategoria.Text = "Seleccione una categoría"; isValid = false; }

            // Validación de talle: Debe estar habilitado y ser un ComboBoxItem válido
            if (!cmbTalle.Enabled || !(cmbTalle.SelectedItem is ComboBoxItem))
            { lblErrorTalle.Text = "Seleccione un talle"; isValid = false; }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            { lblErrorColor.Text = "Campo obligatorio"; isValid = false; }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            { lblErrorMarca.Text = "Campo obligatorio"; isValid = false; }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            { lblErrorPrecio.Text = "Precio inválido"; isValid = false; }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            { lblErrorStock.Text = "Stock inválido"; isValid = false; }

            if (!(cmbProveedor.SelectedItem is ComboBoxItem))
            { lblErrorProveedor.Text = "Seleccione un proveedor"; isValid = false; }

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

            if (!Confirm("¿Deseas continuar con esta acción?", "Confirmar acción"))
                return;

            var producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombreProducto.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                IdTalle = ((ComboBoxItem)cmbTalle.SelectedItem).Value,
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

                LimpiarCampos();
                CargarProductosEnDGV();
                isEditing = false;
                btnRegistrarProducto.Text = "Registrar Producto";
                btnCancelarEdicion.Visible = false;
                btnDesactivar.Visible = false;
                hayCambios = false;
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

            if (!Confirm($"¿Deseas {accion} este producto?", "Confirmar acción"))
                return;

            productoDatos.CambiarEstado(currentProductId, activar);
            MessageBox.Show($"Producto {(activar ? "activado" : "desactivado")} correctamente.");

            LimpiarCampos();
            CargarProductosEnDGV();
            btnRegistrarProducto.Text = "Registrar Producto";
            btnCancelarEdicion.Visible = false;
            btnDesactivar.Visible = false;
            isEditing = false;
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
            // Aseguramos que la columna "Id" exista antes de accederla
            if (!dgvProductos.Columns.Contains("Id")) return;

            currentProductId = Convert.ToInt32(row.Cells["Id"].Value);

            var producto = productoDatos.ObtenerProductos().FirstOrDefault(p => p.Id == currentProductId);
            if (producto == null) return;

            txtCodigo.Text = producto.Codigo;
            txtNombreProducto.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            txtColor.Text = producto.Color;
            txtMarca.Text = producto.Marca;
            txtPrecio.Text = producto.Precio.ToString();
            txtStock.Text = producto.Stock.ToString();

            SeleccionarComboPorValor(cmbCategoria, producto.IdCategoria);
            // El evento SelectedIndexChanged ya carga los talles, pero lo forzamos si no lo hace
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

        private void SeleccionarComboPorValor(ComboBox combo, int valor)
        {
            foreach (var item in combo.Items)
            {
                if (item is ComboBoxItem cbi && cbi.Value == valor)
                {
                    combo.SelectedItem = item;
                    break;
                }
            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (Confirm("¿Deseas limpiar todos los campos?", "Confirmar limpieza"))
            {
                LimpiarCampos();
                isEditing = false;
                currentProductId = 0;
                btnRegistrarProducto.Text = "Registrar Producto";
                btnCancelarEdicion.Visible = false;
                btnDesactivar.Visible = false;
                hayCambios = false;
            }
        }

        // Se unifican los clics a un solo método para evitar redundancia
        private void btnLimpiar_Click_1(object sender, EventArgs e) => btnLimpiar_Click(sender, e);
        private void btnLimpiar_Click_2(object sender, EventArgs e) => btnLimpiar_Click(sender, e);

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            // Este botón debería simplemente cancelar el modo de edición y limpiar, sin cerrar el formulario
            if (Confirm("¿Seguro que deseas cancelar la edición y limpiar el formulario?", "Confirmar cancelación"))
            {
                LimpiarCampos();
                isEditing = false;
                currentProductId = 0;
                btnRegistrarProducto.Text = "Registrar Producto";
                btnCancelarEdicion.Visible = false;
                btnDesactivar.Visible = false;
                hayCambios = false;
            }
        }

        // Se unifican los clics a un solo método para evitar redundancia
        private void btnCancelarEdicion_Click_1(object sender, EventArgs e) => btnCancelarEdicion_Click(sender, e);
        private void btnCancelarEdicion_Click_2(object sender, EventArgs e) => btnCancelarEdicion_Click(sender, e);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // La lógica de cierre con confirmación ya está en FormRegistrarProducto_FormClosing
            this.Close();
        }

        // ========================
        // CLASE AUXILIAR
        // ========================
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}