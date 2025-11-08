using GestionDeVentas.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class RendimientoVendedorResumen
    {
        public string Vendedor { get; set; }
        public decimal Total { get; set; }
        public int Cantidad { get; set; }
    }

    public class RendimientoMensual
    {
        public string Mes { get; set; }
        public decimal Total { get; set; }
    }

    public class ProductoVendido
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }

    public class RendimientoVendedorDatos
    {
        // 🔹 NUEVO: Obtener lista de vendedores activos
        public List<(int Id, string Vendedor)> ObtenerVendedores()
        {
            var lista = new List<(int, string)>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT id_usuario, CONCAT(nombre_usuario, ' ', apellido_usuario) AS Vendedor
                    FROM usuario
                    WHERE id_tipo_usuario = 4 AND estado_usuario = 'activo'";
                using (var cmd = new SqlCommand(query, conn))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add((Convert.ToInt32(dr["id_usuario"]), dr["Vendedor"].ToString()));
                }
            }
            return lista;
        }

        public List<RendimientoVendedorResumen> ObtenerRanking(DateTime desde, DateTime hasta)
        {
            var lista = new List<RendimientoVendedorResumen>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        CONCAT(u.nombre_usuario, ' ', u.apellido_usuario) AS Vendedor,
                        SUM(df.cantidad * df.precio_unitario) AS Total,
                        SUM(df.cantidad) AS Cantidad
                    FROM factura f
                    JOIN detalle_factura df ON df.id_factura = f.id_factura
                    JOIN usuario u ON u.id_usuario = f.id_usuario
                    WHERE f.fecha_factura BETWEEN @Desde AND @Hasta
                          AND f.activo = 1
                          AND u.id_tipo_usuario = 4
                    GROUP BY u.nombre_usuario, u.apellido_usuario
                    ORDER BY Total DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date.AddDays(1).AddTicks(-1));

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RendimientoVendedorResumen
                            {
                                Vendedor = dr["Vendedor"].ToString(),
                                Total = Convert.ToDecimal(dr["Total"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public (decimal ingresos, int unidades, decimal ticketPromedio, decimal participacion) ObtenerDatosVendedor(int idVendedor, DateTime desde, DateTime hasta)
        {
            decimal ingresos = 0, ticketPromedio = 0, participacion = 0;
            int unidades = 0;

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                // Total general
                decimal totalGeneral = 0;
                string totalQuery = @"
                    SELECT SUM(df.cantidad * df.precio_unitario) AS Total
                    FROM factura f
                    JOIN detalle_factura df ON df.id_factura = f.id_factura
                    WHERE f.fecha_factura BETWEEN @Desde AND @Hasta AND f.activo = 1";
                using (var cmd = new SqlCommand(totalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    var res = cmd.ExecuteScalar();
                    totalGeneral = res != DBNull.Value ? Convert.ToDecimal(res) : 0;
                }

                // Totales del vendedor
                string query = @"
                    SELECT 
                        SUM(df.cantidad * df.precio_unitario) AS Ingresos,
                        SUM(df.cantidad) AS Unidades,
                        COUNT(DISTINCT f.id_factura) AS Ventas
                    FROM factura f
                    JOIN detalle_factura df ON df.id_factura = f.id_factura
                    WHERE f.id_usuario = @IdVendedor
                          AND f.fecha_factura BETWEEN @Desde AND @Hasta
                          AND f.activo = 1";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", idVendedor);
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ingresos = dr["Ingresos"] != DBNull.Value ? Convert.ToDecimal(dr["Ingresos"]) : 0;
                            unidades = dr["Unidades"] != DBNull.Value ? Convert.ToInt32(dr["Unidades"]) : 0;
                            ticketPromedio = dr["Ventas"] != DBNull.Value && Convert.ToInt32(dr["Ventas"]) > 0
                                ? ingresos / Convert.ToInt32(dr["Ventas"])
                                : 0;
                        }
                    }
                }

                participacion = totalGeneral > 0 ? (ingresos / totalGeneral) * 100 : 0;
            }

            return (ingresos, unidades, ticketPromedio, participacion);
        }

        public List<RendimientoMensual> ObtenerIngresosMensuales(int idVendedor, DateTime desde, DateTime hasta)
        {
            var lista = new List<RendimientoMensual>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
            SELECT DATENAME(MONTH, f.fecha_factura) AS Mes,
                   SUM(df.cantidad * df.precio_unitario) AS Total
            FROM factura f
            JOIN detalle_factura df ON df.id_factura = f.id_factura
            WHERE f.id_usuario = @IdVendedor 
                  AND f.activo = 1
                  AND f.fecha_factura BETWEEN @Desde AND @Hasta
            GROUP BY DATENAME(MONTH, f.fecha_factura), MONTH(f.fecha_factura)
            ORDER BY MONTH(f.fecha_factura)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", idVendedor);
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new RendimientoMensual
                            {
                                Mes = dr["Mes"].ToString(),
                                Total = Convert.ToDecimal(dr["Total"])
                            });
                        }
                    }
                }
            }
            return lista;
        }


        public List<ProductoVendido> ObtenerProductosMasVendidos(int idVendedor, DateTime desde, DateTime hasta)
        {
            var lista = new List<ProductoVendido>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT p.nombre_producto AS Producto, SUM(df.cantidad) AS Cantidad
                    FROM factura f
                    JOIN detalle_factura df ON df.id_factura = f.id_factura
                    JOIN producto p ON p.id_producto = df.id_producto
                    WHERE f.id_usuario = @IdVendedor
                          AND f.fecha_factura BETWEEN @Desde AND @Hasta
                    GROUP BY p.nombre_producto
                    ORDER BY Cantidad DESC";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", idVendedor);
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ProductoVendido
                            {
                                Producto = dr["Producto"].ToString(),
                                Cantidad = Convert.ToInt32(dr["Cantidad"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
