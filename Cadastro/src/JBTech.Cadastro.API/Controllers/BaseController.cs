using JBTech.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JBTech.Cadastro.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public INotificationHandler Notification { get; set; }

        public BaseController(INotificationHandler notification)
        {
            Notification = notification;
        }

        protected IActionResult RetornarResponse(object data = null)
        {   
            if (!Notification.HasErrorNotifications())
                return Ok(data);

            return BadRequest(Notification.GetNotifications());
        }
    }
}
