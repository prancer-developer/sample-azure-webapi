using System.Threading.Tasks;
using azapiapp.Supermarket.Domain.Repositories;
using azapiapp.Supermarket.Persistence.Contexts;

namespace azapiapp.Supermarket.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}