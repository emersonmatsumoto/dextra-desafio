using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PedidoAPI.Models.Repositories
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.ToTable("Item");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Descricao).IsRequired().HasMaxLength(50);
        }
    }
}