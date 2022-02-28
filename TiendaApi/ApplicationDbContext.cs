using Microsoft.EntityFrameworkCore;
using TiendaApi.Entity;

namespace TiendaApi
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaProducto>()
                .HasKey(x => new { x.categoriaId, x.productoId });

            base.OnModelCreating(modelBuilder);
        }

        //Muchos a muchos
        public DbSet<CategoriaProducto> categoriaProductos { get; set; }
        public DbSet<Producto> productos { get; set; }

        public DbSet<Categoria> categorias { get; set; }

        public DbSet<Orden> ordenes { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<DetalleOrden> detallesOrdenes { get; set; }
    }
}
