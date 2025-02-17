using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Contenido { get; set; } = null!;
    }
}
