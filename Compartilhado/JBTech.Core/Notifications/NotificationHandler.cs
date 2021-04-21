using System;
using System.Collections.Generic;
using System.Linq;

namespace JBTech.Core.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasErrorNotifications()
            => _notifications.Any(x => x.Type == NotificationType.Error);
           
        public bool HasNotifications()
           => _notifications.Any();

        public void RaiseError(string key, string message)
        {
            if(!_notifications.Any(n => key.Equals(n.Key)))
                _notifications.Add(new Notification(key, message, NotificationType.Error));

        }

        public void RaiseWarning(string key, string message)
        {
            if (!_notifications.Any(n => key.Equals(n.Key)))
                _notifications.Add(new Notification(key, message, NotificationType.Warning));

        }

        public void RaiseInformation(string key, string message)
        {
            if (!_notifications.Any(n => key.Equals(n.Key)))
                _notifications.Add(new Notification(key, message, NotificationType.Information));

        }

        public void RaiseSuccess(string key, string message)
        {
            if (!_notifications.Any(n => n.Key.Equals(key)))
                _notifications.Add(new Notification(key, message, NotificationType.Success));
        }

        public void Dispose()
            => _notifications = new List<Notification>();
    }
}
