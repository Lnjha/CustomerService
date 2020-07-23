using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
    }
}