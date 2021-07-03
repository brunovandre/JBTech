using JBTech.Cadastro.Domain.Dto.Usuario;
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
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(
            IUsuarioDomainService usuarioDomainService,
            IUsuarioRepository usuarioRepository,
            INotificationHandler notification) : base(notification)
        {
            _usuarioDomainService = usuarioDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            return RetornarResponse(usuarios);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            return RetornarResponse(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarUsuarioDto dto)
        {
            var id = default(Guid?);

            if (ModelState.IsValid)
                id = await _usuarioDomainService.CriarAsync(dto);

            return RetornarResponse(id);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarUsuarioDto dto)
        {
            if (ModelState.IsValid)
                await _usuarioDomainService.AtualizarAsync(dto);

            return RetornarResponse();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> DeletarAsync(Guid id)
        {
            if (ModelState.IsValid)
                await _usuarioDomainService.InativarAsync(id);

            return RetornarResponse();
        }
    }
}
