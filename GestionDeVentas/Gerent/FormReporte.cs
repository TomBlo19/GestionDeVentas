using System;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    public partial class FormReportesGerente : Form
    {
        public FormReportesGerente()
        {
            InitializeComponent();
        }

        private void FormReportesGerente_Load(object sender, EventArgs e)
        {
            // Inicializar combos
            cmbCliente.Items.AddRange(new object[] { "Todos", "Valentina Barbero", "Juan Pérez", "Ana Torres" });
            cmbCliente.SelectedIndex = 0;

            cmbVendedor.Items.AddRange(new object[] { "Todos", "Tomás Bolo", "Valentina Asselborn", "Juan Gómez" });
            cmbVendedor.SelectedIndex = 0;

            cmbMetodoPago.Items.AddRange(new object[] { "Todos", "Efectivo", "Tarjeta", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();

            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de facturas ficticias
            dgvFacturas.Rows.Add("000001", "10/09/2025", "Valentina Barbero", "Tomás Bolo", "Efectivo", "$1200");
            dgvFacturas.Rows.Add("000002", "12/09/2025", "Juan Pérez", "Valentina Asselborn", "Tarjeta", "$2400");
            dgvFacturas.Rows.Add("000003", "13/09/2025", "Ana Torres", "Juan Gómez", "Transferencia", "$1800");

            lblResultados.Text = $"{dgvFacturas.Rows.Count} facturas encontradas";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbCliente.SelectedIndex = 0;
            cmbVendedor.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;

            dgvFacturas.Rows.Clear();
            lblResultados.Text = "0 facturas encontradas";
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso");
                return;
            }
            MessageBox.Show("Exportación PDF (estético).");
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.Rows.Count == 0)
            {
                MessageBox.Show("No hay facturas para exportar.", "Aviso");
                return;
            }
            MessageBox.Show("Exportación Excel (estético).");
        }

        // 🔹 Manejar clic en "Ver Detalle"
        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvFacturas.Columns["colVerDetalle"].Index)
            {
                // Abrir detalle (datos ficticios por ahora)
                FormDetalleFacturaGerente frm = new FormDetalleFacturaGerente();
                frm.ShowDialog();
            }
        }
    }
}
