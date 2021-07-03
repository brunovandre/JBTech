using JBTech.Cadastro.Domain.Dto.Fornecedor;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
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
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorDomainService _fornecedorDomainService;
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorController(
            IFornecedorDomainService fornecedorDomainService,
            IFornecedorRepository fornecedorRepository,
            INotificationHandler notification) : base(notification)
        {
            _fornecedorDomainService = fornecedorDomainService;
            _fornecedorRepository = fornecedorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var fornecedores = await _fornecedorRepository.GetAllAsync();

            return RetornarResponse(fornecedores);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);

            return RetornarResponse(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarFornecedorDto dto)
        {
            var id = default(Guid?);

            if (ModelState.IsValid)
                id = await _fornecedorDomainService.CriarAsync(dto);

            return RetornarResponse(id);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarFornecedorDto dto)
        {
            if (ModelState.IsValid)
                await _fornecedorDomainService.AtualizarAsync(dto);

            return RetornarResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletarAsync(Guid id)
        {
            if (ModelState.IsValid)
                await _fornecedorDomainService.DeletarAsync(id);

            return RetornarResponse();
        }
    }
}
