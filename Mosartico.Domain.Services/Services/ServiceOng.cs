using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceOng : ServiceBase<Ong>, IServiceOng
    {
        private readonly IRepositoryOng _repositoryOng;
        public ServiceOng(IRepositoryOng repositoryOng) : base(repositoryOng)
        {
            _repositoryOng = repositoryOng;
        }
        public IEnumerable<Ong> GetAllOng()
        {
            return _repositoryOng.GetAllOng();
        }

        public Ong GetByIdOng(int ongId)
        {
            return _repositoryOng.GetByIdOng(ongId);
        }
    }
}
