using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Web.Models 
{
    public class Lanche 
    {
        public Lanche()
        {
            Ingredientes = new List<Ingrediente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public decimal Total 
        {
            get 
            {
                var t = 0m;
                foreach(var i in Ingredientes)
                {
                    t += i.Valor * i.Quantidade;
                }

                return t;
            }
        }

        public List<Ingrediente> Ingredientes { get; set; }
    }
}