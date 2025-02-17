using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Repositorios.Interface
{
        public interface IGenericRepository<TModel> where TModel : class
        {
            Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
            Task<TModel> Crear(TModel modelo);
            Task<bool> Editar(TModel modelo);
            Task<bool> Delete(TModel modelo);
            Task<bool> DeletePosts(Post modelo);
            Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>>? filtro = null);

        }
    }


