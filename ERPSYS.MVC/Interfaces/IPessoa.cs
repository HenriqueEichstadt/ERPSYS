using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IPessoa
    {
        char TipoPessoa { get; set; }
        string Nome { get; set; }
        DateTime? DataNascimento { get; set; }
        char? Genero { get; set; }
        string RG { get; set; }
        string CPFCNPJ { get; set; }
        string Email { get; set; }
        string TelefoneUm { get; set; }
        string TelefoneDois { get; set; }
        string NomeFantasia { get; set; }
        string NomeRazaoSocial { get; set; }
        string InscricaoEstadual { get; set; }
        string Observacoes { get; set; }
        bool Ativo { get; set; }
        Endereco Endereco { get; set; }
        int Id { get; set; }
        DateTime DataInclusao { get; set; }
        DateTime? DataAlteracao { get; set; }
        Usuario UsuarioInclusao { get; set; }
        Usuario UsuarioAlteracao { get; set; }
    }
}
