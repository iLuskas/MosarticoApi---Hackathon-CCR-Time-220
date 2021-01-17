using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.Interface;

namespace MosarticoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OngController : ControllerBase
    {
        private readonly IApplicationServiceOng _applicationServiceOng;

        public OngController(IApplicationServiceOng applicationServiceOng)
        {
            _applicationServiceOng = applicationServiceOng;
        }

        //<summary>
        // Get All Ong
        //</summary>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<OngDTO>> Get()
        {
            try
            {
                return Ok(_applicationServiceOng.GetAllOng());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById Ong
        //</summary>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<OngDTO> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceOng.GetByIdOng(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Insert new Ong
        //</summary>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] OngDTO ongDTO)
        {
            try
            {
                if (ongDTO == null)
                    return NotFound(new { message = "Ong inválida!" });

                _applicationServiceOng.Add(ongDTO);
                return Ok("Ong Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        //<summary>
        // Update Ong
        //</summary>
        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] OngDTO ongDTO)
        {
            try
            {
                if (ongDTO == null)
                    return NotFound(new { message = "Ong inválida!" });

                _applicationServiceOng.Update(ongDTO);
                return Ok("Ong Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        //<summary>
        // Delete Ong
        //</summary>
        [HttpDelete]
        [Authorize]
        public ActionResult Delete([FromBody] OngDTO ongDTO)
        {
            try
            {
                if (ongDTO == null)
                    return NotFound(new { message = "Ong inválida!" });

                _applicationServiceOng.Remove(ongDTO);
                return Ok("Ong Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}

