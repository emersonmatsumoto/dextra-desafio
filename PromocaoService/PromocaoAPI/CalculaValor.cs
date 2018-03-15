using PromocaoAPI.Models;
namespace PromocaoAPI
{
    public class CalculaValor : ICalculaValor
    {
        public decimal Light(Lanche lanche)
        {
            var alface = false;
            var bacon = false;
            var total = 0m;            

            foreach(var i in lanche.Ingredientes)
            {
                if (i.Nome == "Alface")
                {
                    alface = true;
                }
                else if (i.Nome == "Bacon")
                {
                    bacon = true;
                }
                total += i.Valor * i.Quantidade;
            }            

            if (!alface || bacon)
            {
                return 0;
            }

            return total * 0.2m;
        }
        
        public decimal Queijo(Lanche lanche)
        {
            return DescontoPagueLeve(lanche, "Queijo", 3);
        }

        public decimal Carne(Lanche lanche)
        {

            return DescontoPagueLeve(lanche, "Hambúrguer de carne", 3);
        }

        private decimal DescontoPagueLeve(Lanche lanche, string ingrediente, int fator)
        {
            var ingredienteQuantidade = 0;
            var ingredienteValor = 0m;
            var total = 0m;            

            foreach(var i in lanche.Ingredientes)
            {
                if (i.Nome == ingrediente)
                {
                    ingredienteQuantidade = i.Quantidade;
                    ingredienteValor = i.Valor;
                }

                total += i.Valor * i.Quantidade;
            }        

            var descontoQueijo = ingredienteQuantidade/fator;
            
            return ingredienteValor * descontoQueijo;
        }
    }
}