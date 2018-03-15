using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LancheAPI.Models.Repositories
{
    public class LancheIngredienteMap
    {
        public LancheIngredienteMap(EntityTypeBuilder<LancheIngrediente> entityBuilder)
        {
            entityBuilder.ToTable("Lanche_Ingrediente");
            entityBuilder.HasKey(t => new {t.LancheId, t.IngredienteId});            
        }
    }
}