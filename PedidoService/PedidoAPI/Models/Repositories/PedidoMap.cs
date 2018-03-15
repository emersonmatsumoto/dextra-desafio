using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PedidoAPI.Models.Repositories
{
    public class PedidoMap
    {
        public PedidoMap(EntityTypeBuilder<Pedido> entityBuilder)
        {
            entityBuilder.ToTable("Pedido");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Ignore(t => t.Total);
            entityBuilder.HasMany(t => t.Itens).WithOne(t => t.Pedido).OnDelete(DeleteBehavior.Cascade);
            entityBuilder.HasMany(t => t.Descontos).WithOne(t => t.Pedido).OnDelete(DeleteBehavior.Cascade);
        }
    }
}