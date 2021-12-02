using HBMStore.Catalogo.Domain.Events;
using HBMStore.Core.Bus;
using System;
using System.Threading.Tasks;

namespace HBMStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandle _bus;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandle bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            if(!produto.PossuiEmEstoque(quantidade))
            {
                return false;
            }

            produto.DebitarEstoque(quantidade);

            if(produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoEstoqueBaixoEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();            
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
