using Blog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Servicios.Interface
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> Lista();
    }
}
