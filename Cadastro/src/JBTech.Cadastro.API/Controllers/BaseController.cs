using JBTech.Core.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
