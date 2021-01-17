using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Services.Services
{
    public class ServiceOficina : ServiceBase<Oficinas>, IServiceOficina
    {
        private readonly IRepositoryOficina _repositoryOficina;
        public ServiceOficina(IRepositoryOficina repositoryOficina) : base(repositoryOficina)
        {
            _repositoryOficina = repositoryOficina;
        }
        public IEnumerable<Oficinas> GetAllOficina()
        {
            return _repositoryOficina.GetAllOficina();
        }

        public Oficinas GetByIdOficina(int oficinaId)
        {
            return _repositoryOficina.GetByIdOficina(oficinaId);
        }
    }
}
