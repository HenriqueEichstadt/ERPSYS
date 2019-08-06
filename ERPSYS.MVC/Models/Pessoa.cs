using ERPSYS.MVC.IOC;
using System;

namespace ERPSYS.MVC.Models
{
    public partial class Pessoa
    {
        public int GetIdade(DateTime dataNascimento)
        {
            TimeSpan ts = DateTime.Today - dataNascimento;
            DateTime idade = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            return idade.Year;
        }
    }
}