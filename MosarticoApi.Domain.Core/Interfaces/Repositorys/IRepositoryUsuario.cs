using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Usuario GetUserByUsernameAndPass(Usuario usuario);
        Usuario getUsuarioByEmail(string email);
        IEnumerable<Usuario> GetAllUsuario();
    }
}
