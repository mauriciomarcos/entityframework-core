using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.EntityMap
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");

            builder.Property(e => e.Id);

            builder.Property(e => e.Quantidade)
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(e => e.ValorUnitarioProduto)
                .IsRequired();

            builder.Property(e => e.Desconto)
                .IsRequired();
        }
    }
}
