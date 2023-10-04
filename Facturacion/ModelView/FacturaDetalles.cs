using Facturacion.Models;

namespace Facturacion.ModelView
{
    public class FacturaDetalles
    {

        public int idFactura { get; set; }
        public Facturas FacturaV { get; set; }
        public List<Detalles> DetallesV { get; set; }
    

    }
}
