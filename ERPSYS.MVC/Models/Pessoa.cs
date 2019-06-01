using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERPSYS.MVC.Models
{
    public class Pessoa : IPessoa
    {

        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual char? Genero { get; set; }
        [MaxLength(15)]
        public virtual string RG { get; set; }
        [Required, MinLength(14), MaxLength(18)]
        public virtual string CPF { get; set; }
        [Required, MaxLength(50)]
        public virtual string Email { get; set; }
        [Required, MinLength(13), MaxLength(14)]
        public virtual string TelefoneUm { get; set; }
        [MinLength(13), MaxLength(14)]
        public virtual string TelefoneDois { get; set; }
        public virtual DateTime DataInclusao { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }
       
        public Pessoa(string nome)
        {
            this.Nome = nome;
        }
        
        public Pessoa() { }

        public int GetIdadePessoa(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
    }
}