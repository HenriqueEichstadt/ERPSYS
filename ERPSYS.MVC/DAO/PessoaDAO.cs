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
        [Inject] public IUsuarioDAO UsuarioDAO { get; set; }
        public void Add(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                pessoa.Ativo = true;
                pessoa.DataInclusao = DateTime.Now;
                pessoa.UsuarioInclusao = UsuarioDAO.GetById(1) as Usuario;
                dbSet.Add(pessoa);
                dbSet.Add(pessoa.Endereco);
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

        public void Inativar(IPessoa pessoa)
        {
            using (var dbSet = new ApplicationContext())
            {
                pessoa.Ativo = false;
                dbSet.Update(pessoa);
                dbSet.SaveChanges();
            }
        }

        public IPessoa GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var pessoa = dbSet.PESSOAS.SingleOrDefault(p => p.Id == id);
                pessoa.Endereco = dbSet.ENDERECOS.SingleOrDefault(p => p.Pessoa.Id == pessoa.Id);
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
            using (var contexto = new ApplicationContext())
            {
                return contexto.PESSOAS.Where(c => c.CPFCNPJ == cpfOrCnpj).FirstOrDefault();
            }
        }
    }
}
