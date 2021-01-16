using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceTelefone : ServiceBase<Telefone>, IServiceTelefone
    {
        private readonly IRepositoryTelefone _repositoryTelefone;

        public ServiceTelefone(IRepositoryTelefone repositoryTelefone) : base(repositoryTelefone)
        {
            _repositoryTelefone = repositoryTelefone;
        }
    }
}
