using System.Threading.Tasks;
using System.Collections.Generic;

namespace LancheAPI.Models.Repositories
{
    public interface IGenericRepository<T> where T: class, IEntity, new()
    {
        Task Save(T entity);
        Task Delete(int id);
        Task Update(T entity);
    }
}