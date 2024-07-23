using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BranchName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BranchDsc = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CategoryImage = table.Column<string>(type: "text", nullable: true),
                    CategoryRootId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_category",
                        column: x => x.CategoryRootId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MethodName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    MethodDsc = table.Column<string>(type: "text", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Pwd = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductImage = table.Column<string>(type: "longtext", nullable: true),
                    ProductDesciption = table.Column<string>(type: "longtext", nullable: true),
                    ProductSlug = table.Column<string>(type: "longtext", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductContent = table.Column<string>(type: "longtext", nullable: true),
                    RootId = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "fk_product_category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_product_root",
                        column: x => x.RootId,
                        principalTable: "Products",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderStatus = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "char(20)", nullable: true),
                    Ischeckout = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_order_paymentMethod",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_order_user",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Iventory",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "varchar(20)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iventory", x => new { x.ProductID, x.BranchID });
                    table.ForeignKey(
                        name: "fk_Iventory_branch",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Iventory_product",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    OptionName = table.Column<string>(type: "longtext", nullable: false),
                    ProductID = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_option_product",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<string>(type: "varchar(20)", nullable: false),
                    VariantPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariantSlug = table.Column<string>(type: "longtext", nullable: false),
                    VariantQty = table.Column<int>(type: "int", nullable: false),
                    VariantName = table.Column<string>(type: "longtext", nullable: true),
                    VariantRootId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variant_Variant_VariantRootId",
                        column: x => x.VariantRootId,
                        principalTable: "Variant",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OptionID = table.Column<string>(type: "varchar(30)", nullable: false),
                    OptionValueName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_optionvalue_option",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImageDsc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "fk_image_product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_image_variant",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: false),
                    OdtQty = table.Column<int>(type: "int", nullable: true),
                    odt_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.OrderId, x.VariantId });
                    table.ForeignKey(
                        name: "fk_orderdt_order",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_orderdt_variant",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VariantAttributes",
                columns: table => new
                {
                    OptionValueID = table.Column<int>(type: "int", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAT = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.VariantId, x.OptionValueID });
                    table.ForeignKey(
                        name: "fk_attribute_optionvalue",
                        column: x => x.OptionValueID,
                        principalTable: "OptionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_attribute_variant",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_category",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryRootId",
                table: "Categories",
                column: "CategoryRootId");

            migrationBuilder.CreateIndex(
                name: "IDX_imageID",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IDX_imageName",
                table: "Images",
                column: "ImageDsc");

            migrationBuilder.CreateIndex(
                name: "IX_Images_VariantId",
                table: "Images",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Iventory_BranchID",
                table: "Iventory",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ProductID",
                table: "Options",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OptionValues_OptionID",
                table: "OptionValues",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IDX_Ordt_variant",
                table: "OrderDetails",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail",
                table: "OrderDetails",
                columns: new[] { "VariantId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_order_id",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RootId",
                table: "Products",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_ProductId",
                table: "Variant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variant_VariantRootId",
                table: "Variant",
                column: "VariantRootId");

            migrationBuilder.CreateIndex(
                name: "IX_optionvalue_attribute_OptionValueID",
                table: "VariantAttributes",
                column: "OptionValueID");

            migrationBuilder.CreateIndex(
                name: "IX_variant_attribute_VariantId",
                table: "VariantAttributes",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Iventory");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "VariantAttributes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OptionValues");

            migrationBuilder.DropTable(
                name: "Variant");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
