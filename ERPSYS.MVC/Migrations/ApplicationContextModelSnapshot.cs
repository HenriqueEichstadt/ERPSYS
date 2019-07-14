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

            modelBuilder.Entity("ERPSYS.MVC.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(18);

                    b.Property<DateTime>("DataAlteracao");

                    b.Property<DateTime>("DataInclusao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Genero")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("Nome");

                    b.Property<string>("RG")
                        .HasMaxLength(15);

                    b.Property<string>("TelefoneDois")
                        .HasMaxLength(14);

                    b.Property<string>("TelefoneUm")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioInclusaoId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasMaxLength(18);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DATANASCIMENTO");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasMaxLength(50);

                    b.Property<string>("Genero")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("GENERO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME");

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

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioInclusaoId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasMaxLength(18);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusão")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(50);

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnName("INSCRICAOESTADUAL")
                        .HasMaxLength(50);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("NOMEFANTASIA")
                        .HasMaxLength(50);

                    b.Property<string>("NomeRazaoSocial")
                        .IsRequired()
                        .HasColumnName("NOMERAZAOSOCIAL")
                        .HasMaxLength(50);

                    b.Property<string>("Observacoes")
                        .HasColumnName("OBSERVACOES")
                        .HasMaxLength(200);

                    b.Property<string>("TelefoneDois")
                        .HasColumnName("TELEFONEDOIS")
                        .HasMaxLength(14);

                    b.Property<string>("TelefoneUm")
                        .IsRequired()
                        .HasColumnName("TELEFONEUM")
                        .HasMaxLength(14);

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioInclusaoId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnName("NOMEUSUARIO");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA");

                    b.Property<int?>("UsuarioAlteracaoId");

                    b.Property<int?>("UsuarioInclusaoId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioAlteracaoId");

                    b.HasIndex("UsuarioInclusaoId")
                        .IsUnique()
                        .HasFilter("[UsuarioInclusaoId] IS NOT NULL");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Pessoa", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.PessoaFisica", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.PessoaJuridica", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithMany()
                        .HasForeignKey("UsuarioInclusaoId");
                });

            modelBuilder.Entity("ERPSYS.MVC.Models.Usuario", b =>
                {
                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioAlteracao")
                        .WithMany()
                        .HasForeignKey("UsuarioAlteracaoId");

                    b.HasOne("ERPSYS.MVC.Models.Usuario", "UsuarioInclusao")
                        .WithOne()
                        .HasForeignKey("ERPSYS.MVC.Models.Usuario", "UsuarioInclusaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
