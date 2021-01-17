using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceEndereco
    {
        void Add(EnderecoDTO obj);
        EnderecoDTO GetById(int id);
        IEnumerable<EnderecoDTO> GetAll();
        void Update(EnderecoDTO obj);
        void Remove(EnderecoDTO obj);
        void Dispose();
    }
}
