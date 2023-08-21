using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do contato!")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Insira o e-mail do contato!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Insira o telefone/celular do contato!")]
        [Phone(ErrorMessage = "O telefone/celular informado é inválido!")]
        public string Telefone { get; set; }

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
