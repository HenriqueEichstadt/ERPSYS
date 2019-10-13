using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Venda : EntityModel, IVenda
    {
        public double TotalUnidades { get; set; }
        public DateTime Data { get; set; }
        public double PrecoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }
        public List<VendaItens> VendaItens { get; set; }
        public int FormaPagamento { get; set; }

        public Venda()
        {
            VendaItens = new List<VendaItens>();
        }
    }
}
