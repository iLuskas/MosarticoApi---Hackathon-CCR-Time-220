using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryTipoArte : RepositoryBase<TipoArte>, IRepositoryTipoArte
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryTipoArte(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }
    }
}
