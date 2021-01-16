using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class ImagemArte : Base
    {
        public int ArteId { get; set; }
        public virtual Arte Arte { get; set; }
        [MaxLength(2000)]
        public string Imagem { get; set; }
    }
}
