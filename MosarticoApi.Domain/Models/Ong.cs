using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MosarticoApi.Domain.Models
{
    public class Ong : Base
    {
        [MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(2000)]
        public string Descricao { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }

        public virtual List<ImagemOng> ImagensOng { get; set; }
        public virtual List<Oficinas> Oficinas { get; set; }
    }
}