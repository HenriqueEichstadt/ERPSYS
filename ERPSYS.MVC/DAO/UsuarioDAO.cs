using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
using ERPSYS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ERPSYS.Common;

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
                    return (dbSet.USUARIOS.FirstOrDefault(u => u.Apelido == apelido)) != null;
                else
                    return (dbSet.USUARIOS.FirstOrDefault(u => u.Apelido == apelido && u.Senha == senha)) != null;
            }
        }

        public IUsuario GetByApelido(string apelido)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.FirstOrDefault(u => u.Apelido == apelido);
            }
        }
        
        public IUsuario GetByApelidoESenha(string apelido, string senha)
        {
            using (var dbSet = new ApplicationContext())
            {
                return dbSet.USUARIOS.FirstOrDefault(a => a.Apelido == apelido && a.Senha == senha);
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

        public Usuario Teste()
        {
            var query = new Query("SELECT * FROM USUARIOS");
            DbEntity result = query.Execute().FirstOrDefault();
            var user = new Usuario();
            //user.Id = result["ID"];
            return null; //result;
        }
    }
}
