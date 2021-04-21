using JBTech.Core.Notifications;

namespace JBTech.Cadastro.Domain.Services
{
    public abstract class BaseDomainService
    {
        protected INotificationHandler Notification { get; }

        public BaseDomainService(INotificationHandler notification)
        {
            Notification = notification;
        }
    }
}
