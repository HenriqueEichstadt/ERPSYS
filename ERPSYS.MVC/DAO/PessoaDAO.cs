using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO
{
    public class PessoaDAO : IPessoaDAO
    {
        public void Add(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Add(pessoa);
                dbSet.SaveChanges();
            }
        }

        public void Update(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Update(pessoa);
                dbSet.SaveChanges();
            }
        }

        public void Delete(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Remove(pessoa);
                dbSet.SaveChanges();
            }
        }

        public IPessoa GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PESSOAS.Where(p => p.Id == id).SingleOrDefault();
            }
        }

        public IList<Pessoa> ListActives()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PESSOAS.Where(c => c.Ativo == true).ToList();
            }
        }

        public IList<Pessoa> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PESSOAS.ToList();
            }
        }

        public IPessoa GeyByCPFOrCNPJ(string cpfOrCnpj)
        {
            using (var contexto = new ApplicationContext())
            {
                return contexto.PESSOAS.Where(c => c.CPF == cpfOrCnpj).FirstOrDefault();
            }
        }
    }
}
