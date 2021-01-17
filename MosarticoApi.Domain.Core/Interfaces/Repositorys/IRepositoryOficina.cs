﻿using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryOficina : IRepositoryBase<Oficinas>
    {
        IEnumerable<Oficinas> GetAllOficina();
        Oficinas GetByIdOficina(int oficinaId);
    }
}
