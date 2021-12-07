using HBMStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBMStore.Vendas.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);
        Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId);
        void Adicionar(Pedido pedido);  
        void Atualizar(Pedido pedido);  

        Task<PedidoItem> ObterPedidoItemPorId(Guid id);
        Task<PedidoItem> ObterPedidoItemPorPedidoId(Guid pedidoId, Guid produtoId);
        void AdicionarPedidoItem(PedidoItem pedidoItem);
        void AtualizarPedidoItem(PedidoItem pedidoItem);
        void RemoverPedidoItem(PedidoItem pedidoItem);

        Task<Voucher> ObterVoucherPorCodigo(string codigo);
    }
}
