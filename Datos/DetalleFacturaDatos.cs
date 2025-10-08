using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;

namespace Datos
{
    public class DetalleFacturaDatos
    {
        private readonly string connectionString =
            "Server=DESKTOP-QFPBC6S\\SQLEXPRESS;Database=bd_BarberoBolo;Trusted_Connection=True;";

        public void InsertarDetalles(int idFactura, List<DetalleFactura> detalles)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var d in detalles)
                {
                    string query = @"
                        INSERT INTO detalle_factura (id_factura, id_producto, cantidad, precio_unitario)
                        VALUES (@Factura, @Producto, @Cantidad, @Precio);
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Factura", idFactura);
                        cmd.Parameters.AddWithValue("@Producto", d.IdProducto);
                        cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@Precio", d.PrecioUnitario);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
