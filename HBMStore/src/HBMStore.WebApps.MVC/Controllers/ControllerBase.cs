using HBMStore.Core.Communication.Mediator;
using HBMStore.Core.Messages.CommomMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBMStore.WebApps.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notification;
        private readonly IMediatorHandle _mediatorHandler;

        protected ControllerBase(INotificationHandler<DomainNotification> notification,
                                 IMediatorHandle mediatorHandler)
        {
            _notification = (DomainNotificationHandler)notification;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notification.TemNotificacoes();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notification.ObterNotificacoes().Select(n => n.Value).ToList();
        }

        protected void NotificarErro(string type, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(type, mensagem));
        }

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
    }
}
