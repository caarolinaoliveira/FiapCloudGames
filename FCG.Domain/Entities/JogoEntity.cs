using System; 
using FCG.Domain.Enums; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FCG.Domain.Entities
{
    public class JogoEntity : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public JogoGeneroEnum Genero { get; set; }
        public decimal Preco { get; set; }
        public decimal? PrecoDesconto { get; set; }
        public DateTime DataLancamento { get; set; }
        public JogoStatusEnum StatusJogo { get; set; }
    
    }
    
}