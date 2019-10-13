using System.Collections.Generic;
using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.DAO
{
    public interface IVendaDAO
    {
        void Add(Venda venda);
        void Update(Venda venda);
        void Delete(Venda venda);
        Venda GetById(int id);
        IList<Venda> ListAll();
        void TrocaPorPontos(int clienteId, int pontos);
        void AdicionaVenda(Venda venda);
        void DecrementaDoEstoque(IList<VendaItens> vendaItens);
        void SomaPontos(int clienteId, int pontos);
        void GravarVenda(Venda venda);
    }
}