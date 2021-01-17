using AutoMapper;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Service
{
    public class ApplicationServiceTipoArte
    {
        private readonly IServiceTipoArte _serviceTipoArte;
        private readonly IMapper _mapper;

        public ApplicationServiceTipoArte(IServiceTipoArte serviceTipoArte, IMapper mapper)
        {
            _serviceTipoArte = serviceTipoArte;
            _mapper = mapper;
        }

        public void Add(TipoArteDTO obj)
        {
            var objEntity = _mapper.Map<TipoArte>(obj);

            _serviceTipoArte.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceTipoArte.Dispose();
        }

        public IEnumerable<TipoArteDTO> GetAll()
        {
            var listObjEntity = _serviceTipoArte.GetAll();

            return _mapper.Map<IEnumerable<TipoArteDTO>>(listObjEntity);
        }

        public TipoArteDTO GetById(int id)
        {
            var objEntity = _serviceTipoArte.GetById(id);

            return _mapper.Map<TipoArteDTO>(objEntity);
        }

        public void Remove(TipoArteDTO obj)
        {
            var objEntity = _mapper.Map<TipoArte>(obj);

            _serviceTipoArte.Remove(objEntity);
        }

        public void Update(TipoArteDTO obj)
        {
            var objEntity = _mapper.Map<TipoArte>(obj);

            _serviceTipoArte.Update(objEntity);
        }
    }
}
