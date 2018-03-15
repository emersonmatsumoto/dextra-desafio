using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PromocaoAPI.Models.Repositories
{
    public class PromocaoMap
    {
        public PromocaoMap(EntityTypeBuilder<Promocao> entityBuilder)
        {
            entityBuilder.ToTable("Promocao");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            entityBuilder.HasMany(t => t.Lanches).WithOne(t => t.Promocao).OnDelete(DeleteBehavior.Cascade);
        }
    }
}