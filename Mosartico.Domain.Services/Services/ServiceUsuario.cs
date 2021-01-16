using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using MosarticoApi.Domain.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IEmailSender _emailSender;
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario, IEmailSender emailSender) : base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
            _emailSender = emailSender;
        }

        public void AlterarSenhaUsuario(ModeloAlterarSenhaUser modeloAlterarSenhaUser)
        {
            var usuario = _repositoryUsuario.getUsuarioByEmail(modeloAlterarSenhaUser.Email);

            if (usuario == null)
                throw new Exception("Email não encontrato em nossa base.");

            usuario.Senha = Utilidades.GerarHashMd5(modeloAlterarSenhaUser.Senha);

            _repositoryUsuario.Update(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return _repositoryUsuario.GetAllUsuario();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            return _repositoryUsuario.GetUserByUsernameAndPass(usuario);
        }

        public Usuario getUsuarioByEmail(string email)
        {
            return _repositoryUsuario.getUsuarioByEmail(email);
        }

        public bool resetSenhaUsuario(string email)
        {
            var usuario = _repositoryUsuario.getUsuarioByEmail(email);

            if (usuario == null)
                throw new Exception("Email não encontrato em nossa base.");

            var token = ServiceToken.GenerateToken(usuario, true);

            var response = _emailSender.SendEmailRecoveryPassAsync(usuario.Email, token).GetAwaiter();

            return response.IsCompleted;
        }
    }
}
