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
    public class OficinaController : ControllerBase
    {
        private readonly IApplicationServiceOficina _applicationServiceOficina;

        public OficinaController(IApplicationServiceOficina applicationServiceOficina)
        {
            _applicationServiceOficina = applicationServiceOficina;
        }

        //<summary>
        // Get All Oficina
        //</summary>
        [HttpGet]
        public ActionResult<IEnumerable<OficinasDTO>> Get()
        {
            try
            {
                return Ok(_applicationServiceOficina.GetAllOficina());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById Oficina
        //</summary>
        [HttpGet("{id}")]
        public ActionResult<OficinasDTO> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceOficina.GetByIdOficina(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Insert new Oficina
        //</summary>
        [HttpPost]
        public ActionResult Post([FromBody] OficinasDTO oficinaDTO)
        {
            try
            {
                if (oficinaDTO == null)
                    return NotFound(new { message = "Oficinas inválida!" });

                _applicationServiceOficina.Add(oficinaDTO);
                return Ok("Oficinas Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        //<summary>
        // Update Oficina
        //</summary>
        [HttpPut]
        public ActionResult Put([FromBody] OficinasDTO oficinaDTO)
        {
            try
            {
                if (oficinaDTO == null)
                    return NotFound(new { message = "Oficina inválida!" });

                _applicationServiceOficina.Update(oficinaDTO);
                return Ok("Oficina Atualizada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        //<summary>
        // Delete Oficina
        //</summary>
        [HttpDelete]
        public ActionResult Delete([FromBody] OficinasDTO oficinaDTO)
        {
            try
            {
                if (oficinaDTO == null)
                    return NotFound(new { message = "Oficina inválida!" });

                _applicationServiceOficina.Remove(oficinaDTO);
                return Ok("Oficina Removida com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}
