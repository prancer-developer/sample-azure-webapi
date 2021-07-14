using System.Collections.Generic;
using System.Threading.Tasks;
using azapiapp.Supermarket.Domain.Models;
using azapiapp.Supermarket.Domain.Models.Queries;

namespace azapiapp.Supermarket.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task AddAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        void Update(Product product);
        void Remove(Product product);
    }
}