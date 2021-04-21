using System;
using System.Collections.Generic;

namespace JBTech.Core.Notifications
{
    public interface INotificationHandler
    {
        bool HasNotifications();
        bool HasErrorNotifications();
        List<Notification> GetNotifications();
        void RaiseError(string key, string message);
        void RaiseSuccess(string referenceId, string message);
        void RaiseWarning(string key, string message);
        void RaiseInformation(string key, string message);
    }
}
