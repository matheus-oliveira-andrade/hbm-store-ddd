using System.Threading.Tasks;

namespace HBMStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
