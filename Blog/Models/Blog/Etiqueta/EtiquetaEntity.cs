using Blog.Models.PostagemEtiqueta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{
    public class EtiquetaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<PostagemEtiquetaEntity> PostagemEtiquetas { get; set; }
    }
}
