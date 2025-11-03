using GestionDeVentas.Datos;
using GestionDeVentas.Modelos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ReporteDatos
    {
        //--------------------------------------------------
        // 1️⃣ - PRODUCTOS CON STOCK BAJO
        //--------------------------------------------------
        public List<Producto> ObtenerProductosBajoStock()
        {
            var lista = new List<Producto>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        id_producto,
                        codigo_producto,
                        nombre_producto,
                        stock_producto,
                        stock_minimo,
                        marca_producto,
                        precio_producto
                    FROM producto
                    WHERE stock_producto <= stock_minimo
                    ORDER BY stock_producto ASC;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = Convert.ToInt32(reader["id_producto"]),
                            Codigo = reader["codigo_producto"].ToString(),
                            Nombre = reader["nombre_producto"].ToString(),
                            Stock = Convert.ToInt32(reader["stock_producto"]),
                            StockMinimo = Convert.ToInt32(reader["stock_minimo"]),
                            Marca = reader["marca_producto"].ToString(),
                            Precio = Convert.ToDecimal(reader["precio_producto"])
                        });
                    }
                }
            }
            return lista;
        }

        //--------------------------------------------------
        // 2️⃣ - HISTORIAL DE MOVIMIENTOS (STOCK Y GENERALES)
        //--------------------------------------------------
        public List<MovimientoGeneral> ObtenerHistorialMovimientos()
        {
            var lista = new List<MovimientoGeneral>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        m.fecha_movimiento AS Fecha,
                        p.nombre_producto AS Detalle,
                        'Stock' AS Modulo,
                        m.tipo_movimiento AS Tipo,
                        m.cantidad AS Cantidad,
                        m.descripcion AS Descripcion
                    FROM movimientos_stock m
                    INNER JOIN producto p ON m.id_producto = p.id_producto

                    UNION ALL

                    SELECT 
                        g.fecha AS Fecha,
                        g.descripcion AS Detalle,
                        g.modulo AS Modulo,
                        g.accion AS Tipo,
                        NULL AS Cantidad,
                        g.usuario AS Descripcion
                    FROM movimientos_generales g

                    ORDER BY Fecha DESC;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovimientoGeneral
                        {
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Detalle = reader["Detalle"].ToString(),
                            Modulo = reader["Modulo"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Cantidad = reader["Cantidad"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Cantidad"]),
                            Descripcion = reader["Descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        //--------------------------------------------------
        // 3️⃣ - PRODUCTOS MÁS VENDIDOS (TOP 5)
        //--------------------------------------------------
        public List<TendenciaVenta> ObtenerProductosMasVendidos()
        {
            var lista = new List<TendenciaVenta>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT TOP 5 
                        p.nombre_producto AS Producto,
                        SUM(m.cantidad) AS total_vendido
                    FROM movimientos_stock m
                    INNER JOIN producto p ON m.id_producto = p.id_producto
                    WHERE LOWER(m.tipo_movimiento) IN ('venta', 'salida')
                    GROUP BY p.nombre_producto
                    HAVING SUM(m.cantidad) > 0
                    ORDER BY total_vendido DESC;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new TendenciaVenta
                        {
                            Producto = reader["Producto"].ToString(),
                            Ventas = Convert.ToInt32(reader["total_vendido"])
                        });
                    }
                }
            }

            return lista;
        }

        //--------------------------------------------------
        // 4️⃣ - REGISTRO DE MOVIMIENTOS GENERALES (AUDITORÍA)
        //--------------------------------------------------
        public void RegistrarMovimientoGeneral(string usuario, string modulo, string accion, string descripcion)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    INSERT INTO movimientos_generales (usuario, modulo, accion, descripcion)
                    VALUES (@Usuario, @Modulo, @Accion, @Descripcion);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", (object)usuario ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modulo", modulo);
                    cmd.Parameters.AddWithValue("@Accion", accion);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //--------------------------------------------------
        // 5️⃣ - OBTENER TODOS LOS PRODUCTOS (para panel de inventario)
        //--------------------------------------------------
        public List<Producto> ObtenerTodosLosProductos()
        {
            var lista = new List<Producto>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_producto,
                        nombre_producto,
                        stock_producto,
                        stock_minimo,
                        estado_producto
                    FROM producto
                    ORDER BY nombre_producto;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            Id = Convert.ToInt32(reader["id_producto"]),
                            Nombre = reader["nombre_producto"].ToString(),
                            Stock = Convert.ToInt32(reader["stock_producto"]),
                            StockMinimo = Convert.ToInt32(reader["stock_minimo"]),
                            Estado = reader["estado_producto"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }

    //--------------------------------------------------
    // 🔸 MODELOS AUXILIARES (para reportes y auditoría)
    //--------------------------------------------------
    public class MovimientoGeneral
    {
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public string Modulo { get; set; }
        public string Tipo { get; set; }
        public int? Cantidad { get; set; }
        public string Descripcion { get; set; }
    }

    public class TendenciaVenta
    {
        public string Producto { get; set; }
        public int Ventas { get; set; }
    }
}
