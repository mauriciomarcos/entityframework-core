using EntityFrameworkCore.Data.EntityMap;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;

namespace EntityFrameworkCore.Data.Context
{
    public class DataBaseContext : DbContext
    {
        // Necessário instalar o pacote Microsoft.Extensions.Logging.Console
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(param => param.AddConsole());

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
            optionsBuilder
                .UseLoggerFactory(_logger)
                // Habilitado o EnableSensitiveDataLogging para poder visualizar os valores dos parâmentos no log do console
                .EnableSensitiveDataLogging()
                .UseSqlServer(config.GetConnectionString("stringConnectionPedidosDB"));
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

            // Chamada para o método de configuração default
            DefautMappingConfiguration(modelBuilder);
        }

        private void DefautMappingConfiguration(ModelBuilder modelBuilder)
        {
            // Iterando a lista de Entidades da Aplicação
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Obter todas as propriedades (IEnumerable) da Entidade corrente do tipo string
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                // Iterando cada uma das propriedade para validar se a mesma foi confugurada ou se devemos adicionar o valor Default
                foreach (var propertyValue in properties)
                {
                     //Verifica se a propriedade possui um valor já configurado e se não tem nenhum tamanho definido                     
                    if (string.IsNullOrEmpty(propertyValue.GetColumnType()) && !propertyValue.GetMaxLength().HasValue)
                    {
                        // Definindo o tamanho default para os campos do tipo string
                        propertyValue.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }
    }
}