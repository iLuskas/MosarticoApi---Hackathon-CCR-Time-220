using AutoMapper;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.Interface;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Service
{
    public class ApplicationServiceArte : IApplicationServiceArte
    {
        private readonly IServiceArte _serviceArte;
        private readonly IMapper _mapper;

        public ApplicationServiceArte(IServiceArte serviceArte, IMapper mapper)
        {
            _serviceArte = serviceArte;
            _mapper = mapper;
        }

        public void Add(ArteDTO obj)
        {
            var objEntity = _mapper.Map<Arte>(obj);

            _serviceArte.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceArte.Dispose();
        }

        public IEnumerable<ArteDTO> GetAll()
        {
            var listObjEntity = _serviceArte.GetAll();

            return _mapper.Map<IEnumerable<ArteDTO>>(listObjEntity);
        }

        public ArteDTO GetById(int id)
        {
            var objEntity = _serviceArte.GetById(id);

            return _mapper.Map<ArteDTO>(objEntity);
        }

        public void Remove(ArteDTO obj)
        {
            var objEntity = _mapper.Map<Arte>(obj);

            _serviceArte.Remove(objEntity);
        }

        public void Update(ArteDTO obj)
        {
            var objEntity = _mapper.Map<Arte>(obj);

            _serviceArte.Update(objEntity);
        }
    }
}
