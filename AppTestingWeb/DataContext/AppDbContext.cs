using AppTestingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTestingWeb.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
