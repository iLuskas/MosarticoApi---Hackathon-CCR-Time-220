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
                .Include(u => u.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id).ToList();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Login.ToLower() == usuario.Login.ToLower() && user.Senha == usuario.Senha).FirstOrDefault();
        }

        public Usuario getUsuarioByEmail(string email)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
