﻿using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HBMStore.Core.Messages.CommomMessages.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes() => _notifications;

        public virtual bool TemNotificacoes() => ObterNotificacoes().Any();

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

    }
}
