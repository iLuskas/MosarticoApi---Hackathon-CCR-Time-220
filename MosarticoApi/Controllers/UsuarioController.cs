using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.DTO.DTOs.DTOHelpers;
using MosarticoApi.Application.Interface;

namespace MosarticoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;

        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }

        //<summary>
        // Get All Usuarios
        //</summary>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            try
            {
                return Ok(_applicationServiceUsuario.GetAllUsuario());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById Usuario
        //</summary>
        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceUsuario.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Recover password Usuario
        //</summary>
        [HttpPost("recuperarSenha")]
        public ActionResult recuperarSenha([FromQuery] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return NotFound(new { message = "Email inválido!" });

                return Ok(_applicationServiceUsuario.ResetSenhaUsuario(email));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        //<summary>
        // Update password Usuario
        //</summary>
        [HttpPost("alterarSenha")]
        [Authorize]
        public ActionResult alterarSenha([FromBody] ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO)
        {
            try
            {
                if (modeloAlterarSenhaUserDTO == null)
                    return NotFound(new { message = "Usuário inválido!" });

                _applicationServiceUsuario.AlterarSenhaUsuario(modeloAlterarSenhaUserDTO);

                return Ok("Senha Alterada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        //<summary>
        // Insert Usuario
        //</summary>
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Add(usuarioDTO);
                return Ok("Usuário Cadastrado com sucesso!");
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método POST - {e.Message}");
            }
        }

        //<summary>
        // Login Usuario
        //</summary>
        [HttpPost("Login")]
        public ActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválido!" });

                return Ok(_applicationServiceUsuario.GetUserByUserAndPass(usuarioDTO));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        //<summary>
        // Update Usuario
        //</summary>
        [HttpPut]
        public ActionResult Put([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Update(usuarioDTO);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método PUT - {e.Message}");
            }
        }

        //<summary>
        // Delete Usuario
        //</summary>
        [HttpDelete]
        public ActionResult Delete([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Remove(usuarioDTO);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}
