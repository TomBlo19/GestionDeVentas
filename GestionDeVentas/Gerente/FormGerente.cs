using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace gestionDeVentas
{
    public partial class FormGerente : Form
    {
        // ------ Modelo simple para demo ------
        private class Venta
        {
            public DateTime Fecha { get; set; }
            public string Vendedor { get; set; }
            public string Cliente { get; set; }
            public string Categoria { get; set; }
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnit { get; set; }
            public decimal Total => Cantidad * PrecioUnit;
        }

        private List<Venta> _todasLasVentas = new List<Venta>();

        public FormGerente()
        {
            InitializeComponent();
        }

        private void FormGerente_Load(object sender, EventArgs e)
        {
            UiStyles.ApplySidebarStyle(panelSidebar, lblTituloSidebar); //barra lateral para todoas las vistas
            // Rango de fechas por defecto: mes actual
            var now = DateTime.Now;
            dtDesde.Value = new DateTime(now.Year, now.Month, 1);
            dtHasta.Value = dtDesde.Value.AddMonths(1).AddDays(-1);

            GenerarDatosEjemplo();
            CargarVendedores();
            AplicarFiltrosYRefrescar();
        }

        private void GenerarDatosEjemplo()
        {
            // Datos mock para visualizar la UI (reemplaza con DB real)
            var vendedores = new[] { "María", "Carlos", "Ana", "Pedro" };
            var categorias = new[] { "Remeras", "Pantalones", "Camperas", "Accesorios" };
            var rnd = new Random();

            _todasLasVentas.Clear();

            // Dos meses de historial
            DateTime inicio = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1);
            for (int i = 0; i < 400; i++)
            {
                var f = inicio.AddDays(rnd.Next(0, 60));
                var v = vendedores[rnd.Next(vendedores.Length)];
                var c = $"Cliente {rnd.Next(1, 60)}";
                var cat = categorias[rnd.Next(categorias.Length)];
                var prod = $"{cat} #{rnd.Next(1, 120)}";
                var cant = rnd.Next(1, 5);
                var precio = 3000 + rnd.Next(0, 7000);

                _todasLasVentas.Add(new Venta
                {
                    Fecha = f,
                    Vendedor = v,
                    Cliente = c,
                    Categoria = cat,
                    Producto = prod,
                    Cantidad = cant,
                    PrecioUnit = precio
                });
            }
        }

        private void CargarVendedores()
        {
            var lista = _todasLasVentas.Select(x => x.Vendedor)
                                       .Distinct()
                                       .OrderBy(x => x)
                                       .ToList();
            lista.Insert(0, "Todos");
            cboVendedor.DataSource = lista;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltrosYRefrescar();
        }

        private void AplicarFiltrosYRefrescar()
        {
            var desde = dtDesde.Value.Date;
            var hasta = dtHasta.Value.Date;

            IEnumerable<Venta> filtradas = _todasLasVentas
                .Where(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta);

            if (cboVendedor.SelectedItem != null && cboVendedor.SelectedItem.ToString() != "Todos")
            {
                string vend = cboVendedor.SelectedItem.ToString();
                filtradas = filtradas.Where(x => x.Vendedor == vend);
            }

            var lista = filtradas.OrderByDescending(x => x.Fecha).ToList();

            PoblarGrilla(lista);
            PoblarKpis(lista);
            PoblarChartVendedores(lista);
            PoblarChartCategorias(lista);
        }

        private void PoblarGrilla(List<Venta> datos)
        {
            var table = new DataTable();
            table.Columns.Add("Fecha");
            table.Columns.Add("Vendedor");
            table.Columns.Add("Cliente");
            table.Columns.Add("Producto");
            table.Columns.Add("Categoría");
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("Precio Unit.", typeof(decimal));
            table.Columns.Add("Total", typeof(decimal));

            foreach (var v in datos)
            {
                table.Rows.Add(
                    v.Fecha.ToString("dd/MM/yyyy"),
                    v.Vendedor,
                    v.Cliente,
                    v.Producto,
                    v.Categoria,
                    v.Cantidad,
                    v.PrecioUnit,
                    v.Total
                );
            }

            dgvVentas.DataSource = table;
        }

        private void PoblarKpis(List<Venta> datos)
        {
            decimal ingresos = datos.Sum(x => x.Total);
            int unidades = datos.Sum(x => x.Cantidad);

            // crecimiento muy simple vs mismo rango anterior
            var rango = (dtHasta.Value.Date - dtDesde.Value.Date).Days + 1;
            var desdeAnterior = dtDesde.Value.Date.AddDays(-rango);
            var hastaAnterior = dtHasta.Value.Date.AddDays(-rango);

            var prev = _todasLasVentas.Where(x => x.Fecha.Date >= desdeAnterior && x.Fecha.Date <= hastaAnterior)
                                      .ToList();
            decimal ingresosPrev = prev.Sum(x => x.Total);
            decimal growth = ingresosPrev == 0 ? 100 :
                             Math.Round(((ingresos - ingresosPrev) / ingresosPrev) * 100m, 1);

            lblKpi1Val.Text = ingresos.ToString("C0"); // $ formato local
            lblKpi2Val.Text = unidades.ToString();
            lblKpi3Val.Text = (growth >= 0 ? "+" : "") + growth.ToString("0.0") + "%";
        }

        private void PoblarChartVendedores(List<Venta> datos)
        {
            chartVendedores.Series[0].Points.Clear();
            chartVendedores.Series[0].IsValueShownAsLabel = true;

            var porVendedor = datos.GroupBy(x => x.Vendedor)
                                   .Select(g => new { Vendedor = g.Key, Total = g.Sum(v => v.Total) })
                                   .OrderByDescending(x => x.Total);

            foreach (var item in porVendedor)
            {
                chartVendedores.Series[0].Points.AddXY(item.Vendedor, item.Total);
            }
        }

        private void PoblarChartCategorias(List<Venta> datos)
        {
            chartCategorias.Series[0].Points.Clear();
            chartCategorias.Series[0].IsValueShownAsLabel = true;

            var porCat = datos.GroupBy(x => x.Categoria)
                              .Select(g => new { Categoria = g.Key, Cant = g.Sum(v => v.Cantidad) })
                              .OrderByDescending(x => x.Cant);

            foreach (var item in porCat)
            {
                chartCategorias.Series[0].Points.AddXY(item.Categoria, item.Cant);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerrar o volver al login
            this.Close();
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
