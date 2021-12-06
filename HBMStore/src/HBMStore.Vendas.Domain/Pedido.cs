using HBMStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBMStore.Vendas.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidosItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidosItems;

        // EF Relation
        public virtual Voucher Voucher { get; private set; }

        protected Pedido()
        {
            _pedidosItems = new List<PedidoItem>();
        }

        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _pedidosItems = new List<PedidoItem>();
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorPedido();
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());

            CalcularValorTotalDesconto();
        }

        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado)
            {
                return;
            }

            var desconto = Voucher.TipoDescontoVoucher switch
            {
                TipoDescontoVoucher.Porcentagem => CalcularValorDesconto(),
                TipoDescontoVoucher.Fixo => Voucher.ValorDesconto.HasValue ? Voucher.ValorDesconto.Value : 0,
                _ => 0
            };

            var valorTotal = ValorTotal -= desconto;

            ValorTotal = valorTotal < 0 ? 0 : valorTotal;
            Desconto = desconto;
        }

        public bool PedidoItemJaAdicionado(PedidoItem pedidoItem)
        {
            return _pedidosItems.Any(p => p.ProdutoId == pedidoItem.ProdutoId);
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            if (!pedidoItem.EhValido())
            {
                return;
            }

            pedidoItem.AssociarPedido(Id);

            if (PedidoItemJaAdicionado(pedidoItem))
            {
                PedidoItem pedidoItemExistente = _pedidosItems.First(p => p.ProdutoId == pedidoItem.ProdutoId);
                pedidoItemExistente.AdicionarUnidades(pedidoItem.Quantidade);
                pedidoItem = pedidoItemExistente;

                _pedidosItems.Remove(pedidoItemExistente);
            }

            _pedidosItems.Add(pedidoItem);
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            if (!pedidoItem.EhValido())
            {
                return;
            }

            var pedidoItemRemover = PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

            if (pedidoItemRemover == null)
            {
                throw new DomainException("O item não pertence ao pedido");
            }

            _pedidosItems.Remove(pedidoItemRemover);

            CalcularValorPedido();
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            if (!pedidoItem.EhValido())
            {
                return;
            }

            pedidoItem.AssociarPedido(Id);


            var pedidoItemExistente = PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

            if (pedidoItemExistente == null)
            {
                throw new DomainException("O item não pertence ao pedido");
            }

            _pedidosItems.Remove(pedidoItemExistente);
            _pedidosItems.Add(pedidoItem);

            CalcularValorPedido();
        }

        public void AtualizarUnidadesPedidoItem(PedidoItem pedidoItem, int quantidadeUnidades)
        {
            pedidoItem.AtualizarUnidades(quantidadeUnidades);
            AtualizarItem(pedidoItem);
        }

        public void TornarRascunho()
        {
            PedidoStatus = PedidoStatus.Rascunho;
        }

        public void IniciarPedido()
        {
            PedidoStatus = PedidoStatus.Iniciado;
        }

        public void FinalizarPedido()
        {
            PedidoStatus = PedidoStatus.Pago;
        }

        public void CancelarPedido()
        {
            PedidoStatus = PedidoStatus.Cancelado;
        }

        private decimal CalcularValorDesconto()
        {
            if (!Voucher.Percentual.HasValue)
            {
                return 0;
            }

            return ValorTotal * Voucher.Percentual.Value / 100;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido = new Pedido()
                {
                    ClienteId = clienteId
                };

                pedido.TornarRascunho();

                return pedido;
            }
        }
    }
}
