using System;
using System.Collections.Generic;

namespace Blog.Model;

public partial class Post
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; } = new List<Comentario>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
