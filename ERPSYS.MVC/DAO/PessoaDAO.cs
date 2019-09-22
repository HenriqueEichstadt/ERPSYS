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
        [Inject] public IUsuarioDAO UsuarioDao { get; set; }
        public void Add(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                //pessoa.Ativo = true;
                //pessoa.DataInclusao = DateTime.Now;
                //pessoa.UsuarioInclusao = UsuarioDAO.GetById(1) as Usuario;
                dbSet.Add(pessoa);
                //dbSet.Add(pessoa.Endereco);
                dbSet.SaveChanges();
            }
        }

        public void Update(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Update(pessoa);
                dbSet.Update(pessoa.Endereco);
                dbSet.SaveChanges();
            }
        }

        public void Ativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var pessoa = GetById(id);
                pessoa.Ativo = true;
                dbSet.PESSOAS.Update(pessoa);
                dbSet.SaveChanges();
            }
        }

        public void Inativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var pessoa = GetById(id);
                pessoa.Ativo = false;
                dbSet.PESSOAS.Update(pessoa);
                dbSet.SaveChanges();
            }
        }

        public Pessoa GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var pessoa = dbSet.PESSOAS.Include(e => e.Endereco).SingleOrDefault(p => p.Id == id);
                return pessoa;
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
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PESSOAS.Where(c => c.CPFCNPJ == cpfOrCnpj).FirstOrDefault();
            }
        }

        public IList<Pessoa> ListFornecedores()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.PESSOAS.Where(f => f.TipoPessoa == 'J').ToList();
            }
        }
    }
}
