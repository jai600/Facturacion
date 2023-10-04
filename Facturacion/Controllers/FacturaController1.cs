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

        public FacturaController1(FacturaContext context)
        {
            _facturaContext = context;
        }
        // GET: FacturaController1
        public async Task<IActionResult> Index()
        {

            List<Facturas> fact = new List<Facturas>();
            fact = await _facturaContext.Factura.ToListAsync();
            return View(fact);
        }

        // GET: FacturaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult FormFacturas(int id = 0)
        {
            //var factura = new Facturas
            //{
            //    // Otras propiedades de la factura
            //    DetalleFactura = new List<Detalles>() // Inicializa la lista de detalles
            //};

            //List<Productos> Pro = new List<Productos>();
            //Pro = _facturaContext.Producto.ToList();
            //@ViewBag.ListaPro = Pro;
            //return PartialView(factura);

            var factura = new Facturas
            {
                // Otras propiedades de la factura
                DetalleFactura = new List<Detalles>() // Inicializa la lista de detalles
            };

            List<Productos> Pro = new List<Productos>();
            Pro = _facturaContext.Producto.ToList();
            @ViewBag.ListaPro = Pro;

            Detalles detalles = new Detalles();
             
            

            if (id != 0)
            {
                var EditarFactura = _facturaContext.Factura.FirstOrDefault(p => p.idFactura == id);
                var listaDetalles = _facturaContext.Detalle.Where(p => p.idFactura == EditarFactura.idFactura).ToList();
                @ViewBag.ListaDetalles = listaDetalles;
                return PartialView(EditarFactura);
            }
            else
            {
                return PartialView(factura);
            }


               
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] FacturaDetalles Fact)
        {
            try
            {

                Facturas RFactura = Fact.FacturaV;


                RFactura.DetalleFactura = Fact.DetallesV;

                if(Fact.idFactura == 0)
                {
                    _facturaContext.Add(RFactura);
                    await _facturaContext.SaveChangesAsync();
                    return Json(new { respuesta = "La factura a sido almacenada con éxito!" });
                }
                else
                {
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

        // POST: FacturaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController1/Edit/5
        public ActionResult EditarFactura(int id)
        {
            var factura = new Facturas
            {
                // Otras propiedades de la factura
                DetalleFactura = new List<Detalles>() // Inicializa la lista de detalles
            };

            List<Productos> Pro = new List<Productos>();
            Pro = _facturaContext.Producto.ToList();
            @ViewBag.ListaPro = Pro;

          

            var EditarFactura = _facturaContext.Factura.FirstOrDefault(p => p.idFactura == id);
            var listaDetalles = _facturaContext.Detalle.Where(p => p.idFactura == EditarFactura.idFactura).ToList();
            @ViewBag.ListaDetalles = listaDetalles;

            return PartialView(EditarFactura);
        }

        // POST: FacturaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
