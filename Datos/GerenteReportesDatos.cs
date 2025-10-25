using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace GestionDeVentas.Datos
{
    // ---------- MODELOS AUXILIARES ----------
    public class KpiGerente
    {
        public decimal TotalVentas { get; set; }
        public int CantFacturas { get; set; }
        public int CantProductosVendidos { get; set; }
        public int ClientesNuevos { get; set; }

        // Ticket promedio calculado automáticamente
        public decimal TicketPromedio => CantFacturas > 0 ? Math.Round(TotalVentas / CantFacturas, 2) : 0m;
    }

    public class VentasMes
    {
        public string Mes { get; set; }
        public decimal Total { get; set; }
    }

    public class TopProducto
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }

    // ---------- CLASE PRINCIPAL ----------
    public class GerenteReportesDatos
    {
        // --- KPI PRINCIPALES ---
        public KpiGerente ObtenerKpis(DateTime desde, DateTime hasta)
        {
            var result = new KpiGerente();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                // Total de ventas y cantidad de facturas
                string queryKpi = @"
                    SELECT 
                        SUM(total_factura) AS TotalVentas,
                        COUNT(*) AS CantFacturas
                    FROM factura
                    WHERE fecha_factura BETWEEN @Desde AND @Hasta
                      AND activo = 1;";

                using (var cmd = new SqlCommand(queryKpi, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result.TotalVentas = rdr["TotalVentas"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["TotalVentas"]);
                            result.CantFacturas = rdr["CantFacturas"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["CantFacturas"]);
                        }
                    }
                }

                // Productos vendidos
                string queryProductos = @"
                    SELECT 
                        SUM(df.cantidad) AS CantProductosVendidos
                    FROM detalle_factura df
                    INNER JOIN factura f ON f.id_factura = df.id_factura
                    WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
                      AND f.activo = 1;";

                using (var cmd = new SqlCommand(queryProductos, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    result.CantProductosVendidos = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                }

                // Clientes nuevos (primera factura en el rango)
                string queryClientes = @"
                    SELECT COUNT(*) 
                    FROM (
                        SELECT c.id_cliente, MIN(f.fecha_factura) AS PrimeraCompra
                        FROM cliente c
                        INNER JOIN factura f ON f.id_cliente = c.id_cliente
                        GROUP BY c.id_cliente
                        HAVING MIN(f.fecha_factura) BETWEEN @Desde AND @Hasta
                    ) AS Nuevos;";

                using (var cmd = new SqlCommand(queryClientes, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    result.ClientesNuevos = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                }
            }

            return result;
        }

        // --- VENTAS POR MES (con nombres abreviados en español) ---
        public List<VentasMes> ObtenerVentasPorMes(DateTime desde, DateTime hasta)
        {
            var lista = new List<VentasMes>();
            var cultura = new CultureInfo("es-ES"); // asegura meses en español

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        YEAR(fecha_factura) AS Anio,
                        MONTH(fecha_factura) AS NumMes,
                        SUM(total_factura) AS Total
                    FROM factura
                    WHERE fecha_factura BETWEEN @Desde AND @Hasta
                      AND activo = 1
                    GROUP BY YEAR(fecha_factura), MONTH(fecha_factura)
                    ORDER BY YEAR(fecha_factura), MONTH(fecha_factura);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int numMes = Convert.ToInt32(rdr["NumMes"]);
                            string mesAbreviado = cultura.DateTimeFormat.GetAbbreviatedMonthName(numMes);
                            decimal total = Math.Round(Convert.ToDecimal(rdr["Total"]), 2);

                            lista.Add(new VentasMes
                            {
                                Mes = char.ToUpper(mesAbreviado[0]) + mesAbreviado.Substring(1), // Ene, Feb, Mar...
                                Total = total
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // --- TOP 5 PRODUCTOS MÁS VENDIDOS ---
        public List<TopProducto> ObtenerTopProductos(DateTime desde, DateTime hasta)
        {
            var lista = new List<TopProducto>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT TOP 5 
                        p.nombre_producto AS Producto,
                        SUM(df.cantidad) AS Cantidad
                    FROM detalle_factura df
                    INNER JOIN factura f ON f.id_factura = df.id_factura
                    INNER JOIN producto p ON p.id_producto = df.id_producto
                    WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
                      AND f.activo = 1
                    GROUP BY p.nombre_producto
                    ORDER BY Cantidad DESC;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new TopProducto
                            {
                                Producto = rdr["Producto"].ToString(),
                                Cantidad = Convert.ToInt32(rdr["Cantidad"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}
