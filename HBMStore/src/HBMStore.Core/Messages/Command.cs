using FluentValidation.Results;
using MediatR;
using System;

namespace HBMStore.Core.Messages
{
    public class Command : Message, IRequest<bool>
    {
        public DateTime TimeStamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool EhValido() => throw new NotImplementedException();
    }
}
