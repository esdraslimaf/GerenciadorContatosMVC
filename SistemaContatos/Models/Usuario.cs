using SistemaContatos.Enums;
using SistemaContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o login do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Insira o e-mail do usuário!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Escolha o tipo do usuário!")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Insira a senha do usuário!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public List<Contato>? Contatos { get; set; }

        public bool ValidaSenha(string senha)
        {
            return this.Senha == senha.GerarHash();
        }

        public void SetSenhaCriptografada()
        {
            this.Senha = this.Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            this.Senha = novaSenha.GerarHash();
            return novaSenha;
        }

        public void SetSenhaNova(string novaSenha)
        {
            this.Senha = novaSenha.GerarHash();
        }
    }
}
