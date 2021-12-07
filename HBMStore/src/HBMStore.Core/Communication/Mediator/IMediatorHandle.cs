using HBMStore.Core.Messages;
using System.Threading.Tasks;

namespace HBMStore.Core.Communication.Mediator
{
    public interface IMediatorHandle
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
