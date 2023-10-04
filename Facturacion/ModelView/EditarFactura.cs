namespace Facturacion.ModelView
{
    public class EditarFactura
    {

     
        public int idFactura { get; set; }

     
        public int NumeroFactura { get; set; }

    
        public DateTime Fecha { get; set; }
     
        public string TipodePago { get; set; }
     
        public string DocumentoCliente { get; set; }
     

        public string NombreCliente { get; set; }
      

        public decimal Subtotal { get; set; }
        
        public string Descuento { get; set; }
       
        public string Iva { get; set; }
  
        public decimal TotalDescuento { get; set; }
   
        public decimal TotalImpuesto { get; set; }
    
        public decimal Total { get; set; }
    }
}
