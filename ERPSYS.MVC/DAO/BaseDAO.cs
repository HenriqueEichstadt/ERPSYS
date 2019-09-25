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
        protected readonly ApplicationContext Context;

        protected readonly DbSet<T> DbSet;

        public BaseDAO(ApplicationContext contexto)
        {
            Context = contexto;
            DbSet = contexto.Set<T>();
        }
    }
}
