using Web.Models;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IPromocaoService
    {
        Task<Desconto> CalculaDesconto(Lanche lanche);
    }
}