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
    public class ApplicationServiceOficina : IApplicationServiceOficina
    {
        private readonly IServiceOficina _serviceOficina;
        private readonly IMapper _mapper;

        public ApplicationServiceOficina(IServiceOficina serviceOficinas, IMapper mapper)
        {
            _serviceOficina = serviceOficinas;
            _mapper = mapper;
        }
        public void Add(OficinasDTO obj)
        {
            var objEntity = _mapper.Map<Oficinas>(obj);

            _serviceOficina.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceOficina.Dispose();
        }

        public IEnumerable<OficinasDTO> GetAll()
        {
            var listObjEntity = _serviceOficina.GetAll();

            return _mapper.Map<IEnumerable<OficinasDTO>>(listObjEntity);
        }

        public IEnumerable<OficinasDTO> GetAllOficina()
        {
            var listObjEntity = _serviceOficina.GetAllOficina();

            return _mapper.Map<IEnumerable<OficinasDTO>>(listObjEntity);
        }

        public OficinasDTO GetById(int id)
        {
            var objEntity = _serviceOficina.GetById(id);

            return _mapper.Map<OficinasDTO>(objEntity);
        }

        public OficinasDTO GetByIdOficina(int oficinaId)
        {
            var objEntity = _serviceOficina.GetByIdOficina(oficinaId);

            return _mapper.Map<OficinasDTO>(objEntity);
        }

        public void Remove(OficinasDTO obj)
        {
            var objEntity = _mapper.Map<Oficinas>(obj);

            _serviceOficina.Remove(objEntity);
        }

        public void Update(OficinasDTO obj)
        {
            var objEntity = _mapper.Map<Oficinas>(obj);

            _serviceOficina.Update(objEntity);
        }
    }
}
