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
        // 2️⃣ - HISTORIAL DE MOVIMIENTOS
        //--------------------------------------------------
        public List<MovimientoStock> ObtenerHistorialMovimientos()
        {
            var lista = new List<MovimientoStock>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        m.id_movimiento,
                        p.nombre_producto,
                        m.tipo_movimiento,
                        m.cantidad,
                        m.fecha_movimiento,
                        m.descripcion
                    FROM movimientos_stock m
                    INNER JOIN producto p ON m.id_producto = p.id_producto
                    ORDER BY m.fecha_movimiento DESC;";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovimientoStock
                        {
                            IdMovimiento = Convert.ToInt32(reader["id_movimiento"]),
                            ProductoNombre = reader["nombre_producto"].ToString(),
                            TipoMovimiento = reader["tipo_movimiento"].ToString(),
                            Cantidad = Convert.ToInt32(reader["cantidad"]),
                            Fecha = Convert.ToDateTime(reader["fecha_movimiento"]),
                            Descripcion = reader["descripcion"].ToString()
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

                // 🔸 Se adapta a tu tabla y detecta "venta" o "salida" sin importar mayúsculas
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
    }

    //--------------------------------------------------
    // 🔸 MODELOS AUXILIARES (para reportes)
    //--------------------------------------------------
    public class MovimientoStock
    {
        public int IdMovimiento { get; set; }
        public string ProductoNombre { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }

    public class TendenciaVenta
    {
        public string Producto { get; set; }
        public int Ventas { get; set; }
    }
}
