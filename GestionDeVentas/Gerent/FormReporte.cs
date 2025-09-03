using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Gerent
{
    public partial class FormReportes : Form
    {
        private List<Venta> _ventas;     // dataset base (demo)
        private List<Venta> _filtradas;  // dataset filtrado actual

        public FormReportes()
        {
            InitializeComponent();
            this.Load += FormReportes_Load;
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // OCULTAR elementos de dashboard si existen en tu Designer
            try { panelKpis.Visible = false; } catch { }
            try { panelGraficos.Visible = false; } catch { }

            // 1) Datos demo (últimos 6 meses)
            _ventas = GenerarVentasDemoUltimos6Meses();

            // 2) Cargar vendedores al combo
            var vendedores = _ventas.Select(v => v.Vendedor).Distinct().OrderBy(x => x).ToList();
            vendedores.Insert(0, "Todos");
            cboVendedor.DataSource = vendedores;

            // 3) Rango por defecto: todo el rango disponible
            var min = _ventas.Min(v => v.Fecha).Date;
            var max = _ventas.Max(v => v.Fecha).Date;
            dtpDesde.MinDate = min; dtpDesde.MaxDate = max;
            dtpHasta.MinDate = min; dtpHasta.MaxDate = max;
            dtpDesde.Value = min; dtpHasta.Value = max;

            AplicarFiltros();
        }

        private void btnAplicar_Click(object sender, EventArgs e) => AplicarFiltros();

        // Exportar CSV del detalle
        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            if (_filtradas == null || _filtradas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog()
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = $"reporte_ventas_{DateTime.Now:yyyyMMdd_HHmm}.csv"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExportarCsv(sfd.FileName, _filtradas);
                    MessageBox.Show("Archivo exportado correctamente.", "Exportar CSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Exportar captura de la grilla (por si la querés pegar en un informe)
        private void btnExportarPng_Click(object sender, EventArgs e)
        {
            if (_filtradas == null || _filtradas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar imagen.", "Exportar PNG",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog()
            {
                Filter = "PNG (*.png)|*.png",
                FileName = $"reporte_detalle_{DateTime.Now:yyyyMMdd_HHmm}.png"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var bmp = new System.Drawing.Bitmap(dgvDetalle.Width, dgvDetalle.Height))
                    {
                        dgvDetalle.DrawToBitmap(bmp, dgvDetalle.ClientRectangle);
                        bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    MessageBox.Show("Imagen exportada.", "Exportar PNG",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ============================
        // Filtros y visualización (solo detalle)
        // ============================
        private void AplicarFiltros()
        {
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date;
            if (hasta < desde)
            {
                MessageBox.Show("'Hasta' no puede ser menor que 'Desde'.", "Rango inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vendedor = cboVendedor.SelectedItem?.ToString() ?? "Todos";

            _filtradas = _ventas
                .Where(v => v.Fecha.Date >= desde && v.Fecha.Date <= hasta
                            && (vendedor == "Todos" || v.Vendedor == vendedor))
                .OrderBy(v => v.Fecha)
                .ToList();

            PintarGrillaDetalle(_filtradas);
        }

        private void PintarGrillaDetalle(List<Venta> data)
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.Columns.Clear();

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "Fecha", Width = 90, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vendedor", DataPropertyName = "Vendedor", Width = 120 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Producto", DataPropertyName = "Producto", Width = 150 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", DataPropertyName = "Cantidad", Width = 70 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Importe", DataPropertyName = "Importe", Width = 90, DefaultCellStyle = { Format = "C2", FormatProvider = CultureInfo.GetCultureInfo("es-AR") } });

            dgvDetalle.DataSource = data;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;

            // Muestra totales en el título del formulario (o podés poner labels propios)
            var cultura = CultureInfo.GetCultureInfo("es-AR");
            decimal monto = data.Sum(v => v.Importe);
            int unidades = data.Sum(v => v.Cantidad);
            int pedidos = data.Count;
            this.Text = $"Reportes - Detalle ({pedidos} pedidos, {unidades} unidades, {monto.ToString("$ #,0", cultura)})";
        }

        // ============================
        // Utilidades
        // ============================
        private void ExportarCsv(string path, List<Venta> data)
        {
            var cultura = CultureInfo.GetCultureInfo("es-AR");
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("Fecha,Vendedor,Producto,Cantidad,Importe");
                foreach (var v in data)
                    sw.WriteLine($"{v.Fecha:yyyy-MM-dd},{Esc(v.Vendedor)},{Esc(v.Producto)},{v.Cantidad},{v.Importe.ToString(cultura)}");
            }
        }

        private string Esc(string s) { return "\"" + s.Replace("\"", "\"\"") + "\""; }

        private List<Venta> GenerarVentasDemoUltimos6Meses()
        {
            var rnd = new Random(7);
            var vendedores = new[] { "Vendedor 1", "Vendedor 2", "Vendedor 3" };
            var productos = new[] { "Remera", "Buzo", "Jean", "Campera", "Hoodie" };

            var hoyMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var lista = new List<Venta>();

            for (int i = 5; i >= 0; i--)
            {
                var baseMes = hoyMes.AddMonths(-i);
                int ventasMes = rnd.Next(40, 71);
                for (int k = 0; k < ventasMes; k++)
                {
                    var fecha = baseMes.AddDays(rnd.Next(0, DateTime.DaysInMonth(baseMes.Year, baseMes.Month)));
                    var vend = vendedores[rnd.Next(vendedores.Length)];
                    var prod = productos[rnd.Next(productos.Length)];
                    int cant = rnd.Next(1, 5);

                    decimal precio;
                    switch (prod)
                    {
                        case "Remera": precio = 12000m; break;
                        case "Buzo": precio = 25000m; break;
                        case "Jean": precio = 38000m; break;
                        case "Campera": precio = 65000m; break;
                        default: precio = 30000m; break;
                    }

                    lista.Add(new Venta
                    {
                        Fecha = fecha,
                        Vendedor = vend,
                        Producto = prod,
                        Cantidad = cant,
                        Importe = precio * cant
                    });
                }
            }
            return lista;
        }

        // Clase de dominio
        private class Venta
        {
            public DateTime Fecha { get; set; }
            public string Vendedor { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal Importe { get; set; }
        }
    }
}
