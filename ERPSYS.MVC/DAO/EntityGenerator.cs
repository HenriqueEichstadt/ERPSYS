using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSYS.MVC.DAO
{
    public class EntityGenerator
    {
        internal void GerarTabelaPESSOAS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().HasKey(p => p.Id);
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Nome).IsRequired().HasColumnName("NOME");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataNascimento).IsRequired().HasColumnName("DATANASCIMENTO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Genero).HasColumnName("GENERO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.RG).HasColumnName("RG");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.CPF).IsRequired().HasColumnName("CPF");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.TelefoneUm).IsRequired().HasColumnName("TELEFONEUM");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.TelefoneDois).HasColumnName("TELEFONEDOIS");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Ativo).IsRequired().HasColumnName("ATIVO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataAlteracao).IsRequired().HasColumnName("DATAALTERACAO");
            modelBuilder.Entity<Pessoa>().HasOne(u => u.UsuarioInclusao);
            modelBuilder.Entity<Pessoa>().HasOne(u => u.UsuarioAlteracao);

        }

        internal void GerarTabelaENDERECOS(ModelBuilder modelBuilder)
        {
            
        }
        internal void GerarTabelaUSUARIOS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Nome).IsRequired().HasColumnName("NOME");
            modelBuilder.Entity<Usuario>().Property(prop => prop.NomeUsuario).IsRequired().HasColumnName("NOMEUSUARIO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Email).IsRequired().HasColumnName("EMAIL");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Senha).IsRequired().HasColumnName("SENHA");
            modelBuilder.Entity<Usuario>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.DataAlteracao).IsRequired().HasColumnName("DATAALTERACAO");
            modelBuilder.Entity<Usuario>().HasOne(p => p.UsuarioInclusao);
            modelBuilder.Entity<Usuario>().HasOne(p => p.UsuarioAlteracao);
        }
    }
}
