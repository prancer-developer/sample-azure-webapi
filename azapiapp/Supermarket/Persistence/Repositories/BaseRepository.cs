using azapiapp.Supermarket.Persistence.Contexts;

namespace azapiapp.Supermarket.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}