namespace Modelos
{
    public static class SesionActual
    {
        // 🔹 ID del usuario logueado
        public static int IdUsuario { get; set; } = 0;

        // 🔹 Nombre completo del usuario
        public static string NombreCompleto { get; set; } = "";

        // 🔹 Rol del usuario (Administrador, Gerente, etc.)
        public static string Rol { get; set; } = "";

        // 🔹 Descripción amigable para mostrar o registrar
        public static string Descripcion => $"{NombreCompleto} ({Rol})";

        // 🔹 Limpia todos los datos de sesión (al cerrar sesión)
        public static void CerrarSesion()
        {
            IdUsuario = 0;
            NombreCompleto = "";
            Rol = "";
        }
    }
}
