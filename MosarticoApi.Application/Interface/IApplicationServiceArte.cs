using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceArte
    {
        void Add(ArteDTO obj);
        ArteDTO GetById(int id);
        IEnumerable<ArteDTO> GetAll();
        void Update(ArteDTO obj);
        void Remove(ArteDTO obj);
        void Dispose();
    }
}
