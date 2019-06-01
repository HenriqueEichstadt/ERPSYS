using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NomeUsuario { get; set; }
    }
}
