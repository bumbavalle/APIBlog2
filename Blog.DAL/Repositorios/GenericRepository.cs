
using Blog.DAL.Repositorios.Interface;
using Blog.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Blog.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {

        private readonly BlogDbContext _dbContext;

        public GenericRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(filtro);

                return modelo;

            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }


        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo = filtro == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
                return queryModelo;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeletePosts(Post modelo)
        {
            _dbContext.Database.EnsureCreated();
  
            //SqlParameter IdPostParametro = new SqlParameter("@IdPost", System.Data.SqlDbType.Int );
            //IdPostParametro.Value = modelo.Id;
            var filasAfectadas = await _dbContext.Database.ExecuteSqlRawAsync($"EXEC ElminarPost @IdPost = {modelo.Id}");
            return filasAfectadas > 0;
        }
    
    } 



}


