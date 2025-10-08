using System;
using System.Collections.Generic;

namespace Modelos
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int? IdMetodoPago { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal TotalFactura { get; set; }
        public bool Activo { get; set; }



        // 🔹 Cliente
        public string ClienteNombre { get; set; }

        // 🆕 Campos nuevos (para los datos del cliente)
        public string ClienteDni { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteCiudad { get; set; }
        public string ClienteCorreo { get; set; }

        // 🔹 Vendedor
        public string UsuarioNombre { get; set; }

        // 🔹 Método de pago
        public string MetodoPagoNombre { get; set; }

        // 🔹 Estado legible
        public string ActivoTexto => Activo ? "Activo" : "Inactivo";

        // 🔹 Lista de detalles
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
    }
}
