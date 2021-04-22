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

        public void NotificarEntidadeNaoEncontrada(string nomeEntidade)
           => Notification.RaiseError("NaoEncontrado", $"{nomeEntidade} não encontrado(a).");
    }
}
