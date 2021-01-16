using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        private readonly IRepositoryEndereco _repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco repositoryEndereco) : base(repositoryEndereco)
        {
            _repositoryEndereco = repositoryEndereco;
        }
    }
}
