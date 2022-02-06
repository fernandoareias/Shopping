using System.Threading.Tasks;

namespace Shopping.Cliente.API.Shared.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
