using Facturacion.Models;
using Microsoft.EntityFrameworkCore;

namespace Facturacion
{
      
      // Configuracion del DbContext 
    
    public class FacturaContext : DbContext
    {
        //Constructor del contexto de base de datos
        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options)
        {

        }

        //Se envian los modelos a tener en cuenta para la cracion de tablas en la base de datos
        public DbSet<Facturas> Factura { get; set; }
        public DbSet<Detalles> Detalle { get; set; }

        public DbSet<Productos> Producto { get; set; }

        //Se configura los ajuste a la creacion del modelado de base de datos 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Se detalla el tipo de campo decimal 
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


            //Se llena la tabla productos con valores por defecto
            modelBuilder.Entity<Productos>().HasData(
               new Productos { idProducto = 1, Producto = "Camisa" },
               new Productos { idProducto = 2, Producto = "Pantalon" },
               new Productos { idProducto = 3, Producto = "Zapatos" },
               new Productos { idProducto = 4, Producto = "Tenis" },
               new Productos { idProducto = 5, Producto = "Falda"},
               new Productos { idProducto = 6, Producto = "Blusa" }
            );

            //Se detalla la longito de los campos varchar
            modelBuilder.Entity<Productos>()
               .Property(d => d.Producto)
               .HasColumnType("varchar(30)");

            modelBuilder.Entity<Facturas>()
                .Property(d => d.TipodePago)
                .HasColumnType("varchar(30)");

            modelBuilder.Entity<Facturas>()
                .Property(d => d.DocumentoCliente)
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Facturas>()
               .Property(d => d.NombreCliente)
               .HasColumnType("varchar(50)");

            modelBuilder.Entity<Facturas>()
               .Property(d => d.Descuento)
               .HasColumnType("varchar(3)");

            modelBuilder.Entity<Facturas>()
            .Property(d => d.Iva)
            .HasColumnType("varchar(3)");
        }
    }
}
