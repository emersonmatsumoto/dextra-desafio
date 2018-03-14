using System.Threading.Tasks;
using System.Collections.Generic;

namespace LancheAPI.Models 
{
    public interface IGenericRepository<T> where T: class, IEntity, new()
    {
        Task<T> Get(int? id);
        Task Save(T employee);
        Task Delete(T employee);
        Task Update(T employee);
        Task<IEnumerable<T>> FindAll();
    }
}