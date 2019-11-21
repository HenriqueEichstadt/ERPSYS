using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Usuario : EntityModel<Usuario>, IUsuario
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "O Apelido deve ter no mínimo 5 caracteres")]
        [MaxLength(40, ErrorMessage = "O Apelido deve ter no máximo 40 caracteres")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "O Email deve ter no mínimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha com um email válido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "A Senha deve ter no mínimo 5 caracteres")]
        [MaxLength(30, ErrorMessage = "A Senha deve ter no máximo 30 caracteres")]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public char NivelAcesso { get; set; }
    }
}
