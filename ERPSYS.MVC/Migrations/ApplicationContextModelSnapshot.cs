﻿// <auto-generated />
using System;
using ERPSYS.MVC.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPSYS.MVC.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERPSYS.MVC.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("ATIVO");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<int>("PESSOA");

                    b.Property<int?>("Pontos")
                        .HasColumnName("PONTOS");

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.HasKey("Id");

                    b.HasIndex("PESSOA")
                        .IsUnique();

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.ToTable("CLIENTES");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("BAIRRO")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasMaxLength(9);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("CIDADE")
                        .HasMaxLength(50);

                    b.Property<string>("Complemento")
                        .HasColumnName("COMPLEMENTO")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("NUMERO")
                        .HasMaxLength(7);

                    b.Property<int>("PESSOA");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnName("RUA")
                        .HasMaxLength(100);

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.HasKey("Id");

                    b.HasIndex("PESSOA")
                        .IsUnique();

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.ToTable("ENDERECOS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("ATIVO");

                    b.Property<string>("CPFCNPJ")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasMaxLength(18);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("GENERO");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnName("INSCRICAOESTADUAL")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(100);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NOMEFANTASIA")
                        .HasMaxLength(50);

                    b.Property<string>("NomeRazaoSocial")
                        .IsRequired()
                        .HasColumnName("NOMERAZAOSOCIAL")
                        .HasMaxLength(50);

                    b.Property<string>("Observacoes")
                        .HasMaxLength(200);

                    b.Property<string>("RG")
                        .HasColumnName("RG")
                        .HasMaxLength(15);

                    b.Property<string>("TelefoneDois")
                        .HasColumnName("TELEFONEDOIS")
                        .HasMaxLength(14);

                    b.Property<string>("TelefoneUm")
                        .IsRequired()
                        .HasColumnName("TELEFONEUM")
                        .HasMaxLength(14);

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("TIPOPESSOA");

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.HasKey("Id");

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.ToTable("PESSOAS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("CATEGORIA")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime?>("DataFabricacao")
                        .HasColumnName("DATAFABRICACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasMaxLength(200);

                    b.Property<double>("EstoqueAtual")
                        .HasColumnName("ESTOQUEATUAL");

                    b.Property<double?>("LimiteEstoque")
                        .HasColumnName("LIMITEESTOQUE");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnName("MARCA")
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(30);

                    b.Property<double>("PrecoCusto")
                        .HasColumnName("PRECOCUSTO");

                    b.Property<double>("PrecoVenda")
                        .HasColumnName("PRECOVENDA");

                    b.Property<int?>("QtdPontosProgFidelidade")
                        .HasColumnName("QTDPONTOSPROGFIDELIDADE");

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.Property<DateTime?>("Validade")
                        .HasColumnName("VALIDADE");

                    b.HasKey("Id");

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.ToTable("PRODUTOS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnName("APELIDO")
                        .HasMaxLength(40);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasMaxLength(30);

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int?>("USUARIOINCLUSAO");

                    b.HasKey("Id");

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique()
                        .HasFilter("[USUARIOINCLUSAO] IS NOT NULL");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnName("CLIENTE");

                    b.Property<DateTime>("Data")
                        .HasColumnName("DATA");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<int>("FormaPagamento")
                        .HasColumnName("FORMAPAGAMENTO");

                    b.Property<double>("PrecoTotal")
                        .HasColumnName("PRECOTOTAL");

                    b.Property<double>("TotalUnidades")
                        .HasColumnName("TOTALUNIDADES");

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.ToTable("VENDAS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.VendaItens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<double>("PrecoTotalItem")
                        .HasColumnName("PRECOTOTALITEM");

                    b.Property<int>("ProdutoId")
                        .HasColumnName("PRODUTO");

                    b.Property<int?>("USUARIOALTERACAO");

                    b.Property<int>("USUARIOINCLUSAO");

                    b.Property<double>("Unidades")
                        .HasColumnName("UNIDADES");

                    b.Property<int>("VendaId")
                        .HasColumnName("VENDA");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("USUARIOALTERACAO")
                        .IsUnique()
                        .HasFilter("[USUARIOALTERACAO] IS NOT NULL");

                    b.HasIndex("USUARIOINCLUSAO")
                        .IsUnique();

                    b.HasIndex("VendaId");

                    b.ToTable("VENDAITENS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Cliente", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Cliente", "PESSOA")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Cliente", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Cliente", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Endereco", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Pessoa", "Pessoa")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Endereco", "PESSOA")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Endereco", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Endereco", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Pessoa", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Pessoa", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Pessoa", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Produto", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Produto", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Produto", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Usuario", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Usuario", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Usuario", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Venda", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Venda", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Venda", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.VendaItens", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Produto", "Produto")
                        .WithMany("VendaItens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.VendaItens", "USUARIOALTERACAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.VendaItens", "USUARIOINCLUSAO")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ERPSYS.MVC.Models.Venda", "Venda")
                        .WithMany("VendaItens")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
