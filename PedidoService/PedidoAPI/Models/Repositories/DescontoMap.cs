using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PedidoAPI.Models.Repositories
{
    public class DescontoMap
    {
        public DescontoMap(EntityTypeBuilder<Desconto> entityBuilder)
        {
            entityBuilder.ToTable("Desconto");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Descricao).IsRequired().HasMaxLength(50);
        }
    }
}