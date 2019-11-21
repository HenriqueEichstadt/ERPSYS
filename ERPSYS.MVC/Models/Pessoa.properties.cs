using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Pessoa : EntityModel<Pessoa>, IPessoa
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public char TipoPessoa { get; set; }
        
        [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        
        public char? Genero { get; set; }

        [MaxLength(15, ErrorMessage = "O RG deve ter no máximo 15 caracteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(11, ErrorMessage = "O campo ter no mínimo 11 caracteres")]
        [MaxLength(18, ErrorMessage = "O campo deve ter no máximo 18 caracteres")]
        public string CPFCNPJ { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracteres")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(10, ErrorMessage = "O Telefone deve ter no mínimo 10 caracteres")]
        [MaxLength(14, ErrorMessage = "O Telefone deve ter no máximo 14 caracteres")]
        public string TelefoneUm { get; set; }

        [MinLength(10, ErrorMessage = "O Telefone deve ter no mínimo 10 caracteres")]
        [MaxLength(14, ErrorMessage = "O Telefone deve ter no máximo 14 caracteres")]
        public string TelefoneDois { get; set; }

        [MinLength(5, ErrorMessage = "O Nome Fantasia deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome Fantasia deve ter no máximo 50 caracteres")]
        public string NomeFantasia { get; set; }

        [MinLength(5, ErrorMessage = "O Nome da Razão social deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome da Razão social deve ter no máximo 50 caracteres")]
        public string NomeRazaoSocial { get; set; }

        [MinLength(5, ErrorMessage = "A Inscrição estadual deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "A Inscrição estadual deve ter no máximo 50 caracteres")]
        public string InscricaoEstadual { get; set; }


        [MaxLength(200, ErrorMessage = "As observações devem ter no máximo 200 caractetes")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }
    }
}
