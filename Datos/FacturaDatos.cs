using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class FacturaDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-QFPBC6S\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";

        // ✅ INSERTAR FACTURA Y DEVOLVER SU ID
        public int InsertarFactura(Factura factura)
        {
            int idFacturaGenerada = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    INSERT INTO factura (id_cliente, id_usuario, id_metodo_pago, fecha_factura, total_factura, activo)
                    OUTPUT INSERTED.id_factura
                    VALUES (@Cliente, @Usuario, @Metodo, @Fecha, @Total, @Activo);
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cliente", factura.IdCliente);
                    cmd.Parameters.AddWithValue("@Usuario", factura.IdUsuario);
                    cmd.Parameters.AddWithValue("@Metodo", (object)factura.IdMetodoPago ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fecha", factura.FechaFactura);
                    cmd.Parameters.AddWithValue("@Total", factura.TotalFactura);
                    cmd.Parameters.AddWithValue("@Activo", factura.Activo);

                    idFacturaGenerada = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return idFacturaGenerada;
        }

        // ✅ ACTIVAR / DESACTIVAR FACTURA
        public void CambiarEstadoFactura(int idFactura, bool activa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE factura SET activo = @Activo WHERE id_factura = @Id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Activo", activa);
                    cmd.Parameters.AddWithValue("@Id", idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ OBTENER LISTA DE FACTURAS (con datos del cliente y vendedor activo)
        public List<Factura> ObtenerFacturasPorVendedor(int idUsuario)
        {
            var lista = new List<Factura>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        f.id_factura,
                        f.id_cliente,
                        f.id_usuario,
                        f.id_metodo_pago,
                        f.fecha_factura,
                        f.total_factura,
                        f.activo,

                        -- 🧍 CLIENTE
                        c.nombre_cliente,
                        c.apellido_cliente,
                        c.dni_cliente,
                        c.telefono_cliente,
                        c.direccion_cliente,
                        c.ciudad_cliente,
                        c.correo_cliente,

                        -- 👨‍💼 USUARIO (vendedor)
                        u.nombre_usuario AS usuario_nombre,

                        -- 💳 MÉTODO DE PAGO
                        ISNULL(mp.nombre_metodo,'Sin método') AS metodo_pago_nombre

                    FROM factura f
                    INNER JOIN cliente c ON f.id_cliente = c.id_cliente
                    INNER JOIN usuario u ON f.id_usuario = u.id_usuario
                    LEFT JOIN metodo_pago mp ON f.id_metodo_pago = mp.id_metodo_pago
                    WHERE f.id_usuario = @IdUsuario  -- solo facturas del vendedor activo
                    ORDER BY f.id_factura DESC;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Factura
                            {
                                IdFactura = Convert.ToInt32(reader["id_factura"]),
                                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                IdMetodoPago = reader["id_metodo_pago"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["id_metodo_pago"]),
                                FechaFactura = Convert.ToDateTime(reader["fecha_factura"]),
                                TotalFactura = Convert.ToDecimal(reader["total_factura"]),
                                Activo = Convert.ToBoolean(reader["activo"]),

                                // Datos del cliente
                                ClienteNombre = reader["nombre_cliente"].ToString() + " " + reader["apellido_cliente"].ToString(),
                                ClienteDni = reader["dni_cliente"].ToString(),
                                ClienteTelefono = reader["telefono_cliente"].ToString(),
                                ClienteDireccion = reader["direccion_cliente"].ToString(),
                                ClienteCiudad = reader["ciudad_cliente"].ToString(),
                                ClienteCorreo = reader["correo_cliente"].ToString(),

                                // Vendedor
                                UsuarioNombre = reader["usuario_nombre"].ToString(),

                                // Método de pago
                                MetodoPagoNombre = reader["metodo_pago_nombre"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

        // ✅ OBTENER DETALLES DE UNA FACTURA
        public List<DetalleFactura> ObtenerDetallesPorFactura(int idFactura)
        {
            var lista = new List<DetalleFactura>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                df.id_detalle,
                df.id_factura,
                df.id_producto,
                df.cantidad,
                df.precio_unitario,
                p.nombre_producto,
                p.codigo_producto,
                t.nombre_talle
            FROM detalle_factura df
            INNER JOIN producto p ON df.id_producto = p.id_producto
            LEFT JOIN talle t ON p.id_talle = t.id_talle
            WHERE df.id_factura = @IdFactura;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdFactura", idFactura);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetalleFactura
                            {
                                IdDetalle = Convert.ToInt32(reader["id_detalle"]),
                                IdFactura = Convert.ToInt32(reader["id_factura"]),
                                IdProducto = Convert.ToInt32(reader["id_producto"]),
                                Cantidad = Convert.ToInt32(reader["cantidad"]),
                                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                                ProductoNombre = reader["nombre_producto"].ToString(),
                                ProductoCodigo = reader["codigo_producto"].ToString(),
                                TalleNombre = reader["nombre_talle"] == DBNull.Value ? "-" : reader["nombre_talle"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }

    }
}
