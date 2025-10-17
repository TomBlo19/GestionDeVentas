using Datos;
using GestionDeVentas.Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVentas : Form
    {
        private readonly FacturaDatos facturaDatos = new FacturaDatos();
        private readonly ClienteDatos clienteDatos = new ClienteDatos(); // Ya lo teníamos de antes
        private List<Factura> facturas = new List<Factura>();
        private System.Windows.Forms.TextBox txtBuscarCliente;

        public FormVentas()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.txtBuscarCliente = this.txtBusquedaCliente;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarFacturas();

            cboClienteCriterio.Items.Clear();
            cboClienteCriterio.Items.Add("Apellido");
            cboClienteCriterio.Items.Add("DNI");
            cboClienteCriterio.SelectedIndex = 0;

            SetPlaceholder(txtBusquedaCliente, "Apellido o DNI del cliente...");
            SetPlaceholder(txtBuscarNroFactura, "Número de factura");
        }

        private void CargarFacturas()
        {
            try
            {
                facturas = facturaDatos.ObtenerFacturasPorVendedor(SesionActual.IdUsuario);
                ActualizarTablaVentas(facturas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // 🔹 BUSCAR FACTURAS (LÓGICA ACTUALIZADA)
        // ======================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nroFacturaTexto = (txtBuscarNroFactura.ForeColor != Color.Gray) ? txtBuscarNroFactura.Text.Trim() : "";

                // --- CASO 1: Si se busca por un número de factura específico ---
                if (!string.IsNullOrEmpty(nroFacturaTexto) && int.TryParse(nroFacturaTexto, out int idFacturaBuscada))
                {
                    var facturaEncontrada = facturaDatos.ObtenerFacturaPorId(idFacturaBuscada, SesionActual.IdUsuario);
                    var resultadoBusqueda = new List<Factura>();
                    if (facturaEncontrada != null)
                    {
                        resultadoBusqueda.Add(facturaEncontrada);
                    }
                    ActualizarTablaVentas(resultadoBusqueda);
                    return; // Terminamos la búsqueda aquí, porque el ID es único
                }

                // --- CASO 2: Si no se busca por ID, se aplican los otros filtros ---
                var facturasFiltradas = new List<Factura>(facturas);

                string criterioCliente = cboClienteCriterio.SelectedItem.ToString();
                string textoCliente = (txtBusquedaCliente.ForeColor != Color.Gray) ? txtBusquedaCliente.Text.Trim() : "";

                if (!string.IsNullOrEmpty(textoCliente))
                {
                    List<Cliente> clientesEncontrados;
                    if (criterioCliente == "Apellido")
                    {
                        clientesEncontrados = clienteDatos.BuscarClientesPorApellido(textoCliente);
                    }
                    else // DNI
                    {
                        clientesEncontrados = clienteDatos.BuscarClientesPorDni(textoCliente);
                    }
                    List<int> idsClientesEncontrados = clientesEncontrados.Select(c => c.Id).ToList();
                    facturasFiltradas = facturasFiltradas.Where(f => idsClientesEncontrados.Contains(f.IdCliente)).ToList();
                }

                // Filtro por fecha (se aplica sobre la lista ya filtrada por cliente, si aplica)
                facturasFiltradas = facturasFiltradas.Where(f =>
                    (!dtpFechaInicio.Checked || f.FechaFactura.Date >= dtpFechaInicio.Value.Date) &&
                    (!dtpFechaFin.Checked || f.FechaFactura.Date <= dtpFechaFin.Value.Date)
                ).ToList();

                ActualizarTablaVentas(facturasFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            SetPlaceholder(txtBusquedaCliente, "Apellido o DNI del cliente...");
            SetPlaceholder(txtBuscarNroFactura, "Número de factura");
            cboClienteCriterio.SelectedIndex = 0;
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;

            ActualizarTablaVentas(facturas);
        }

        // --- El resto de tus métodos (ActualizarTablaVentas, MostrarFactura, etc.) van aquí sin cambios ---
        private void ActualizarTablaVentas(List<Factura> lista)
        {
            dgvVentas.Rows.Clear();
            foreach (var f in lista)
            {
                int index = dgvVentas.Rows.Add(
                    f.IdFactura.ToString("D6"),
                    f.FechaFactura.ToShortDateString(),
                    f.ClienteNombre,
                    f.MetodoPagoNombre,
                    f.TotalFactura.ToString("C", CultureInfo.CurrentCulture)
                );
                dgvVentas.Rows[index].DefaultCellStyle.ForeColor = f.Activo ? Color.Black : Color.Gray;
            }
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idFactura = int.Parse(dgvVentas.Rows[e.RowIndex].Cells["colNroFactura"].Value.ToString());
                MostrarFactura(idFactura);
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvVentas.Columns["colVer"].Index)
            {
                int idFactura = int.Parse(dgvVentas.Rows[e.RowIndex].Cells["colNroFactura"].Value.ToString());
                MostrarFactura(idFactura);
            }
        }

        private void MostrarFactura(int idFactura)
        {
            try
            {
                var factura = facturas.FirstOrDefault(f => f.IdFactura == idFactura);
                if (factura == null)
                {
                    // Si la factura no está en la lista cargada, la buscamos por si acaso
                    factura = facturaDatos.ObtenerFacturaPorId(idFactura, SesionActual.IdUsuario);
                    if (factura == null)
                    {
                        MessageBox.Show("No se encontró la factura seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                factura.Detalles = facturaDatos.ObtenerDetallesPorFactura(idFactura);
                var formDetalle = new FormVisualizarFactura(factura);
                formDetalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar factura:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.Font = new Font(txt.Font, FontStyle.Italic);
            txt.GotFocus += (s, e) => {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font(txt.Font, FontStyle.Regular);
                }
            };
            txt.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.Font = new Font(txt.Font, FontStyle.Italic);
                }
            };
        }
    }
}