using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PedidoAPI.Models.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        protected DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            var context = _dbContext.Set<T>();
            var entity = await context.FindAsync(id);

            if (entity == null) 
            {
                throw new ArgumentException("Entidade não foi encontrada");
            }

            context.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        
       

        public async Task Save(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}