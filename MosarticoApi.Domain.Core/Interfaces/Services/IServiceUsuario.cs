using MosarticoApi.Domain.Models;
using MosarticoApi.Domain.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Usuario GetUserByUsernameAndPass(Usuario usuario);
        bool resetSenhaUsuario(string email);
        void AlterarSenhaUsuario(ModeloAlterarSenhaUser modeloAlterarSenhaUser);
        IEnumerable<Usuario> GetAllUsuario();
        Usuario getUsuarioByEmail(string email);
    }
}
