using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.Interfaces
{
    public interface IProduto
    {
        string Nome { get; set; }
        string Marca { get; set; }
        char Categoria { get; set; }
        double PrecoVenda { get; set; }
        double PrecoCusto { get; set; }
        string Descricao { get; set; }
        double EstoqueAtual { get; set; }
        double? LimiteEstoque { get; set; }
        DateTime? DataFabricacao { get; set; }
        DateTime? Validade { get; set; }
        int? QtdPontosProgFidelidade { get; set; }
        IList<VendaItens> VendaItens { get; set; }
        bool Ativo { get; set; }
    }
}
