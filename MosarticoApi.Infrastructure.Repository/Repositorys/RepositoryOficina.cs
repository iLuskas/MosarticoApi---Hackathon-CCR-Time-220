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
    public class RepositoryOficina : RepositoryBase<Oficinas>, IRepositoryOficina
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryOficina(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }

        public IEnumerable<Oficinas> GetAllOficina()
        {
            IQueryable<Oficinas> query = _mosarticoContext.Oficinas
                .Include(o => o.Ong)
                .Include(o => o.ImagensOficina);

            return query.AsNoTracking().OrderByDescending(o => o.Id).ToList();
        }

        public Oficinas GetByIdOficina(int oficinaId)
        {
            IQueryable<Oficinas> query = _mosarticoContext.Oficinas
                .Include(o => o.Ong)
                .Include(o => o.ImagensOficina)
                .Include(o => o.UsuarioOficinas)
                    .ThenInclude(o => o.Usuario);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(of => of.Id == oficinaId).FirstOrDefault();
        }
    }
}
