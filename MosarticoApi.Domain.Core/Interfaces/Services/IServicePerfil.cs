using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Domain.Models;
using System.Collections.Generic;

namespace MosarticoApi.Domain.Core.Interfaces.Services
{
    public interface IServicePerfil : IServiceBase<Perfil>
    {
        IEnumerable<Perfil> GetAllPerfil();
    }
}
