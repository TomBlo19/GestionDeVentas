using Datos;
using GestionDeVentas.Modelos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public class ClienteDatos
    {
        //------------------------------------------------------
        // 🔹 OBTENER TODOS LOS CLIENTESRegistrarMovimientoGeneral
        //------------------------------------------------------
        public List<Cliente> ObtenerClientes()
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.ObtenerConexion())
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

        //------------------------------------------------------
        // 🔹 INSERTAR CLIENTE + REGISTRO AUTOMÁTICO
        //------------------------------------------------------
        public void InsertarCliente(Cliente c, string usuario = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
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

                // 🔸 Registrar en auditoría
                new ReporteDatos().RegistrarMovimientoGeneral(
                    SesionActual.NombreCompleto,
                    "Clientes",
                    "Alta",
                    $"Nuevo cliente agregado: {c.Nombre} {c.Apellido}"
                );
            }
        }

        //------------------------------------------------------
        // 🔹 EDITAR CLIENTE + REGISTRO AUTOMÁTICO
        //------------------------------------------------------
        public void EditarCliente(Cliente c, string usuario = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
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

                // 🔸 Registrar modificación
                new ReporteDatos().RegistrarMovimientoGeneral(
                    usuario,
                    "Clientes",
                    "Modificación",
                    $"Cliente actualizado: {c.Nombre} {c.Apellido}"
                );
            }
        }

        //------------------------------------------------------
        // 🔹 CAMBIAR ESTADO (ACTIVAR/INACTIVAR) + REGISTRO AUTOMÁTICO
        //------------------------------------------------------
        public void CambiarEstado(int idCliente, bool activar, string nombreCliente = "", string usuario = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE cliente SET estado_cliente=@Estado WHERE id_cliente=@Id;";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", activar ? "activo" : "inactivo");
                    cmd.Parameters.AddWithValue("@Id", idCliente);
                    cmd.ExecuteNonQuery();
                }

                string accion = activar ? "Activación" : "Inactivación";

                // 🔸 Registrar cambio de estado
                new ReporteDatos().RegistrarMovimientoGeneral(
                    usuario,
                    "Clientes",
                    accion,
                    $"Cliente {accion.ToLower()}: {nombreCliente}"
                );
            }
        }

        //------------------------------------------------------
        // 🔹 CONSULTAS AUXILIARES
        //------------------------------------------------------
        public bool ExisteDni(string dni, int? idExcluir = null)
        {
            using (var conn = ConexionBD.ObtenerConexion())
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

        public bool ExisteCorreo(string correo, int? idExcluir = null)
        {
            using (var conn = ConexionBD.ObtenerConexion())
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

        //------------------------------------------------------
        // 🔹 BÚSQUEDAS
        //------------------------------------------------------
        public List<Cliente> BuscarClientes(string filtro)
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.ObtenerConexion())
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

        public List<Cliente> BuscarClientesPorDni(string dni)
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT id_cliente, nombre_cliente, apellido_cliente, dni_cliente, telefono_cliente, direccion_cliente, pais_cliente, ciudad_cliente, correo_cliente, estado_cliente FROM cliente WHERE dni_cliente LIKE @dni + '%';",
                    conn);

                cmd.Parameters.AddWithValue("@dni", dni);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = Convert.ToInt32(reader["id_cliente"]),
                            Nombre = reader["nombre_cliente"].ToString(),
                            Apellido = reader["apellido_cliente"].ToString(),
                            Dni = reader["dni_cliente"].ToString(),
                            Telefono = reader["telefono_cliente"].ToString(),
                            Direccion = reader["direccion_cliente"].ToString(),
                            Pais = reader["pais_cliente"].ToString(),
                            Ciudad = reader["ciudad_cliente"].ToString(),
                            CorreoElectronico = reader["correo_cliente"].ToString(),
                            Activo = reader["estado_cliente"].ToString().Equals("activo", StringComparison.OrdinalIgnoreCase)
                        });
                    }
                }
            }

            return lista;
        }

        public List<Cliente> BuscarClientesPorApellido(string apellido)
        {
            var lista = new List<Cliente>();

            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT id_cliente, nombre_cliente, apellido_cliente, dni_cliente, telefono_cliente, direccion_cliente, pais_cliente, ciudad_cliente, correo_cliente, estado_cliente FROM cliente WHERE apellido_cliente LIKE '%' + @apellido + '%';",
                    conn);

                cmd.Parameters.AddWithValue("@apellido", apellido);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cliente
                        {
                            Id = Convert.ToInt32(reader["id_cliente"]),
                            Nombre = reader["nombre_cliente"].ToString(),
                            Apellido = reader["apellido_cliente"].ToString(),
                            Dni = reader["dni_cliente"].ToString(),
                            Telefono = reader["telefono_cliente"].ToString(),
                            Direccion = reader["direccion_cliente"].ToString(),
                            Pais = reader["pais_cliente"].ToString(),
                            Ciudad = reader["ciudad_cliente"].ToString(),
                            CorreoElectronico = reader["correo_cliente"].ToString(),
                            Activo = reader["estado_cliente"].ToString().Equals("activo", StringComparison.OrdinalIgnoreCase)
                        });
                    }
                }
            }

            return lista;
        }
    }
}
