using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelos
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }              
        public int IdFactura { get; set; }                 
        public int IdProducto { get; set; }               
        public int Cantidad { get; set; }                  
        public decimal PrecioUnitario { get; set; }
        public string TalleNombre { get; set; }


        public decimal Subtotal => Cantidad * PrecioUnitario;

     
        public string ProductoNombre { get; set; }        
        public string ProductoCodigo { get; set; }         
    }
}
