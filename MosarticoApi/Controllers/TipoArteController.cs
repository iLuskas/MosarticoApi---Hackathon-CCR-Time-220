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
    public class TipoArteController : ControllerBase
    {
        private readonly IApplicationServiceTipoArte _applicationServiceTipoArte;

        public TipoArteController(IApplicationServiceTipoArte applicationServiceTipoArte)
        {
            _applicationServiceTipoArte = applicationServiceTipoArte;
        }

        //<summary>
        // Get All TipoArte
        //</summary>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<TipoArteDTO>> Get()
        {
            try
            {
                return Ok(_applicationServiceTipoArte.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        //<summary>
        // GetById TipoArte
        //</summary>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceTipoArte.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        //<summary>
        // Insert new TipoArte
        //</summary>
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] TipoArteDTO tipoArteDTO)
        {
            try
            {
                if (tipoArteDTO == null)
                    return NotFound(new { message = "Tipo de Arte inválida!" });

                _applicationServiceTipoArte.Add(tipoArteDTO);
                return Ok("Tipo de Arte Cadastrada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        //<summary>
        // Update TipoArte
        //</summary>
        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] TipoArteDTO tipoArteDTO)
        {
            try
            {
                if (tipoArteDTO == null)
                    return NotFound(new { message = "Tipo de Arte inválida!" });

                _applicationServiceTipoArte.Update(tipoArteDTO);
                return Ok("Tipo de Arte Atualizada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        //<summary>
        // Delete TipoArte
        //</summary>
        [HttpDelete]
        [Authorize]
        public ActionResult Delete([FromBody] TipoArteDTO tipoArteDTO)
        {
            try
            {
                if (tipoArteDTO == null)
                    return NotFound(new { message = "Tipo de Arte inválida!" });

                _applicationServiceTipoArte.Remove(tipoArteDTO);
                return Ok("Tipo de Arte Removida com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}
