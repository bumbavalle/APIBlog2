using Blog.API.Utilidad;
using Blog.BLL.Servicios.Interface;
using Blog.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
            private readonly IPostService _PostServicio;

            public PostController(IPostService PostService)
            {
            _PostServicio = PostService;
            }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PostDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _PostServicio.Lista();

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
        public async Task<IActionResult> Guardar([FromBody] PostDTO post)
        {
            var rsp = new Response<PostDTO>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _PostServicio.Crear(post);

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
        public async Task<IActionResult> Editar([FromBody] PostDTO post)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _PostServicio.Editar(post);

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
                rsp.Value = await _PostServicio.Eliminar(id);

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

