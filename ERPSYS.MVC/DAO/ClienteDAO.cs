using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSYS.MVC.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        public void Add(ICliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Add(cliente);
                dbSet.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.CLIENTES.Update(cliente);
                dbSet.SaveChanges();
            }
        }

        public void Delete(ICliente cliente)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Remove(cliente);
                dbSet.SaveChanges();
            }
        }

        public Cliente GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES
                    .Include(c => c.Pessoa)
                    .ThenInclude(p => p.Endereco)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public IList<Cliente> ListActives()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES
                    .Include(p => p.Pessoa)
                    .Where(a => a.Ativo == true)
                    .ToList();
            }
        }

        public IList<Cliente> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES
                    .Include(p => p.Pessoa)
                    .ToList();
            }
        }

        public IList<Cliente> ListarClientes()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.CLIENTES
                    .Include(p => p.Pessoa)
                    .Where(a => a.Pessoa.TipoPessoa.Equals('F'))
                    .ToList();
            }
        }
        
        public void Inativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var cliente = GetById(id);
                cliente.Ativo = false;
                dbSet.CLIENTES.Update(cliente);
                dbSet.SaveChanges();
            }
        }

        public void Ativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var cliente = GetById(id);
                cliente.Ativo = true;
                dbSet.CLIENTES.Update(cliente);
                dbSet.SaveChanges();
            }
        }
    }
}