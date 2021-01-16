using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MosarticoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Infrastructure.Data
{
    public class MosarticoContext : DbContext
    {
        public MosarticoContext() { }

        public MosarticoContext(DbContextOptions<MosarticoContext> options) : base(options)
        {

        }
        public IDbContextTransaction Transaction { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfils { get; set; }        
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Arte> Artes { get; set; }
        public DbSet<TipoArte> TipoArtes { get; set; }
        public DbSet<ImagemArte> ImagemArtes { get; set; }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null)
                Transaction = this.Database.BeginTransaction();

            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Cad_Usuario");

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Enderecos)
                .WithOne(e => e.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Telefones)
                .WithOne(e => e.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Artes)
                .WithOne(e => e.Usuario)
                .OnDelete(DeleteBehavior.Cascade);
    
            modelBuilder.Entity<Endereco>().ToTable("Cad_Endereco");
            modelBuilder.Entity<Telefone>().ToTable("Cad_Telefone");

            modelBuilder.Entity<Perfil>().ToTable("Cad_Perfil")
                .HasData(new List<Perfil>() {
                    new Perfil(){Id=1,Tipo="Membro"},
                    new Perfil(){Id=2,Tipo="Artísta"},
                    new Perfil(){Id=3,Tipo="Empresa"}
                });

            modelBuilder.Entity<Arte>().ToTable("Cad_Arte");
          
            modelBuilder.Entity<TipoArte>().ToTable("Cad_TipoArte")
                .HasData(new List<TipoArte>() {
                    new TipoArte(){Id=1,Tipo="Música"},
                    new TipoArte(){Id=2,Tipo="Dança"},
                    new TipoArte(){Id=3,Tipo="Pintura"},
                    new TipoArte(){Id=4,Tipo="Escultura"},
                    new TipoArte(){Id=5,Tipo="Teatro"},
                    new TipoArte(){Id=6,Tipo="Literatura"},
                    new TipoArte(){Id=7,Tipo="Cinema"},
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
