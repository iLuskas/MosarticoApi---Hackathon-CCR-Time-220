using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryImagemArte : RepositoryBase<ImagemArte>, IRepositoryImagemArte
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryImagemArte(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }
    }
}
