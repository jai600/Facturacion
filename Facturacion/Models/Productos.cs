using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{
    public class Productos
    {
        [Key]
        public int idProducto { get; set; }
        [Required]
        public string Producto {  get; set; }      
    }
}
