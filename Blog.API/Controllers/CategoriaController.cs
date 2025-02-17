using Blog.API.Utilidad;
using Blog.BLL.Servicios.Interface;
using Blog.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        public readonly ICategoriaService _categoriaservicio;

        public CategoriaController(ICategoriaService categoriaservicio)
        {
            _categoriaservicio = categoriaservicio;
        }

        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {

            var rsp = new Response<List<CategoriaDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _categoriaservicio.Lista();

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

