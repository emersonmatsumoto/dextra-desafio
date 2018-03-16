using System.Collections.Generic;
using Web.Models;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface ILancheService
    {
        Task<List<Lanche>> Listar();        
    }
}