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
        void Add(IPessoa pessoa);
        void Update(IPessoa pessoa);
        void Delete(IPessoa pessoa);
        IPessoa GetById(int id);
        IList<Pessoa> ListActives();
        IList<Pessoa> ListAll();
        IPessoa GeyByCPFOrCNPJ(string cpfOrCnpj);
    }
}
