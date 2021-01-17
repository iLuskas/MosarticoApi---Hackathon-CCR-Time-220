using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class Oficinas : Base
    {
        public int OngId { get; set; }
        public virtual Ong Ong { get; set; }
        [MaxLength(2000)]
        public string Descricao { get; set; }
        [MaxLength(500)]
        public string Link { get; set; }
        public DateTime Data { get; set; }

        public virtual List<UsuarioOficina> UsuarioOficinas { get; set; }
        public virtual List<ImagemOficina> ImagensOficina { get; set; }
    }
}
