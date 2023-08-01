using SistemaContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Insira o e-mail do usuário!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
