using Blog.DTO;


namespace Blog.BLL.Servicios.Interface
{
    public interface IPostService
    {
        Task<List<PostDTO>>Lista();
        Task<PostDTO> Crear(PostDTO modelo);
        Task<bool> Editar(PostDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
