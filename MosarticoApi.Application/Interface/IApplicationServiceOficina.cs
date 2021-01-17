using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceOficina
    {
        void Add(OficinasDTO obj);
        OficinasDTO GetById(int id);
        IEnumerable<OficinasDTO> GetAll();
        void Update(OficinasDTO obj);
        void Remove(OficinasDTO obj);
        IEnumerable<OficinasDTO> GetAllOficina();
        OficinasDTO GetByIdOficina(int oficinaId);
        void Dispose();
    }
}
