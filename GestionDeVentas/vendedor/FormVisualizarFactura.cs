using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Modelos;

namespace GestionDeVentas.Vendedor
{
    public partial class FormVisualizarFactura : Form
    {
        private readonly Factura _factura;   

        public FormVisualizarFactura(Factura factura)
        {
            InitializeComponent();
            _factura = factura ?? throw new ArgumentNullException(nameof(factura));
        }

        private void FormVisualizarFactura_Load(object sender, EventArgs e)
        {
            CargarDatosFactura();
        }

        private void CargarDatosFactura()
        {
            // ========= Encabezado =========
            lblTitulo.Text = $"Factura Nº {_factura.IdFactura:D6}";
            lblFecha.Text = $"Fecha: {_factura.FechaFactura:dd/MM/yyyy}";
            lblVendedor.Text = $"Vendedor: {_factura.UsuarioNombre ?? "-"}";

            // ========= Cliente =========
            txtClienteNombre.Text = _factura.ClienteNombre ?? "-";
            txtClienteDni.Text = _factura.ClienteDni ?? "-";
            txtClienteDireccion.Text = _factura.ClienteDireccion ?? "-";

            // 👇 Mostramos teléfono + correo juntos, más claro visualmente
            if (!string.IsNullOrEmpty(_factura.ClienteTelefono) && !string.IsNullOrEmpty(_factura.ClienteCorreo))
                txtClienteContacto.Text = $"{_factura.ClienteTelefono} | {_factura.ClienteCorreo}";
            else if (!string.IsNullOrEmpty(_factura.ClienteTelefono))
                txtClienteContacto.Text = _factura.ClienteTelefono;
            else if (!string.IsNullOrEmpty(_factura.ClienteCorreo))
                txtClienteContacto.Text = _factura.ClienteCorreo;
            else
                txtClienteContacto.Text = "-";

            // ========= Detalle =========
            dgvProductos.Rows.Clear();

            if (_factura.Detalles != null && _factura.Detalles.Count > 0)
            {
                foreach (var d in _factura.Detalles)
                {
                    dgvProductos.Rows.Add(
                        d.ProductoCodigo,
                        d.ProductoNombre,
                        d.TalleNombre ?? "-", 
                        d.Cantidad,
                        d.PrecioUnitario.ToString("C", CultureInfo.CurrentCulture),
                        (d.Cantidad * d.PrecioUnitario).ToString("C", CultureInfo.CurrentCulture)
                    );
                }
            }

            // ========= Totales =========
            decimal subtotal = _factura.Detalles?.Sum(x => x.Cantidad * x.PrecioUnitario) ?? 0m;
            decimal iva = subtotal * 0.21m;
            decimal total = _factura.TotalFactura > 0 ? _factura.TotalFactura : subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("C", CultureInfo.CurrentCulture);
            txtIVA.Text = iva.ToString("C", CultureInfo.CurrentCulture);
            txtTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);

            // ========= Método de pago =========
            txtMetodoPago.Text = _factura.MetodoPagoNombre ?? "-";

            // ========= Monto entregado / vuelto =========
           // txtMontoEntregado.Text = "-";
          //  txtVuelto.Text = "-";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Eventos vacíos (requeridos por el .Designer)
        private void lblEmpresaDireccion_Click(object sender, EventArgs e) { }
        private void lblEmpresaNombre_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Cargar plantilla HTML
                string rutaPlantilla = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "plantilla_TYV.html");
                if (!File.Exists(rutaPlantilla))
                {
                    MessageBox.Show("No se encontró plantilla_TYV.html en /Resources", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string html = File.ReadAllText(rutaPlantilla, Encoding.UTF8);

                // 2️⃣ Logo embebido permanentemente en Base64 (sin depender del archivo físico)
                string logoBase64 = "";

                try
                {
                    // Ruta del archivo que contiene el texto Base64 del logo
                    string rutaLogoBase64 = Path.Combine(Application.StartupPath, "Resources", "logoFactura_base64.txt");

                    if (File.Exists(rutaLogoBase64))
                    {
                        // Leer todo el contenido del archivo Base64
                        logoBase64 = File.ReadAllText(rutaLogoBase64);
                    }
                    else
                    {
                        // Si el archivo no existe, se muestra advertencia y se deja vacío
                        MessageBox.Show("No se encontró logoFactura_base64.txt en /Resources",
                                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        logoBase64 = "";
                    }
                }
                catch (Exception ex)
                {
                    // Si hay error de lectura, se informa
                    MessageBox.Show($"Error al leer el logo en Base64:\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logoBase64 = "";
                }

                // Reemplazar el marcador @LOGO en la plantilla HTML
                html = html.Replace("@LOGO", logoBase64);



                // 3️⃣ Datos de la empresa
                html = html.Replace("@EMPRESA", "TYV CLOTHES S.A.");
                html = html.Replace("@DIRECCION_EMPRESA", "Av. 3 de Abril 1455 - Corrientes, Argentina");
                html = html.Replace("@CUIT", "30-99999999-9");
                html = html.Replace("@CONTACTO_EMPRESA", "(3794) 999999 | tyvclothes@gmail.com");

                // 4️⃣ Datos de la factura
                html = html.Replace("@NUMERO_FACTURA", _factura.IdFactura.ToString("D6"));
                html = html.Replace("@FECHA", _factura.FechaFactura.ToString("dd/MM/yyyy"));
                html = html.Replace("@VENDEDOR", _factura.UsuarioNombre ?? "-");

                // 5️⃣ Datos del cliente
                html = html.Replace("@CLIENTE", _factura.ClienteNombre ?? "-");
                html = html.Replace("@DNI", _factura.ClienteDni ?? "-");
                html = html.Replace("@DIRECCION", _factura.ClienteDireccion ?? "-");

                string contactoCliente = "-";
                if (!string.IsNullOrEmpty(_factura.ClienteTelefono) && !string.IsNullOrEmpty(_factura.ClienteCorreo))
                    contactoCliente = $"{_factura.ClienteTelefono} | {_factura.ClienteCorreo}";
                else if (!string.IsNullOrEmpty(_factura.ClienteTelefono))
                    contactoCliente = _factura.ClienteTelefono;
                else if (!string.IsNullOrEmpty(_factura.ClienteCorreo))
                    contactoCliente = _factura.ClienteCorreo;

                html = html.Replace("@CONTACTO", contactoCliente);
                html = html.Replace("@METODO_PAGO", _factura.MetodoPagoNombre ?? "-");

                // 6️⃣ Armar filas del detalle
                StringBuilder filas = new StringBuilder();
                foreach (var d in _factura.Detalles)
                {
                    filas.AppendLine("<tr>");
                    filas.AppendLine($"<td>{d.ProductoCodigo}</td>");
                    filas.AppendLine($"<td>{d.ProductoNombre}</td>");
                    filas.AppendLine($"<td>{d.TalleNombre}</td>");
                    filas.AppendLine($"<td>{d.Cantidad}</td>");
                    filas.AppendLine($"<td>{d.PrecioUnitario.ToString("C")}</td>");
                    filas.AppendLine($"<td>{(d.Cantidad * d.PrecioUnitario).ToString("C")}</td>");
                    filas.AppendLine("</tr>");
                }
                html = html.Replace("@FILAS", filas.ToString());

                // 7️⃣ Totales
                decimal subtotal = _factura.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
                decimal iva = subtotal * 0.21m;
                decimal total = subtotal + iva;

                html = html.Replace("@SUBTOTAL", subtotal.ToString("C"));
                html = html.Replace("@IVA", iva.ToString("C"));
                html = html.Replace("@TOTAL", total.ToString("C"));

                // 8️⃣ Guardar PDF
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.FileName = $"Factura_{_factura.IdFactura:D6}.pdf";
                guardar.Filter = "Archivos PDF|*.pdf";
                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdf, stream);
                    pdf.Open();

                    using (StringReader sr = new StringReader(html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdf, sr);
                    }

                    pdf.Close();
                }

                // 9️⃣ Mostrar confirmación
                MessageBox.Show("Factura PDF generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(guardar.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
