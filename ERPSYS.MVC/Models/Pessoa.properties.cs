using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Pessoa : EntityModel, IPessoa
    {
        [Required]
        public char TipoPessoa { get; set; }
        
        [MinLength(5), MaxLength(100)]
        public string Nome { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        
        public char? Genero { get; set; }

        [MaxLength(15)]
        public string RG { get; set; }

        [Required, MinLength(11), MaxLength(18)]
        public string CPFCNPJ { get; set; }

        [Required, MinLength(10), MaxLength(100), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(10), MaxLength(14)]
        public string TelefoneUm { get; set; }

        [MinLength(10), MaxLength(14)]
        public string TelefoneDois { get; set; }

        [MinLength(5), MaxLength(50)]
        public string NomeFantasia { get; set; }

        [MinLength(5), MaxLength(50)]
        public string NomeRazaoSocial { get; set; }

        [MinLength(5), MaxLength(50)]
        public string InscricaoEstadual { get; set; }

        [MaxLength(200)]
        public string Observacoes { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }
    }
}
