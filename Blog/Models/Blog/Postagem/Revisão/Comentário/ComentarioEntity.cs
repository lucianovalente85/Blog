using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisão.Comentário
{
    public class ComentarioEntity
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime Data { get; set; }
        public int RevisaoId { get; set; }
        public virtual RevisaoEntity Revisao { get; set; }
    }
}
