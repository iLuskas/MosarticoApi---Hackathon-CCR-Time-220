using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs
{
    public class OficinasDTO : BaseDTO
    {
        public int OngId { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }
        public DateTime Data { get; set; }

        public virtual List<UsuarioDTO> UsuarioDTOs { get; set; }
        public virtual List<ImagemOficinaDTO> ImagensOficinaDTOs { get; set; }
    }
}
