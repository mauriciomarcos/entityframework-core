using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.EntityMap
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataInicio)
                .HasDefaultValue("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.StatusPedido)
                .HasConversion<string>();

            builder.Property(e => e.TipoFrete)
                .HasConversion<int>();

            builder.HasMany(e => e.ItensPedido)
                .WithOne(e => e.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
