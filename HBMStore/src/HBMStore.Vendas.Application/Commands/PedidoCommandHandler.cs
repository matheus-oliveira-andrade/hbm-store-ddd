using HBMStore.Core.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HBMStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        public async Task<bool> Handle(AdicionarItemPedidoCommand comando, CancellationToken cancellationToken)
        {
            if(!ComandoValido(comando))
            {
                return false;
            }

            // lógica

            return true;
        }

        private bool ComandoValido(Command command)
        {
            if(command.EhValido())
            {
                return true;
            }

            foreach (var erro in command.ValidationResult.Errors)
            {
                // lançar evento erro
            }

            return false;
        }
    }
}
