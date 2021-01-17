using System.ComponentModel.DataAnnotations;

namespace MosarticoApi.Domain.Models
{
    public class ImagemOng : Base
    {
        public int OngId { get; set; }
        public virtual Ong Ong { get; set; }
        [MaxLength(2000)]
        public string Imagem { get; set; }
    }
}