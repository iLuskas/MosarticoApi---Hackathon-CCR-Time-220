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
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapper _mapper;

        public ApplicationServiceEndereco(IServiceEndereco serviceEndereco, IMapper mapper)
        {
            _serviceEndereco = serviceEndereco;
            _mapper = mapper;
        }

        public void Add(EnderecoDTO obj)
        {
            var objEntity = _mapper.Map<Endereco>(obj);

            _serviceEndereco.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceEndereco.Dispose();
        }

        public IEnumerable<EnderecoDTO> GetAll()
        {
            var listObjEntity = _serviceEndereco.GetAll();

            return _mapper.Map<IEnumerable<EnderecoDTO>>(listObjEntity);
        }

        public EnderecoDTO GetById(int id)
        {
            var objEntity = _serviceEndereco.GetById(id);

            return _mapper.Map<EnderecoDTO>(objEntity);
        }

        public void Remove(EnderecoDTO obj)
        {
            var objEntity = _mapper.Map<Endereco>(obj);

            _serviceEndereco.Remove(objEntity);
        }

        public void Update(EnderecoDTO obj)
        {
            var objEntity = _mapper.Map<Endereco>(obj);

            _serviceEndereco.Update(objEntity);
        }
    }
}
