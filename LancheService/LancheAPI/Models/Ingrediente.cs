using System.Collections.Generic;

namespace LancheAPI.Models 
{
    public class Ingrediente : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<LancheIngrediente> LancheIngrediente { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}