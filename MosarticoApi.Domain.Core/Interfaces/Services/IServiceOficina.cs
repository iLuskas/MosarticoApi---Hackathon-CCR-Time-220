using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Services
{
    public interface IServiceOficina : IServiceBase<Oficinas>
    {
        IEnumerable<Oficinas> GetAllOficina();
        Oficinas GetByIdOficina(int oficinaId);
    }
}
