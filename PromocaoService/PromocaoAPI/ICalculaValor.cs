using PromocaoAPI.Models;
namespace PromocaoAPI
{
    public interface ICalculaValor
    {
        decimal Light(Lanche lanche);
        decimal Queijo(Lanche lanche);
        decimal Carne(Lanche lanche);
    }
}