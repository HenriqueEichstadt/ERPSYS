using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class Endereco : IEndereco
    {
        public int Id { get; set; }
        public Pessoa PessoaId { get; set; }
        public Endereco EnderecoId { get; set; }

        [Required, MaxLength(100)]
        public string Rua { get; set; }

        [Required, MaxLength(7)]
        public string Numero { get; set; }

        [Required, MaxLength(50)]
        public string Bairro { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required, MaxLength(50)]
        public string Estado { get; set; }

        [Required, MaxLength(50)]
        public string Cidade { get; set; }

        [Required, MaxLength(9)]
        public string CEP { get; set; }
        public virtual DateTime DataInclusao { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
        public virtual Usuario UsuarioAlteracao { get; set; }

    }
}
