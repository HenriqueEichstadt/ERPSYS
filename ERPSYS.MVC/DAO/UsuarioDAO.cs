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

        public Usuario GetById(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.SingleOrDefault(p => p.Id == id);
            }
        }

        public void Ativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var usuario = GetById(id);
                usuario.Ativo = true;
                dbSet.USUARIOS.Update(usuario);
                dbSet.SaveChanges();
            }
        }

        public void Inativar(int id)
        {
            using (var dbSet = new ApplicationContext())
            {
                var usuario = GetById(id);
                usuario.Ativo = false;
                dbSet.USUARIOS.Update(usuario);
                dbSet.SaveChanges();
            }
        }

        public IList<Usuario> ListActives()
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.Where(a => a.Ativo).ToList();
            }
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
