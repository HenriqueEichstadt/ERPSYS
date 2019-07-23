using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IApplicationContext
    {
        //EntityGenerator Gerador { get; set; }
        //void OnModelCreating(ModelBuilder modelBuilder);
        void Add();
    }
}
