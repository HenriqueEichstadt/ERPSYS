using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ERPSYS.MVC.DAO
{
    public class BaseDAO<T> where T : EntityModel<T>
    {
        protected readonly ApplicationContext Context;

        protected readonly DbSet<T> DbSet;

        public BaseDAO(ApplicationContext contexto)
        {
            Context = contexto;
            DbSet = contexto.Set<T>();
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            Context.Database.RollbackTransaction();
        }
    }
}
