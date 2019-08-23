using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IUsuario
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Apelido { get; set; }
        string Email { get; set; }
        string Senha { get; set; }
        bool Ativo { get; set; }
        char NivelAcesso { get; set; }
        DateTime DataInclusao { get; set; }
        DateTime? DataAlteracao { get; set; }
        Usuario UsuarioInclusao { get; set; }
        Usuario UsuarioAlteracao { get; set; }
    }
}
