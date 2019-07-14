using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPSYS.MVC.Models
{
    public class PessoaFisica : IPessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char? Genero { get; set; }
        [MaxLength(15)]
        public string RG { get; set; }
        [MinLength(14), MaxLength(18)]
        public string CPF { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MinLength(13), MaxLength(14)]
        public string TelefoneUm { get; set; }
        [MinLength(13), MaxLength(14)]
        public string TelefoneDois { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public Usuario UsuarioInclusao { get; set; }
        public Usuario UsuarioAlteracao { get; set; }

        public PessoaFisica(string nome)
        {
            this.Nome = nome;
        }

        public PessoaFisica() { }

        public int GetIdade(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
    }
}