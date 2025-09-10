using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionDeVentas.Admin
{
    public partial class FormGestionProductos : Form
    {
        // Datos simulados para el dashboard y análisis
        private List<dynamic> productos = new List<dynamic>
        {
            new { Nombre = "Remera Básica", Stock = 3, Proveedor = "Proveedor A", Precio = 15.00m },
            new { Nombre = "Pantalón Cargo", Stock = 15, Proveedor = "Proveedor B", Precio = 30.00m },
            new { Nombre = "Sudadera con Capucha", Stock = 1, Proveedor = "Proveedor A", Precio = 45.00m },
            new { Nombre = "Campera de Cuero", Stock = 8, Proveedor = "Proveedor C", Precio = 80.00m },
            new { Nombre = "Gorra Deportiva", Stock = 2, Proveedor = "Proveedor B", Precio = 10.00m },
        };

        private List<dynamic> historialMovimientos = new List<dynamic>
        {
            new { Fecha = "25/10/2025", Producto = "Remera Básica", Movimiento = "Venta", Cantidad = 2 },
            new { Fecha = "25/10/2025", Producto = "Pantalón Cargo", Movimiento = "Venta", Cantidad = 1 },
            new { Fecha = "24/10/2025", Producto = "Remera Básica", Movimiento = "Entrada", Cantidad = 5 },
            new { Fecha = "23/10/2025", Producto = "Campera de Cuero", Movimiento = "Venta", Cantidad = 3 }
        };

        private List<dynamic> tendenciasVenta = new List<dynamic>
        {
            new { Producto = "Pantalón Cargo", Ventas = 50 },
            new { Producto = "Remera Básica", Ventas = 45 },
            new { Producto = "Campera de Cuero", Ventas = 30 }
        };

        public FormGestionProductos()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Ya no es necesario ocultar panelRegistro, porque no existe en el diseño.
            CargarTodosLosDatosEnVistaUnica();
        }

        private void CargarTodosLosDatosEnVistaUnica()
        {
            // Alertas de Stock Bajo
            var productosBajoStock = productos.Where(p => p.Stock <= 5).ToList();
            lblAlertasStock.Text = "Alertas de Stock Bajo:\n";
            if (productosBajoStock.Any())
            {
                foreach (var producto in productosBajoStock)
                {
                    lblAlertasStock.Text += $"- {producto.Nombre} (Stock: {producto.Stock})\n";
                }
            }
            else
            {
                lblAlertasStock.Text += "No hay productos con stock bajo.";
            }

            // Historial de Movimientos
            dgvHistorial.Rows.Clear();
            foreach (var movimiento in historialMovimientos)
            {
                dgvHistorial.Rows.Add(movimiento.Fecha, movimiento.Producto, movimiento.Movimiento, movimiento.Cantidad);
            }

            // Tendencias de Venta
            lblTendencias.Text = "Productos más vendidos (Último mes):\n";
            foreach (var tendencia in tendenciasVenta)
            {
                lblTendencias.Text += $"- {tendencia.Producto} ({tendencia.Ventas} ventas)\n";
            }

            // Promociones Activadas
            lblPromociones.Text = "Promociones Activadas:\n";
            lblPromociones.Text += "- Descuento del 20% en Remeras (hasta 30/11/2025)\n";
            lblPromociones.Text += "- 2x1 en Gorras Deportivas (hasta 05/11/2025)\n";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}