using JBTech.Cadastro.Domain.Dto.Categoria;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
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
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(
            ICategoriaDomainService categoriaDomainService,
            ICategoriaRepository categoriaRepository,
            INotificationHandler notification) : base(notification)
        {
            _categoriaDomainService = categoriaDomainService;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();

            return RetornarResponse(categorias);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            return RetornarResponse(categoria);
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
