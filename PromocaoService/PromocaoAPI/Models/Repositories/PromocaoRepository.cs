using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PromocaoAPI.Models.Repositories
{
    public class PromocaoRepository : GenericRepository<Promocao>
    {
        public PromocaoRepository(DbContext dbContext) : base(dbContext)
        {            
        }

        public async Task<IEnumerable<Promocao>> FindAll()
        {
            return await _dbContext.Set<Promocao>()
                .Include("Lanches")
                .ToListAsync();
        }

        public async Task<Promocao> Get(int id)
        {
            return await _dbContext.Set<Promocao>()
                .Where(w => w.Id == id)
                .Include("Lanches")
                .FirstOrDefaultAsync();
        }

        public async Task<Promocao> Get(string lancheNome)
        {
            return await _dbContext.Set<Lanche>()
                .Where(w => w.Nome == lancheNome)
                .Include("Promocao")
                .Select(s => s.Promocao)
                .FirstOrDefaultAsync();
        }

    }
}