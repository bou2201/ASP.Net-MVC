using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Menswear_App.Models
{
    public partial class menswear_dbContext : DbContext
    {
        public menswear_dbContext()
        {
        }

        public menswear_dbContext(DbContextOptions<menswear_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Invoicedetail> Invoicedetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Productdetail> Productdetails { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseMySql("server=localhost;user id=admin;password=admin2002;port=3306;database=menswear_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(50)
                    .HasColumnName("color_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(100)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(100)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(20)
                    .HasColumnName("customer_phone");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.CustomerId, "fk_customer_name");

                entity.HasIndex(e => e.UserId, "fk_user_name");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("invoice_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.InvoiceStatus)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_customer_name");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_name");
            });

            modelBuilder.Entity<Invoicedetail>(entity =>
            {
                entity.HasKey(e => new { e.InvoiceId, e.ProductId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("invoicedetails");

                entity.HasIndex(e => e.ProductId, "fk_invoiceDetail_product");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalDue)
                    .HasPrecision(5, 2)
                    .HasColumnName("total_due");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Invoicedetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoiceDetail_invoice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Invoicedetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoiceDetail_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.CategoryId, "fk_category_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProductBrand)
                    .HasMaxLength(50)
                    .HasColumnName("product_brand");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(600)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(1000)
                    .HasColumnName("product_image");

                entity.Property(e => e.ProductMaterial)
                    .HasMaxLength(50)
                    .HasColumnName("product_material");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasPrecision(10, 3)
                    .HasColumnName("product_price");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_category_id");
            });

            modelBuilder.Entity<Productdetail>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SizeId, e.ColorId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("productdetails");

                entity.HasIndex(e => e.ColorId, "fk_productDetail_color");

                entity.HasIndex(e => e.SizeId, "fk_productDetail_size");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Productdetails)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productDetail_color");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productdetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productDetail_product");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Productdetails)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productDetail_size");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("sizes");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .HasColumnName("size_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .HasColumnName("user_phone");

                entity.Property(e => e.UserUsername)
                    .HasMaxLength(50)
                    .HasColumnName("user_username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
