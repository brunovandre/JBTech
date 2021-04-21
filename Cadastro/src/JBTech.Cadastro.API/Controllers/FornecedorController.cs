using JBTech.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBTech.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : BaseController
    {
        public FornecedorController(INotificationHandler notification) : base(notification)
        {
        }
    }
}
