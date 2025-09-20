using System;
using System.Windows.Forms;

namespace GestionDeVentas.Gerente
{
    public partial class FormDetalleFacturaGerente : Form
    {
        public FormDetalleFacturaGerente()
        {
            InitializeComponent();
        }

        private void FormDetalleFacturaGerente_Load(object sender, EventArgs e)
        {
            // Simulación de datos en la factura
            dgvProductos.Rows.Add("A123", "Camiseta Básica", "M", "2", "$20", "$40");
            dgvProductos.Rows.Add("B456", "Jeans Slim Fit", "32", "1", "$50", "$50");

            txtSubtotal.Text = "$90";
            txtIVA.Text = "$18.90";
            txtTotal.Text = "$108.90";
            txtMontoEntregado.Text = "$120";
            txtVuelto.Text = "$11.10";
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulación de impresión de factura.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblNroFactura_Click(object sender, EventArgs e)
        {

        }
    }
}
