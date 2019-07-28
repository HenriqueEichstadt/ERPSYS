using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        private EntityGenerator Gerador => new EntityGenerator();

        public DbSet<Pessoa> PESSOAS { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Gerador.GerarTabelaPESSOAS(modelBuilder);
            Gerador.GerarTabelaUSUARIOS(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Startup.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
