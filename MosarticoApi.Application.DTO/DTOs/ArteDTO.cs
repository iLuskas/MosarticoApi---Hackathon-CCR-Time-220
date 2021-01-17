using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs
{
    public class ArteDTO : BaseDTO
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCricao { get; set; }
        public int TipoArteId { get; set; }
        public List<ImagemArteDTO> ImagemArteDTOs { get; set; }
    }
}
