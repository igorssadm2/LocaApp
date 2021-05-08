using LocaApp.Identidade.API.Data.Configuration;
using LocaApp.Identidade.API.Models;
using LocaApp.Identidade.API.Models.Cliente;
using LocaApp.Identidade.API.Models.Endereco;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocaApp.Identidade.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<LocaAppUserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new EnderecoModelConfiguration());
        //}
    }
}
