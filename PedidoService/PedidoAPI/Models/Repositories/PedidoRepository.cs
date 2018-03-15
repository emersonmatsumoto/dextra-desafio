using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PedidoAPI.Models.Repositories
{
    public class PedidoRepository : GenericRepository<Pedido>
    {
        public PedidoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Pedido>> FindAll()
        {
            return await _dbContext.Set<Pedido>()
                .Include("Itens")
                .Include("Descontos")
                .ToListAsync();
        }

        public async Task<Pedido> Get(int id)
        {
            return await _dbContext.Set<Pedido>()
                .Include("Itens")
                .Include("Descontos")
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}