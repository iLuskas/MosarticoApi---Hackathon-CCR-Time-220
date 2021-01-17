using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MosarticoApi.Application.DTO.DTOs;
using MosarticoApi.Application.Interface;

namespace MosarticoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArteController : ControllerBase
    {
        private readonly IApplicationServiceArte _applicationServiceArte;

        public ArteController(IApplicationServiceArte applicationServiceArte)
        {
            _applicationServiceArte = applicationServiceArte;
        }

        //<summary>
        // Get All Artes
        //</summary>
        [HttpGet]
        public ActionResult<IEnumerable<ArteDTO>> Get()
        {
            try
            {
                return Ok(_applicationServiceArte.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById Arte
        //</summary>
        [HttpGet("{id}")]
        public ActionResult<ArteDTO> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceArte.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Insert new Arte
        //</summary>
        [HttpPost]
        public ActionResult Post([FromBody] ArteDTO ArteDTO)
        {
            try
            {
                if (ArteDTO == null)
                    return NotFound(new { message = "Arte inválida!" });

                _applicationServiceArte.Add(ArteDTO);
                return Ok("Arte Cadastrada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        //<summary>
        // Update Arte
        //</summary>
        [HttpPut]
        public ActionResult Put([FromBody] ArteDTO ArteDTO)
        {
            try
            {
                if (ArteDTO == null)
                    return NotFound(new { message = "Arte inválida!" });

                _applicationServiceArte.Update(ArteDTO);
                return Ok("Arte Atualizada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        //<summary>
        // Delete Arte
        //</summary>
        [HttpDelete]
        public ActionResult Delete([FromBody] ArteDTO ArteDTO)
        {
            try
            {
                if (ArteDTO == null)
                    return NotFound(new { message = "Arte inválida!" });

                _applicationServiceArte.Remove(ArteDTO);
                return Ok("Arte Removida com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}
