using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IClientes
    {
        Pessoa Pessoa { get; set; }
        int? Pontos { get; set; }
        bool Ativo { get; set; }
    }
}
