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
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "O Nome deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Marca é obrigatória")]
        [MinLength(3, ErrorMessage = "A Marca deve ter no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "A Marca deve ter no máximo 30 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "A Categoria é obrigatória")]
        [MinLength(3, ErrorMessage = "A Categoria deve ter no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "A Categoria deve ter no máximo 30 caracteres")]
        public char Categoria { get; set; }

        [Required(ErrorMessage = "O Preço de Venda é obrigatório")]
        public double PrecoVenda { get; set; }

        [Required(ErrorMessage = "O Preço de Custo é obrigatório")]
        public double PrecoCusto { get; set; }

        [MaxLength(200, ErrorMessage = "A Descrição deve ter no máximo 200 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Estoque Atual é obrigatório")]
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
