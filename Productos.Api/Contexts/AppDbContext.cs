using Microsoft.EntityFrameworkCore;
using Productos.Api.Entities;

namespace Productos.Api.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<ProductoEntity> Producto { get; set; }
    }
}