using System.Threading.Tasks;
using azapiapp.Supermarket.Domain.Models;
using azapiapp.Supermarket.Domain.Models.Queries;
using azapiapp.Supermarket.Domain.Services.Communication;

namespace azapiapp.Supermarket.Domain.Services
{
    public interface IProductService
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}