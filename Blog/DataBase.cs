﻿using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Classificacao;
using Blog.Models.Blog.Postagem.Comentario;
using Blog.Models.Blog.Postagem.Revisao;
using Microsoft.EntityFrameworkCore;
using Blog.Models.ControleDeAcesso;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog
{
    public class DataBase : IdentityDbContext<Usuario, Papel, int>
    {
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<AutorEntity> Autores { get; set; }
        public DbSet<EtiquetaEntity> Etiquetas { get; set; }
        public DbSet<PostagemEntity> Postagens { get; set; }
        public DbSet<RevisaoEntity> Revisoes { get; set; }
        public DbSet<ComentarioEntity> Comentarios { get; set; }
        public DbSet<ClassificacaoEntity> Classificacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=localhost;database=blog;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapear relacionamentos entre as entidades
            // N:N (Postagens -> Etiquetas [PostagemEtiquetaEntity])
            modelBuilder.Entity<PostagemEtiquetaEntity>().ToTable("PostagensEtiquetas");

            modelBuilder.Entity<PostagemEtiquetaEntity>()
                .HasOne(pe => pe.Postagem)
                .WithMany(p => p.PostagensEtiquetas);

            modelBuilder.Entity<PostagemEtiquetaEntity>()
               .HasOne(pe => pe.Etiqueta)
               .WithMany(e => e.PostagensEtiquetas);


        }
    }
}
