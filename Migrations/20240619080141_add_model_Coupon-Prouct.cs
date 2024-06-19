using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class add_model_CouponProuct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupon_Products",
                columns: table => new
                {
                    CouponID = table.Column<string>(type: "char(10)", nullable: false),
                    ProductID = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon_Products", x => new { x.CouponID, x.ProductID });
                    table.ForeignKey(
                        name: "fk_Coupon_Product_Coupon",
                        column: x => x.CouponID,
                        principalTable: "coupon",
                        principalColumn: "coupon_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Coupon_Product_Product",
                        column: x => x.ProductID,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_Products_ProductID",
                table: "Coupon_Products",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupon_Products");
        }
    }
}
