using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class Postagem
    {
        public string titulo { get; set; }
        public AutorEntity autor { get; set; }
        public CategoriaEntity categoria { get; set; }
    }
}
