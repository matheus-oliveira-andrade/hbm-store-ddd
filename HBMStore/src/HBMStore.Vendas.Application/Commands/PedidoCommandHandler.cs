using HBMStore.Core.Messages;
using HBMStore.Vendas.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HBMStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler : IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<bool> Handle(AdicionarItemPedidoCommand comando, CancellationToken cancellationToken)
        {
            if (!ComandoValido(comando))
            {
                return false;
            }

            Pedido pedido = await _pedidoRepository.ObterPedidoRascunhoPorClienteId(comando.ClienteId);

            PedidoItem pedidoItem = new PedidoItem(comando.ProdutoId,
                                                   comando.Nome,
                                                   comando.Quantidade,
                                                   comando.ValorUnitario);

            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.NovoPedidoRascunho(comando.ClienteId);
                pedido.AdicionarItem(pedidoItem);

                _pedidoRepository.Adicionar(pedido);
            }
            else
            {
                var pedidoItemJaAdicionado = pedido.PedidoItemJaAdicionado(pedidoItem);
                pedido.AdicionarItem(pedidoItem);

                if (pedidoItemJaAdicionado)
                {
                    PedidoItem pedidoItemAtualizar = pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);
                    _pedidoRepository.AtualizarPedidoItem(pedidoItemAtualizar);
                }
                else
                {
                    _pedidoRepository.AdicionarPedidoItem(pedidoItem);
                }
            }

            return await _pedidoRepository.UnitOfWork.Commit();
        }

        private bool ComandoValido(Command command)
        {
            if (command.EhValido())
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
