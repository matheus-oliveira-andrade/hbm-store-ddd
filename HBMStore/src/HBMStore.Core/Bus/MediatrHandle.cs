using HBMStore.Core.Messages;
using MediatR;
using System;
using System.Threading.Tasks;

namespace HBMStore.Core.Bus
{
    public class MediatrHandle : IMediatrHandle
    {
        private readonly IMediator _mediator;

        public MediatrHandle(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}
