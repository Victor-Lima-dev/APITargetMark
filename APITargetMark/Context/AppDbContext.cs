using APITargetMark.Models;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
    }
}
