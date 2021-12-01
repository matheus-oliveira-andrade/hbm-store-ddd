using HBMStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBMStore.Catalogo.Domain
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);


        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
