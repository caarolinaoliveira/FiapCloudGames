using System.ComponentModel.DataAnnotations;

namespace FCG.Application.Requests.Usuarios
{
    public sealed record CriarUsuarioRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; init; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; init; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; init; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; init; }
    }

}