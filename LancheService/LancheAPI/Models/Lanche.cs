using System.Collections.Generic;
namespace LancheAPI.Models 
{
    public class Lanche : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<LancheIngrediente> LancheIngrediente { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}