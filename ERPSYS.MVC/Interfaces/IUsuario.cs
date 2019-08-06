using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IUsuario
    {
        string Nome { get; set; }
        string Apelido { get; set; }
        string Email { get; set; }
        string Senha { get; set; }
    }
}
