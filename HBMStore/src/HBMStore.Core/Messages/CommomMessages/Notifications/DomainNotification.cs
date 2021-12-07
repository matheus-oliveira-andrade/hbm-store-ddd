using MediatR;
using System;

namespace HBMStore.Core.Messages.CommomMessages.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            TimeStamp = DateTime.Now;
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
