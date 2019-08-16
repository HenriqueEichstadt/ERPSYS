using ERPSYS.MVC.Common;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        public void Add(IUsuario usuario)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Add(usuario);
                dbSet.SaveChanges();
            }
        }

        public IUsuario GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.SingleOrDefault(p => p.Id == id);
            }
        }

        public void Inativar(IUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> ListActives()
        {
            throw new NotImplementedException();
        }

        public bool ExisteComMesmoApelido(string apelido)
        {
            using (var dbSet = new ApplicationContext())
            {
                return (dbSet.USUARIOS.FirstOrDefault(u => u.Apelido == apelido) != null);
            }
        }

        public IList<Usuario> ListAll()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.ToList();
            }
        }

        public void Update(IUsuario usuario)
        {
            using (var dbSet = new ApplicationContext())
            {
                dbSet.Update(usuario);
                dbSet.SaveChanges();
            }
        }

        public void Teste()
        {
            var query = new Query("SELECT NOME, EMAIL FROM USUARIOS");
            var entidade = query.Execute();
            var nome = entidade["Nome"];
            var email = entidade["Email"];
        }
    }
}
