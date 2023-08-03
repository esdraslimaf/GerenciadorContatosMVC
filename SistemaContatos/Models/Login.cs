using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Insira o login!")]
        public string NomeLogin { get; set; }
        [Required(ErrorMessage = "Insira a senha!")]
        public string Senha { get; set; }
    }
}
