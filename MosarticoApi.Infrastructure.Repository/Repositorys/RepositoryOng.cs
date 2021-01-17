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
    public class RepositoryOng : RepositoryBase<Ong>, IRepositoryOng
    {
        private readonly MosarticoContext _mosarticoContext;

        public RepositoryOng(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }

        public IEnumerable<Ong> GetAllOng()
        {
            IQueryable<Ong> query = _mosarticoContext.Ongs
                .Include(o => o.ImagensOng)
                .Include(o => o.Oficinas);

            return query.AsNoTracking().OrderByDescending(o => o.Id).ToList();
        }

        public Ong GetByIdOng(int ongId)
        {
            IQueryable<Ong> query = _mosarticoContext.Ongs
                .Include(o => o.ImagensOng)
                .Include(o => o.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(of => of.Id == ongId).FirstOrDefault();
        }
    }
}
