using Facturacion.Models;

namespace Facturacion.ModelView
{

    //Modelo para los datos solicitados en la vista de formulario de facturas con su detalle
    public class FacturaDetalles
    {

        public int idFactura { get; set; }
        public Facturas FacturaV { get; set; }
        public List<Detalles> DetallesV { get; set; }
    

    }
}
