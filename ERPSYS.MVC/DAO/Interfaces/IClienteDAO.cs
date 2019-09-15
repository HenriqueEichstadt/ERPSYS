using System.Collections.Generic;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IClienteDAO
    {
        void Add(ICliente cliente);
        void Update(Cliente cliente);
        void Delete(ICliente cliente);
        Cliente GetById(int id);
        IList<Cliente> ListActives();
        IList<Cliente> ListAll();
        IList<Cliente> ListarClientes();
        void Inativar(int id);
        void Ativar(int id);
    }
}