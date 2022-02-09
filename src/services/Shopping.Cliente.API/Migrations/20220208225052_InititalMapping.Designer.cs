﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping.Cliente.API.Data;

namespace Shopping.Cliente.API.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20220208225052_InititalMapping")]
    partial class InititalMapping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shopping.Cliente.API.Models.Clientes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Shopping.Cliente.API.Models.VOs.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Shopping.Cliente.API.Models.Clientes", b =>
                {
                    b.OwnsOne("Shopping.Cliente.API.Models.VOs.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("ClientesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)");

                            b1.HasKey("ClientesId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClientesId");
                        });

                    b.OwnsOne("Shopping.Cliente.API.Models.VOs.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientesId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("ClientesId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClientesId");
                        });

                    b.Navigation("Cpf");

                    b.Navigation("Email");
                });

            modelBuilder.Entity("Shopping.Cliente.API.Models.VOs.Endereco", b =>
                {
                    b.HasOne("Shopping.Cliente.API.Models.Clientes", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("Shopping.Cliente.API.Models.VOs.Endereco", "ClienteId")
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Shopping.Cliente.API.Models.Clientes", b =>
                {
                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
