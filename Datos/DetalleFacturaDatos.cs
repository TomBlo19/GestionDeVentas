using System.Collections.Generic;
using System.Data.SqlClient;
using Modelos;
using GestionDeVentas.Datos;

namespace Datos
{
    public class DetalleFacturaDatos
    {
        public void InsertarDetalles(int idFactura, List<DetalleFactura> detalles)
        {
            using (SqlConnection conn = ConexionBD.ObtenerConexion())
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
