using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IVendaItens
    {
        int VendaId { get; set; }
        Venda Venda { get; set; }
        int ProdutoId { get; set; }
        Produto Produto { get; set; }
        double Unidades { get; set; }
        double PrecoTotalItem { get; set; }
    }
}
