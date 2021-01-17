using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryOng : IRepositoryBase<Ong>
    {
        IEnumerable<Ong> GetAllOng();
        Ong GetByIdOng(int ongId);
    }
}
