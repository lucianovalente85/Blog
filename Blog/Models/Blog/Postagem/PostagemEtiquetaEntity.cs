using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.PostagemEtiqueta
{
    public class PostagemEtiquetaEntity
    {
        [Key]
        public int Id { get; set; }

        public PostagemEntity Postagem { get; set; }

        public EtiquetaEntity Etiqueta { get; set; }
    }
}
