using HBMStore.Core.Messages;
using MediatR;
using System.Threading.Tasks;

namespace HBMStore.Core.Bus
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
    }
}
