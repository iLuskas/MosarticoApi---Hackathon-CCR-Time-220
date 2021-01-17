using AutoMapper;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.DTO.DTOs.DTOHelpers;
using MosarticoApi.Application.Interface;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Models;
using MosarticoApi.Domain.Models.Helpers;
using System;
using System.Collections.Generic;
using Util;

namespace MosarticoApi.Application.Service
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapper _mapper;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapper mapper)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Add(objEntity);
        }

        public void AlterarSenhaUsuario(ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO)
        {
            if (string.IsNullOrEmpty(modeloAlterarSenhaUserDTO.Email))
                throw new Exception("O campo e-mail é obrigatorio");

            if (string.IsNullOrEmpty(modeloAlterarSenhaUserDTO.Senha))
                throw new Exception("O campo senha é obrigatorio");

            var objEntity = _mapper.Map<ModeloAlterarSenhaUser>(modeloAlterarSenhaUserDTO);

            _serviceUsuario.AlterarSenhaUsuario(objEntity);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public IEnumerable<UsuarioDTO> GetAllUsuario()
        {
            var listObjEntity = _serviceUsuario.GetAllUsuario();

            return _mapper.Map<IEnumerable<UsuarioDTO>>(listObjEntity);
        }

        public UsuarioDTO GetById(int id)
        {
            var objEntity = _serviceUsuario.GetById(id);

            return _mapper.Map<UsuarioDTO>(objEntity);
        }

        public ModeloRetornoLoginDTO GetUserByUserAndPass(ModeloLogarDTO usuarioDTO)
        {
            var objEntity = new Usuario() { Login = usuarioDTO.Login, Senha = Utilidades.GerarHashMd5(usuarioDTO.Senha) };

            var obj = _serviceUsuario.GetUserByUsernameAndPass(objEntity);
            
            var objMap = _mapper.Map<UsuarioDTO>(obj);

            if (objMap == null)
                throw new ArgumentNullException("Usuário não foi encontrato.");

            var token = Utilidades.GenerateToken(obj);

            return new ModeloRetornoLoginDTO()
            {
                Login = objMap.Login,
                UsuarioId = objMap.Id,
                Token = token
            };
        }

        public void Remove(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Remove(objEntity);
        }

        public bool ResetSenhaUsuario(string email)
        {
            return _serviceUsuario.resetSenhaUsuario(email);
        }

        public void Update(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Update(objEntity);
        }
    }
}
