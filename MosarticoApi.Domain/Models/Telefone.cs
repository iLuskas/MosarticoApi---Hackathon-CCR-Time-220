using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class Telefone : Base
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [MaxLength(3)]
        public string ddd_tel { get; set; }
        [MaxLength(9)]
        public string Telefone_tel { get; set; }
    }
}
