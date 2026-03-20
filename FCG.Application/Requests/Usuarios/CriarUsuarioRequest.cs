using System.ComponentModel.DataAnnotations;

namespace FCG.Application.Requests.Usuarios
{
    public sealed record CriarUsuarioRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; init; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [MaxLength(200, ErrorMessage = "Email deve ter no máximo 200 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres")]
        [MaxLength(255, ErrorMessage = "Senha deve ter no máximo 255 caracteres")]
        public string Senha { get; init; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public DateTime DataNascimento { get; init; }
    }
}