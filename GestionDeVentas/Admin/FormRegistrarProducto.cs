using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        // Lista visible (para la grilla)
        private readonly List<Producto> listaProductos = new List<Producto>();

        // Índice para detectar duplicados en O(1)
        private readonly HashSet<string> clavesUnicas =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Estado de edición
        private bool _editMode = false;
        private int _editingProductId = -1;
        private string _oldKeyWhileEditing = null; // clave original del producto en edición

        public FormRegistrarProducto()
        {
            InitializeComponent();
            CargarTallesYCategorias();
            ConfigurarDataGridView();

            // Validaciones de tipeo
            this.txtPrecio.KeyPress += txt_SoloNumeros_KeyPress;
            this.txtStock.KeyPress += txt_SoloNumeros_KeyPress;
            this.txtColor.KeyPress += txt_SoloLetras_KeyPress;

            // Asegura estado inicial
            HabilitarEdicion(false);
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            // Si más adelante cargas productos desde BD/archivo,
            // reconstruí acá el HashSet con BuildKey(prod).
        }

        #region Inicialización UI

        private void CargarTallesYCategorias()
        {
            string[] talles = { "S", "M", "L", "XL", "XXL", "30", "32", "34", "36", "38", "40", "42" };
            cmbTalle.Items.AddRange(talles);

            string[] categorias = { "Remera", "Pantalón", "Hoodie", "Campera" };
            cmbCategoria.Items.AddRange(categorias);
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AllowUserToResizeColumns = true;
            dgvProductos.ReadOnly = true;

            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Id", "ID");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Talle", "Talle");
            dgvProductos.Columns.Add("Color", "Color");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Codigo", "Código");
        }

        private void ActualizarDataGridView()
        {
            dgvProductos.Rows.Clear();
            foreach (var p in listaProductos)
            {
                dgvProductos.Rows.Add(p.Id, p.Nombre, p.Talle, p.Color, p.Precio, p.Stock, p.Codigo);
            }
        }

        #endregion

        #region Clave compuesta (evitar duplicados)

        private static string N(string s) => (s ?? string.Empty).Trim().ToUpperInvariant();

        private static string BuildKey(string nombre, string talle, string color, string codigo)
            => $"{N(nombre)}|{N(talle)}|{N(color)}|{N(codigo)}";

        private static string BuildKey(Producto p)
            => BuildKey(p.Nombre, p.Talle, p.Color, p.Codigo);

        #endregion

        #region Botón principal (Registrar/Aceptar cambios)

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string nuevaKey = BuildKey(
                txtNombreProducto.Text,
                cmbTalle.SelectedItem?.ToString(),
                txtColor.Text,
                txtCodigo.Text
            );

            if (_editMode)
            {
                // En edición: si la clave nueva es distinta a la original, verificar duplicado
                if (!string.Equals(nuevaKey, _oldKeyWhileEditing, StringComparison.OrdinalIgnoreCase) &&
                    clavesUnicas.Contains(nuevaKey))
                {
                    lblErrorCodigo.Text = "Ya existe una prenda con mismo Nombre + Talle + Color + Código.";
                    return;
                }

                var prod = listaProductos.FirstOrDefault(p => p.Id == _editingProductId);
                if (prod != null)
                {
                    // Actualiza índice de claves
                    if (_oldKeyWhileEditing != null)
                        clavesUnicas.Remove(_oldKeyWhileEditing);

                    prod.Nombre = txtNombreProducto.Text;
                    prod.Descripcion = txtDescripcion.Text;
                    prod.Talle = cmbTalle.SelectedItem?.ToString();
                    prod.Color = txtColor.Text;
                    prod.Precio = decimal.Parse(txtPrecio.Text);
                    prod.Stock = int.Parse(txtStock.Text);
                    prod.Categoria = cmbCategoria.SelectedItem?.ToString();
                    prod.Marca = txtMarca.Text;
                    prod.Codigo = txtCodigo.Text;

                    clavesUnicas.Add(BuildKey(prod));
                }

                MessageBox.Show("Cambios guardados.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarEdicion(false);
                _editingProductId = -1;
                _oldKeyWhileEditing = null;
                LimpiarCampos();
                ActualizarDataGridView();
            }
            else
            {
                // Alta normal
                if (clavesUnicas.Contains(nuevaKey))
                {
                    lblErrorCodigo.Text = "Ya existe una prenda con mismo Nombre + Talle + Color + Código.";
                    return;
                }

                var nuevo = new Producto
                {
                    Nombre = txtNombreProducto.Text,
                    Descripcion = txtDescripcion.Text,
                    Talle = cmbTalle.SelectedItem?.ToString(),
                    Color = txtColor.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Categoria = cmbCategoria.SelectedItem?.ToString(),
                    Marca = txtMarca.Text,
                    Codigo = txtCodigo.Text
                };

                listaProductos.Add(nuevo);
                clavesUnicas.Add(BuildKey(nuevo));

                MessageBox.Show("Producto registrado correctamente.", "Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCampos();
                ActualizarDataGridView();
            }
        }

        #endregion

        #region Doble clic en grilla -> Modo edición

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvProductos.Rows[e.RowIndex];
            if (fila.Cells["Id"].Value == null) return;

            _editingProductId = Convert.ToInt32(fila.Cells["Id"].Value);
            var prod = listaProductos.FirstOrDefault(p => p.Id == _editingProductId);
            if (prod == null) return;

            txtNombreProducto.Text = prod.Nombre;
            txtDescripcion.Text = prod.Descripcion;
            cmbTalle.SelectedItem = prod.Talle;
            txtColor.Text = prod.Color;
            txtPrecio.Text = prod.Precio.ToString();
            txtStock.Text = prod.Stock.ToString();
            cmbCategoria.SelectedItem = prod.Categoria;
            txtMarca.Text = prod.Marca;
            txtCodigo.Text = prod.Codigo;

            // Guardar clave original por si cambia
            _oldKeyWhileEditing = BuildKey(prod);

            HabilitarEdicion(true);
        }

        private void HabilitarEdicion(bool habilitar)
        {
            _editMode = habilitar;
            btnRegistrarProducto.Text = habilitar ? "Aceptar cambios" : "Registrar Producto";
            btnCancelarEdicion.Visible = habilitar;
            dgvProductos.Enabled = !habilitar;
        }

        private void btnCancelarEdicion_Click(object sender, EventArgs e)
        {
            // Cancela edición, NO guarda cambios ni toca el HashSet
            HabilitarEdicion(false);
            _editingProductId = -1;
            _oldKeyWhileEditing = null;
            LimpiarCampos();
            dgvProductos.Enabled = true;
        }

        #endregion

        #region Validaciones y utilidades

        private bool ValidarCampos()
        {
            bool ok = true;

            lblErrorNombre.Text = " ";
            lblErrorDescripcion.Text = " ";
            lblErrorTalle.Text = " ";
            lblErrorColor.Text = " ";
            lblErrorPrecio.Text = " ";
            lblErrorStock.Text = " ";
            lblErrorCategoria.Text = " ";
            lblErrorMarca.Text = " ";
            lblErrorCodigo.Text = " ";

            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                lblErrorDescripcion.Text = "La descripción es obligatoria.";
                ok = false;
            }
            if (cmbTalle.SelectedItem == null)
            {
                lblErrorTalle.Text = "Selecciona un talle.";
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                lblErrorColor.Text = "El color es obligatorio.";
                ok = false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                lblErrorPrecio.Text = "El precio debe ser un número.";
                ok = false;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                lblErrorStock.Text = "El stock debe ser un número entero.";
                ok = false;
            }
            if (cmbCategoria.SelectedItem == null)
            {
                lblErrorCategoria.Text = "Selecciona una categoría.";
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                lblErrorMarca.Text = "La marca es obligatoria.";
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                lblErrorCodigo.Text = "El código es obligatorio.";
                ok = false;
            }

            return ok;
        }

        private void LimpiarCampos()
        {
            txtNombreProducto.Clear();
            txtDescripcion.Clear();
            cmbTalle.SelectedIndex = -1;
            txtColor.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cmbCategoria.SelectedIndex = -1;
            txtMarca.Clear();
            txtCodigo.Clear();

            lblErrorNombre.Text = lblErrorDescripcion.Text = lblErrorTalle.Text =
                lblErrorColor.Text = lblErrorPrecio.Text = lblErrorStock.Text =
                lblErrorCategoria.Text = lblErrorMarca.Text = lblErrorCodigo.Text = " ";
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            var tb = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                (tb.Text.Contains('.') || tb.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }

    public class Producto
    {
        public static int IdCounter = 0;
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Codigo { get; set; }

        public Producto()
        {
            Id = ++IdCounter;
        }

        public override string ToString() => $"{Nombre} - {Codigo} - ${Precio}";
    }
}
