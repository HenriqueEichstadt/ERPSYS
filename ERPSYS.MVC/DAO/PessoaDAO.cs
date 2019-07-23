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
    public class PessoaDAO : BaseDAO<Pessoa>, IPessoaDAO
    {
        public PessoaDAO(ApplicationContext contexto) : base(contexto)
        {
        }

        public void AddCliente(IPessoa pessoa)
        {
            dbSet.Add(pessoa as Pessoa);
            contexto.SaveChanges(); 
        }

        //public Pessoa GetCliente(int id)
        //{
        //    return dbSet.Where(p => p.Id == id).SingleOrDefault();
        //}

        //public void UpdateCliente(Pessoa pessoa)
        //{
        //    dbSet.Update(pessoa);
        //    contexto.SaveChanges();
        //}

        //public IList<Cliente> ListaClientes()
        //{
        //    using (var contexto = new ApplicationContext())
        //    {
        //        return contexto.Clientes.Include(f => f.Pessoa).Where(c => c.Ativo == true).ToList();
        //    }
        //}

        //public Cliente BuscaPorId(int id)
        //{
        //    using (var contexto = new ApplicationContext())
        //    {

        //        return contexto.Clientes.Include(c => c.Pessoa).ThenInclude(p => p.Endereco).Include(p => p.Pessoa.Veiculo).Where(c => c.Id == id).FirstOrDefault();
        //    }
        //}

        //public void Atualiza(Cliente cliente)
        //{
        //    using (var contexto = new ApplicationContext())
        //    {
        //        contexto.Clientes.Update(cliente);
        //        contexto.SaveChanges();
        //    }
        //}

        //public Pessoa Busca(string login, string senha)
        //{
        //    using (var contexto = new ApplicationContext())
        //    {
        //        return contexto.Pessoas.FirstOrDefault();
        //    }
        //}

        //public Pessoa BuscaCPfCnpj(string cpfECnpj)
        //{
        //    using (var contexto = new ApplicationContext())
        //    {
        //        return contexto.Pessoas.Where(c => c.CpfeCnpj == cpfECnpj).FirstOrDefault();
        //    }
        //}
    }
}
