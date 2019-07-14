using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class PessoaJuridica : IPessoaJuridica
    {
        public int Id { get; set; }

        [MinLength(5), MaxLength(50)]
        public string NomeFantasia { get; set; }

        [MinLength(5), MaxLength(50)]
        public string NomeRazaoSocial { get; set; }

        [MinLength(5), MaxLength(50)]
        public string InscricaoEstadual { get; set; }
        [MinLength(18), MaxLength(18)]
        public string CNPJ { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        [MinLength(13), MaxLength(14)]
        public string TelefoneUm { get; set; }

        [MinLength(13), MaxLength(14)]
        public string TelefoneDois { get; set; }
        [MaxLength(200)]
        public string Observacoes { get; set; }
        public virtual DateTime DataInclusão { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
    }
}
