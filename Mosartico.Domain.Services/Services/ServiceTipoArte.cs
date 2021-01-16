using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceTipoArte : ServiceBase<TipoArte>, IServiceTipoArte
    {
        private readonly IRepositoryTipoArte _repositoryTipoArte;
        public ServiceTipoArte(IRepositoryTipoArte repositoryTipoArte) : base(repositoryTipoArte)
        {
            _repositoryTipoArte = repositoryTipoArte;
        }
    }
}
