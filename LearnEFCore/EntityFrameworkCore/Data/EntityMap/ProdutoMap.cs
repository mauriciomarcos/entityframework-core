using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.EntityMap
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CodigoBarras)
                .HasColumnType("VARCHAR(14)")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(60)");

            builder.Property(e => e.Valor)
                .IsRequired();

            builder.Property(e => e.TipoProduto)
                .HasConversion<string>();
        }
    }
}
