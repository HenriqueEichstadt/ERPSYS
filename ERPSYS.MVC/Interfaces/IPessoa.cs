using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IPessoa
    {
        int Id { get; }
        string Nome { get; set; }
        DateTime DataNascimento { get; set; }
        char? Genero { get; set; }
        string RG { get; set; }
        string CPF { get; set; }
        string Email { get; set; }
        string TelefoneUm { get; set; }
        string TelefoneDois { get; set; }
        DateTime DataInclusao { get; set; }
        DateTime DataAlteracao { get; set; }
        Usuario UsuarioInclusao { get; set; }
        Usuario UsuarioAlteracao { get; set; }
        int GetIdade(DateTime dataNascimento);
    }
}
