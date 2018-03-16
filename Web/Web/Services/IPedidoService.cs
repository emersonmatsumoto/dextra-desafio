using Web.Models;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IPedidoService
    {
        Task Criar(Pedido pedido);
    }
}