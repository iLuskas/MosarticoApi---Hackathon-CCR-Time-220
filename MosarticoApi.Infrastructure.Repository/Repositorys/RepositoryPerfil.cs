using Microsoft.EntityFrameworkCore;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryPerfil : RepositoryBase<Perfil>, IRepositoryPerfil
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryPerfil(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
            //AdicionarDados();
        }

        public void AdicionarDados()
        {

            _mosarticoContext.Perfils.Add(new Perfil { Id = 1, Tipo = "Membro" });
            _mosarticoContext.Perfils.Add(new Perfil { Id = 2, Tipo = "Artísta" });
            _mosarticoContext.Perfils.Add(new Perfil { Id = 3, Tipo = "Empresa" });
            _mosarticoContext.Perfils.Add(new Perfil { Id = 4, Tipo = "Assossiado" });

            _mosarticoContext.SaveChanges();
        }

        public IEnumerable<Perfil> GetAllPerfil()
        {
            IQueryable<Perfil> query = _mosarticoContext.Perfils;

            return query.AsNoTracking().OrderByDescending(u => u.Id).ToList();
        }
    }
}
