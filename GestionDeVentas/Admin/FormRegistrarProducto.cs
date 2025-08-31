using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormRegistrarProducto : Form
    {
        private List<Producto> listaProductos = new List<Producto>();

        public FormRegistrarProducto()
        {
            InitializeComponent();
            CargarTallesYCategorias();
            ConfigurarDataGridView();
            // Asignar los eventos KeyPress a los TextBoxes
            this.txtPrecio.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtStock.KeyPress += new KeyPressEventHandler(txt_SoloNumeros_KeyPress);
            this.txtColor.KeyPress += new KeyPressEventHandler(txt_SoloLetras_KeyPress);
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            // Código que se ejecuta al cargar el formulario.
        }

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
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Codigo", "Código");
        }

        private void ActualizarDataGridView()
        {
            dgvProductos.Rows.Clear();
            foreach (var prod in listaProductos)
            {
                dgvProductos.Rows.Add(prod.Id, prod.Nombre, prod.Talle, prod.Precio, prod.Stock, prod.Codigo);
            }
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Producto nuevoProducto = new Producto
                {
                    Nombre = txtNombreProducto.Text,
                    Descripcion = txtDescripcion.Text,
                    Talle = cmbTalle.SelectedItem.ToString(),
                    Color = txtColor.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Categoria = cmbCategoria.SelectedItem.ToString(),
                    Marca = txtMarca.Text,
                    Codigo = txtCodigo.Text
                };

                listaProductos.Add(nuevoProducto);
                MessageBox.Show("Producto registrado correctamente!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                ActualizarDataGridView();
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            // Limpiar todos los errores al inicio de la validación
            lblErrorNombre.Text = " ";
            lblErrorDescripcion.Text = " ";
            lblErrorTalle.Text = " ";
            lblErrorColor.Text = " ";
            lblErrorPrecio.Text = " ";
            lblErrorStock.Text = " ";
            lblErrorCategoria.Text = " ";
            lblErrorMarca.Text = " ";
            lblErrorCodigo.Text = " ";

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                lblErrorNombre.Text = "El nombre es obligatorio.";
                esValido = false;
            }

            // Validar Descripción
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                lblErrorDescripcion.Text = "La descripción es obligatoria.";
                esValido = false;
            }

            // Validar Talle
            if (cmbTalle.SelectedItem == null)
            {
                lblErrorTalle.Text = "Selecciona un talle.";
                esValido = false;
            }

            // Validar Color
            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                lblErrorColor.Text = "El color es obligatorio.";
                esValido = false;
            }

            // Validar Precio (numérico)
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                lblErrorPrecio.Text = "El precio debe ser un número.";
                esValido = false;
            }

            // Validar Stock (numérico)
            if (!int.TryParse(txtStock.Text, out _))
            {
                lblErrorStock.Text = "El stock debe ser un número entero.";
                esValido = false;
            }

            // Validar Categoría
            if (cmbCategoria.SelectedItem == null)
            {
                lblErrorCategoria.Text = "Selecciona una categoría.";
                esValido = false;
            }

            // Validar Marca
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                lblErrorMarca.Text = "La marca es obligatoria.";
                esValido = false;
            }

            // Validar Código Único
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                lblErrorCodigo.Text = "El código es obligatorio.";
                esValido = false;
            }
            else if (listaProductos.Any(p => p.Codigo == txtCodigo.Text))
            {
                lblErrorCodigo.Text = "Este código ya existe.";
                esValido = false;
            }

            return esValido;
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
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvProductos.Rows[e.RowIndex];
                if (fila.Cells["Id"].Value != null)
                {
                    var idProducto = int.Parse(fila.Cells["Id"].Value.ToString());
                    var productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

                    if (productoSeleccionado != null)
                    {
                        txtNombreProducto.Text = productoSeleccionado.Nombre;
                        txtDescripcion.Text = productoSeleccionado.Descripcion;
                        cmbTalle.SelectedItem = productoSeleccionado.Talle;
                        txtColor.Text = productoSeleccionado.Color;
                        txtPrecio.Text = productoSeleccionado.Precio.ToString();
                        txtStock.Text = productoSeleccionado.Stock.ToString();
                        cmbCategoria.SelectedItem = productoSeleccionado.Categoria;
                        txtMarca.Text = productoSeleccionado.Marca;
                        txtCodigo.Text = productoSeleccionado.Codigo;
                    }
                }
            }
        }

        private void txt_SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, la tecla de retroceso (Backspace) y el punto/coma decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Si es un punto o una coma, evita que se ponga más de uno.
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras, la tecla de retroceso (Backspace) y la barra espaciadora
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
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

        public override string ToString()
        {
            return $"{Nombre} - {Codigo} - ${Precio}";
        }
    }
}