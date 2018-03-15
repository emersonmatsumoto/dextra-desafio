using System.Collections.Generic;
namespace PromocaoAPI.Models 
{
    public class Lanche : IEntity
    {
        public virtual Promocao Promocao { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}