using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Domain.Models
{
    public class UsuarioOficina : Base
    {
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public int OficinasId { get; set; }
        public Oficinas Oficinas { get; set; }
    }
}
