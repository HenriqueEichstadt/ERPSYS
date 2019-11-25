using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Usuario : EntityModel, IUsuario
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        [MinLength(5)]
        [MaxLength(40)]
        public string Apelido { get; set; }

        [Required()]
        [MinLength(5)]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required()]
        [MinLength(5)]
        [MaxLength(30)]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }

        [Required]
        public char NivelAcesso { get; set; }
    }
}
