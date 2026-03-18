
namespace  FCG.Domain.Entities
{
    public class BibliotecaUsuarioEntity : Entity
    {
        public Guid UsuarioId { get; set; }
        public Guid JogoId { get; set; }
        public DateTime DataAquisicao { get; set; }
        public decimal PrecoPago { get; set; }
        public UsuarioEntity Usuario { get; set; }
        public JogoEntity Jogo { get; set; }
    }
    
}