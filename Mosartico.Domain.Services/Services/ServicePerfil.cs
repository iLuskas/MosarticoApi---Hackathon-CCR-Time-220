using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServicePerfil : ServiceBase<Perfil>, IServicePerfil
    {
        private readonly IRepositoryPerfil _repositoryPerfil;

        public ServicePerfil(IRepositoryPerfil repositoryPerfil) : base(repositoryPerfil)
        {
            _repositoryPerfil = repositoryPerfil;
        }
    }
}
