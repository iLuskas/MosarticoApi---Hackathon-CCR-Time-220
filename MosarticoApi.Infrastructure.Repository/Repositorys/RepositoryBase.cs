using Microsoft.EntityFrameworkCore;
using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly MosarticoContext _mosarticoContext;

        public RepositoryBase(MosarticoContext mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
        }

        public virtual void Add(TEntity obj)
        {
            _mosarticoContext.InitTransacao();
            _mosarticoContext.Add(obj);
            _mosarticoContext.SendChanges();
        }

        public virtual void Dispose()
        {
            _mosarticoContext.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _mosarticoContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _mosarticoContext.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _mosarticoContext.InitTransacao();
            _mosarticoContext.Remove(obj);
            _mosarticoContext.SendChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _mosarticoContext.InitTransacao();
            _mosarticoContext.Update(obj);
            _mosarticoContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mosarticoContext.SendChanges();
        }
    }
}
