﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MosarticoApi.Infrastructure.Data;

namespace MosarticoApi.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MosarticoContext))]
    [Migration("20210117050406_adjustmentTableOng")]
    partial class adjustmentTableOng
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MosarticoApi.Domain.Models.Arte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoArteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("TipoArteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cad_Arte");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro_end")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep_end")
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade_end")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado_end")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero_end")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pais_end")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Rua_end")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cad_Endereco");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemArte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagem")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArteId");

                    b.ToTable("ImagemArtes");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemOficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagem")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("OficinasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OficinasId");

                    b.ToTable("ImagemOficinas");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemOng", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imagem")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("OngId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OngId");

                    b.ToTable("ImagemOngs");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Oficinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("OngId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OngId");

                    b.ToTable("Cad_Oficiona");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Ong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasMaxLength(14)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cad_Ong");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cad_Perfil");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Membro"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Artísta"
                        },
                        new
                        {
                            Id = 3,
                            Tipo = "Empresa"
                        });
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone_tel")
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ddd_tel")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cad_Telefone");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.TipoArte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cad_TipoArte");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tipo = "Música"
                        },
                        new
                        {
                            Id = 2,
                            Tipo = "Dança"
                        },
                        new
                        {
                            Id = 3,
                            Tipo = "Pintura"
                        },
                        new
                        {
                            Id = 4,
                            Tipo = "Escultura"
                        },
                        new
                        {
                            Id = 5,
                            Tipo = "Teatro"
                        },
                        new
                        {
                            Id = 6,
                            Tipo = "Literatura"
                        },
                        new
                        {
                            Id = 7,
                            Tipo = "Cinema"
                        });
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(16)
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Foto")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("PerfilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Cad_Usuario");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.UsuarioOficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OficinasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OficinasId");

                    b.HasIndex("UsuarioID");

                    b.ToTable("UsuarioOficina");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Arte", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.TipoArte", "TipoArte")
                        .WithMany()
                        .HasForeignKey("TipoArteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MosarticoApi.Domain.Models.Usuario", "Usuario")
                        .WithMany("Artes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoArte");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Endereco", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemArte", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Arte", "Arte")
                        .WithMany("ImagemArte")
                        .HasForeignKey("ArteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arte");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemOficina", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Oficinas", "Oficinas")
                        .WithMany("ImagensOficina")
                        .HasForeignKey("OficinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oficinas");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.ImagemOng", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Ong", "Ong")
                        .WithMany("ImagensOng")
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ong");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Oficinas", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Ong", "Ong")
                        .WithMany("Oficinas")
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ong");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Telefone", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Usuario", "Usuario")
                        .WithMany("Telefones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Usuario", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.UsuarioOficina", b =>
                {
                    b.HasOne("MosarticoApi.Domain.Models.Oficinas", "Oficinas")
                        .WithMany("UsuarioOficinas")
                        .HasForeignKey("OficinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MosarticoApi.Domain.Models.Usuario", "Usuario")
                        .WithMany("UsuarioOficinas")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oficinas");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Arte", b =>
                {
                    b.Navigation("ImagemArte");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Oficinas", b =>
                {
                    b.Navigation("ImagensOficina");

                    b.Navigation("UsuarioOficinas");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Ong", b =>
                {
                    b.Navigation("ImagensOng");

                    b.Navigation("Oficinas");
                });

            modelBuilder.Entity("MosarticoApi.Domain.Models.Usuario", b =>
                {
                    b.Navigation("Artes");

                    b.Navigation("Enderecos");

                    b.Navigation("Telefones");

                    b.Navigation("UsuarioOficinas");
                });
#pragma warning restore 612, 618
        }
    }
}
