using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceArte : ServiceBase<Arte>, IServiceArte
    {
        private readonly IRepositoryArte _repositoryArte;
        public ServiceArte(IRepositoryArte repositoryArte) : base(repositoryArte)
        {
            _repositoryArte = repositoryArte;
        }
    }
}
