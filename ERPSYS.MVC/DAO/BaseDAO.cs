using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO
{
    public class BaseDAO<T> where T : EntityModel
    {
        protected readonly ApplicationContext contexto;

        protected readonly DbSet<T> dbSet;

        public BaseDAO(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
