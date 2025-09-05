using System;
using System.Windows.Forms;

namespace GestionDeVentas.Vendedor
{
    public partial class FormFactura : Form
    {
        public FormFactura()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Simulación: agregar fila vacía
            dgvDetalle.Rows.Add("Remera", 1, 5000, 5000);
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["colSubtotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["colSubtotal"].Value);
                }
            }

            decimal iva = subtotal * 0.21m;
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C");
            txtIVA.Text = iva.ToString("C");
            txtTotal.Text = total.ToString("C");
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Factura generada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
