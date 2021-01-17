using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosarticoApi.Domain.Models
{
    public class Arte : Base
    {
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        [MaxLength(255)]
        public string Descricao { get; set; }
        public DateTime DataCricao { get; set; }
        public int TipoArteId { get; set; }
        public TipoArte TipoArte { get; set; }
        public virtual List<ImagemArte> ImagemArte { get; set; }
    }
}
