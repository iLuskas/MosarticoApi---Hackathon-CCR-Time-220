using System.ComponentModel.DataAnnotations;

namespace MosarticoApi.Domain.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
