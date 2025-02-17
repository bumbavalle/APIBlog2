using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.DTO;
using Blog.Model;

namespace Blog.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Post
            CreateMap<Post,PostDTO>().ReverseMap();
            #endregion Post

            #region Comentario
            CreateMap<Comentario,ComentarioDTO>().ReverseMap();
            #endregion Comentario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

        }


    }
}
