using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class VendaItens : EntityModel, IVendaItens
    {
        public int VendaId { get; set; }

        [Column("VENDA")]
        public Venda Venda { get; set; }

        [Column("PRODUTO")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double Unidades { get; set; }
        public double PrecoTotalItem { get; set; }
    }
}
