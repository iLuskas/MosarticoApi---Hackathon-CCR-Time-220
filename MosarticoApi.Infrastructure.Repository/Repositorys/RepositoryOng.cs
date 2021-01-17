using Microsoft.EntityFrameworkCore;
using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Models;
using MosarticoApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MosarticoApi.Infrastructure.Repository.Repositorys
{
    public class RepositoryOng : RepositoryBase<Ong>, IRepositoryOng
    {
        private readonly MosarticoContext _mosarticoContext;

        public RepositoryOng(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
            //AdicionarDados();
        }

        public void AdicionarDados()
        {
            if (string.IsNullOrEmpty(_mosarticoContext.ImagemOngs.First().Imagem))
                return;

            _mosarticoContext.ImagemOngs.Add(
                new ImagemOng
                {
                    Id=1,
                    Imagem="ong1.png",
                    OngId = 1
                });

            _mosarticoContext.ImagemOngs.Add(
                new ImagemOng
                {
                    Id = 2,
                    Imagem = "ong2.png",
                    OngId = 1
                });

            _mosarticoContext.ImagemOngs.Add(
                new ImagemOng
                {
                    Id = 3,
                    Imagem = "ong3.png",
                    OngId=1
                    
                });

            _mosarticoContext.Oficinas.Add(
                new Oficinas { 
                    Id=1,
                    OngId=1,
                    Link="vivario.com.br",
                    Descricao= "Oficina de arte urbana",
                    Data=DateTime.Now
                }
                );

            _mosarticoContext.Ongs.Add(
                new Ong {
                    Id=1,
                    Cnpj="7897879879",
                    Descricao= "A Fundação Sara nasceu da convivência que os pais, parentes e amigos da pequena Sara tiveram com a dor e a esperança durante seu tratamento de leucemia, em 1996/1997. O transplante muito caro fez com que amigos e colegas de trabalho se unissem e promovessem a campanha “Ajude a Salvar a Vida da Sara”. Formou-se uma corrente de amor, numa demonstração de solidariedade jamais igualável.",
                    Nome= "Ong Viva rio",
                    Telefone="2198878845"
                }
                );

            _mosarticoContext.SaveChanges();
        }

        public IEnumerable<Ong> GetAllOng()
        {
            IQueryable<Ong> query = _mosarticoContext.Ongs
                .Include(o => o.ImagensOng)
                .Include(o => o.Oficinas);

            return query.AsNoTracking().OrderByDescending(o => o.Id).ToList();
        }

        public Ong GetByIdOng(int ongId)
        {
            IQueryable<Ong> query = _mosarticoContext.Ongs
                .Include(o => o.ImagensOng)
                .Include(o => o.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(of => of.Id == ongId).FirstOrDefault();
        }
    }
}
