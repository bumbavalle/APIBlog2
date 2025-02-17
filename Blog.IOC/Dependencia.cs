
using Blog.DAL.Repositorios.Interface;
using Blog.DAL.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Utility;
using Blog.BLL.Servicios.Interface;
using Blog.BLL.Servicios;
using Blog.DAL;


namespace Blog.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BlogDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddAutoMapper(typeof(AutoMapperProfile));

            service.AddScoped<IPostService, PostService>();
            service.AddScoped<IComentarioService, ComentarioService>();
            service.AddScoped<ICategoriaService, CategoriaService>();
        }
    }
}
