using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.DTO.DTOs.DTOHelpers;
using System.Collections.Generic;

namespace MosarticoApi.Application.Interface
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO usuarioDTO);
        UsuarioDTO GetById(int id);
        IEnumerable<UsuarioDTO> GetAllUsuario();
        UsuarioDTO GetUserByUserAndPass(UsuarioDTO usuarioDTO);
        bool ResetSenhaUsuario(string email);
        void AlterarSenhaUsuario(ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO);
        void Update(UsuarioDTO usuarioDTO);
        void Remove(UsuarioDTO usuarioDTO);
        void Dispose();
    }
}
