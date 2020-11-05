using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.DatabaseContext
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=CASA-PC\\SQLEXPRESS,1433;Initial Catalog=Library;User ID=sa;Password=10081997w;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Editora)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Título)
                    .IsRequired()
                    .HasMaxLength(120);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.Property(e => e.Celular).HasMaxLength(14);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
