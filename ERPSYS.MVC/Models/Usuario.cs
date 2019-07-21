using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class Usuario : EntityModel
    {
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [NotMapped] public Pessoa PessoaFisica { get; set; }
        [NotMapped] public PessoaJuridica PessoaJuridica { get; set; }
    }
}
