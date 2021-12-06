using HBMStore.Catalogo.Application.Services;
using HBMStore.Catalogo.Data;
using HBMStore.Catalogo.Data.Repository;
using HBMStore.Catalogo.Domain;
using HBMStore.Catalogo.Domain.Events;
using HBMStore.Core.Bus;
using HBMStore.Vendas.Application.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HBMStore.WebApps.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain bus
            services.AddScoped<IMediatrHandle, MediatrHandle>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoEstoqueBaixoEvent>, ProdutoEventHandler>();


            // Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        }
    }
}
