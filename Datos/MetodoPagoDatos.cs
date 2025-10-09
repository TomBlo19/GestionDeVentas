using Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GestionDeVentas.Datos;

namespace Datos
{
    public class MetodoPagoDatos
    {
        public List<MetodoPago> ObtenerMetodosPago()
        {
            var lista = new List<MetodoPago>();

            using (SqlConnection conn = ConexionBD.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT id_metodo_pago, nombre_metodo, descripcion FROM metodo_pago ORDER BY nombre_metodo;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new MetodoPago
                        {
                            IdMetodoPago = (int)dr["id_metodo_pago"],
                            NombreMetodo = dr["nombre_metodo"].ToString(),
                            Descripcion = dr["descripcion"] == DBNull.Value ? null : dr["descripcion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
