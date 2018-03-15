using System.Collections.Generic;

namespace PromocaoAPI.Models 
{
    public class Promocao : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Lanche> Lanches { get; set; }
    }
}