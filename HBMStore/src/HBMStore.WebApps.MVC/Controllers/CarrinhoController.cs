using HBMStore.Catalogo.Application.Services;
using HBMStore.Core.Communication.Mediator;
using HBMStore.Core.Messages.CommomMessages.Notifications;
using HBMStore.Vendas.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HBMStore.WebApps.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandle _mediatrHandle;

        public CarrinhoController(INotificationHandler<DomainNotification> notification,
                                  IProdutoAppService produtoAppService,
                                  IMediatorHandle mediatorHandler)
                                  : base(notification, mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatrHandle = mediatorHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null)
            {
                return BadRequest();
            }

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatrHandle.EnviarComando(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index", "Vitrine");
            }

            TempData["Erros"] = ObterMensagensErro();
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
