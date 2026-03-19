namespace FCG.Application.Requests.Usuarios
{
    public sealed record CriarUsuarioRequest
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Senha { get; init; }
        public DateTime DataNascimento { get; init; }
    }
}