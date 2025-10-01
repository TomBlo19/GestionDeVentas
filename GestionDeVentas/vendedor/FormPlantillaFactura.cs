using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

// ASUMIMOS QUE ESTE ES EL NAMESPACE DONDE ESTÁN LOS NUEVOS FORMULARIOS
// Si tus nuevos formularios tienen un namespace diferente, ajusta esto.
using TuProyecto;

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        private int numeroFactura = 12;

        // Vendedor se sigue cargando al iniciar
        private string vendedorActual = "V001 - Tomás Bolo";

        public FormFactura()
        {
            InitializeComponent();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            // Configuración inicial del formulario
            lblNroFactura.Text = $"Nº Factura: {numeroFactura.ToString("D6")}";
            lblFecha.Text = $"Fecha: {DateTime.Now.ToShortDateString()}";

            // Asignar el vendedor actual al label
            lblVendedorActual.Text = $"Vendedor: {vendedorActual}";

            // Configurar el ComboBox de Métodos de Pago
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;

            // Eliminamos los placeholders de los campos de búsqueda (ya no se usan para entrada manual)
            // Se dejan solo los placeholders para los campos de pago
            SetPlaceholder(txtInfoPago, "Número, vencimiento, CVV");

            // Asegura que los campos de detalle del cliente son de solo lectura
            txtDni.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtContacto.ReadOnly = true;
            txtBuscarCliente.ReadOnly = true; // El usuario ya no escribe aquí
            txtBuscarProducto.ReadOnly = true; // El usuario ya no escribe aquí

            // Llama a la lógica de pago al iniciar
            cmbMetodoPago_SelectedIndexChanged(null, null);
        }

        // === Placeholder y Diseño (MISMO CÓDIGO) ===
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            // ... (El código de SetPlaceholder es el mismo)
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.Font = new Font(txt.Font, FontStyle.Italic);

            txt.GotFocus += (s, ev) =>
            {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font(txt.Font, FontStyle.Regular);
                }
            };

            txt.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.Font = new Font(txt.Font, FontStyle.Italic);
                }
            };
        }

        // ----------------------------------------------------------------------
        // MODIFICACIÓN CLAVE: Abrir Formulario de Búsqueda de Clientes
        // ----------------------------------------------------------------------
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Ocultamos el campo de texto de búsqueda temporalmente
            // txtBuscarCliente.Text = "Buscando cliente...";

            using (BuscarClienteForm buscarCliente = new BuscarClienteForm())
            {
                // Abrir el formulario de búsqueda de forma modal
                if (buscarCliente.ShowDialog() == DialogResult.OK)
                {
                    // ASUMIMOS QUE LA PROPIEDAD SE LLAMA ClienteSeleccionado (como en la respuesta anterior)
                    string clienteData = buscarCliente.ClienteSeleccionado;

                    // Lógica para parsear y cargar los datos del cliente seleccionado
                    // NOTA: Esto es una simulación. En una aplicación real, usarías objetos o IDs.
                    if (!string.IsNullOrEmpty(clienteData))
                    {
                        // Ejemplo de asignación de datos simulados al encontrar un cliente
                        txtBuscarCliente.Text = clienteData;
                        txtDni.Text = "40222333";
                        txtNombre.Text = clienteData;
                        txtDireccion.Text = "Calle Falsa 123";
                        txtContacto.Text = "contacto@ejemplo.com";
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // ----------------------------------------------------------------------
        // MODIFICACIÓN CLAVE: Abrir Formulario de Búsqueda de Productos
        // ----------------------------------------------------------------------
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            // txtBuscarProducto.Text = "Buscando producto...";

            using (BuscarProductoForm buscarProducto = new BuscarProductoForm())
            {
                if (buscarProducto.ShowDialog() == DialogResult.OK)
                {
                    // Recupera el objeto ProductoInfo
                    var p = buscarProducto.ProductoSeleccionado;

                    if (p != null)
                    {
                        // Añadir el producto al DataGridView
                        // Columnas: Código, Producto, Talle, Cantidad (1), Precio Unitario, Subtotal
                        // ASUMIMOS que p.Talle existe en la clase ProductoInfo de BuscarProductoForm
                        string talle = (p.GetType().GetProperty("Talle") != null) ? (string)p.GetType().GetProperty("Talle").GetValue(p) : "N/A";

                        // Buscamos si ya existe el producto en el carrito
                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            if (row.Cells["colCodigo"].Value?.ToString() == p.Id.ToString())
                            {
                                // Si existe, incrementamos la cantidad
                                int cantidadActual = Convert.ToInt32(row.Cells["colCantidad"].Value);
                                row.Cells["colCantidad"].Value = cantidadActual + 1;
                                dgvDetalle_CellEndEdit(dgvDetalle, new DataGridViewCellEventArgs(dgvDetalle.Columns["colCantidad"].Index, row.Index));
                                return;
                            }
                        }

                        // Si no existe, agregamos nueva fila.
                        dgvDetalle.Rows.Add(p.Id.ToString(), p.Nombre, talle, 1, p.Precio.ToString("N2", CultureInfo.CurrentCulture), p.Precio.ToString("C", CultureInfo.CurrentCulture));

                        // Opcional: Mostrar stock disponible
                        txtBuscarProducto.Text = $"Producto cargado. Stock: {p.StockDisponible}";

                        CalcularTotales();
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // === Totales y Lógica de Pago (MISMO CÓDIGO) ===
        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvDetalle.Rows[e.RowIndex];

            // Validar la cantidad
            if (e.ColumnIndex == dgvDetalle.Columns["colCantidad"].Index)
            {
                if (!int.TryParse(row.Cells["colCantidad"].Value?.ToString(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    row.Cells["colCantidad"].Value = 1;
                    cantidad = 1;
                }
            }

            // Validar el precio
            if (e.ColumnIndex == dgvDetalle.Columns["colPrecio"].Index)
            {
                if (!decimal.TryParse(row.Cells["colPrecio"].Value?.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número decimal mayor a 0.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Aquí ya no tenemos la lista 'productos' para obtener el precio original, 
                    // así que simplemente mantenemos el valor anterior (o un valor por defecto)
                    row.Cells["colPrecio"].Value = 1.00m.ToString("N2");
                }
            }

            if (row.Cells["colCantidad"].Value != null && row.Cells["colPrecio"].Value != null)
            {
                int cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);
                // Asegurar que el precio se parsea correctamente (quitando símbolo de moneda si existe)
                decimal precio;
                if (!decimal.TryParse(row.Cells["colPrecio"].Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, ""), out precio))
                {
                    precio = 0m; // Fallback
                }

                row.Cells["colSubtotal"].Value = (cantidad * precio).ToString("C", CultureInfo.CurrentCulture);
            }
            CalcularTotales();
        }

        private void dgvDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0
                && e.ColumnIndex == dgvDetalle.Columns["colEliminar"].Index
                && dgvDetalle.Rows.Count > 0)
            {
                // Verifico que no sea la fila "nueva" de DataGridView
                if (!dgvDetalle.Rows[e.RowIndex].IsNewRow)
                {
                    dgvDetalle.Rows.RemoveAt(e.RowIndex);
                    CalcularTotales();
                }
            }
        }


        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodoSeleccionado = cmbMetodoPago.SelectedItem.ToString();

            bool esEfectivo = metodoSeleccionado == "Efectivo";

            lblMontoEntregado.Visible = esEfectivo;
            txtMontoEntregado.Visible = esEfectivo;
            lblVuelto.Visible = esEfectivo;
            txtVuelto.Visible = esEfectivo;

            lblInfoPago.Visible = !esEfectivo;
            txtInfoPago.Visible = !esEfectivo;

            if (metodoSeleccionado == "Tarjeta")
            {
                lblInfoPago.Text = "Datos de Tarjeta:";
                SetPlaceholder(txtInfoPago, "Número, vencimiento, CVV");
            }
            else if (metodoSeleccionado == "Transferencia")
            {
                lblInfoPago.Text = "Datos de Transferencia:";
                SetPlaceholder(txtInfoPago, "Nº de Referencia / ID de Transacción");
            }
            // Asegurar que txtMontoEntregado se limpia si no es efectivo
            if (!esEfectivo)
            {
                txtMontoEntregado.Text = "";
            }


            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            // Usamos un loop inverso o verificamos IsNewRow para evitar errores en DGV
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                DataGridViewRow row = dgvDetalle.Rows[i];
                if (!row.IsNewRow && row.Cells["colSubtotal"].Value != null)
                {
                    // Limpieza del string antes de parsear (quita el símbolo de moneda)
                    string subtotalStr = row.Cells["colSubtotal"].Value.ToString().Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim();

                    if (decimal.TryParse(subtotalStr, NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out decimal rowSubtotal))
                    {
                        subtotal += rowSubtotal;
                    }
                }
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);

            if (cmbMetodoPago.SelectedItem?.ToString() == "Efectivo")
            {
                if (decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado))
                {
                    if (montoEntregado < total)
                    {
                        txtVuelto.Text = "Monto insuficiente";
                        txtVuelto.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtVuelto.Text = (montoEntregado - total).ToString("C", CultureInfo.CurrentCulture);
                        txtVuelto.ForeColor = Color.Black;
                    }
                }
                else
                {
                    txtVuelto.Text = "";
                    txtVuelto.ForeColor = Color.Black;
                }
            }
            else
            {
                txtVuelto.Text = "";
                txtVuelto.ForeColor = Color.Black;
            }
        }

        // === Botones de Acción (MISMO CÓDIGO) ===
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0 || (dgvDetalle.Rows.Count == 1 && dgvDetalle.Rows[0].IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que se haya seleccionado un cliente (usando el campo DNI como proxy)
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente antes de facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string metodoPago = cmbMetodoPago.SelectedItem.ToString();
            // Limpieza del string para el cálculo del total
            decimal totalFactura;
            string totalStr = txtTotal.Text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim();
            decimal.TryParse(totalStr, NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out totalFactura);

            if (metodoPago == "Efectivo")
            {
                if (!decimal.TryParse(txtMontoEntregado.Text, out decimal montoEntregado) || montoEntregado < totalFactura)
                {
                    MessageBox.Show("Debe ingresar un monto válido y suficiente para calcular el vuelto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtInfoPago.Text) || txtInfoPago.ForeColor == Color.Gray)
                {
                    MessageBox.Show($"Debe ingresar los datos de {metodoPago.ToLower()}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Lógica para avanzar el número de factura y limpiar campos
            numeroFactura++;
            // ... (Lógica de limpieza)
            FormFactura_Load(sender, e); // Recargar/resetear
        }

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();
        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}