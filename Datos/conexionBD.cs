using System.Data.SqlClient;

namespace GestionDeVentas.Datos
{
    public static class ConexionBD
    {

        private static readonly string connectionString =
           "Server=localhost\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}
