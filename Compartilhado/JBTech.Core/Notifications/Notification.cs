using System;

namespace JBTech.Core.Notifications
{
    public class Notification
    {
        public string Key { get; private set; }
        public string Message { get; private set; }
        public NotificationType Type { get; private set; }

        public Notification(string key, string message, NotificationType type)
        {
            Key = key;
            Type = type;
            Message = message;
        }
    }

    public enum NotificationType
    {
        Error,
        Success,
        Warning,
        Information
    }
}
