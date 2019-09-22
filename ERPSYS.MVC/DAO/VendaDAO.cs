using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.DAO
{
    public class VendaDAO : IVendaDAO
    {
        public void Add(Venda venda)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.VENDAS.Add(venda);
                dbSet.SaveChanges();
            }
        }

        public void Update(Venda venda)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.VENDAS.Update(venda);
                dbSet.SaveChanges();
            }
        }

        public void Delete(Venda venda)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.VENDAS.Remove(venda);
                dbSet.SaveChanges();
            }
        }

        public Venda GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.VENDAS.FirstOrDefault(a => a.Id == id);
            }
        }

        public IList<Venda> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.VENDAS.ToList();
            }
        }

        public void TrocaPorPontos(int? clienteId, int pontos)
        {
            if (clienteId == null) return;
            
            using (var dbSet = new ApplicationContext())
            {
                var cliente = dbSet.CLIENTES.Find(clienteId);
                cliente.Pontos -= pontos;
                dbSet.SaveChanges();
            }
        }

        public void AdicionaVenda(Venda venda)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.VENDAS.Add(venda);
                dbSet.SaveChanges();
            }
        }
        
        public void SomaPontos(int clienteId, int pontos)
        {
            using (var dbSet = new ApplicationContext())
            {
                var cliente = dbSet.CLIENTES.Find(clienteId);
                cliente.Pontos += pontos;
                dbSet.SaveChanges();
            }
        }

        public void DecrementaDoEstoque(List<VendaItens> vendaItens)
        {
            foreach (var item in vendaItens)
            {
                DecrementaProdutoDoEstoque(item.ProdutoId, item.Unidades);
            }
        }

        private void DecrementaProdutoDoEstoque(int id, double quantidade)
        {
            using (var dbSet = new ApplicationContext())
            {
                var produto = dbSet.PRODUTOS.Find(id);
                produto.EstoqueAtual -= quantidade;
                dbSet.SaveChanges();
            }
        }
    }
}