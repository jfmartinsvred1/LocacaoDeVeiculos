using LocacaoDeVeiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoDeVeiculos.Repository.Data
{
    public class LocacaoDeVeiculosContext:DbContext
    {
        public LocacaoDeVeiculosContext(DbContextOptions<LocacaoDeVeiculosContext> opts):base(opts)
        {
            
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Locador> Locadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}
