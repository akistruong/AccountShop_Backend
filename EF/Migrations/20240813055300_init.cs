using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Dev.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchDsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryImage = table.Column<string>(type: "text", nullable: true),
                    CategoryRootId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "fk_category",
                        column: x => x.CategoryRootId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MethodDsc = table.Column<string>(type: "text", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Pwd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDesciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "fk_product_category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_root",
                        column: x => x.RootId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderQty = table.Column<int>(type: "int", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderStatus = table.Column<bool>(type: "bit", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nchar(20)", nullable: true),
                    Ischeckout = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "Iventory",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "fk_option_product",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    VariantPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VariantSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariantQty = table.Column<int>(type: "int", nullable: false),
                    VariantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariantRootId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "OptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionID = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    OptionValueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "fk_optionvalue_option",
                        column: x => x.OptionID,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ImageDsc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_image_variant",
                        column: x => x.VariantId,
                        principalTable: "Variant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdtQty = table.Column<int>(type: "int", nullable: true),
                    odt_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.VariantId });
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
                });

            migrationBuilder.CreateTable(
                name: "VariantAttributes",
                columns: table => new
                {
                    OptionValueID = table.Column<int>(type: "int", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantAttributes", x => new { x.VariantId, x.OptionValueID });
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_category",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryRootId",
                table: "Categories",
                column: "CategoryRootId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

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
