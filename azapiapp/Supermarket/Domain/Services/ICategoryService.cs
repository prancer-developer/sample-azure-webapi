using System.Collections.Generic;
using System.Threading.Tasks;
using azapiapp.Supermarket.Domain.Models;
using azapiapp.Supermarket.Domain.Services.Communication;

namespace azapiapp.Supermarket.Domain.Services
{
    public interface ICategoryService
    {
         Task<IEnumerable<Category>> ListAsync();
         Task<CategoryResponse> SaveAsync(Category category);
         Task<CategoryResponse> UpdateAsync(int id, Category category);
         Task<CategoryResponse> DeleteAsync(int id);
    }
}