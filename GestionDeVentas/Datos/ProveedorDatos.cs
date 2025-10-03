using GestionDeVentas.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public class ProveedorDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-QFPBC6S\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";

        public List<Proveedor> ObtenerProveedores()
        {
            var lista = new List<Proveedor>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT id_proveedor, nombre_proveedor, empresa_proveedor, cuit_proveedor,
                                        telefono_proveedor, direccion_proveedor, pais_proveedor,
                                        ciudad_proveedor, correo_proveedor, estado_proveedor
                                 FROM proveedor";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Proveedor
                        {
                            Id = Convert.ToInt32(reader["id_proveedor"]),
                            Nombre = reader["nombre_proveedor"].ToString(),
                            Empresa = reader["empresa_proveedor"].ToString(),
                            Cuit = reader["cuit_proveedor"].ToString(),
                            Telefono = reader["telefono_proveedor"].ToString(),
                            Direccion = reader["direccion_proveedor"].ToString(),
                            Pais = reader["pais_proveedor"].ToString(),
                            Ciudad = reader["ciudad_proveedor"].ToString(),
                            Correo = reader["correo_proveedor"].ToString(),
                            Activo = reader["estado_proveedor"].ToString().ToLower() == "activo"
                        });
                    }
                }
            }
            return lista;
        }

        public void InsertarProveedor(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO proveedor 
                                (nombre_proveedor, empresa_proveedor, cuit_proveedor, telefono_proveedor,
                                 direccion_proveedor, pais_proveedor, ciudad_proveedor, correo_proveedor, estado_proveedor)
                                VALUES (@Nombre, @Empresa, @Cuit, @Telefono, @Direccion,
                                        @Pais, @Ciudad, @Correo, 'activo')";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Empresa", proveedor.Empresa);
                    cmd.Parameters.AddWithValue("@Cuit", proveedor.Cuit);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", proveedor.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", proveedor.Ciudad);
                    cmd.Parameters.AddWithValue("@Correo", proveedor.Correo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarProveedor(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE proveedor SET 
                                nombre_proveedor=@Nombre, empresa_proveedor=@Empresa, cuit_proveedor=@Cuit,
                                telefono_proveedor=@Telefono, direccion_proveedor=@Direccion,
                                pais_proveedor=@Pais, ciudad_proveedor=@Ciudad, correo_proveedor=@Correo
                                WHERE id_proveedor=@Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", proveedor.Id);
                    cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@Empresa", proveedor.Empresa);
                    cmd.Parameters.AddWithValue("@Cuit", proveedor.Cuit);
                    cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", proveedor.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", proveedor.Ciudad);
                    cmd.Parameters.AddWithValue("@Correo", proveedor.Correo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CambiarEstado(int idProveedor, bool activar)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE proveedor SET estado_proveedor=@Estado WHERE id_proveedor=@Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", activar ? "activo" : "desactivado");
                    cmd.Parameters.AddWithValue("@Id", idProveedor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteCuit(string cuit, int? idExcluir = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM proveedor WHERE cuit_proveedor=@Cuit" +
                               (idExcluir != null ? " AND id_proveedor<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuit", cuit);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public bool ExisteCorreo(string correo, int? idExcluir = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM proveedor WHERE correo_proveedor=@Correo" +
                               (idExcluir != null ? " AND id_proveedor<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
