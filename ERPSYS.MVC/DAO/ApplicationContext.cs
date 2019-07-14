﻿using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSYS.MVC.DAO
{
    public class ApplicationContext : DbContext
    {
        private EntityGenerator Gerador => new EntityGenerator();

        public DbSet<Pessoa> PESSOASFISICAS { get; set; }
        public DbSet<Pessoa> PESSOASJURIDICAS { get; set; }
        public DbSet<Usuario> USUARIOS { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Gerador.GerarTabelaPESSOASFISICAS(modelBuilder);
            Gerador.GerarTabelaPESSOASJURIDICAS(modelBuilder);
            Gerador.GerarTabelaUSUARIOS(modelBuilder);
            Gerador.GerarTabelaENDERECOS(modelBuilder);

        }


    }
}