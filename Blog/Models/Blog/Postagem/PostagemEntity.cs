using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem.Revisão;
using Blog.Models.PostagemEtiqueta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public virtual AutorEntity Autor { get; set; }
        public virtual CategoriaEntity Categoria { get; set; }
        public virtual ICollection<PostagemEtiquetaEntity> PostagemEtiquetas { get; set; }
        public virtual ICollection<RevisaoEntity> Revisoes { get; set; }



    }
}
