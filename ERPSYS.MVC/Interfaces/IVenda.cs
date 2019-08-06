using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IVenda
    {
        double TotalUnidades { get; set; }
        DateTime Data { get; set; }
        double PrecoTotal { get; set; }
        Cliente Cliente { get; set; }
        int ClienteId { get; set; }
        IList<VendaItens> VendaItens { get; set; }
        int FormaPagamento { get; set; }
    }
}
