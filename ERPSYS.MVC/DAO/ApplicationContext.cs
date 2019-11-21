using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.Common;

namespace ERPSYS.MVC.DAO
{
    public class ApplicationContext : DbContext
    {
        private EntityGenerator Gerador => new EntityGenerator();

        public DbSet<Pessoa> PESSOAS { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Endereco> ENDERECOS { get; set; }
        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Produto> PRODUTOS { get; set; }
        public DbSet<Venda> VENDAS { get; set; }
        public DbSet<VendaItens> VENDAITENS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Gerador.IgnorarPropriedadesNaoMapeadas(modelBuilder);

            Gerador.GerarTabelaPESSOAS(modelBuilder);
            Gerador.GerarTabelaUSUARIOS(modelBuilder);
            Gerador.GerarTabelaENDERECOS(modelBuilder);
            Gerador.GerarTabelaCLIENTES(modelBuilder);
            Gerador.GerarTabelaPRODUTOS(modelBuilder);
            Gerador.GerarTabelaVENDAS(modelBuilder);
            Gerador.GerarTabelaVENDAITENS(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Application.DbConnectionString);
        }
    }
}
