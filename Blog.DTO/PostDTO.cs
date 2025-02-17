using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Contenido { get; set; } = null!;
        public int? IdCategoria { get; set; }
    }
}
