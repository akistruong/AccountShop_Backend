﻿// <auto-generated />
using System;
using AccountShop.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountShop.EF.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240723035315_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AccountShop.EF.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BranchDsc")
                        .HasColumnType("longtext");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Branches", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryImage")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CategoryRootId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("CategoryRootId");

                    b.HasIndex(new[] { "CategoryName" }, "idx_category");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageDsc")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("VariantId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("VariantId");

                    b.HasIndex(new[] { "ProductId" }, "IDX_imageID");

                    b.HasIndex(new[] { "ImageDsc" }, "IDX_imageName");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Iventory", b =>
                {
                    b.Property<string>("ProductID")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductID", "BranchID");

                    b.HasIndex("BranchID");

                    b.ToTable("Iventory");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Option", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("ProductID");

                    b.ToTable("Options", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.OptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OptionID")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("OptionValueName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("OptionID");

                    b.ToTable("OptionValues", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("Ischeckout")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal?>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("OrderQty")
                        .HasColumnType("int");

                    b.Property<bool?>("OrderStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .HasColumnType("char(20)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.Property<decimal?>("OdtPrice")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("odt_price");

                    b.Property<int?>("OdtQty")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "VariantId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "VariantId" }, "IDX_Ordt_variant");

                    b.HasIndex(new[] { "VariantId", "OrderId" }, "IX_OrderDetail");

                    b.HasIndex(new[] { "OrderId" }, "IX_orderdetail_order_id");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MethodDsc")
                        .HasColumnType("text");

                    b.Property<string>("MethodName")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("PaymentMethods", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductContent")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductDesciption")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductImage")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductSlug")
                        .HasColumnType("longtext");

                    b.Property<string>("RootId")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RootId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(20)
                        .HasColumnType("char(20)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pwd")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("VariantName")
                        .HasColumnType("longtext");

                    b.Property<decimal>("VariantPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VariantQty")
                        .HasColumnType("int");

                    b.Property<int?>("VariantRootId")
                        .HasColumnType("int");

                    b.Property<string>("VariantSlug")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("VariantRootId");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.VariantAttribute", b =>
                {
                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.Property<int>("OptionValueID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("VariantId", "OptionValueID")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "OptionValueID" }, "IX_optionvalue_attribute_OptionValueID");

                    b.HasIndex(new[] { "VariantId" }, "IX_variant_attribute_VariantId");

                    b.ToTable("VariantAttributes", (string)null);
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Category", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Category", "CategoryRoot")
                        .WithMany("InverseCategoryRoot")
                        .HasForeignKey("CategoryRootId")
                        .HasConstraintName("fk_category");

                    b.Navigation("CategoryRoot");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Image", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Product", "Product")
                        .WithMany("TblImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_image_product");

                    b.HasOne("AccountShop.EF.Entities.Variant", "Variant")
                        .WithMany("Images")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_image_variant");

                    b.Navigation("Product");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Iventory", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Branch", "Branch")
                        .WithMany("Iventories")
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Iventory_branch");

                    b.HasOne("AccountShop.EF.Entities.Product", "Product")
                        .WithMany("Iventories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Iventory_product");

                    b.Navigation("Branch");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Option", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Product", "Product")
                        .WithMany("Options")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_option_product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.OptionValue", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Option", "Option")
                        .WithMany("OptionValues")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_optionvalue_option");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Order", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodId")
                        .HasConstraintName("fk_order_paymentMethod");

                    b.HasOne("AccountShop.EF.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_order_user");

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.OrderDetail", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Order", "Order")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("fk_orderdt_order");

                    b.HasOne("AccountShop.EF.Entities.Variant", "Variant")
                        .WithMany("OrderDetails")
                        .HasForeignKey("VariantId")
                        .IsRequired()
                        .HasConstraintName("fk_orderdt_variant");

                    b.Navigation("Order");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Product", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category");

                    b.HasOne("AccountShop.EF.Entities.Product", "Root")
                        .WithMany("InverseRoot")
                        .HasForeignKey("RootId")
                        .HasConstraintName("fk_product_root");

                    b.Navigation("Category");

                    b.Navigation("Root");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Variant", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AccountShop.EF.Entities.Variant", "VariantRoot")
                        .WithMany()
                        .HasForeignKey("VariantRootId");

                    b.Navigation("Product");

                    b.Navigation("VariantRoot");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.VariantAttribute", b =>
                {
                    b.HasOne("AccountShop.EF.Entities.OptionValue", "OptionValue")
                        .WithMany("VariantAttributes")
                        .HasForeignKey("OptionValueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attribute_optionvalue");

                    b.HasOne("AccountShop.EF.Entities.Variant", "Variant")
                        .WithMany("VariantAttributes")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_attribute_variant");

                    b.Navigation("OptionValue");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Branch", b =>
                {
                    b.Navigation("Iventories");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Category", b =>
                {
                    b.Navigation("InverseCategoryRoot");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Option", b =>
                {
                    b.Navigation("OptionValues");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.OptionValue", b =>
                {
                    b.Navigation("VariantAttributes");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Order", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Product", b =>
                {
                    b.Navigation("InverseRoot");

                    b.Navigation("Iventories");

                    b.Navigation("Options");

                    b.Navigation("TblImages");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AccountShop.EF.Entities.Variant", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderDetails");

                    b.Navigation("VariantAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
