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

        public string Total 
        {
            get 
            {
                var t = 0m;
                foreach(var i in Ingredientes)
                {
                    t += i.Valor * i.Quantidade;
                }

                CultureInfo pt = new CultureInfo("pt-BR");
                return t.ToString("C", pt);
            }
        }

        public List<Ingrediente> Ingredientes { get; set; }
    }
}