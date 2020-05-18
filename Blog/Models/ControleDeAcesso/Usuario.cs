using Microsoft.AspNetCore.Identity;

namespace Blog.Models.ControleDeAcesso
{
    public class Usuario : IdentityUser<int>
    {
        public string Apelido { get; set; }
    }
}