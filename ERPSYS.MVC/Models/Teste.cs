using ERPSYS.MVC.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public class Teste
    {
        [Inject]
        public IPessoa Pessoa { get; set; }


        public string RetornaTexto()
        {
            Pessoa.Nome = "HENRIQUE";
            return Pessoa.Nome;
        }
    }
}
