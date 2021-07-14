using System.Threading.Tasks;

namespace azapiapp.Supermarket.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}