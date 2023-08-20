using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class MudarSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira a senha atual do usuário!")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Insira a nova senha do usuário!")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha do usuário!")]
        [Compare("NovaSenha", ErrorMessage ="As senhas não estão iguais!")] //Irá comparar com o NovaSenha, se for diferente apresenta erro
        public string ConfirmarNovaSenha { get; set; }
    }
}
