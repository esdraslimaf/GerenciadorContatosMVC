﻿using SistemaContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaContatos.Models
{
    public class UsuarioSemSenhaEdicao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o nome do usuário!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Insira o e-mail do usuário!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Escolha o tipo do usuário!")]
        public PerfilEnum? Perfil { get; set; }

    }
}
