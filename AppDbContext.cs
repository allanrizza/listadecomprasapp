using Microsoft.EntityFrameworkCore;

namespace ListaDeComprasApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Item> Itens { get; set; }
    }
}
