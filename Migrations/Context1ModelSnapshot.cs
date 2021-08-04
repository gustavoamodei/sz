﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sz.Models;

namespace sz.Migrations
{
    [DbContext(typeof(Context1))]
    partial class Context1ModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("sz.Models.Acessorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Acessorio");
                });

            modelBuilder.Entity("sz.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Celular")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TelResidencial")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("sz.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Rua")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("sz.Models.Frasco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Frasco");
                });

            modelBuilder.Entity("sz.Models.OleoBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ml")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco_ml")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SimulacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Valor_Compra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SimulacaoId");

                    b.ToTable("OleoBase");
                });

            modelBuilder.Entity("sz.Models.OleoEssencial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ml")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco_Gota")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SimulacaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Valor_Compra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SimulacaoId");

                    b.ToTable("OleoEssencial");
                });

            modelBuilder.Entity("sz.Models.SimulOB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ml")
                        .HasColumnType("int");

                    b.Property<int>("OleoBaseId")
                        .HasColumnType("int");

                    b.Property<int>("SimulacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OleoBaseId");

                    b.HasIndex("SimulacaoId");

                    b.ToTable("SimulOB");
                });

            modelBuilder.Entity("sz.Models.SimulOE", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GotasOE")
                        .HasColumnType("int");

                    b.Property<int>("OleoEssencialId")
                        .HasColumnType("int");

                    b.Property<int>("SimulacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OleoEssencialId");

                    b.HasIndex("SimulacaoId");

                    b.ToTable("SimulOE");
                });

            modelBuilder.Entity("sz.Models.Simulacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AcessorioId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("FrascoId")
                        .HasColumnType("int");

                    b.Property<int>("Lucro")
                        .HasColumnType("int");

                    b.Property<decimal>("Margem_lucro")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Ml_oleo_essencial")
                        .HasColumnType("int");

                    b.Property<float>("Ml_por_cento")
                        .HasColumnType("float");

                    b.Property<string>("NomeSimulacao")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco_Parcial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AcessorioId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FrascoId");

                    b.ToTable("Simulacao");
                });

            modelBuilder.Entity("sz.Models.Endereco", b =>
                {
                    b.HasOne("sz.Models.Cliente", "Cliente")
                        .WithMany("Endereco")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("sz.Models.OleoBase", b =>
                {
                    b.HasOne("sz.Models.Simulacao", null)
                        .WithMany("OleoBase")
                        .HasForeignKey("SimulacaoId");
                });

            modelBuilder.Entity("sz.Models.OleoEssencial", b =>
                {
                    b.HasOne("sz.Models.Simulacao", null)
                        .WithMany("OleoEssencial")
                        .HasForeignKey("SimulacaoId");
                });

            modelBuilder.Entity("sz.Models.SimulOB", b =>
                {
                    b.HasOne("sz.Models.OleoBase", "OleoBase")
                        .WithMany()
                        .HasForeignKey("OleoBaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sz.Models.Simulacao", null)
                        .WithMany("SimulOB")
                        .HasForeignKey("SimulacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OleoBase");
                });

            modelBuilder.Entity("sz.Models.SimulOE", b =>
                {
                    b.HasOne("sz.Models.OleoEssencial", "OleoEssencial")
                        .WithMany()
                        .HasForeignKey("OleoEssencialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sz.Models.Simulacao", null)
                        .WithMany("SimulOE")
                        .HasForeignKey("SimulacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OleoEssencial");
                });

            modelBuilder.Entity("sz.Models.Simulacao", b =>
                {
                    b.HasOne("sz.Models.Acessorio", "Acessorio")
                        .WithMany("Simulacao")
                        .HasForeignKey("AcessorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sz.Models.Cliente", "Cliente")
                        .WithMany("Simulacao")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sz.Models.Frasco", "Frasco")
                        .WithMany()
                        .HasForeignKey("FrascoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acessorio");

                    b.Navigation("Cliente");

                    b.Navigation("Frasco");
                });

            modelBuilder.Entity("sz.Models.Acessorio", b =>
                {
                    b.Navigation("Simulacao");
                });

            modelBuilder.Entity("sz.Models.Cliente", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Simulacao");
                });

            modelBuilder.Entity("sz.Models.Simulacao", b =>
                {
                    b.Navigation("OleoBase");

                    b.Navigation("OleoEssencial");

                    b.Navigation("SimulOB");

                    b.Navigation("SimulOE");
                });
#pragma warning restore 612, 618
        }
    }
}
