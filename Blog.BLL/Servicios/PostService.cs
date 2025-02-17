using AutoMapper;
using Blog.BLL.Servicios.Interface;
using Blog.DAL.Repositorios.Interface;
using Blog.DTO;
using Blog.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.Servicios
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> _PostRepositorio;
        private readonly IMapper _mapper;

        public PostService(IGenericRepository<Post> postRepositorio, IMapper mapper)
        {
            _PostRepositorio = postRepositorio;
            _mapper = mapper;
        }
                
        public async Task<List<PostDTO>>Lista()
        {
            try
            {
                var queryPost = await _PostRepositorio.Consultar();

                var listaPost = queryPost.Include(cat => cat.IdCategoriaNavigation).ToList();

                return _mapper.Map<List<PostDTO>>(listaPost.ToList());

            }
            catch
            {
                throw;

            }
        }

        public async Task<PostDTO> Crear(PostDTO modelo)
        {
            try
            {
                var PostCreado = await _PostRepositorio.Crear(_mapper.Map<Post>(modelo));

                if (PostCreado.Id == 0)
                    throw new TaskCanceledException("No se pudo Crear el Post");

                return _mapper.Map<PostDTO>(PostCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PostDTO modelo)
        {
            try
            {
                var PostModelo = _mapper.Map<Post>(modelo);
                var PostEncontrado = await _PostRepositorio.Obtener(u =>
                u.Id == PostModelo.Id
                );

                if (PostEncontrado == null)
                    throw new TaskCanceledException("El Post no existe");

                PostEncontrado.Titulo = PostModelo.Titulo;
                PostEncontrado.Contenido = PostModelo.Contenido;
                PostEncontrado.IdCategoria = PostModelo.IdCategoria;

                bool respuesta = await _PostRepositorio.Editar(PostEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar Post");

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
                var postEncontrado = await _PostRepositorio.Obtener(p => p.Id == id);

                if (postEncontrado == null)
                    throw new TaskCanceledException("El Post no existe");


                bool respuesta = await _PostRepositorio.DeletePosts(postEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo Eliminar Post");

                return respuesta;
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}