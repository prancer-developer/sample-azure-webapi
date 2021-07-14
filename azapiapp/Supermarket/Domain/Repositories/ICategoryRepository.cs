using System.Collections.Generic;
using System.Threading.Tasks;
using azapiapp.Supermarket.Domain.Models;

namespace azapiapp.Supermarket.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindByIdAsync(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}