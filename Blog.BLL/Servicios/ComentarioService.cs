using AutoMapper;
using Blog.BLL.Servicios.Interface;
using Blog.DAL.Repositorios.Interface;
using Blog.DTO;
using Blog.Model;
using Microsoft.EntityFrameworkCore;


namespace Blog.BLL.Servicios
{
    public class ComentarioService : IComentarioService
    {
        private readonly IGenericRepository<Comentario> _comentarioRepositorio;
        private readonly IMapper _mapper;

        public ComentarioService(IGenericRepository<Comentario> comentarioRepositorio, IMapper mapper)
        {
            _comentarioRepositorio = comentarioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ComentarioDTO>>Lista(int postId)
        {
            try
            {
                var queryComentario = await _comentarioRepositorio.Consultar(c => c.PostId == postId);

                var listaComentario = queryComentario.Include(c => c.Post).ToList();

                return _mapper.Map<List<ComentarioDTO>>(listaComentario);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ComentarioDTO> Crear(ComentarioDTO modelo)
            {
                try
                {
                    var ComentarioCreado = await _comentarioRepositorio.Crear(_mapper.Map<Comentario>(modelo));

                    if (ComentarioCreado.Id == 0)
                        throw new TaskCanceledException("No se pudo Crear el Comentario");

                    return _mapper.Map<ComentarioDTO>(ComentarioCreado);

                }
                catch
                {
                    throw;
                }
            }

            public async Task<bool> Editar(ComentarioDTO modelo)
            {
                try
                {
                    var comentarioModelo = _mapper.Map<Comentario>(modelo);
                    var comentarioEncontrado = await _comentarioRepositorio.Obtener(u =>
                    u.Id == comentarioModelo.Id
                    );

                    if (comentarioEncontrado == null)
                        throw new TaskCanceledException("El Comentario no existe");

                    comentarioEncontrado.Contenido = comentarioModelo.Contenido;

                    bool respuesta = await _comentarioRepositorio.Editar(comentarioEncontrado);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo editar");

                    return respuesta;

                }
                catch
                {
                    throw;

                }
            }

            public async Task<bool> Eliminar(int id)
            {
                try
                {
                    var comentarioEncontrado = await _comentarioRepositorio.Obtener(p => p.Id == id);

                    if (comentarioEncontrado == null)
                        throw new TaskCanceledException("El Comentario no existe");


                    bool respuesta = await _comentarioRepositorio.Delete(comentarioEncontrado);

                    if (!respuesta)
                        throw new TaskCanceledException("No se pudo Eliminar Comentario");

                    return respuesta;
                }
                catch
                {
                    throw;

                }
            }
    }
}
