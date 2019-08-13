using System.Collections.Generic;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IClienteDAO
    {
        void Add(ICliente cliente);
        void Update(ICliente cliente);
        void Delete(ICliente cliente);
        ICliente GetById(int id);
        IList<Cliente> ListActives();
        IList<Cliente> ListAll();
    }
}