using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.ViewModels.Home;
using System.Collections.Generic;
using Blog.Models.Blog.Postagem.Revisão;
using System.Diagnostics;
using System.Linq;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            DataBase databaseContext = new DataBase();

            HomeIndexViewModel model = new HomeIndexViewModel();

            List<PostagemEntity> listaPostagens = databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .ToList();

            foreach (PostagemEntity postagem in listaPostagens)
            {
                PostagemHomeIndex postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                postagemHomeIndex.Descricao = postagem.Descricao;
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentarios.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.Id.ToString();

                // Obter última revisão
                RevisaoEntity ultimaRevisao = postagem.Revisoes.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimaRevisao != null)
                {
                    postagemHomeIndex.Data = ultimaRevisao.DataCriacao.ToLongDateString();
                }

                model.Postagens.Add(postagemHomeIndex);
            }


            List<CategoriaEntity> listaCategorias = databaseContext.Categorias.ToList();

            foreach (CategoriaEntity categoria in listaCategorias)
            {
                Categoria categoriaHomeIndex = new Categoria();
                categoriaHomeIndex.Nome = categoria.Nome;
                categoriaHomeIndex.CategoriaId = categoria.Id.ToString();

                model.Categorias.Add(categoriaHomeIndex);
            }


            List<EtiquetaEntity> listaEtiquetas = databaseContext.Etiquetas.ToList();

            foreach (EtiquetaEntity etiqueta in listaEtiquetas)
            {
                Etiqueta etiquetaHomeIndex = new Etiqueta();
                etiquetaHomeIndex.Nome = etiqueta.Nome;
                etiquetaHomeIndex.EtiquetaId = etiqueta.Id.ToString();

                model.Etiquetas.Add(etiquetaHomeIndex);
            }


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
