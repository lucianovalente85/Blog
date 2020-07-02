using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.ControleDeAcesso;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PWABlog.Models.Blog.Postagem;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionar o mecanismo de controle de acesso (Identity)
            services.AddIdentity<Usuario, Papel>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<DatabaseContext>()
                .AddErrorDescriber<DescritorDeErros>();

            // Configurar o mecanismo de controle de acesso
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/acesso/login";
            });

            // Adicionar o servi�o do controle de acesso
            services.AddTransient<ControleDeAcessoService>();

            // Adicionar o servi�o do banco de dados
            services.AddDbContext<DatabaseContext>();

            // Adicionar os servi�os de ORM das entidades do dom�nio
            services.AddTransient<AutorOrmService>();
            services.AddTransient<CategoriaOrmService>();
            services.AddTransient<EtiquetaOrmService>();
            services.AddTransient<PostagemOrmService>();
            services.AddTransient<ClassificacaoOrmService>();
            services.AddTransient<ComentarioOrmService>();
            services.AddTransient<RevisaoOrmService>();

            // Adicionar os servi�os que possibilitam o funcionamento dos controllers e das views
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            // Configura��o de Rotas
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Rotas da �rea Comum
                endpoints.MapControllerRoute(
                    name: "comum",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index" }
                );

                // Rotas do Controle de Acesso
                endpoints.MapControllerRoute(
                    name: "controleDeAcesso",
                    pattern: "acesso/{action}",
                    defaults: new { controller = "ControleDeAcesso", action = "Login" }
                );

                // Rotas da �rea Administrativa
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "admin",
                    defaults: new { controller = "Admin", action = "Painel" }
                );
                endpoints.MapControllerRoute(
                    name: "admin.categorias",
                    pattern: "admin/categorias/{action}/{id?}",
                    defaults: new { controller = "AdminCategorias", action = "Listar" }
                );
                endpoints.MapControllerRoute(
                    name: "admin.etiquetas",
                    pattern: "admin/etiquetas/{action}/{id?}",
                    defaults: new { controller = "AdminEtiquetas", action = "Listar" }
                );
                endpoints.MapControllerRoute(
                    name: "admin.postagens",
                    pattern: "admin/postagens/{action}/{id?}",
                    defaults: new { controller = "AdminPostagens", action = "Listar" }
                );
            });
        }
    }
}
