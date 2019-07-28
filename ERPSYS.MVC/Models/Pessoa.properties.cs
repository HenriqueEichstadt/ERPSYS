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
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 catacteres")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 catacteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório")]
        public char? Genero { get; set; }

        [MaxLength(15, ErrorMessage = "O RG deve ter no máximo 15 catacteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve ter no mínimo 11 catacteres")]
        [MaxLength(14, ErrorMessage = "O CPF deve ter no máximo 14 catacteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 catacteres")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 catacteres")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [MinLength(10, ErrorMessage = "O Telefone deve ter no mínimo 10 catacteres")]
        [MaxLength(14, ErrorMessage = "O Telefone deve ter no máximo 14 catacteres")]
        public string TelefoneUm { get; set; }

        [MinLength(10, ErrorMessage = "O Telefone deve ter no mínimo 10 catacteres")]
        [MaxLength(14, ErrorMessage = "O Telefone deve ter no máximo 14 catacteres")]
        public string TelefoneDois { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
