using System;
using System.Collections.Generic;

namespace Blog.Model;

public partial class Comentario
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public virtual Post Post { get; set; } = null!;
}
