using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LancheAPI.Models.Repositories
{
    public class LancheMap
    {
        public LancheMap(EntityTypeBuilder<Lanche> entityBuilder)
        {
            entityBuilder.ToTable("Lanche");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            entityBuilder.Ignore(t => t.Ingredientes);
        }
    }
}