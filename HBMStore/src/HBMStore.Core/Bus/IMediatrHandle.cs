using HBMStore.Core.Messages;
using System.Threading.Tasks;

namespace HBMStore.Core.Bus
{
    public interface IMediatrHandle
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
