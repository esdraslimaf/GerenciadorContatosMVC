using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Insira o login!")]
        public string NomeLogin { get; set; }
        [Required(ErrorMessage = "Insira o e-mail!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }
    }
}
