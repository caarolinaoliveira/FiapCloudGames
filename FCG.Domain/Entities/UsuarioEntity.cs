using FCG.Domain.Enums;

namespace FCG.Domain.Entities
{
    public class UsuarioEntity : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataNascimento { get; set; }
        // public UsuarioRoleEnum Role { get; set; }
        // public UsuarioStatusEnum StatusConta { get; set; }

        //vamos setar os valores padrão para Role e StatusConta, para evitar que sejam nulos e depois implementamos 
        public UsuarioRoleEnum Role { get; set; } = UsuarioRoleEnum.Usuario;
        public UsuarioStatusEnum StatusConta { get; set; } = UsuarioStatusEnum.Ativo;
        public DateTime DataCriacao { get; set; }
        public ICollection<BibliotecaUsuarioEntity> Biblioteca { get; set; }

        public UsuarioEntity()
        {
            Biblioteca = new List<BibliotecaUsuarioEntity>();
        }
    }
}