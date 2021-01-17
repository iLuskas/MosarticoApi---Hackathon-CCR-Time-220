using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs
{
    public class OngDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }

        public virtual List<ImagemOngDTO> ImagensOngDTOs { get; set; }
        public virtual List<OficinasDTO> OficinaDTOs { get; set; }
    }
}
