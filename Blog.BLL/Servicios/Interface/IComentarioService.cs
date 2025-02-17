using Blog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Servicios.Interface
{
    public interface IComentarioService
    {
        Task<List<ComentarioDTO>> Lista(int postId);
        Task<ComentarioDTO> Crear(ComentarioDTO modelo);
        Task<bool> Editar(ComentarioDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
