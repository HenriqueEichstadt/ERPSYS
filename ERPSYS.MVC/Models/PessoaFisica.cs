using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class PessoaFisica
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public char? Genero { get; set; }

        [MaxLength(15)]
        public string RG { get; set; }

        [Required, MinLength(14), MaxLength(14)]
        public string CPF { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MinLength(13), MaxLength(14)]
        public string TelefoneUm { get; set; }

        [MinLength(13), MaxLength(14)]
        public string TelefoneDois { get; set; }
        public Endereco Endereco { get; set; }
        public virtual DateTime DataInclusão { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }

        // Construtores
        //Pede para adicionar o nome do cliente
        public PessoaFisica(string nome)
        {
            this.Nome = nome;
        }
        public PessoaFisica() { }

        public int RetornarIdadePessoa(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
    }
}
