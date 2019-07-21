using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.IOC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPSYS.MVC.Models
{
    public class Pessoa : EntityModel, IPessoa
    {
        public Pessoa() { }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char? Genero { get; set; }
        [MaxLength(15)]
        public string RG { get; set; }
        [Required, MinLength(14), MaxLength(18)]
        public string CPF { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, MinLength(13), MaxLength(14)]
        public string TelefoneUm { get; set; }
        [MinLength(13), MaxLength(14)]
        public string TelefoneDois { get; set; }
       
        public Pessoa(string nome)
        {
            this.Nome = nome;
        }

        public int GetIdade(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
    }
}