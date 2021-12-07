using HBMStore.Catalogo.Application.Services;
using HBMStore.Catalogo.Data;
using HBMStore.Catalogo.Data.Repository;
using HBMStore.Catalogo.Domain;
using HBMStore.Catalogo.Domain.Events;
using HBMStore.Vendas.Application.Commands;
using HBMStore.Vendas.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using HBMStore.Vendas.Data.Repository;
using HBMStore.Vendas.Data;
using HBMStore.Core.Messages.CommomMessages.Notifications;
using HBMStore.Core.Communication.Mediator;

namespace HBMStore.WebApps.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandle, MediatorHandle>();

            // Notificações
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoEstoqueBaixoEvent>, ProdutoEventHandler>();


            // Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<VendasContext>();
        }
    }
}
