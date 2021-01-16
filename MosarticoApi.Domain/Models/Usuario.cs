using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class Usuario : Base
    {
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(20)]
        public string Senha { get; set; }
        public string Nome { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        [MaxLength(16)]
        public string CpfCnpj { get; set; }
        [MaxLength(255)]
        public string Descricao { get; set; }
        [MaxLength(2000)]
        public string Foto { get; set; }
        public DateTime Nascimento { get; set; }
        public virtual List<Endereco> Enderecos{ get; set; }
        public virtual List<Telefone> Telefones { get; set; }
        public virtual List<Arte> Artes { get; set; }

    }
}
