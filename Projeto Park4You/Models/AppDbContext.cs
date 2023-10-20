using Microsoft.EntityFrameworkCore;

namespace Projeto_Park4You.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<cadast_Usuario> cadast_Usuario { get; set; }

        public DbSet<Endereco_Vaga> endereco_Vagas { get; set; }
    }
}
