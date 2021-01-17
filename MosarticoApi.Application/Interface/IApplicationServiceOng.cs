using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceOng 
    {
        void Add(OngDTO obj);
        OngDTO GetById(int id);
        IEnumerable<OngDTO> GetAll();
        void Update(OngDTO obj);
        void Remove(OngDTO obj);
        IEnumerable<OngDTO> GetAllOng();
        OngDTO GetByIdOng(int ongId);
        void Dispose();
    }
}
