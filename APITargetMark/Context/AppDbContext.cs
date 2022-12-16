using APITargetMark.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APITargetMark.Context
{
    public class AppDbContext : IdentityDbContext
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
