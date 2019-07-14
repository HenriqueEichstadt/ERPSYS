using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    interface IPessoaJuridica
    {
        int Id { get; set; }
        string NomeFantasia { get; set; }
        string NomeRazaoSocial { get; set; }
        string InscricaoEstadual { get; set; }        
        string CNPJ { get; set; }
        string Email { get; set; }
        string TelefoneUm { get; set; }
        string TelefoneDois { get; set; }
        string Observacoes { get; set; }
        DateTime DataInclusão { get; set; }
        DateTime DataAlteracao { get; set; }
        Usuario UsuarioInclusao { get; set; }
    }
}
