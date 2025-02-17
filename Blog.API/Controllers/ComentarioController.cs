using Blog.API.Utilidad;
using Blog.BLL.Servicios.Interface;
using Blog.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _ComentarioServicio;

        public ComentarioController(IComentarioService ComentarioService)
        {
            _ComentarioServicio = ComentarioService;
        }

        [HttpGet]
        [Route("Lista/{postId}")]

        public async Task<IActionResult> Lista(int postId)
        {
            var rsp = new Response<List<ComentarioDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _ComentarioServicio.Lista(postId);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Message = ex.Message;

            }
            return Ok(rsp);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ComentarioDTO comentario)
        {
            var rsp = new Response<ComentarioDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _ComentarioServicio.Crear(comentario);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Message = ex.Message;

            }
            return Ok(rsp);

        }


        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ComentarioDTO comentario)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _ComentarioServicio.Editar(comentario);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Message = ex.Message;

            }
            return Ok(rsp);

        }


        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _ComentarioServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Message = ex.Message;

            }
            return Ok(rsp);

        }

    }
}
