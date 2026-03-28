

using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Repositories.Core.Entities;

namespace PuntoDeVenta.Repositories.Sql.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductoEntity> Producto { get; set; }
    }
}