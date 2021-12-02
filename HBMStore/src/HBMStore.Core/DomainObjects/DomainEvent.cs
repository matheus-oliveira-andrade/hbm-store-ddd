using HBMStore.Core.Messages;
using System;

namespace HBMStore.Core.DomainObjects
{
    public class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;  
        }
    }
}
