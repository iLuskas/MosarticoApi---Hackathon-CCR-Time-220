using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.Interface;

namespace MosarticoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IApplicationServicePerfil _applicationServicePerfil;

        public PerfilController(IApplicationServicePerfil applciationServicePerfil)
        {
            _applicationServicePerfil = applciationServicePerfil;
        }

        //<summary>
        // Get All Perfil
        //</summary>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<PerfilDTO>> Get()
        {
            try
            {
                return Ok(_applicationServicePerfil.GetAllPerfil());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById Perfil
        //</summary>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<PerfilDTO> Get(int id)
        {
            try
            {
                return Ok(_applicationServicePerfil.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Insert new Perfil
        //</summary>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválido!" });

                _applicationServicePerfil.Add(perfilDTO);
                return Ok("Perfil Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        //<summary>
        // Update Perfil
        //</summary>
        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválidos!" });

                _applicationServicePerfil.Update(perfilDTO);
                return Ok("Perfil Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        //<summary>
        // Delete Perfil
        //</summary>
        [HttpDelete]
        [Authorize]
        public ActionResult Delete([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválidos!" });

                _applicationServicePerfil.Remove(perfilDTO);
                return Ok("Perfil Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}
