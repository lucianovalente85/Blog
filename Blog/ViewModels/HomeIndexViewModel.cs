using System.Collections.Generic;

namespace Blog.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public ICollection<PostagemHomeIndex> Postagens { get; set; }

        public ICollection<Categoria> Categorias { get; set; }

        public ICollection<Etiqueta> Etiquetas { get; set; }

        public ICollection<PostagemPopular> PostagensPopulares { get; set; }


        public HomeIndexViewModel()
        {
            Postagens = new List<PostagemHomeIndex>();
            Categorias = new List<Categoria>();
            Etiquetas = new List<Etiqueta>();
            PostagensPopulares = new List<PostagemPopular>();
        }
    }

    public class PostagemHomeIndex
    {
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string NumeroComentarios { get; set; }
        public string PostagemId { get; set; }
    }

    public class Categoria
    {
        public string Nome { get; set; }
        public string CategoriaId { get; set; }
    }

    public class Etiqueta
    {
        public string Nome { get; set; }
        public string EtiquetaId { get; set; }
    }

    public class PostagemPopular
    {
        public string Titulo { get; set; }
        public string PostagemId { get; set; }
    }
}