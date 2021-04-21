using JBTech.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace JBTech.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        public UsuarioController(INotificationHandler notification) : base(notification)
        {
        }
    }
}
