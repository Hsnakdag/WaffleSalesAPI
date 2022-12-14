using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api
{
    public partial class wafflessalessystemContext : DbContext
    {
        public wafflessalessystemContext()
        {
        }

        public wafflessalessystemContext(DbContextOptions<wafflessalessystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Categorydetail> Categorydetails { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Salesdetail> Salesdetails { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

               // optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=wafflessalessystem", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.CategoryName, "CetagoryName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(500);

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Categorydetail>(entity =>
            {
                entity.ToTable("categorydetail");

                entity.HasIndex(e => e.CategoryId, "CatId");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Categorydetails)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("CatId");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.SalesDate).HasColumnType("datetime");

                entity.Property(e => e.SalesName).HasMaxLength(200);
            });

            modelBuilder.Entity<Salesdetail>(entity =>
            {
                entity.ToTable("salesdetail");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");

                entity.Property(e => e.SalesPrice).HasColumnName("salesPrice");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.StockName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
