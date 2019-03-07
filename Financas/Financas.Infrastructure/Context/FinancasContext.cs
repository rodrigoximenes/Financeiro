using Financas.Domain;
using System.Data.Entity;

namespace Financas.Infrastructure.Context
{
    public class FinancasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>().HasRequired(movi => movi.Usuario);
        }
    }
}
