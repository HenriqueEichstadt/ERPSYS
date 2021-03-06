﻿// <auto-generated />
using System;
using ERPSYS.MVC.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPSYS.MVC.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190803143330_AdicionandoTabelaEnderecos")]
    partial class AdicionandoTabelaEnderecos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<DateTime>("DataAlteracao")
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

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataAlteracao")
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasMaxLength(100);

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
#pragma warning restore 612, 618
        }
    }
}
