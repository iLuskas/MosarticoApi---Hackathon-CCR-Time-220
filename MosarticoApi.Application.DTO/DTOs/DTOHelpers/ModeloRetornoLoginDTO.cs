using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs.DTOHelpers
{
    public class ModeloRetornoLoginDTO
    {
        public string Login { get; set; }
        public int? UsuarioId { get; set; }
        public string Token { get; set; }
    }
}
