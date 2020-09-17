using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.EntityMap
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .HasColumnType("VARCHAR(80)")
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnType("CHAR(11)");

            builder.Property(e => e.CEP)
                .HasColumnType("CHAR(8)")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType("CHAR(2)")
                .IsRequired();

            // o HasMaxLength cria oum NVARCHAR na base de dados
            builder.Property(e => e.Cidade)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(ix => ix.Telefone)
                .HasName("ix_cliente_telefone");
        }
    }
}
