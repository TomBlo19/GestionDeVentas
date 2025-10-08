using GestionDeVentas.Modelos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class ProductoDatos
    {
        // 🔗 Cadena de conexión
        private readonly string connectionString =
            "Server=DESKTOP-QFPBC6S\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";

        public string ConnectionString => connectionString;

        // ================================================================
        // 📘 OBTENER TODOS LOS PRODUCTOS
        // ================================================================
        public List<Producto> ObtenerProductos()
        {
            var lista = new List<Producto>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.id_producto, 
                        p.codigo_producto, 
                        p.nombre_producto, 
                        p.descripcion_producto,
                        t.id_talle,
                        t.nombre_talle,
                        p.color_producto, 
                        p.marca_producto, 
                        p.precio_producto,
                        p.stock_producto, 
                        p.stock_minimo, 
                        p.estado_producto,
                        c.id_categoria,
                        c.nombre_categoria,
                        pr.id_proveedor,
                        pr.nombre_proveedor
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

        // ================================================================
        // 📘 OBTENER NOMBRE DE TALLE
        // ================================================================
        public string ObtenerNombreTalle(int idTalle)
        {
            if (idTalle <= 0) return "-";

            using (var conn = new SqlConnection(connectionString))
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

        // ================================================================
        // 📘 OBTENER NOMBRE DE CATEGORÍA
        // ================================================================
        public string ObtenerNombreCategoria(int idCategoria)
        {
            if (idCategoria <= 0) return "-";

            using (var conn = new SqlConnection(connectionString))
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

        // ================================================================
        // 🔹 ACTUALIZAR STOCK DESPUÉS DE UNA VENTA
        // ================================================================
        public void ActualizarStock(int idProducto, int cantidadVendida)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Usamos el nombre real de columna: stock_producto
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

        // ================================================================
        // 📘 INSERTAR NUEVO PRODUCTO
        // ================================================================
        public void InsertarProducto(Producto producto)
        {
            if (ExisteCodigo(producto.Codigo))
                throw new InvalidOperationException("El código ingresado ya existe. No se puede duplicar.");

            using (var conn = new SqlConnection(connectionString))
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
            }
        }

        // ================================================================
        // 📘 EDITAR PRODUCTO EXISTENTE
        // ================================================================
        public void EditarProducto(Producto producto)
        {
            if (ExisteCodigo(producto.Codigo, producto.Id))
                throw new InvalidOperationException("Ya existe otro producto con este código.");

            using (var conn = new SqlConnection(connectionString))
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
            }
        }

        // ================================================================
        // 📘 CAMBIAR ESTADO ACTIVO/INACTIVO
        // ================================================================
        public void CambiarEstado(int idProducto, bool activar)
        {
            using (var conn = new SqlConnection(connectionString))
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
            }
        }

        // ================================================================
        // 📘 VERIFICAR CÓDIGO DUPLICADO
        // ================================================================
        public bool ExisteCodigo(string codigo, int? idExcluir = null)
        {
            using (var conn = new SqlConnection(connectionString))
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
