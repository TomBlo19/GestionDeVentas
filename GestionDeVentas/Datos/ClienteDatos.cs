using GestionDeVentas.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public class ClienteDatos
    {
        // Ajustá si tu instancia o base cambian
        private readonly string connectionString =
            "Server=DESKTOP-QFPBC6S\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";

        // LISTAR
        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT id_cliente, nombre_cliente, apellido_cliente, dni_cliente,
                           telefono_cliente, direccion_cliente, pais_cliente,
                           ciudad_cliente, correo_cliente, estado_cliente
                    FROM cliente
                    ORDER BY apellido_cliente, nombre_cliente;";

                using (var cmd = new SqlCommand(query, conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = Convert.ToInt32(rdr["id_cliente"]),
                            Nombre = rdr["nombre_cliente"].ToString(),
                            Apellido = rdr["apellido_cliente"].ToString(),
                            Dni = rdr["dni_cliente"].ToString(),
                            Telefono = rdr["telefono_cliente"].ToString(),
                            Direccion = rdr["direccion_cliente"].ToString(),
                            Pais = rdr["pais_cliente"].ToString(),
                            Ciudad = rdr["ciudad_cliente"].ToString(),
                            CorreoElectronico = rdr["correo_cliente"].ToString(),
                            Activo = rdr["estado_cliente"].ToString().Equals("activo", StringComparison.OrdinalIgnoreCase)
                        });
                    }
                }
            }

            return lista;
        }

        // INSERTAR
        public void InsertarCliente(Cliente c)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO cliente
                    (nombre_cliente, apellido_cliente, dni_cliente, telefono_cliente,
                     direccion_cliente, pais_cliente, ciudad_cliente, correo_cliente, estado_cliente)
                    VALUES
                    (@Nombre, @Apellido, @Dni, @Telefono,
                     @Direccion, @Pais, @Ciudad, @Correo, 'activo');";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Dni", c.Dni);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", c.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", c.Ciudad);
                    cmd.Parameters.AddWithValue("@Correo", c.CorreoElectronico);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // EDITAR
        public void EditarCliente(Cliente c)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE cliente SET
                        nombre_cliente=@Nombre,
                        apellido_cliente=@Apellido,
                        dni_cliente=@Dni,
                        telefono_cliente=@Telefono,
                        direccion_cliente=@Direccion,
                        pais_cliente=@Pais,
                        ciudad_cliente=@Ciudad,
                        correo_cliente=@Correo
                    WHERE id_cliente=@Id;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", c.Id);
                    cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@Dni", c.Dni);
                    cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", c.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", c.Ciudad);
                    cmd.Parameters.AddWithValue("@Correo", c.CorreoElectronico);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // CAMBIAR ESTADO (true = activo, false = inactivo)
        public void CambiarEstado(int idCliente, bool activar)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE cliente SET estado_cliente=@Estado WHERE id_cliente=@Id;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", activar ? "activo" : "inactivo");
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // VALIDACIÓN: DNI único
        public bool ExisteDni(string dni, int? idExcluir = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM cliente WHERE dni_cliente=@Dni"
                               + (idExcluir != null ? " AND id_cliente<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Dni", dni);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir.Value);

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // BUSCAR por DNI o Apellido
        public List<Cliente> BuscarClientes(string filtro)
        {
            var lista = new List<Cliente>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT id_cliente, nombre_cliente, apellido_cliente, dni_cliente,
                   telefono_cliente, direccion_cliente, pais_cliente,
                   ciudad_cliente, correo_cliente, estado_cliente
            FROM cliente
            WHERE dni_cliente LIKE @Filtro OR apellido_cliente LIKE @Filtro
            ORDER BY apellido_cliente, nombre_cliente;";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id = Convert.ToInt32(rdr["id_cliente"]),
                                Nombre = rdr["nombre_cliente"].ToString(),
                                Apellido = rdr["apellido_cliente"].ToString(),
                                Dni = rdr["dni_cliente"].ToString(),
                                Telefono = rdr["telefono_cliente"].ToString(),
                                Direccion = rdr["direccion_cliente"].ToString(),
                                Pais = rdr["pais_cliente"].ToString(),
                                Ciudad = rdr["ciudad_cliente"].ToString(),
                                CorreoElectronico = rdr["correo_cliente"].ToString(),
                                Activo = rdr["estado_cliente"].ToString().Equals("activo", StringComparison.OrdinalIgnoreCase)
                            });
                        }
                    }
                }
            }

            return lista;
        }


        // VALIDACIÓN: Correo único
        public bool ExisteCorreo(string correo, int? idExcluir = null)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM cliente WHERE correo_cliente=@Correo"
                               + (idExcluir != null ? " AND id_cliente<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir.Value);

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
