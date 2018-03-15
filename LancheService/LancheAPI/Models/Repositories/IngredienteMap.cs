using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LancheAPI.Models.Repositories
{
    public class IngredienteMap
    {
        public IngredienteMap(EntityTypeBuilder<Ingrediente> entityBuilder)
        {
            entityBuilder.ToTable("Ingrediente");
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            entityBuilder.Ignore(t => t.Lanches);
        }
    }
}