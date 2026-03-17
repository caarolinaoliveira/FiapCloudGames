using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCG.Domain.Enums;

namespace FCG.Domain.Entities
{
    public class UsuarioEntity : Entity
    {

        public string Nome { get; set; }
        public string Email { get;  set; }
        public string SenhaHash { get; set; }
        public UsuarioRoleEnum Role { get; set; }
        public DateTime DataNascimento { get; set; }
        public UsuarioStatusEnum StatusConta { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<BibliotecaUsuarioEntity> Biblioteca { get; set; } = new List<BibliotecaUsuarioEntity>();
    }

}