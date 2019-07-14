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
        internal void GerarTabelaPESSOASFISICAS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaFisica>().HasKey(p => p.Id);
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.Nome).IsRequired().HasColumnName("NOME");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.DataNascimento).IsRequired().HasColumnName("DATANASCIMENTO");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.Genero).HasColumnName("GENERO");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.RG).HasColumnName("RG");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.CPF).IsRequired().HasColumnName("CPF");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.TelefoneUm).IsRequired().HasColumnName("TELEFONEUM");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.TelefoneDois).HasColumnName("TELEFONEDOIS");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<PessoaFisica>().Property(prop => prop.DataAlteracao).IsRequired().HasColumnName("DATAALTERACAO");
            modelBuilder.Entity<PessoaFisica>().HasOne(u => u.UsuarioInclusao);
            modelBuilder.Entity<PessoaFisica>().HasOne(u => u.UsuarioAlteracao);
            //modelBuilder.Entity<PessoaFisica>().Property(prop => prop.UsuarioInclusao).HasColumnName("USUARIOINCLUSAO");
            //modelBuilder.Entity<PessoaFisica>().Property(prop => prop.UsuarioAlteracao).HasColumnName("USUARIOALTERACAO");
        }

        internal void GerarTabelaENDERECOS(ModelBuilder modelBuilder)
        {
            
        }

        internal void GerarTabelaPESSOASJURIDICAS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaJuridica>().HasKey(p => p.Id);
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.NomeFantasia).IsRequired().HasColumnName("NOMEFANTASIA");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.NomeRazaoSocial).IsRequired().HasColumnName("NOMERAZAOSOCIAL");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.InscricaoEstadual).IsRequired().HasColumnName("INSCRICAOESTADUAL");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.CNPJ).IsRequired().HasColumnName("CNPJ");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.Email).IsRequired().HasColumnName("EMAIL");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.TelefoneUm).IsRequired().HasColumnName("TELEFONEUM");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.TelefoneDois).HasColumnName("TELEFONEDOIS");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.Observacoes).HasColumnName("OBSERVACOES");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.DataInclusão).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.DataAlteracao).IsRequired().HasColumnName("DATAALTERACAO");
            //modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.UsuarioInclusao).IsRequired().HasColumnName("USUARIOINCLUSAO");
            //modelBuilder.Entity<PessoaJuridica>().Property(prop => prop.UsuarioAlteracao).IsRequired().HasColumnName("USUARIOALTERACAO");
            modelBuilder.Entity<PessoaJuridica>().HasOne(u => u.UsuarioInclusao);
            modelBuilder.Entity<PessoaJuridica>().HasOne(u => u.UsuarioAlteracao);
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
            //modelBuilder.Entity<Usuario>().Property(prop => prop.UsuarioInclusao).HasColumnName("USUARIOINCLUSAO");
            //modelBuilder.Entity<Usuario>().Property(prop => prop.UsuarioAlteracao).HasColumnName("USUARIOALTERACAO");
        }


    }
}
