using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceTipoArte
    {
        void Add(TipoArteDTO obj);
        TipoArteDTO GetById(int id);
        IEnumerable<TipoArteDTO> GetAll();
        void Update(TipoArteDTO obj);
        void Remove(TipoArteDTO obj);
        void Dispose();
    }
}
