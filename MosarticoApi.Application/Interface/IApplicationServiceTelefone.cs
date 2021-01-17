using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceTelefone
    {
        void Add(TelefoneDTO obj);
        TelefoneDTO GetById(int id);
        IEnumerable<TelefoneDTO> GetAll();
        void Update(TelefoneDTO obj);
        void Remove(TelefoneDTO obj);
        void Dispose();
    }
}
