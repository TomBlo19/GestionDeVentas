using Modelos;
using Datos;
using GestionDeVentas.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public class UsuarioDatos
    {
        //--------------------------------------------------------------
        // 🔹 OBTENER TODOS LOS USUARIOS
        //--------------------------------------------------------------
        public List<Usuario> ObtenerUsuarios()
        {
            var lista = new List<Usuario>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"SELECT u.id_usuario, u.nombre_usuario, u.apellido_usuario, u.dni_usuario, 
                                        u.correo_usuario, u.telefono, u.direccion, u.pais, u.ciudad,
                                        u.nacimiento_usuario, u.contrasena_usuario,
                                        u.estado_usuario, t.nombre_tipo
                                 FROM usuario u
                                 INNER JOIN tipo_usuario t ON u.id_tipo_usuario = t.id_tipo_usuario";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Usuario
                        {
                            Id = Convert.ToInt32(reader["id_usuario"]),
                            Nombre = reader["nombre_usuario"].ToString(),
                            Apellido = reader["apellido_usuario"].ToString(),
                            DNI = reader["dni_usuario"].ToString(),
                            Email = reader["correo_usuario"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            Direccion = reader["direccion"].ToString(),
                            Pais = reader["pais"].ToString(),
                            Ciudad = reader["ciudad"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["nacimiento_usuario"]),
                            Contrasena = reader["contrasena_usuario"].ToString(),
                            Rol = reader["nombre_tipo"].ToString(),
                            Activo = reader["estado_usuario"].ToString().ToLower() == "activo"
                        });
                    }
                }
            }
            return lista;
        }

        //--------------------------------------------------------------
        // 🔹 INSERTAR USUARIO + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void InsertarUsuario(Usuario usuario, string usuarioActual = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"INSERT INTO usuario 
                (nombre_usuario, apellido_usuario, nacimiento_usuario, dni_usuario, correo_usuario, contrasena_usuario, 
                 id_tipo_usuario, estado_usuario, telefono, direccion, pais, ciudad) 
                VALUES (@Nombre, @Apellido, @Nacimiento, @DNI, @Correo, @Contrasena,
                        (SELECT id_tipo_usuario FROM tipo_usuario WHERE nombre_tipo=@Rol),
                        'activo', @Telefono, @Direccion, @Pais, @Ciudad)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Nacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Email);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", usuario.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);
                    cmd.ExecuteNonQuery();
                }

                // 🔸 Registrar en auditoría
                new ReporteDatos().RegistrarMovimientoGeneral(
                   SesionActual.NombreCompleto,
                    "Usuarios",
                    "Alta",
                    $"Nuevo usuario agregado: {usuario.Nombre} {usuario.Apellido} ({usuario.Rol})"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 EDITAR USUARIO + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void EditarUsuario(Usuario usuario, string usuarioActual = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = @"UPDATE usuario SET 
                                 nombre_usuario=@Nombre, apellido_usuario=@Apellido, nacimiento_usuario=@Nacimiento,
                                 dni_usuario=@DNI, correo_usuario=@Correo, contrasena_usuario=@Contrasena,
                                 id_tipo_usuario=(SELECT id_tipo_usuario FROM tipo_usuario WHERE nombre_tipo=@Rol),
                                 telefono=@Telefono, direccion=@Direccion,
                                 pais=@Pais, ciudad=@Ciudad
                                 WHERE id_usuario=@Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Nacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@DNI", usuario.DNI);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Email);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                    cmd.Parameters.AddWithValue("@Pais", usuario.Pais);
                    cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);
                    cmd.ExecuteNonQuery();
                }

                // 🔸 Registrar modificación
                new ReporteDatos().RegistrarMovimientoGeneral(
                  SesionActual.NombreCompleto,
                    "Usuarios",
                    "Modificación",
                    $"Usuario actualizado: {usuario.Nombre} {usuario.Apellido} ({usuario.Rol})"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 CAMBIAR ESTADO (ACTIVAR/INACTIVAR) + REGISTRO AUTOMÁTICO
        //--------------------------------------------------------------
        public void CambiarEstado(int idUsuario, bool activar, string nombreUsuario = "", string usuarioActual = "Administrador")
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "UPDATE usuario SET estado_usuario=@Estado WHERE id_usuario=@Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Estado", activar ? "activo" : "inactivo");
                    cmd.Parameters.AddWithValue("@Id", idUsuario);
                    cmd.ExecuteNonQuery();
                }

                string accion = activar ? "Activación" : "Inactivación";

                // 🔸 Registrar cambio de estado
                new ReporteDatos().RegistrarMovimientoGeneral(
                    SesionActual.NombreCompleto,
                    "Usuarios",
                    accion,
                    $"Usuario {accion.ToLower()}: {nombreUsuario}"
                );
            }
        }

        //--------------------------------------------------------------
        // 🔹 VALIDACIONES Y ROLES
        //--------------------------------------------------------------
        public bool ExisteDNI(string dni, int? idExcluir = null)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuario WHERE dni_usuario=@DNI" +
                               (idExcluir != null ? " AND id_usuario<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public bool ExisteCorreo(string correo, int? idExcluir = null)
        {
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM usuario WHERE correo_usuario=@Correo" +
                               (idExcluir != null ? " AND id_usuario<>@Id" : "");
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    if (idExcluir != null) cmd.Parameters.AddWithValue("@Id", idExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public List<string> ObtenerRoles()
        {
            var roles = new List<string>();
            using (var conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT nombre_tipo FROM tipo_usuario";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        roles.Add(reader["nombre_tipo"].ToString());
                }
            }
            return roles;
        }
    }
}
