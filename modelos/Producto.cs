namespace Modelos
{
    public class Producto
    {
        public int Id { get; set; }                  
        public string Codigo { get; set; }              
        public string Nombre { get; set; }              
        public string Descripcion { get; set; }
        public int IdTalle { get; set; }
        public string TalleNombre { get; set; }
        public string Color { get; set; }               
        public string Marca { get; set; }              
        public decimal Precio { get; set; }            
        public int Stock { get; set; }                
        public int StockMinimo { get; set; }         
        public string Estado { get; set; }
        
        public int IdCategoria { get; set; }            
        public int IdProveedor { get; set; }           

        
        public string CategoriaNombre { get; set; }    
        public string ProveedorNombre { get; set; }     
    }
}
