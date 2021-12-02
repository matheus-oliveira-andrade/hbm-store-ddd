using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HBMStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoEstoqueBaixoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoEstoqueBaixoEvent mensagem, CancellationToken cancellationToken)
        {
            Produto produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // notificação comprar mais produtos            
        }
    }
}
