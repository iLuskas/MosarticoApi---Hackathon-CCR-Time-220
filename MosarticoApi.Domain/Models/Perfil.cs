using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class Perfil : Base
    {
        [MaxLength(150)]
        public string Tipo { get; set; }
    }
}
