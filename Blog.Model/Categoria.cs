using System;
using System.Collections.Generic;

namespace Blog.Model;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
