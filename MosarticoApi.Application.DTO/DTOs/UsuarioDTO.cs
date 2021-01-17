using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Application.DTO.DTOs
{
    public class UsuarioDTO : BaseDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int PerfilId { get; set; }
        public string CpfCnpj { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime Nascimento { get; set; }
        public List<EnderecoDTO> EnderecosDTOs { get; set; }
        public List<TelefoneDTO> TelefonesDTOs { get; set; }
        public List<ArteDTO> ArtesDTOs { get; set; }
        public List<OficinasDTO> OficinaDTOs { get; set; }
    }
}
