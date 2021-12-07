using HBMStore.Core.Messages.CommomMessages.DomainEvents;
using System;

namespace HBMStore.Catalogo.Domain.Events
{
    public class ProdutoEstoqueBaixoEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoEstoqueBaixoEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
