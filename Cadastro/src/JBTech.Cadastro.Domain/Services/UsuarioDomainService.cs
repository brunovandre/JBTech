using AutoMapper;
using JBTech.Cadastro.Domain.Dto.Usuario;
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
        private readonly IMapper _mapper;

        public UsuarioDomainService(
            IMapper mapper,
            INotificationHandler notificationHandler,
            IUsuarioRepository usuarioRepository):base(notificationHandler)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<Guid?> CriarAsync(CriarUsuarioDto dto)
        {
            await ValidarSeCpfeEmailEstaoDisponiveis(dto.Email, dto.Cpf);

            var usuario = _mapper.Map<Usuario>(dto);

            if (Notification.HasErrorNotifications()) return null;

            await _usuarioRepository.InsertAsync(usuario);

            return usuario.Id;
        }

        public async Task AtualizarAsync(AtualizarUsuarioDto dto)
        {
            var usuarioDb = await _usuarioRepository.GetByIdAsync(dto.Id);
            
            ValidarSeUsuarioExiste(usuarioDb);

            usuarioDb.Atualizar(dto.Nome, dto.Sobrenome);

            if (Notification.HasErrorNotifications()) return;

            await _usuarioRepository.UpdateAsync(usuarioDb);
        }

        public async Task InativarAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            ValidarSeUsuarioExiste(usuario);

            usuario.Inativar();

            if (Notification.HasErrorNotifications()) return;

            await _usuarioRepository.UpdateAsync(usuario);
        }

        private void ValidarSeUsuarioExiste(Usuario usuario)
        {
            if (usuario == null)
                NotificarEntidadeNaoEncontrada("Usuario");
        }

        private async Task ValidarSeCpfeEmailEstaoDisponiveis(string email, string cpf)
        {
            if (!await _usuarioRepository.CpfeEmailEstaoDisponiveisAsync(email, cpf))
                Notification.RaiseError("CpfOuEmailIndisponivel", "E-mail ou Cpf já utilizados");
        }
    }
}
