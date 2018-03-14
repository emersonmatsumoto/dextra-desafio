using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LancheAPI.Models 
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class, IEntity, new()
{
    private DbContext _dbContext;
    public GenericRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Delete(T employee)
    {
        _dbContext.Set<T>().Remove(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> Get(int? id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Save(T employee)
    {
        _dbContext.Set<T>().Add(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(T employee)
    {
        _dbContext.Set<T>().Update(employee);
        await _dbContext.SaveChangesAsync();
    }
}
}