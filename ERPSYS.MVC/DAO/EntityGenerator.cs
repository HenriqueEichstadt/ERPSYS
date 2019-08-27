using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSYS.MVC.Common.Interfaces;
using ERPSYS.MVC.DAO.Interfaces;
using ERPSYS.MVC.Interfaces;
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
            modelBuilder.Entity<Pessoa>().Property(prop => prop.TipoPessoa).HasColumnName("TIPOPESSOA");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Nome).HasColumnName("NOME");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataNascimento).HasColumnName("DATANASCIMENTO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Genero).HasColumnName("GENERO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.RG).HasColumnName("RG");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.CPFCNPJ).IsRequired().HasColumnName("CPF");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Email).HasColumnName("EMAIL");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.TelefoneUm).IsRequired().HasColumnName("TELEFONEUM");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.TelefoneDois).HasColumnName("TELEFONEDOIS");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Ativo).IsRequired().HasColumnName("ATIVO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.NomeFantasia).HasColumnName("NOMEFANTASIA");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.NomeRazaoSocial).HasColumnName("NOMERAZAOSOCIAL");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.InscricaoEstadual).HasColumnName("INSCRICAOESTADUAL");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
            modelBuilder.Entity<Pessoa>().Property(prop => prop.Observacoes).HasColumnName("OBSERVACOES");
            modelBuilder.Entity<Pessoa>().HasOne(p => p.Endereco).WithOne().IsRequired().HasForeignKey(typeof(Pessoa).ToString(), "ENDERECO").OnDelete(DeleteBehavior.Restrict);
        }

        internal void GerarTabelaENDERECOS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>().HasKey(p => p.Id);
            modelBuilder.Entity<Endereco>().Property(prop => prop.CEP).HasColumnName("CEP");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Estado).HasColumnName("ESTADO");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Cidade).HasColumnName("CIDADE");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Bairro).HasColumnName("BAIRRO");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Rua).HasColumnName("RUA");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Numero).HasColumnName("NUMERO");
            modelBuilder.Entity<Endereco>().Property(prop => prop.Complemento).HasColumnName("COMPLEMENTO");
            modelBuilder.Entity<Endereco>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Endereco>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }
        internal void GerarTabelaUSUARIOS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Nome).IsRequired().HasColumnName("NOME");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Apelido).IsRequired().HasColumnName("APELIDO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Email).IsRequired().HasColumnName("EMAIL");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Senha).IsRequired().HasColumnName("SENHA");
            modelBuilder.Entity<Usuario>().Property(prop => prop.Ativo).IsRequired().HasColumnName("ATIVO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.NivelAcesso).IsRequired().HasColumnName("NIVELACESSO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Usuario>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }

        internal void GerarTabelaPRODUTOS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Produto>().Property(prop => prop.Nome).IsRequired().HasColumnName("NOME");
            modelBuilder.Entity<Produto>().Property(prop => prop.Marca).IsRequired().HasColumnName("MARCA");
            modelBuilder.Entity<Produto>().Property(prop => prop.Categoria).IsRequired().HasColumnName("CATEGORIA");
            modelBuilder.Entity<Produto>().Property(prop => prop.DataFabricacao).HasColumnName("DATAFABRICACAO");
            modelBuilder.Entity<Produto>().Property(prop => prop.PrecoVenda).IsRequired().HasColumnName("PRECOVENDA");
            modelBuilder.Entity<Produto>().Property(prop => prop.PrecoCusto).IsRequired().HasColumnName("PRECOCUSTO");
            modelBuilder.Entity<Produto>().Property(prop => prop.EstoqueAtual).IsRequired().HasColumnName("ESTOQUEATUAL");
            modelBuilder.Entity<Produto>().Property(prop => prop.LimiteEstoque).HasColumnName("LIMITEESTOQUE");
            modelBuilder.Entity<Produto>().Property(prop => prop.QtdPontosProgFidelidade).HasColumnName("QTDPONTOSPROGFIDELIDADE");
            modelBuilder.Entity<Produto>().Property(prop => prop.Ativo).IsRequired().HasColumnName("ATIVO");
            modelBuilder.Entity<Produto>().Property(prop => prop.Validade).HasColumnName("VALIDADE");
            modelBuilder.Entity<Produto>().Property(prop => prop.Descricao).HasColumnName("DESCRICAO");
            modelBuilder.Entity<Produto>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Produto>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }

        internal void GerarTabelaCLIENTES(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(p => p.Id);
            modelBuilder.Entity<Cliente>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Cliente>().HasOne(p => p.Pessoa).WithOne().HasForeignKey(typeof(Cliente).ToString(), "PESSOA").OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cliente>().Property(prop => prop.Pontos).HasColumnName("PONTOS");
            modelBuilder.Entity<Cliente>().Property(prop => prop.Ativo).IsRequired().HasColumnName("ATIVO");
            modelBuilder.Entity<Cliente>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Cliente>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }

        internal void GerarTabelaVENDAS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().HasKey(p => p.Id);
            modelBuilder.Entity<Venda>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<Venda>().Property(prop => prop.TotalUnidades).IsRequired().HasColumnName("TOTALUNIDADES");
            modelBuilder.Entity<Venda>().Property(prop => prop.Data).IsRequired().HasColumnName("DATA");
            modelBuilder.Entity<Venda>().Property(prop => prop.ClienteId).HasColumnName("CLIENTE");
            modelBuilder.Entity<Venda>().Property(prop => prop.PrecoTotal).IsRequired().HasColumnName("PRECOTOTAL");
            modelBuilder.Entity<Venda>().Property(prop => prop.FormaPagamento).IsRequired().HasColumnName("FORMAPAGAMENTO");
            modelBuilder.Entity<Venda>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<Venda>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }

        internal void GerarTabelaVENDAITENS(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendaItens>().HasKey(p => p.Id);
            modelBuilder.Entity<VendaItens>().Property(prop => prop.Id).HasColumnName("ID");
            modelBuilder.Entity<VendaItens>().Property(prop => prop.VendaId).HasColumnName("VENDA");
            modelBuilder.Entity<VendaItens>().Property(prop => prop.Unidades).HasColumnName("UNIDADES");
            modelBuilder.Entity<VendaItens>().Property(prop => prop.PrecoTotalItem).HasColumnName("PRECOTOTALITEM");
            modelBuilder.Entity<VendaItens>().Property(prop => prop.DataInclusao).IsRequired().HasColumnName("DATAINCLUSAO");
            modelBuilder.Entity<VendaItens>().Property(prop => prop.DataAlteracao).HasColumnName("DATAALTERACAO");
        }

        internal void IgnorarPropriedadesNaoMapeadas(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IClienteDAO>();
            modelBuilder.Ignore<IPessoaDAO>();
            modelBuilder.Ignore<IUsuarioDAO>();
            modelBuilder.Ignore<IEntityValidationResultFactory>();
            modelBuilder.Ignore<IMyActivator>();
        }
    }
}
