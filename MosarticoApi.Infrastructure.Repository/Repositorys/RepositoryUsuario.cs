using Microsoft.EntityFrameworkCore;
using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryUsuario(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id).ToList();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Login.ToLower() == usuario.Login.ToLower() && user.Senha == usuario.Senha).FirstOrDefault();
        }

        public Usuario getUsuarioByEmail(string email)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
