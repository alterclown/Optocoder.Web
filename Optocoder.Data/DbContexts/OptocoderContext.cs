using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Optocoder.Data.Entities
{
    public partial class OptocoderContext : DbContext
    {
        public OptocoderContext()
        {
        }

        public OptocoderContext(DbContextOptions<OptocoderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompanyAdd> CompanyAdd { get; set; }
        public virtual DbSet<Names> Names { get; set; }
        public virtual DbSet<UserAdd> UserAdd { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Company;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CompanyAdd>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("companyAdd");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyAddress)
                    .HasColumnName("companyAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Names>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAdd>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userAdd");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .HasColumnName("userPassword")
                    .HasMaxLength(50);
            });
        }
    }
}
