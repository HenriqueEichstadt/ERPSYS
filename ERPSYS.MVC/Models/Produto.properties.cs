using ERPSYS.MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.DAO.Interfaces;

namespace ERPSYS.MVC.Models
{
    public partial class Produto : EntityModel<Produto>, IProduto
    {
        public string Nome { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Marca { get; set; }

        [Required] public char Categoria { get; set; }

        [Required] public double PrecoVenda { get; set; }

        [Required] public double PrecoCusto { get; set; }

        [MaxLength(200)] public string Descricao { get; set; }

        [Required] public double EstoqueAtual { get; set; }

        public double? LimiteEstoque { get; set; }

        [DataType(DataType.DateTime)] public DateTime? DataFabricacao { get; set; }

        [DataType(DataType.DateTime)] public DateTime? Validade { get; set; }

        public int? QtdPontosProgFidelidade { get; set; }

        public IList<VendaItens> VendaItens { get; set; }

        public bool Ativo { get; set; }

        public partial class FieldNames
        {
            public const string Id = "ID";
            public const string DataInclusao = "DATAINCLUSAO";
            public const string DataAlteracao = "DATAALTERACAO";
            public const string UsuarioInclusao = "USUARIOINCLUSAO";
            public const string UsuarioInclusaoId = "USUARIOINCLUSAOID";
            public const string UsuarioAlteracao = "USUARIOALTERACAO";
            public const string UsuarioAlteracaoId = "USUARIOALTERACAOID";
            public const string Nome = "NOME";
            public const string Marca = "MARCA";
            public const string Categoria = "CATEGORIA";
            public const string PrecoVenda = "PRECOVENDA";
            public const string PrecoCusto = "PRECOCUSTO";
            public const string Descricao = "DESCRICAO";
            public const string EstoqueAtual = "ESTOQUEATUAL";
            public const string LimiteEstoque = "LIMITEESTOQUE";
            public const string Validade = "VALIDADE";
            public const string QtdPontosProgFidelidade = "QTDPONTOSPROGFIDELIDADE";
            public const string VendaItens = "VENDAITENS";
            public const string Ativo = "ATIVO";
        }
    }
}