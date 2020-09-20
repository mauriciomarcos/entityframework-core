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
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
   
            // Necessário instalar pacote Microsoft.Extensions.Configuration.Json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            // Necessário instalar o pacote Microsoft.EntityFrameworkCore.SqlServer (provider SQL SERVER)
            optionsBuilder.UseSqlServer(config.GetConnectionString("stringConnectionPedidosDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Realizando a configuração dessa forma, não é necessário informar todos as 
             * class de Mapping que for configurada para a aplicação, como por exemplo: modelBuilder.ApplyConfiguration(new ClienteMap());
             * 
             * Utilizando o modelBuilder.ApplyConfigurationsFromAssembly e informando uma classe
             * que está contida dentro do assembly das classes de configuração, o Entity Framework Core
             * realizará um verificação no warm-up da aplicação e aplicará a configuração para todas as 
             * classes que implementarem a interface IEntityTypeConfiguration
             */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteMap).Assembly);
        }
    }
}