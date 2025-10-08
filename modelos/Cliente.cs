using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cliente
    {
        public int Id { get; set; }                    // id_cliente
        public string Nombre { get; set; }             // nombre_cliente
        public string Apellido { get; set; }           // apellido_cliente
        public string Dni { get; set; }                // dni_cliente
        public string Telefono { get; set; }           // telefono_cliente
        public string Direccion { get; set; }          // direccion_cliente
        public string Pais { get; set; }               // pais_cliente
        public string Ciudad { get; set; }             // ciudad_cliente
        public string CorreoElectronico { get; set; }  // correo_cliente
        public bool Activo { get; set; }               // estado_cliente ('activo'/'inactivo' → bool)

        public string ActivoTexto => Activo ? "Activo" : "Inactivo";
    }
}
