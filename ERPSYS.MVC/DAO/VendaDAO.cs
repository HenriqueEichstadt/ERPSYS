using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Models;
using Ninject;

namespace ERPSYS.MVC.DAO
{
    public class VendaDAO : BaseDAO<Venda>, IVendaDAO
    {
        [Inject] public IProdutoDAO ProdutoDao { get; set; }
        [Inject] public IClienteDAO ClienteDao { get; set; }

        public VendaDAO(ApplicationContext contexto) : base(contexto)
        {
        }

        public void Add(Venda venda)
        {
            DbSet.Add(venda);
            Context.SaveChanges();
        }

        public void Update(Venda venda)
        {
            DbSet.Update(venda);
            Context.SaveChanges();
        }

        public void Delete(Venda venda)
        {
            DbSet.Remove(venda);
            Context.SaveChanges();
        }

        public Venda GetById(int id)
        {
            return DbSet.FirstOrDefault(a => a.Id == id);
        }

        public IList<Venda> ListAll()
        {
            return DbSet.ToList();
        }

        public void TrocaPorPontos(int clienteId, int pontos)
        {
            var cliente = ClienteDao.GetById(clienteId);
            cliente.Pontos -= pontos;
            Context.SaveChanges();
        }

        public void AdicionaVenda(Venda venda)
        {
            DbSet.Add(venda);
            Context.SaveChanges();
        }

        public void SomaPontos(int clienteId, int pontos)
        {
            var cliente = ClienteDao.GetById(clienteId);
            cliente.Pontos += pontos;
            Context.SaveChanges();
        }

        public void GravarVenda(Venda venda)
        {
            try
            {
                BeginTransaction();
                AdicionaVenda(venda);
                DecrementaDoEstoque(venda.VendaItens);
                CommitTransaction();
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void DecrementaDoEstoque(IList<VendaItens> vendaItens)
        {
            foreach (var item in vendaItens)
            {
                DecrementaProdutoDoEstoque(item.ProdutoId, item.Unidades);
            }
        }

        private void DecrementaProdutoDoEstoque(int id, double quantidade)
        {
            var produto = ProdutoDao.GetById(id);
            produto.EstoqueAtual -= quantidade;
            Context.SaveChanges();
        }
    }
}