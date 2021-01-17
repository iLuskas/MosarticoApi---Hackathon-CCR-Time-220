using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs
{
    public class EnderecoDTO : BaseDTO
    {
        public string Pais_end { get; set; }
        public string Estado_end { get; set; }
        public string Cidade_end { get; set; }
        public string Bairro_end { get; set; }
        public string Rua_end { get; set; }
        public string Numero_end { get; set; }
        public string Cep_end { get; set; }
    }
}
