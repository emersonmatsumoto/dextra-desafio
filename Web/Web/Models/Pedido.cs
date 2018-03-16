using System.Collections.Generic;

namespace Web.Models
{
    public class Pedido 
    {        
        public Pedido() 
        {
            Itens = new List<Item>();
            Descontos = new List<Desconto>();
        }
        public int Id { get; set; }
        public List<Item> Itens { get; set; }
        public List<Desconto> Descontos { get; set; }
        public decimal Total 
        { 
            get
            {
                var tot = 0m;

                foreach(var item in Itens)
                {
                    tot += item.Valor * item.Quantidade;
                }

                foreach(var desconto in Descontos)
                {
                    tot -= desconto.Valor;
                }

                return tot;
            } 
        }
    }
}