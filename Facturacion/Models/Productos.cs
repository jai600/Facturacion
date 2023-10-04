using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{

   
    //  Modelo Productos del contexto de base de datos
  
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public string Producto {  get; set; }      
    }
}
