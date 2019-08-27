using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IEndereco
    {
        string CEP { get; set; }
        string Estado { get; set; }
        string Cidade { get; set; }
        string Bairro { get; set; }
        string Rua { get; set; }
        string Numero { get; set; }
        string Complemento { get; set; }
    }
}
