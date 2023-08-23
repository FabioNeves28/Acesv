﻿// <auto-generated />
using System;
using Acesv2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Acesvv.Migrations
{
    [DbContext(typeof(BD))]
    partial class BDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Acesv.Models.Dados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bairros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoriaSelecionada")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EscolaId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Escolas");

                    b.Property<int?>("EscolaId1")
                        .HasColumnType("int");

                    b.Property<string>("EscolasSelecionadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Número")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefixo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Veiculo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId1");

                    b.ToTable("Dados");
                });

            modelBuilder.Entity("Acesv.Models.Escola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NomeEscola")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("Acesv.Models.Dados", b =>
                {
                    b.HasOne("Acesv.Models.Escola", "Escola")
                        .WithMany()
                        .HasForeignKey("EscolaId1");

                    b.Navigation("Escola");
                });
#pragma warning restore 612, 618
        }
    }
}
