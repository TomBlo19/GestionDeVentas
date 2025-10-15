using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public static class ConexionBD
    {
//hola
        private static readonly string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;TrustServerCertificate=True";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
