using Microsoft.EntityFrameworkCore;
using WebAPI.Cidades.Models;

namespace WebAPI.Cidades.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CidadeModel> Cidades { get; set; }
    }
}
