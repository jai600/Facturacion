using Facturacion.Models;
using Microsoft.EntityFrameworkCore;

namespace Facturacion
{
    public class FacturaContext : DbContext
    {

        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options)
        {

        }

        public DbSet<Facturas> Factura { get; set; }
        public DbSet<Detalles> Detalle { get; set; }

        public DbSet<Productos> Producto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detalles>()
                .Property(d => d.PrecioUnitario)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Facturas>()
                .Property(d => d.Subtotal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Facturas>()
                .Property(d => d.Total)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Facturas>()
               .Property(d => d.TotalDescuento)
               .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Facturas>()
             .Property(d => d.TotalImpuesto)
             .HasColumnType("decimal(18, 2)");

            // base.OnModelCreating(modelBuilder);
        }
    }
}
