using MosarticoApi.Application.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServicePerfil
    {
        void Add(PerfilDTO obj);
        PerfilDTO GetById(int id);
        IEnumerable<PerfilDTO> GetAll();
        IEnumerable<PerfilDTO> GetAllPerfil();
        void Update(PerfilDTO obj);
        void Remove(PerfilDTO obj);
        void Dispose();
    }
}
