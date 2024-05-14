using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.Models;

public partial class AccountShopContext : DbContext
{
    public AccountShopContext()
    {
    }

    public AccountShopContext(DbContextOptions<AccountShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Paymentmethod> Paymentmethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TblImage> TblImages { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;pwd=123456;database=AccountShop");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.CategoryRootId, "fk_category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryImage)
                .HasColumnType("text")
                .HasColumnName("category_image");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.CategoryRootId).HasColumnName("category_root_id");

            entity.HasOne(d => d.CategoryRoot).WithMany(p => p.InverseCategoryRoot)
                .HasForeignKey(d => d.CategoryRootId)
                .HasConstraintName("fk_category");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.CouponId).HasName("PRIMARY");

            entity.ToTable("coupon");

            entity.Property(e => e.CouponId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("coupon_id");
            entity.Property(e => e.CouponDsc)
                .HasColumnType("text")
                .HasColumnName("coupon_dsc");
            entity.Property(e => e.CouponExpiration)
                .HasColumnType("datetime")
                .HasColumnName("coupon_expiration");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAT");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("datetime")
                .HasColumnName("deleteAT");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAT");
        });

        modelBuilder.Entity<Paymentmethod>(entity =>
        {
            entity.HasKey(e => e.MethodId).HasName("PRIMARY");

            entity.ToTable("paymentmethod");

            entity.Property(e => e.MethodId).HasColumnName("method_id");
            entity.Property(e => e.MethodDsc)
                .HasColumnType("text")
                .HasColumnName("method_dsc");
            entity.Property(e => e.MethodName)
                .HasMaxLength(30)
                .HasColumnName("method_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "fk_product_category");

            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProductContent)
                .HasColumnType("text")
                .HasColumnName("product_content");
            entity.Property(e => e.ProductDesciption)
                .HasColumnType("text")
                .HasColumnName("product_desciption");
            entity.Property(e => e.ProductImage)
                .HasColumnType("text")
                .HasColumnName("product_image");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice)
                .HasPrecision(10)
                .HasColumnName("product_price");
            entity.Property(e => e.ProductSlug)
                .HasColumnType("text")
                .HasColumnName("product_slug");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_product_category");
        });

        modelBuilder.Entity<TblImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("tbl_image");

            entity.HasIndex(e => e.ProductId, "fk_image_product");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageDsc)
                .HasMaxLength(50)
                .HasColumnName("image_dsc");
            entity.Property(e => e.ImageUrl)
                .HasColumnType("text")
                .HasColumnName("image_url");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.TblImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_image_product");
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("tbl_order");

            entity.HasIndex(e => e.CouponId, "fk_order_coupon");

            entity.HasIndex(e => e.PaymentMethodId, "fk_order_paymentMethod");

            entity.HasIndex(e => e.Username, "fk_order_user");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CouponId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("coupon_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAT");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deletedAT");
            entity.Property(e => e.Ischeckout)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ischeckout");
            entity.Property(e => e.OrderPrice)
                .HasPrecision(10)
                .HasDefaultValueSql("'0'")
                .HasColumnName("order_price");
            entity.Property(e => e.OrderQty).HasColumnName("order_qty");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAT");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.Coupon).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("fk_order_coupon");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("fk_order_paymentMethod");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("fk_order_user");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("tbl_user");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAT");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Pwd)
                .HasMaxLength(20)
                .HasColumnName("pwd");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAT");
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("PRIMARY");

            entity.ToTable("variant");

            entity.HasIndex(e => e.ProductId, "fk_variant_product");

            entity.Property(e => e.VariantId).HasColumnName("variant_id");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("product_id");
            entity.Property(e => e.VariantPrice)
                .HasPrecision(10)
                .HasColumnName("variant_price");
            entity.Property(e => e.VariantQty).HasColumnName("variant_qty");
            entity.Property(e => e.VariantSlug)
                .HasColumnType("text")
                .HasColumnName("variant_slug");

            entity.HasOne(d => d.Product).WithMany(p => p.Variants)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_variant_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
