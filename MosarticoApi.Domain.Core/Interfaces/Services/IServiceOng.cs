using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Services
{
    public interface IServiceOng : IServiceBase<Ong>
    {
        IEnumerable<Ong> GetAllOng();
        Ong GetByIdOng(int ongId);
    }
}
