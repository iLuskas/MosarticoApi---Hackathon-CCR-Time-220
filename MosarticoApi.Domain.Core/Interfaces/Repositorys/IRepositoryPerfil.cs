using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPerfil : IRepositoryBase<Perfil>
    {
        IEnumerable<Perfil> GetAllPerfil();
    }
}
