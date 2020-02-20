using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisão;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        public string titulo { get; set; }
        public AutorEntity autor { get; set; }
        public CategoriaEntity categoria { get; set; }

        public List<EtiquetaEntity> Etiquetas;
        public List<RevisaoEntity> Revisoes;
    }
}
