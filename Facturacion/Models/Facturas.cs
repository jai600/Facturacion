using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{    
    
   
    //  Modelo Facturas del contexto de base de datos
  
    public class Facturas
    {
        [Key]
        public int idFactura { get; set; }

        [Required]
        public int NumeroFactura { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string TipodePago { get; set; }
        [Required]
        public string DocumentoCliente { get; set; }
        [Required]
        
        public string NombreCliente {  get; set; }
        [Required]
        
        public decimal Subtotal { get; set; }
        [Required]
        public string Descuento { get; set; }
        [Required]
        public string  Iva {  get; set; }
        [Required]           
        public decimal  TotalDescuento { get; set; }
        [Required]
        public decimal   TotalImpuesto { get; set; }
        [Required]
        public decimal Total {  get; set; }

        //Almacenar los detalles con el modelado de base de datos
        public Facturas()
        {
            DetalleFactura = new HashSet<Detalles>();
        }

        public virtual ICollection<Detalles> DetalleFactura { get; set; }
       
    }
}
