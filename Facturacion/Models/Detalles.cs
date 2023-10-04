using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facturacion.Models
{
    public class Detalles
    {

        [Key]
        public int idDetalle { get; set; }

        [ForeignKey("Facturas")]
        public int idFactura { get; set; } public Facturas Facturas { get; set; }
        [ForeignKey("Productos")]
        public int idProducto {  get; set; } public Productos Productos { get; set; }
        [Required]
        public int  Cantidad {  get; set; }
        [Required]
        public decimal PrecioUnitario {  get; set; }
    }
}
