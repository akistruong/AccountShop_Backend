﻿// <auto-generated />
using System;
using AccountShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountShop.Migrations
{
    [DbContext(typeof(AccountShopContext))]
    [Migration("20240524011658_order_detail_fix_rename")]
    partial class order_detail_fix_rename
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AccountShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("CategoryImage")
                        .HasColumnType("text")
                        .HasColumnName("category_image");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_name");

                    b.Property<int?>("CategoryRootId")
                        .HasColumnType("int")
                        .HasColumnName("category_root_id");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoryRootId" }, "fk_category");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Coupon", b =>
                {
                    b.Property<string>("CouponId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("coupon_id")
                        .IsFixedLength();

                    b.Property<string>("CouponDsc")
                        .HasColumnType("text")
                        .HasColumnName("coupon_dsc");

                    b.Property<DateTime?>("CouponExpiration")
                        .HasColumnType("datetime")
                        .HasColumnName("coupon_expiration");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAT");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deleteAT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAT");

                    b.HasKey("CouponId")
                        .HasName("PRIMARY");

                    b.ToTable("coupon", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Orderdetail", b =>
                {
                    b.Property<int>("VariantID")
                        .HasColumnType("int");

                    b.Property<decimal?>("OdtPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("odt_price");

                    b.Property<int?>("OdtQty")
                        .HasColumnType("int")
                        .HasColumnName("odt_qty");

                    b.HasKey("VariantID")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "VariantID" }, "IDX_Ordt_variant");

                    b.ToTable("orderdetail", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Paymentmethod", b =>
                {
                    b.Property<int>("MethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("method_id");

                    b.Property<string>("MethodDsc")
                        .HasColumnType("text")
                        .HasColumnName("method_dsc");

                    b.Property<string>("MethodName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("method_name");

                    b.HasKey("MethodId")
                        .HasName("PRIMARY");

                    b.ToTable("paymentmethod", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("product_id")
                        .IsFixedLength();

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("ProductContent")
                        .HasColumnType("text")
                        .HasColumnName("product_content");

                    b.Property<string>("ProductDesciption")
                        .HasColumnType("text")
                        .HasColumnName("product_desciption");

                    b.Property<string>("ProductImage")
                        .HasColumnType("text")
                        .HasColumnName("product_image");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("product_name");

                    b.Property<decimal?>("ProductPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("product_price");

                    b.Property<string>("ProductRootProductId")
                        .HasColumnType("char(10)");

                    b.Property<string>("ProductSlug")
                        .HasColumnType("text")
                        .HasColumnName("product_slug");

                    b.Property<string>("RootID")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.HasIndex("ProductRootProductId");

                    b.HasIndex(new[] { "CategoryId" }, "fk_product_category");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.TblImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("image_id");

                    b.Property<string>("ImageDsc")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("image_dsc");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("ProductId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("product_id")
                        .IsFixedLength();

                    b.HasKey("ImageId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "fk_image_product");

                    b.ToTable("tbl_image", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.TblOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<string>("CouponId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("coupon_id")
                        .IsFixedLength();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAT");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("deletedAT");

                    b.Property<bool?>("Ischeckout")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("ischeckout")
                        .HasDefaultValueSql("'0'");

                    b.Property<decimal?>("OrderPrice")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("order_price")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("OrderQty")
                        .HasColumnType("int")
                        .HasColumnName("order_qty");

                    b.Property<bool?>("OrderStatus")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("order_status");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("payment_method_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAT");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("char(30)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.HasKey("OrderId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CouponId" }, "fk_order_coupon");

                    b.HasIndex(new[] { "PaymentMethodId" }, "fk_order_paymentMethod");

                    b.HasIndex(new[] { "Username" }, "fk_order_user");

                    b.ToTable("tbl_order", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.TblUser", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("char(30)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAT");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Pwd")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("pwd");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAT");

                    b.HasKey("Username")
                        .HasName("PRIMARY");

                    b.ToTable("tbl_user", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Variant", b =>
                {
                    b.Property<int>("VariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("variant_id");

                    b.Property<string>("ProductId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("product_id")
                        .IsFixedLength();

                    b.Property<string>("VariantName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("VariantPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("variant_price");

                    b.Property<int?>("VariantQty")
                        .HasColumnType("int")
                        .HasColumnName("variant_qty");

                    b.Property<string>("VariantSlug")
                        .HasColumnType("text")
                        .HasColumnName("variant_slug");

                    b.HasKey("VariantId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ProductId" }, "fk_variant_product");

                    b.ToTable("variant", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Category", b =>
                {
                    b.HasOne("AccountShop.Models.Category", "CategoryRoot")
                        .WithMany("InverseCategoryRoot")
                        .HasForeignKey("CategoryRootId")
                        .HasConstraintName("fk_category");

                    b.Navigation("CategoryRoot");
                });

            modelBuilder.Entity("AccountShop.Models.Orderdetail", b =>
                {
                    b.HasOne("AccountShop.Models.Variant", "Variant")
                        .WithMany("Orderdetails")
                        .HasForeignKey("VariantID")
                        .IsRequired()
                        .HasConstraintName("fk_orderdt_variant");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.Models.Product", b =>
                {
                    b.HasOne("AccountShop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category");

                    b.HasOne("AccountShop.Models.Product", "ProductRoot")
                        .WithMany("Products")
                        .HasForeignKey("ProductRootProductId");

                    b.Navigation("Category");

                    b.Navigation("ProductRoot");
                });

            modelBuilder.Entity("AccountShop.Models.TblImage", b =>
                {
                    b.HasOne("AccountShop.Models.Product", "Product")
                        .WithMany("TblImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_image_product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.Models.TblOrder", b =>
                {
                    b.HasOne("AccountShop.Models.Coupon", "Coupon")
                        .WithMany("TblOrders")
                        .HasForeignKey("CouponId")
                        .HasConstraintName("fk_order_coupon");

                    b.HasOne("AccountShop.Models.Paymentmethod", "PaymentMethod")
                        .WithMany("TblOrders")
                        .HasForeignKey("PaymentMethodId")
                        .HasConstraintName("fk_order_paymentMethod");

                    b.HasOne("AccountShop.Models.TblUser", "UsernameNavigation")
                        .WithMany("TblOrders")
                        .HasForeignKey("Username")
                        .HasConstraintName("fk_order_user");

                    b.Navigation("Coupon");

                    b.Navigation("PaymentMethod");

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("AccountShop.Models.Variant", b =>
                {
                    b.HasOne("AccountShop.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_variant_product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.Models.Category", b =>
                {
                    b.Navigation("InverseCategoryRoot");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("AccountShop.Models.Coupon", b =>
                {
                    b.Navigation("TblOrders");
                });

            modelBuilder.Entity("AccountShop.Models.Paymentmethod", b =>
                {
                    b.Navigation("TblOrders");
                });

            modelBuilder.Entity("AccountShop.Models.Product", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("TblImages");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("AccountShop.Models.TblUser", b =>
                {
                    b.Navigation("TblOrders");
                });

            modelBuilder.Entity("AccountShop.Models.Variant", b =>
                {
                    b.Navigation("Orderdetails");
                });
#pragma warning restore 612, 618
        }
    }
}
