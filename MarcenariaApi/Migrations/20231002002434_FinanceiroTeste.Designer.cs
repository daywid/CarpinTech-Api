﻿// <auto-generated />
using System;
using MarcenariaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarcenariaApi.Migrations
{
    [DbContext(typeof(MarcenariaDbContext))]
    [Migration("20231002002434_FinanceiroTeste")]
    partial class FinanceiroTeste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("MarcenariaApi.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("MarcenariaApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MarcenariaApi.Models.Financeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CustosMateriais")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("DespesasOperacionais")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PagamentosClientes")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SalariosFuncionarios")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Financeiros");
                });

            modelBuilder.Entity("MarcenariaApi.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("MarcenariaApi.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Funcao")
                        .HasColumnType("TEXT");

                    b.Property<int>("HorasTrabalhadas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Salario")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
