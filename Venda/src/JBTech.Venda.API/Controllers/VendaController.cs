using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBTech.Vendas.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBTech.Vendas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("efetuar")]
        public async Task<IActionResult> EfetuarVenda(EfetuarVendaCommand command)
        {
            var retorno = await _mediator.Send(command);
            return Ok(retorno);
        }

        [HttpPatch("cancelar/{id:guid}")]
        public async Task<IActionResult> CancelarVenda(Guid id)
        {
            var retorno = await _mediator.Send(new CancelarVendaCommand(id));

            return Ok(retorno);
        }
    }
}
