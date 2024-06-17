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
    [Migration("20240617103529_add_model_Branch-Inventory")]
    partial class add_model_BranchInventory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AccountShop.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BranchDsc")
                        .HasColumnType("text");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("BranchID");

                    b.ToTable("Branches");
                });

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

            modelBuilder.Entity("AccountShop.Models.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Iventory", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("char(10)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "BranchID");

                    b.HasIndex("BranchID");

                    b.ToTable("Iventories");
                });

            modelBuilder.Entity("AccountShop.Models.Option", b =>
                {
                    b.Property<string>("OptionID")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("option_name");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.HasKey("OptionID")
                        .HasName("PRIMARY");

                    b.HasIndex("ProductID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("AccountShop.Models.OptionValue", b =>
                {
                    b.Property<string>("OptionValueID")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("OptionID")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("OptionValueName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("optionvalue_name");

                    b.HasKey("OptionValueID")
                        .HasName("PRIMARY");

                    b.HasIndex("OptionID");

                    b.ToTable("OptionValues");
                });

            modelBuilder.Entity("AccountShop.Models.Orderdetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("VariantId")
                        .HasColumnType("int")
                        .HasColumnName("VariantID");

                    b.Property<decimal?>("OdtPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("odt_price");

                    b.Property<int?>("OdtQty")
                        .HasColumnType("int")
                        .HasColumnName("odt_qty");

                    b.HasKey("OrderId", "VariantId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "VariantId" }, "IDX_Ordt_variant");

                    b.HasIndex(new[] { "OrderId" }, "IX_orderdetail_order_id");

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

                    b.Property<string>("ProductSlug")
                        .HasColumnType("text")
                        .HasColumnName("product_slug");

                    b.Property<string>("RootId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("RootID")
                        .IsFixedLength();

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RootId" }, "IX_product_RootID");

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

                    b.Property<int?>("VariantId")
                        .HasColumnType("int");

                    b.HasKey("ImageId")
                        .HasName("PRIMARY");

                    b.HasIndex("VariantId");

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
                        .HasDefaultValueSql("'0.00'");

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
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("VariantPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("variant_price");

                    b.Property<int?>("VariantQty")
                        .HasColumnType("int")
                        .HasColumnName("variant_qty");

                    b.Property<int?>("VariantRootID")
                        .HasColumnType("int");

                    b.Property<string>("VariantSlug")
                        .HasColumnType("text")
                        .HasColumnName("variant_slug");

                    b.HasKey("VariantId")
                        .HasName("PRIMARY");

                    b.HasIndex("VariantRootID");

                    b.HasIndex(new[] { "ProductId" }, "fk_variant_product");

                    b.ToTable("variant", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.VariantAttribute", b =>
                {
                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.Property<string>("OptionValueID")
                        .HasColumnType("varchar(10)");

                    b.HasKey("VariantId", "OptionValueID")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "OptionValueID" }, "IX_optionvalue_attribute_OptionValueID");

                    b.HasIndex(new[] { "VariantId" }, "IX_variant_attribute_VariantId");

                    b.ToTable("variant_attribute", (string)null);
                });

            modelBuilder.Entity("AccountShop.Models.Category", b =>
                {
                    b.HasOne("AccountShop.Models.Category", "CategoryRoot")
                        .WithMany("InverseCategoryRoot")
                        .HasForeignKey("CategoryRootId")
                        .HasConstraintName("fk_category");

                    b.Navigation("CategoryRoot");
                });

            modelBuilder.Entity("AccountShop.Models.Iventory", b =>
                {
                    b.HasOne("AccountShop.Models.Branch", "Branch")
                        .WithMany("Iventories")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Iventory_branch");

                    b.HasOne("AccountShop.Models.Product", "Product")
                        .WithMany("Iventories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Iventory_product");

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.Models.Option", b =>
                {
                    b.HasOne("AccountShop.Models.Product", "Product")
                        .WithMany("Options")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_option_product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.Models.OptionValue", b =>
                {
                    b.HasOne("AccountShop.Models.Option", "Option")
                        .WithMany("OptionValues")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_optionvalue_option");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("AccountShop.Models.Orderdetail", b =>
                {
                    b.HasOne("AccountShop.Models.TblOrder", "Order")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("fk_orderdt_order");

                    b.HasOne("AccountShop.Models.Variant", "Variant")
                        .WithMany("Orderdetails")
                        .HasForeignKey("VariantId")
                        .IsRequired()
                        .HasConstraintName("fk_orderdt_variant");

                    b.Navigation("Order");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.Models.Product", b =>
                {
                    b.HasOne("AccountShop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category");

                    b.HasOne("AccountShop.Models.Product", "Root")
                        .WithMany("InverseRoot")
                        .HasForeignKey("RootId")
                        .HasConstraintName("fk_product_root");

                    b.Navigation("Category");

                    b.Navigation("Root");
                });

            modelBuilder.Entity("AccountShop.Models.TblImage", b =>
                {
                    b.HasOne("AccountShop.Models.Product", "Product")
                        .WithMany("TblImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_image_product");

                    b.HasOne("AccountShop.Models.Variant", "Variant")
                        .WithMany("Images")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_image_variant");

                    b.Navigation("Product");

                    b.Navigation("Variant");
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

                    b.HasOne("AccountShop.Models.Variant", "VariantRoot")
                        .WithMany("Children")
                        .HasForeignKey("VariantRootID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_variant_children");

                    b.Navigation("Product");

                    b.Navigation("VariantRoot");
                });

            modelBuilder.Entity("AccountShop.Models.VariantAttribute", b =>
                {
                    b.HasOne("AccountShop.Models.OptionValue", "OptionValue")
                        .WithMany("VariantAttributes")
                        .HasForeignKey("OptionValueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attribute_optionvalue");

                    b.HasOne("AccountShop.Models.Variant", "Variant")
                        .WithMany("VariantAttributes")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attribute_variant");

                    b.Navigation("OptionValue");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.Models.Branch", b =>
                {
                    b.Navigation("Iventories");
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

            modelBuilder.Entity("AccountShop.Models.Option", b =>
                {
                    b.Navigation("OptionValues");
                });

            modelBuilder.Entity("AccountShop.Models.OptionValue", b =>
                {
                    b.Navigation("VariantAttributes");
                });

            modelBuilder.Entity("AccountShop.Models.Paymentmethod", b =>
                {
                    b.Navigation("TblOrders");
                });

            modelBuilder.Entity("AccountShop.Models.Product", b =>
                {
                    b.Navigation("InverseRoot");

                    b.Navigation("Iventories");

                    b.Navigation("Options");

                    b.Navigation("TblImages");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("AccountShop.Models.TblOrder", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("AccountShop.Models.TblUser", b =>
                {
                    b.Navigation("TblOrders");
                });

            modelBuilder.Entity("AccountShop.Models.Variant", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Images");

                    b.Navigation("Orderdetails");

                    b.Navigation("VariantAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
