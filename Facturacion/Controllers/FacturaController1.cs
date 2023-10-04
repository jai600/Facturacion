using Facturacion.Models;
using Facturacion.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Facturacion.Controllers
{
    public class FacturaController1 : Controller
    {

        private readonly FacturaContext _facturaContext;

        //Constructor para el contexto de base de datos
        public FacturaController1(FacturaContext context)
        {
            _facturaContext = context;
        }

        // Metodo index retornamos la lista de facturas almacenadas
        public async Task<IActionResult> Index()
        {

            List<Facturas> fact = new List<Facturas>();
            fact = await _facturaContext.Factura.ToListAsync();
            return View(fact);
        }


        //Metodo FormFacturas el formulario de facturas 
        public ActionResult FormFacturas(int id = 0)
        {
            try
            {
                var factura = new Facturas
                {

                    DetalleFactura = new List<Detalles>() // Inicializa la lista de detalles
                };

                //Instanciamos una lista Pro para enviar los productos almacenados en la base de datos a la vista de formulario de facturas
                List<Productos> Pro = new List<Productos>();
                Pro = _facturaContext.Producto.ToList();
                @ViewBag.ListaPro = Pro;


                Detalles detalles = new Detalles();
                //Se valida si es modificacion de una factura con el id recibido siempre debe ser difrente a cero
                if (id != 0)
                {

                    //Segun el id enviado se realizara la verificacion del registro existente con el contexto de la base de datos
                   // var result =  _facturaContext.Factura.FindAsync(id);
                    var result = _facturaContext.Factura.Where(p => p.idFactura == id).ToList();

                    //Se valida que exista registro
                    if (result.Count == 0)
                    {
                        return PartialView("NoEncontrada");
                    }

                    //Del contexto tomamos la factura y su detalle segun el idFactura
                    var EditarFactura = _facturaContext.Factura.FirstOrDefault(p => p.idFactura == id);
                    var listaDetalles = _facturaContext.Detalle.Where(p => p.idFactura == EditarFactura.idFactura).ToList();
                    @ViewBag.ListaDetalles = listaDetalles;
                    return PartialView(EditarFactura);
                }
                else
                {
                    //Si es creacion de factura solo retornamos la vista 
                    return PartialView(factura);
                }
            } catch (Exception ex)
            {
                throw ex;

            }
        }

        //Metodo Guardar (Este tambien se comportara como el modificar la factura)
        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] FacturaDetalles Fact)
        {
            try
            {
                //Pasamos el valor FacturaV y DetallesV que representara todos los datos de la vista a guardar o modificar segun la accion, DetallesV contendra la lista de detalles de la factura 
                Facturas RFactura = Fact.FacturaV;            
                RFactura.DetalleFactura = Fact.DetallesV;

                //el IdFactura igual a cero, representara que los datos deberan ser almacenados como una nueva factura
                if(Fact.idFactura == 0)
                {
                    _facturaContext.Add(RFactura);
                    await _facturaContext.SaveChangesAsync();
                    return Json(new { respuesta = "La factura a sido almacenada con éxito!" });
                }
                else
                {
                    //En su contrario determinara que es un idFactura existente y debera ser modificada la factura
                    _facturaContext.Update(RFactura);
                    await _facturaContext.SaveChangesAsync();
                    return Json(new { respuesta = "La factura a sido actualizada con éxito" });
                }


               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        
        }

        //Metodo EliminarFactura
        [HttpPost]
        public async Task<IActionResult> ElimninarFactura(int Id)
        {

            try
            {
                //Segun el id enviado se realizara la verificacion del registro existente con el contexto de la base de datos
                var result = await _facturaContext.Factura.FindAsync(Id);

                //Se valida que exista registro
                if (result == null)
                {
                    return Json(new { respuesta = "No hay factura registrada con este idFactura seleccionado!" });
                }
                else
                {
                    //Se removera del contexto de base de datos la factura y todo su modelado que cumpla con el idFactura enviado   
                    _facturaContext.Factura.Remove(result);
                    await _facturaContext.SaveChangesAsync();
                    return Json(new { respuesta = "la factura a sido eliminada con éxito!" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
           
        }

    }
}
