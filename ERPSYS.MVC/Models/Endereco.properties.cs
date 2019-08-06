using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Endereco : EntityModel, IEndereco
    {
        [Required(ErrorMessage = "A Pessoa é obrigatória")]
        public Pessoa Pessoa { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [MaxLength(9, ErrorMessage = "O CEP deve ter no máximo 9 caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Estado deve ter no máximo 50 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória")]
        [MaxLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Bairro deve ter no máximo 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Rua é obrigatória")]
        [MaxLength(100, ErrorMessage = "A Rua deve ter no máximo 100 caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        [MaxLength(7, ErrorMessage = "O Número deve ter no máximo 7 caracteres")]
        public string Numero { get; set; }

        [MaxLength(50, ErrorMessage = "O Complemento deve ter no máximo 50 caracteres")]
        public string Complemento { get; set; }
    }
}