using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.PostagemEtiqueta
{
    public class PostagemEtiquetaEntity
    {
        public int EtiquetaId { get; set; }
        public int PostagemId { get; set; }
        public virtual PostagemEntity Postagem { get; set; }
        public virtual EtiquetaEntity Etiqueta { get; set; }
    }
}
