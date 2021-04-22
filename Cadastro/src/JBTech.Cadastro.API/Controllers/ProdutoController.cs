using JBTech.Cadastro.Domain.Dto.Produto;
using JBTech.Cadastro.Domain.Interfaces.Services;
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
    public class ProdutoController : BaseController
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutoController(
            IProdutoDomainService produtoDomainService,
            INotificationHandler notification) : base(notification)
        {
            _produtoDomainService = produtoDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarProdutoDto dto)
        {
            var id = default(Guid?);

            if (ModelState.IsValid)
                id = await _produtoDomainService.CriarAsync(dto);

            return RetornarResponse(id);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarProdutoDto dto)
        {
            if (ModelState.IsValid)
                await _produtoDomainService.AtualizarAsync(dto);

            return RetornarResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletarAsync(Guid id)
        {
            if (ModelState.IsValid)
                await _produtoDomainService.DeletarAsync(id);

            return RetornarResponse();
        }
    }
}
