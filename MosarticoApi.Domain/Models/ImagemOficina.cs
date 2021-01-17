using System.ComponentModel.DataAnnotations;

namespace MosarticoApi.Domain.Models
{
    public class ImagemOficina : Base
    {
        public int OficinasId { get; set; }
        public virtual Oficinas Oficinas { get; set; }
        [MaxLength(2000)]
        public string Imagem { get; set; }
    }
}