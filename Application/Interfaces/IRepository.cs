using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<TValue>
    {
        Task<List<TValue>> GetAllAsync();
    }

    public interface IRepository<TValue, TKey> : IRepository<TValue>
        where TValue : Entity<TKey>
        where TKey : Id
    {
        Task<TValue> GetAsync(TKey key);
        Task<TValue> CreateAsync(TValue value);
        Task<bool> UpdateAsync(TValue value);
        Task<bool> DeleteAsync(TKey key);
    }

    public interface INameAbbrRepository<TValue, TKey> : IRepository<TValue, TKey>
        where TValue: NameAbbrEntity<TKey>
        where TKey : Id

    {
        Task<TValue> GetByNameAsync(string name);
        Task<TValue> GetByAbbrAsync(string abbr);
    }
}
