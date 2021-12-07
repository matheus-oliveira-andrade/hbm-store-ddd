using HBMStore.Core.Messages;
using HBMStore.Core.Messages.CommomMessages.Notifications;
using System.Threading.Tasks;

namespace HBMStore.Core.Communication.Mediator
{
    public interface IMediatorHandle
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
