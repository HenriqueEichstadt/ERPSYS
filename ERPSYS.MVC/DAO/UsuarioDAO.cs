using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsUsuarioCadastrado(string apelido, string senha = null)
        {
            using (var dbSet = new ApplicationContext())
            {
                if (senha == null)
                    return (dbSet.USUARIOS.Where(u => u.Apelido == apelido).FirstOrDefault()) != null;
                else
                    return (dbSet.USUARIOS.Where(u => u.Apelido == apelido && u.Senha == senha).FirstOrDefault()) != null;
            }
        }

        public IUsuario GetByApelido(string apelido)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.Where(u => u.Apelido == apelido).FirstOrDefault();
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
    }
}
