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
        void Ativar(int id);
        void Inativar(int id);
        Pessoa GetById(int id);
        IList<Pessoa> ListActives();
        IList<Pessoa> ListAll();
        IPessoa GeyByCPFOrCNPJ(string cpfOrCnpj);
        IList<Pessoa> ListFornecedores();
    }
}
