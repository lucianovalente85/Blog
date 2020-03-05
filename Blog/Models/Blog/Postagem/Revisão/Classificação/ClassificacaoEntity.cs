using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisão.Classificação
{
    public class ClassificacaoEntity
    {
        public int Id { get; set; }
        public int RevisaoId { get; set; }
        public virtual RevisaoEntity Revisao { get; set; }
        public bool Classificacao { get; set; }

       
    }
}
