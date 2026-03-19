namespace FCG.Application.Requests.Usuarios
{
    public sealed record AtualizarUsuarioRequest
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public DateTime DataNascimento { get; init; }
    }
}