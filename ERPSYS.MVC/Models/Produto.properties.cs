using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Models
{
    public partial class Produto : EntityModel, IProduto
    {
        public string Nome { get; set; }
        
        public string Marca { get; set; }
        
        public char Categoria { get; set; }
        
        public double PrecoVenda { get; set; }
        
        public double PrecoCusto { get; set; }
        
        public string Descricao { get; set; }
        
        public double EstoqueAtual { get; set; }

        public double? LimiteEstoque { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataFabricacao { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Validade { get; set; }

        public int? QtdPontosProgFidelidade { get; set; }

        public IList<VendaItens> VendaItens { get; set; }

        public bool Ativo { get; set; }
    }
}
