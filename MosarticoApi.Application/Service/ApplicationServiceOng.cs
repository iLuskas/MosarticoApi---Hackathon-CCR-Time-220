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
    public class ApplicationServiceOng : IApplicationServiceOng
    {
        private readonly IServiceOng _serviceOng;
        private readonly IMapper _mapper;

        public ApplicationServiceOng(IServiceOng serviceOng, IMapper mapper)
        {
            _serviceOng = serviceOng;
            _mapper = mapper;
        }
        public void Add(OngDTO obj)
        {
            var objEntity = _mapper.Map<Ong>(obj);

            _serviceOng.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceOng.Dispose();
        }

        public IEnumerable<OngDTO> GetAll()
        {
            var listObjEntity = _serviceOng.GetAll();

            return _mapper.Map<IEnumerable<OngDTO>>(listObjEntity);
        }

        public IEnumerable<OngDTO> GetAllOng()
        {
            var listObjEntity = _serviceOng.GetAllOng();

            return _mapper.Map<IEnumerable<OngDTO>>(listObjEntity);
        }

        public OngDTO GetById(int id)
        {
            var objEntity = _serviceOng.GetById(id);

            return _mapper.Map<OngDTO>(objEntity);
        }

        public OngDTO GetByIdOng(int ongId)
        {
            var objEntity = _serviceOng.GetByIdOng(ongId);

            return _mapper.Map<OngDTO>(objEntity);
        }

        public void Remove(OngDTO obj)
        {
            var objEntity = _mapper.Map<Ong>(obj);

            _serviceOng.Remove(objEntity);
        }

        public void Update(OngDTO obj)
        {
            var objEntity = _mapper.Map<Ong>(obj);

            _serviceOng.Update(objEntity);
        }
    }
}
