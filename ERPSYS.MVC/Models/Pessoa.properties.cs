using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Pessoa : EntityModel, IPessoa
    {
        [Required(ErrorMessage = "O Tipo de Pessoa é obrigatório")]
        public char TipoPessoa { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório")]
        public char? Genero { get; set; }

        [MaxLength(15, ErrorMessage = "O RG deve ter no máximo 15 caracteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF/CNPJ deve ter no mínimo 11 caracteres")]
        [MaxLength(18, ErrorMessage = "O CPF/CNPJ deve ter no máximo 18 caracteres")]
        public string CPFCNPJ { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracteres")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório")]
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

        [Required(ErrorMessage = "O campo Ativo é obrigatório")]
        public bool Ativo { get; set; }
    }
}
