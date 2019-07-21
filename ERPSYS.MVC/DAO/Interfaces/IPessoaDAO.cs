using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IPessoaDAO
    {
        void AddCliente(IPessoa pessoa);
    }
}
