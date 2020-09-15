using EntityFrameworkCore.Data.EntityMap;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EntityFrameworkCore.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Necessário instalar pacote Microsoft.Extensions.Configuration.Json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Necessário instalar o pacote Microsoft.EntityFrameworkCore.SqlServer (provider SQL SERVER)
            optionsBuilder.UseSqlServer(config.GetConnectionString("stringConnectionPedidosDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}