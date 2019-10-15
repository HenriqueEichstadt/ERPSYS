using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSYS.MVC.DAO
{
    public class ClienteDAO : BaseDAO<Cliente>, IClienteDAO
    {
        public ClienteDAO(ApplicationContext contexto) : base(contexto)
        {
        }

        public void Add(Cliente cliente)
        {
            DbSet.Add(cliente);
            Context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            DbSet.Update(cliente);
            Context.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            DbSet.Remove(cliente);
            Context.SaveChanges();
        }

        public Cliente GetById(int id)
        {
            return DbSet
                .Include(c => c.Pessoa)
                .ThenInclude(p => p.Endereco)
                .FirstOrDefault(c => c.Id == id);
        }

        public IList<Cliente> ListActives()
        {
            return DbSet
                .Include(p => p.Pessoa)
                .Where(a => a.Ativo == true)
                .ToList();
        }

        public IList<Cliente> ListAll()
        {
            return DbSet
                .Include(p => p.Pessoa)
                .ToList();
        }

        public IList<Cliente> ListarClientes()
        {
            return DbSet
                .Include(p => p.Pessoa)
                .Where(a => a.Pessoa.TipoPessoa.Equals('F'))
                .ToList();
        }

        public void Inativar(int id)
        {
            var cliente = GetById(id);
            cliente.Ativo = false;
            DbSet.Update(cliente);
            Context.SaveChanges();
        }

        public void Ativar(int id)
        {
            var cliente = GetById(id);
            cliente.Ativo = true;
            DbSet.Update(cliente);
            Context.SaveChanges();
        }

        public void SomaPontos(int clienteId, int pontos)
        {
            var cliente = GetById(clienteId);
            cliente.Pontos += pontos;
            DbSet.Update(cliente);
            Context.SaveChanges();
        }

        public void TrocaPorPontos(int clienteId, int pontos)
        {
            var cliente = GetById(clienteId);
            cliente.Pontos -= pontos;
            DbSet.Update(cliente);
            Context.SaveChanges();
        }
    }
}