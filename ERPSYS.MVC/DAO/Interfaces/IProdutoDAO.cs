using System.Collections.Generic;
using System.Linq;
using ERPSYS.MVC.Models;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IProdutoDAO
    {
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);
        Produto GetById(int id);
        IList<Produto> ListActives();
        IList<Produto> ListAll();
        void Inativar(int id);
        void Ativar(int id);
    }
}