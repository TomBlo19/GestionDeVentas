using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVentas : Form
    {
        private readonly FacturaDatos facturaDatos = new FacturaDatos();
        private List<Factura> facturas = new List<Factura>();

        public FormVentas()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
            SetPlaceholder(txtBuscarCliente, "Nombre del cliente");
            SetPlaceholder(txtBuscarNroFactura, "Número de factura");
        }

        // ======================================================
        // 🔹 CARGAR FACTURAS DESDE LA BASE
        // ======================================================
        private void CargarFacturas()
        {
            try
            {
                facturas = facturaDatos.ObtenerFacturasPorVendedor(SesionActual.IdUsuario);

                ActualizarTablaVentas(facturas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar facturas:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================
        // 🔹 ACTUALIZAR TABLA
        // ======================================================
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

                // Asignar color por estado
                dgvVentas.Rows[index].DefaultCellStyle.ForeColor =
                    f.Activo ? Color.Black : Color.Gray;
            }
        }

        // ======================================================
        // 🔹 PLACEHOLDERS
        // ======================================================
        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.Font = new Font(txt.Font, FontStyle.Italic);
            txt.GotFocus += (s, e) =>
            {
                if (txt.ForeColor == Color.Gray)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    txt.Font = new Font(txt.Font, FontStyle.Regular);
                }
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.Font = new Font(txt.Font, FontStyle.Italic);
                }
            };
        }

        // ======================================================
        // 🔹 BUSCAR FACTURAS
        // ======================================================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cliente = txtBuscarCliente.Text.Trim().ToLower();
            string nroFactura = txtBuscarNroFactura.Text.Trim().ToLower();

            var filtradas = facturas.Where(f =>
                (string.IsNullOrWhiteSpace(cliente) || f.ClienteNombre.ToLower().Contains(cliente)) &&
                (string.IsNullOrWhiteSpace(nroFactura) || f.IdFactura.ToString().Contains(nroFactura)) &&
                (!dtpFechaInicio.Checked || f.FechaFactura.Date >= dtpFechaInicio.Value.Date) &&
                (!dtpFechaFin.Checked || f.FechaFactura.Date <= dtpFechaFin.Value.Date)
            ).ToList();

            ActualizarTablaVentas(filtradas);
        }

        // ======================================================
        // 🔹 LIMPIAR FILTROS
        // ======================================================
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Text = "Nombre del cliente";
            txtBuscarNroFactura.Text = "Número de factura";
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;
            CargarFacturas();
        }

        // ======================================================
        // 🔹 DOBLE CLICK O BOTÓN “VER FACTURA”
        // ======================================================
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

        // ======================================================
        // 🔹 ABRIR FORM DETALLE
        // ======================================================
        private void MostrarFactura(int idFactura)
        {
            try
            {
                var factura = facturas.FirstOrDefault(f => f.IdFactura == idFactura);
                if (factura == null)
                {
                    MessageBox.Show("No se encontró la factura seleccionada.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                factura.Detalles = facturaDatos.ObtenerDetallesPorFactura(idFactura);

                var formDetalle = new FormVisualizarFactura(factura);
                formDetalle.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar factura:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();
    }
}
