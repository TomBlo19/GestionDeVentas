using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        private int numeroFactura = 12;

        private List<string> clientes = new List<string>
        {
            "35123456 - Valentina Barbero",
            "40222333 - Juan Pérez",
            "30987654 - Ana Torres",
            "29876543 - Luis Fernández"
        };

        private List<string> vendedores = new List<string>
        {
            "V001 - Tomás Bolo",
            "V002 - Valentina Asselborn",
            "V003 - Juan Gómez"
        };

        private List<(string codigo, string nombre, string talle, decimal precio)> productos =
            new List<(string, string, string, decimal)>
        {
            // Camisetas
            ("A123", "Camiseta Básica", "M", 20.00m),
            ("A124", "Camiseta Estampada", "L", 25.00m),
            ("A125", "Camiseta Oversize", "XL", 30.00m),

            // Jeans
            ("B456", "Jeans Slim Fit", "32", 50.00m),
            ("B457", "Jeans Regular Fit", "34", 55.00m),
            ("B458", "Jeans Rotos", "30", 60.00m),

            // Hoodies
            ("H001", "Hoodie Clásico", "M", 45.00m),
            ("H002", "Hoodie Oversize", "L", 55.00m),
            ("H003", "Hoodie con Cierre", "XL", 60.00m),

            // Camperas
            ("C789", "Campera Deportiva", "S", 80.00m),
            ("C790", "Campera de Cuero", "M", 120.00m),
            ("C791", "Campera Bomber", "L", 100.00m)
        };

        public FormFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            lblNroFactura.Text = numeroFactura.ToString("D6");
            dtpFecha.Value = DateTime.Now;

            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;

            SetPlaceholder(txtBuscarCliente, "Buscar por nombre o DNI");
            SetPlaceholder(txtBuscarVendedor, "Buscar por nombre o DNI");
            SetPlaceholder(txtBuscarProducto, "Buscar por código o nombre");
        }

        // === Placeholder ===
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;

            txt.GotFocus += (s, e) =>
            {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        // === Cliente ===
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var c in clientes)
            {
                menu.Items.Add(c, null, (s, ev) =>
                {
                    txtBuscarCliente.Text = c;
                    txtBuscarCliente.ForeColor = Color.Black;
                    if (c.Contains("Valentina"))
                    {
                        txtDni.Text = "35123456";
                        txtNombre.Text = "Valentina Barbero";
                        txtDireccion.Text = "Av. Siempre Viva 742";
                        txtContacto.Text = "valentina@example.com, 555-1234";
                    }
                    else if (c.Contains("Juan Pérez"))
                    {
                        txtDni.Text = "40222333";
                        txtNombre.Text = "Juan Pérez";
                        txtDireccion.Text = "Calle San Martín 1200";
                        txtContacto.Text = "juan@example.com, 555-7890";
                    }
                });
            }
            menu.Show(btnBuscarCliente, new Point(0, btnBuscarCliente.Height));
        }

        // === Vendedor ===
        private void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var v in vendedores)
            {
                menu.Items.Add(v, null, (s, ev) =>
                {
                    txtBuscarVendedor.Text = v;
                    txtBuscarVendedor.ForeColor = Color.Black;
                    lblVendedor.Text = "Vendedor: " + v;
                });
            }
            menu.Show(btnBuscarVendedor, new Point(0, btnBuscarVendedor.Height));
        }

        // === Producto ===
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (var p in productos)
            {
                string item = $"{p.codigo} - {p.nombre}";
                menu.Items.Add(item, null, (s, ev) =>
                {
                    dgvDetalle.Rows.Add(p.codigo, p.nombre, p.talle, 1, p.precio, p.precio);
                    CalcularTotales();
                });
            }
            menu.Show(btnBuscarProducto, new Point(0, btnBuscarProducto.Height));
        }

        // === Totales ===
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDetalle.Rows[e.RowIndex];
            if (row.Cells["colCantidad"].Value == null || row.Cells["colPrecio"].Value == null) return;

            if (!int.TryParse(row.Cells["colCantidad"].Value.ToString(), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error");
                row.Cells["colCantidad"].Value = 1;
                cantidad = 1;
            }

            if (!decimal.TryParse(row.Cells["colPrecio"].Value.ToString(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.", "Error");
                row.Cells["colPrecio"].Value = 1;
                precio = 1;
            }

            row.Cells["colSubtotal"].Value = cantidad * precio;
            CalcularTotales();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["colEliminar"].Index && e.RowIndex >= 0)
            {
                dgvDetalle.Rows.RemoveAt(e.RowIndex);
                CalcularTotales();
            }
        }

        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["colSubtotal"].Value != null)
                    subtotal += Convert.ToDecimal(row.Cells["colSubtotal"].Value);
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C");
            txtIVA.Text = iva.ToString("C");
            txtTotal.Text = total.ToString("C");

            if (cmbMetodoPago.SelectedItem.ToString() == "Efectivo")
            {
                if (decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado))
                {
                    if (montoEntregado < total)
                        txtVuelto.Text = "Monto insuficiente";
                    else
                        txtVuelto.Text = (montoEntregado - total).ToString("C");
                }
                else
                {
                    txtVuelto.Text = "";
                }
            }
            else
            {
                txtVuelto.Text = "";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Error");
                return;
            }

            if (cmbMetodoPago.SelectedItem.ToString() == "Efectivo" &&
                (string.IsNullOrWhiteSpace(txtMontoEntregado.Text) ||
                 txtVuelto.Text == "Monto insuficiente"))
            {
                MessageBox.Show("Debe ingresar un monto válido para calcular el vuelto.", "Error");
                return;
            }

            MessageBox.Show("Factura generada correctamente.", "Éxito");
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
