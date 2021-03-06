using HBMStore.Core.Messages;
using HBMStore.Core.Messages.CommomMessages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace HBMStore.Core.Communication.Mediator
{
    public class MediatorHandle : IMediatorHandle
    {
        private readonly IMediator _mediator;

        public MediatorHandle(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }
}
