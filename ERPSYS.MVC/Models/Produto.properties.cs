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
        [Required, MinLength(3), MaxLength(30)]
        public string Nome { get; set; }
        
        [Required, MinLength(3), MaxLength(30)]
        public string Marca { get; set; }
        
        [Required]
        public char Categoria { get; set; }
        
        [Required]
        public double PrecoVenda { get; set; }
        
        [Required]
        public double PrecoCusto { get; set; }
        
        [MaxLength(200)]
        public string Descricao { get; set; }
        
        [Required]
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
