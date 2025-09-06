using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        // Lista visible (para la grilla)
        private readonly List<Producto> listaProductos = new List<Producto>();

        // Índice para detectar duplicados en O(1) (clave compuesta)
        private readonly HashSet<string> clavesUnicas =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Unicidad de códigos (SKU) global
        private readonly HashSet<string> codigosUnicos =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Límites (ajustables)
        private const int MaxNombre = 60, MaxDescripcion = 400, MaxCodigo = 20, MaxMarca = 40, MaxColor = 30;

        // Patrón de código: letras/números y -._ (3 a 20)
        private static readonly Regex RxCodigo = new Regex(@"^[A-Za-z0-9._-]{3,20}$");

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
            // reconstruí acá el HashSet con BuildKey(prod) y codigosUnicos.
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

        #region Helpers y clave compuesta

        private static string N(string s) => (s ?? string.Empty).Trim().ToUpperInvariant();
        private static string T(string s) => (s ?? "").Trim();

        private static string Title(string s)
        {
            var t = T(s).ToLower();
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t);
        }

        private static bool TryParseDecimalFlexible(string text, out decimal value)
        {
            var ci = System.Globalization.CultureInfo.CurrentCulture;
            string sep = ci.NumberFormat.NumberDecimalSeparator;
            text = T(text).Replace(",", sep).Replace(".", sep);
            return decimal.TryParse(
                text,
                System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands,
                ci, out value);
        }

        private static string BuildKey(string nombre, string talle, string color, string codigo)
            => $"{N(nombre)}|{N(talle)}|{N(color)}|{N(codigo)}";

        private static string BuildKey(Producto p)
            => BuildKey(p.Nombre, p.Talle, p.Color, p.Codigo);

        #endregion

        #region Botón principal (Registrar/Aceptar cambios)

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            // Clave compuesta para el índice de duplicados
            string nuevaKey = BuildKey(
                txtNombreProducto.Text,
                cmbTalle.SelectedItem?.ToString(),
                txtColor.Text,
                txtCodigo.Text
            );

            if (_editMode)
            {
                // Verificar duplicado si la clave nueva difiere de la original
                if (!string.Equals(nuevaKey, _oldKeyWhileEditing, StringComparison.OrdinalIgnoreCase) &&
                    clavesUnicas.Contains(nuevaKey))
                {
                    lblErrorCodigo.Text = "Ya existe una prenda con mismo Nombre + Talle + Color + Código.";
                    return;
                }

                var prod = listaProductos.FirstOrDefault(p => p.Id == _editingProductId);
                if (prod != null)
                {
                    // Actualizar índices
                    if (_oldKeyWhileEditing != null)
                        clavesUnicas.Remove(_oldKeyWhileEditing);

                    codigosUnicos.Remove(T(prod.Codigo).ToUpperInvariant());

                    // Normalización al guardar
                    prod.Nombre = Title(txtNombreProducto.Text);
                    prod.Descripcion = T(txtDescripcion.Text);
                    prod.Talle = cmbTalle.SelectedItem?.ToString();
                    prod.Color = Title(txtColor.Text);

                    // Precio/Stock parseados con cultura
                    TryParseDecimalFlexible(txtPrecio.Text, out var precioVal);
                    prod.Precio = precioVal;

                    int.TryParse(T(txtStock.Text), out var stockVal);
                    prod.Stock = stockVal;

                    prod.Categoria = cmbCategoria.SelectedItem?.ToString();
                    prod.Marca = Title(txtMarca.Text);
                    prod.Codigo = T(txtCodigo.Text).ToUpperInvariant();

                    // Reinsertar índices
                    clavesUnicas.Add(BuildKey(prod));
                    codigosUnicos.Add(prod.Codigo);
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
                // Alta normal (ya validado código único)
                var nuevo = new Producto
                {
                    Nombre = Title(txtNombreProducto.Text),
                    Descripcion = T(txtDescripcion.Text),
                    Talle = cmbTalle.SelectedItem?.ToString(),
                    Color = Title(txtColor.Text),
                };

                TryParseDecimalFlexible(txtPrecio.Text, out var precioVal);
                nuevo.Precio = precioVal;

                int.TryParse(T(txtStock.Text), out var stockVal);
                nuevo.Stock = stockVal;

                nuevo.Categoria = cmbCategoria.SelectedItem?.ToString();
                nuevo.Marca = Title(txtMarca.Text);
                nuevo.Codigo = T(txtCodigo.Text).ToUpperInvariant();

                listaProductos.Add(nuevo);
                clavesUnicas.Add(BuildKey(nuevo));
                codigosUnicos.Add(nuevo.Codigo);

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

            // Reset errores
            lblErrorNombre.Text = lblErrorDescripcion.Text = lblErrorTalle.Text =
            lblErrorColor.Text = lblErrorPrecio.Text = lblErrorStock.Text =
            lblErrorCategoria.Text = lblErrorMarca.Text = lblErrorCodigo.Text = " ";

            // Normalizar (para validar)
            string nombre = T(txtNombreProducto.Text);
            string descripcion = T(txtDescripcion.Text);
            string talle = cmbTalle.SelectedItem?.ToString();
            string color = T(txtColor.Text);
            string precioTxt = T(txtPrecio.Text);
            string stockTxt = T(txtStock.Text);
            string categoria = cmbCategoria.SelectedItem?.ToString();
            string marca = T(txtMarca.Text);
            string codigo = T(txtCodigo.Text);

            // Nombre
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2 || nombre.Length > MaxNombre)
            {
                lblErrorNombre.Text = $"El nombre es obligatorio (2–{MaxNombre} caracteres).";
                ok = false;
            }

            // Descripción
            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Length < 5 || descripcion.Length > MaxDescripcion)
            {
                lblErrorDescripcion.Text = $"La descripción es obligatoria (5–{MaxDescripcion} caracteres).";
                ok = false;
            }

            // Talle/Categoría
            if (string.IsNullOrEmpty(talle))
            {
                lblErrorTalle.Text = "Selecciona un talle.";
                ok = false;
            }
            if (string.IsNullOrEmpty(categoria))
            {
                lblErrorCategoria.Text = "Selecciona una categoría.";
                ok = false;
            }

            // Color
            if (string.IsNullOrWhiteSpace(color) || color.Length > MaxColor)
            {
                lblErrorColor.Text = $"El color es obligatorio (≤ {MaxColor} caracteres).";
                ok = false;
            }

            // Marca
            if (string.IsNullOrWhiteSpace(marca) || marca.Length > MaxMarca)
            {
                lblErrorMarca.Text = $"La marca es obligatoria (≤ {MaxMarca} caracteres).";
                ok = false;
            }

            // Código: formato y longitud
            if (string.IsNullOrWhiteSpace(codigo) || codigo.Length > MaxCodigo || !RxCodigo.IsMatch(codigo))
            {
                lblErrorCodigo.Text = $"Código inválido (3–{MaxCodigo}, solo letras/números y -._).";
                ok = false;
            }

            // Precio
            if (!TryParseDecimalFlexible(precioTxt, out var precio) || precio <= 0 || precio > 1_000_000m)
            {
                lblErrorPrecio.Text = "Precio inválido (> 0).";
                ok = false;
            }

            // Stock
            if (!int.TryParse(stockTxt, out var stock) || stock < 0 || stock > 1_000_000)
            {
                lblErrorStock.Text = "Stock inválido (entero ≥ 0).";
                ok = false;
            }

            // Unicidad de código (global)
            if (ok)
            {
                string codeKey = codigo.ToUpperInvariant();

                if (_editMode)
                {
                    var prod = listaProductos.FirstOrDefault(p => p.Id == _editingProductId);
                    if (prod != null && !codeKey.Equals(T(prod.Codigo).ToUpperInvariant(), StringComparison.Ordinal))
                    {
                        if (codigosUnicos.Contains(codeKey))
                        {
                            lblErrorCodigo.Text = "El código ya existe.";
                            ok = false;
                        }
                    }
                }
                else
                {
                    if (codigosUnicos.Contains(codeKey))
                    {
                        lblErrorCodigo.Text = "El código ya existe.";
                        ok = false;
                    }
                }
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void lblTitulo_Click(object sender, EventArgs e) { }
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
