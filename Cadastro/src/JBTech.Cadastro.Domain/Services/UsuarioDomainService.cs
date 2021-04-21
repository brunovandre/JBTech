using JBTech.Cadastro.Domain.Entities;
using JBTech.Cadastro.Domain.Interfaces.Repositories;
using JBTech.Cadastro.Domain.Interfaces.Services;
using JBTech.Core.Notifications;
using System;
using System.Threading.Tasks;

namespace JBTech.Cadastro.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService, IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomainService(
            INotificationHandler notificationHandler,
            IUsuarioRepository usuarioRepository):base(notificationHandler)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task CriarAsync(Usuario usuario)
        {
            if (!await _usuarioRepository.CpfeEmailEstaoDisponiveisAsync(usuario.Email, usuario.Cpf)) return;

            await _usuarioRepository.InsertAsync(usuario);
        }

        public async Task AtualizarAsync(Usuario novoUsuario)
        {
            var usuarioDb = await _usuarioRepository.GetByIdAsync(novoUsuario.Id);
            if (usuarioDb == null) return;
            
            if (!await _usuarioRepository.CpfeEmailEstaoDisponiveisAsync(novoUsuario.Email, novoUsuario.Cpf)) return;

            usuarioDb.Atualizar(novoUsuario.Nome, novoUsuario.Sobrenome);

            await _usuarioRepository.UpdateAsync(usuarioDb);
        }

        public async Task InativarAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return;

            usuario.Inativar();

            await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}
