using GestionDeVentas.Modelos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestionDeVentas.Datos;

namespace Datos
{
    public class ProductoDatos
    {
        //--------------------------------------------------------------
        // 🔹 OBTENER TODOS LOS PRODUCTOS
        //--------------------------------------------------------------
        public List<Producto> ObtenerProductos()
        {
            var lista = new List<Producto>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.id_producto, p.codigo_producto, p.nombre_producto, p.descripcion_producto,
                        t.id_talle, t.nombre_talle, p.color_producto, p.marca_producto, p.precio_producto,
                        p.stock_producto, p.stock_minimo, p.estado_producto, c.id_categoria, c.nombre_categoria,
                        pr.id_proveedor, pr.nombre_proveedor
                    FROM producto p
                    INNER JOIN categoria c ON p.id_categoria = c.id_categoria
                    INNER JOIN proveedor pr ON p.id_proveedor = pr.id_proveedor
                    INNER JOIN talle t ON p.id_talle = t.id_talle;";

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
                            Descripcion = reader["descripcion_producto"].ToString(),
                            IdTalle = Convert.ToInt32(reader["id_talle"]),
                            TalleNombre = reader["nombre_talle"].ToString(),
                            Color = reader["color_producto"].ToString(),
                            Marca = reader["marca_producto"].ToString(),
                            Precio = Convert.ToDecimal(reader["precio_producto"]),
                            Stock = Convert.ToInt32(reader["stock_producto"]),
                            StockMinimo = Convert.ToInt32(reader["stock_minimo"]),
                            Estado = reader["estado_producto"].ToString(),
                            IdCategoria = Convert.ToInt32(reader["id_categoria"]),
                            CategoriaNombre = reader["nombre_categoria"].ToString(),
                            IdProveedor = Convert.ToInt32(reader["id_proveedor"]),
                            ProveedorNombre = reader["nombre_proveedor"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        //--------------------------------------------------------------
        // 🔹 MÉTODOS DE CONSULTA ADICIONALES
        //--------------------------------------------------------------
        public List<string> ObtenerTodasCategorias()
        {
            var lista = new List<string>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombre_categoria FROM categoria ORDER BY nombre_categoria;";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(reader["nombre_categoria"].ToString());
                }
            }
            return lista;
        }

        public List<string> ObtenerTallesPorCategoria(string nombreCategoria)
        {
            var lista = new List<string>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    SELECT DISTINCT t.nombre_talle
                    FROM talle t
                    INNER JOIN producto p ON t.id_talle = p.id_talle
                    INNER JOIN categoria c ON p.id_categoria = c.id_categoria
                    WHERE c.nombre_categoria = @NombreCategoria
                    ORDER BY t.nombre_talle;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreCategoria", nombreCategoria);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(reader["nombre_talle"].ToString());
                    }
                }
            }
            return lista;
        }

        //--------------------------------------------------------------
        // 🔹 OBTENER NOMBRES AUXILIARES
        //--------------------------------------------------------------
        public string ObtenerNombreTalle(int idTalle)
        {
            if (idTalle <= 0) return "-";
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombre_talle FROM talle WHERE id_talle=@IdTalle;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdTalle", idTalle);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "-";
                }
            }
        }

        public string ObtenerNombreCategoria(int idCategoria)
        {
            if (idCategoria <= 0) return "-";
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombre_categoria FROM categoria WHERE id_categoria=@IdCategoria;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "-";
                }
            }
        }

        //--------------------------------------------------------------
        // 🔹 ACTUALIZAR STOCK DESPUÉS DE VENTA
        //--------------------------------------------------------------
        public void ActualizarStock(int idProducto, int cantidadVendida)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    UPDATE producto
                    SET stock_producto = CASE 
                        WHEN stock_producto - @CantidadVendida < 0 THEN 0 
                        ELSE stock_producto - @CantidadVendida 
                    END
                    WHERE id_producto = @IdProducto;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CantidadVendida", cantidadVendida);
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 0)
                        throw new Exception($"No se pudo actualizar el stock del producto (ID {idProducto}).");
                }
            }
        }

        //--------------------------------------------------------------
        // 🔹 INSERTAR NUEVO PRODUCTO + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void InsertarProducto(Producto producto, string usuario = "Administrador")
        {
            if (ExisteCodigo(producto.Codigo))
                throw new InvalidOperationException("El código ingresado ya existe. No se puede duplicar.");

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    INSERT INTO producto
                    (codigo_producto, nombre_producto, descripcion_producto,
                     id_talle, color_producto, marca_producto,
                     precio_producto, stock_producto, stock_minimo,
                     estado_producto, id_categoria, id_proveedor)
                    VALUES
                    (@Codigo, @Nombre, @Descripcion,
                     @IdTalle, @Color, @Marca,
                     @Precio, @Stock, 5,
                     'Activo', @IdCategoria, @IdProveedor);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@IdTalle", producto.IdTalle);
                    cmd.Parameters.AddWithValue("@Color", producto.Color);
                    cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@IdProveedor", producto.IdProveedor);

                    cmd.ExecuteNonQuery();
                }

                // 🔸 Registrar el movimiento general (auditoría)
                new ReporteDatos().RegistrarMovimientoGeneral(
                    SesionActual.NombreCompleto,
                    "Productos",
                    "Alta",
                    $"Nuevo producto agregado: {producto.Nombre}"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 EDITAR PRODUCTO + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void EditarProducto(Producto producto, string usuario = "Administrador")
        {
            if (ExisteCodigo(producto.Codigo, producto.Id))
                throw new InvalidOperationException("Ya existe otro producto con este código.");

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"
                    UPDATE producto
                    SET nombre_producto=@Nombre,
                        descripcion_producto=@Descripcion,
                        id_talle=@IdTalle,
                        color_producto=@Color,
                        marca_producto=@Marca,
                        precio_producto=@Precio,
                        stock_producto=@Stock,
                        id_categoria=@IdCategoria,
                        id_proveedor=@IdProveedor
                    WHERE id_producto=@Id;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", producto.Id);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@IdTalle", producto.IdTalle);
                    cmd.Parameters.AddWithValue("@Color", producto.Color);
                    cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                    cmd.Parameters.AddWithValue("@IdProveedor", producto.IdProveedor);

                    cmd.ExecuteNonQuery();
                }

                // 🔸 Registrar modificación en movimientos generales
                new ReporteDatos().RegistrarMovimientoGeneral(
                    usuario,
                    "Productos",
                    "Modificación",
                    $"Producto actualizado: {producto.Nombre}"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 CAMBIAR ESTADO (ACTIVAR/INACTIVAR) + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void CambiarEstado(int idProducto, bool activar, string nombreProducto = "", string usuario = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string nuevoEstado = activar ? "Activo" : "Inactivo";
                string query = "UPDATE producto SET estado_producto=@Estado WHERE id_producto=@Id;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@Id", idProducto);
                    cmd.ExecuteNonQuery();
                }

                // 🔸 Registrar activación o inactivación
                string accion = activar ? "Activación" : "Inactivación";
                new ReporteDatos().RegistrarMovimientoGeneral(
                    usuario,
                    "Productos",
                    accion,
                    $"Producto {accion.ToLower()}: {nombreProducto}"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 CONSULTAS AUXILIARES
        //--------------------------------------------------------------
        public int ObtenerIdPorCodigo(string codigo)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id_producto FROM producto WHERE codigo_producto = @Codigo";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public bool ExisteCodigo(string codigo, int? idExcluir = null)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM producto WHERE codigo_producto=@Codigo";
                if (idExcluir != null)
                    query += " AND id_producto<>@Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Codigo", codigo);
                    if (idExcluir != null)
                        cmd.Parameters.AddWithValue("@Id", idExcluir);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
