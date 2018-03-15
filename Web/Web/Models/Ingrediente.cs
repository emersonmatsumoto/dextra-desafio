using System.Collections.Generic;

namespace Web.Models 
{
    public class Ingrediente 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }        
        public List<Lanche> Lanches { get; set; }
    }
}