using JBTech.Cadastro.Domain.Dto.Categoria;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaDomainService _categoriaDomainService;

        public CategoriaController(
            ICategoriaDomainService categoriaDomainService,
            INotificationHandler notification) : base(notification)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarCategoriaDto dto)
        {
            var id = default(Guid?);
            
            if (ModelState.IsValid)
              id = await _categoriaDomainService.CriarAsync(dto);

            return RetornarResponse(id);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarCategoriaDto dto)
        {
            if (ModelState.IsValid)
                await _categoriaDomainService.AtualizarAsync(dto);

            return RetornarResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletarAsync(Guid id)
        {
            if (ModelState.IsValid)
                await _categoriaDomainService.DeletarAsync(id);

            return RetornarResponse();
        }
    }
}
