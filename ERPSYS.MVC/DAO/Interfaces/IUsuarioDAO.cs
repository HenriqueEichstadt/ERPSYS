using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IUsuarioDAO
    {
        void Add(IUsuario usuario);
        void Update(IUsuario usuario);
        void Ativar(int id);
        void Inativar(int id);
        Usuario GetById(int id);
        IList<Usuario> ListActives();
        IList<Usuario> ListAll();
        IUsuario GetByApelido(string apelido);
        IUsuario GetByApelidoESenha(string apelido, string senha);
        bool IsUsuarioCadastrado(string apelido, string senha);
    }
}
