using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Usuario UsuarioInclusao { get; set; }
        public Usuario UsuarioAlteracao { get; set; }
        [NotMapped] public PessoaFisica PessoaFisica { get; set; }
        [NotMapped] public PessoaJuridica PessoaJuridica { get; set; }
    }
}
