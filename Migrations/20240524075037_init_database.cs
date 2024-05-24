using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class init_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ProductVersion = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    category_image = table.Column<string>(type: "text", nullable: true),
                    category_root_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.category_id);
                    table.ForeignKey(
                        name: "fk_category",
                        column: x => x.category_root_id,
                        principalTable: "category",
                        principalColumn: "category_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    coupon_id = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: false),
                    coupon_dsc = table.Column<string>(type: "text", nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    deleteAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    coupon_expiration = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.coupon_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paymentmethod",
                columns: table => new
                {
                    method_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    method_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    method_dsc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.method_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    username = table.Column<string>(type: "char(30)", fixedLength: true, maxLength: 30, nullable: false),
                    pwd = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    createdAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.username);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: false),
                    product_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    product_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    product_image = table.Column<string>(type: "text", nullable: true),
                    product_desciption = table.Column<string>(type: "text", nullable: true),
                    product_slug = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    product_content = table.Column<string>(type: "text", nullable: true),
                    RootID = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_id);
                    table.ForeignKey(
                        name: "fk_product_category",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "fk_product_root",
                        column: x => x.RootID,
                        principalTable: "product",
                        principalColumn: "product_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    createdAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletedAT = table.Column<DateTime>(type: "datetime", nullable: true),
                    order_qty = table.Column<int>(type: "int", nullable: true),
                    order_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true, defaultValueSql: "'0.00'"),
                    order_status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    payment_method_id = table.Column<int>(type: "int", nullable: true),
                    coupon_id = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true),
                    username = table.Column<string>(type: "char(30)", fixedLength: true, maxLength: 30, nullable: true),
                    ischeckout = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.order_id);
                    table.ForeignKey(
                        name: "fk_order_coupon",
                        column: x => x.coupon_id,
                        principalTable: "coupon",
                        principalColumn: "coupon_id");
                    table.ForeignKey(
                        name: "fk_order_paymentMethod",
                        column: x => x.payment_method_id,
                        principalTable: "paymentmethod",
                        principalColumn: "method_id");
                    table.ForeignKey(
                        name: "fk_order_user",
                        column: x => x.username,
                        principalTable: "tbl_user",
                        principalColumn: "username");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_image",
                columns: table => new
                {
                    image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    image_url = table.Column<string>(type: "text", nullable: true),
                    image_dsc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    product_id = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.image_id);
                    table.ForeignKey(
                        name: "fk_image_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "variant",
                columns: table => new
                {
                    variant_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    product_id = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true),
                    variant_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true),
                    variant_slug = table.Column<string>(type: "text", nullable: true),
                    variant_qty = table.Column<int>(type: "int", nullable: true),
                    VariantName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.variant_id);
                    table.ForeignKey(
                        name: "fk_variant_product",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orderdetail",
                columns: table => new
                {
                    VariantID = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    odt_qty = table.Column<int>(type: "int", nullable: true),
                    odt_price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.order_id, x.VariantID });
                    table.ForeignKey(
                        name: "fk_orderdt_order",
                        column: x => x.order_id,
                        principalTable: "tbl_order",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "fk_orderdt_variant",
                        column: x => x.VariantID,
                        principalTable: "variant",
                        principalColumn: "variant_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "variant_attribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AttributeId);
                    table.ForeignKey(
                        name: "fk_attribute_variant",
                        column: x => x.VariantId,
                        principalTable: "variant",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_category",
                table: "category",
                column: "category_root_id");

            migrationBuilder.CreateIndex(
                name: "IDX_Ordt_variant",
                table: "orderdetail",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_order_id",
                table: "orderdetail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "fk_product_category",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_RootID",
                table: "product",
                column: "RootID");

            migrationBuilder.CreateIndex(
                name: "fk_image_product",
                table: "tbl_image",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "fk_order_coupon",
                table: "tbl_order",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "fk_order_paymentMethod",
                table: "tbl_order",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "fk_order_user",
                table: "tbl_order",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "fk_variant_product",
                table: "variant",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "idx_attribute",
                table: "variant_attribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_variant_attribute_VariantId",
                table: "variant_attribute",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "orderdetail");

            migrationBuilder.DropTable(
                name: "tbl_image");

            migrationBuilder.DropTable(
                name: "variant_attribute");

            migrationBuilder.DropTable(
                name: "tbl_order");

            migrationBuilder.DropTable(
                name: "variant");

            migrationBuilder.DropTable(
                name: "coupon");

            migrationBuilder.DropTable(
                name: "paymentmethod");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
