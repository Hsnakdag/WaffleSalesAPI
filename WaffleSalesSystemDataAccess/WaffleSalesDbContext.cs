using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


using WaffleSalesSystem.Entity;

namespace WaffleSalesSystemDataAccess
{
  public class WaffleSalesDbContext : DbContext
    {
        
     

        public WaffleSalesDbContext(DbContextOptions<WaffleSalesDbContext> options)
            : base(options)
        {

        }
        public WaffleSalesDbContext()
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
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=wafflessalessystem", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(500);

                entity.Property(e => e.CreatedDatetime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Categorydetail>(entity =>
            {
                entity.ToTable("categorydetail");

                entity.HasIndex(e => e.CategoryId, "CatId");

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

            
      // OnModelCreatingPartial(modelBuilder);
        }


      //  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
       
        
    }
   
}
