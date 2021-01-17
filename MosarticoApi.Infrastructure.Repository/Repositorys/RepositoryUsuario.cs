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
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly MosarticoContext _mosarticoContext;
        public RepositoryUsuario(MosarticoContext mosarticoContext) : base(mosarticoContext)
        {
            _mosarticoContext = mosarticoContext;
            //AdicionarDados();
        }

        public void AdicionarDados()
        {
            _mosarticoContext.Enderecos.Add(
                new Endereco
                {
                    Id = 1,
                    Bairro_end = "Campo Grande",
                    Cep_end = "1234567",
                    Rua_end = "123",
                    Cidade_end = "RJ",
                    Estado_end = "RJ",
                    Numero_end = "123",
                    Pais_end = "Brasil",
                    UsuarioId = 1
                });

            _mosarticoContext.Telefones.Add(new Telefone
            {
                Id = 1,
                ddd_tel = "21",
                Telefone_tel = "98754213",
                UsuarioId = 1
            });

            _mosarticoContext.Perfils.Add(
                new Perfil
                {
                    Id=1,
                    Tipo="Membro"
                });
            _mosarticoContext.Perfils.Add(
                new Perfil
                {
                    Id = 2,
                    Tipo = "Empresa"
                });
            _mosarticoContext.Perfils.Add(
                new Perfil
                {
                    Id = 3,
                    Tipo = "Artísta"
                });

            _mosarticoContext.Usuarios.Add(new Usuario {
                Id=1,
                Login="Master",
                Senha= "e10adc3949ba59abbe56e057f20f883e",
                CpfCnpj="123456789",
                Descricao= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Email="Loremipsum@gmail.com",
                Foto="teste.png",
                Nascimento=DateTime.Now,
                Nome="Lorem Ipsum",
                PerfilId=1
            });

            _mosarticoContext.SaveChanges();
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(u => u.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id).ToList();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Login.ToLower() == usuario.Login.ToLower() && user.Senha == usuario.Senha).FirstOrDefault();
        }

        public Usuario getUsuarioByEmail(string email)
        {
            IQueryable<Usuario> query = _mosarticoContext.Usuarios
                .Include(f => f.Perfil)
                .Include(u => u.Enderecos)
                .Include(u => u.Telefones)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.ImagemArte)
                .Include(u => u.Artes)
                    .ThenInclude(a => a.TipoArte)
                .Include(u => u.UsuarioOficinas)
                    .ThenInclude(uf => uf.Oficinas);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
