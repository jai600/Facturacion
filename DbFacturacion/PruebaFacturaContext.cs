using Facturacion.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFacturacion
{
    public class PruebaFacturaContext : DbContext
    {
        public PruebaFacturaContext(DbContextOptions<PruebaFacturaContext> options) :base(options) 
        {

        }

        public DbSet<Facturas> Factura {  get; set; }
        public DbSet<Detalles> Detaalle { get; set; }

        public DbSet<Productos> Producto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}