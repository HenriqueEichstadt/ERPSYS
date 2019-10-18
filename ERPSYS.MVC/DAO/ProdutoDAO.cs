using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSYS.MVC.DAO
{
    public class ProdutoDAO : IProdutoDAO
    {
         public void Add(Produto produto)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.PRODUTOS.Add(produto);
                dbSet.SaveChanges();
            }
        }

        public void Update(Produto produto)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.PRODUTOS.Update(produto);
                dbSet.SaveChanges();
            }
        }

        public void Delete(Produto produto)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.PRODUTOS.Remove(produto);
                dbSet.SaveChanges();
            }
        }

        public Produto GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PRODUTOS
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public IList<Produto> ListActives()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PRODUTOS
                    .Where(a => a.Ativo)
                    .ToList();
            }
        }

        public IList<Produto> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PRODUTOS
                    .ToList();
            }
        }

        public void Inativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var produto = GetById(id);
                produto.Ativo = false;
                dbSet.PRODUTOS.Update(produto);
                dbSet.SaveChanges();
            }
        }

        public void Ativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var produto = GetById(id);
                produto.Ativo = true;
                dbSet.PRODUTOS.Update(produto);
                dbSet.SaveChanges();
            }
        }

        public void DecrementaEstoque(int produtoId, double quantidade)
        {
            using (var dbSet = new ApplicationContext())
            {
                var produto = GetById(produtoId);
                produto.EstoqueAtual -= quantidade;
                dbSet.PRODUTOS.Update(produto);
                dbSet.SaveChanges();
            }
        }

        public List<Produto> ListarAtivosComEstoqueDisponivel()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PRODUTOS.Where(e => e.EstoqueAtual > 0 && e.Ativo).ToList();
            }
        }
    }
}