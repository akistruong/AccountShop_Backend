using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class model_variants_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariantStock",
                table: "variant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VariantID",
                table: "orderdetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "variantAttribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AttributeId);
                    table.ForeignKey(
                        name: "fk_variant_attribute",
                        column: x => x.VariantId,
                        principalTable: "variant",
                        principalColumn: "variant_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_variantAttribute_VariantId",
                table: "variantAttribute",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail",
                column: "VariantID",
                principalTable: "variant",
                principalColumn: "variant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderdt_variant",
                table: "orderdetail");

            migrationBuilder.DropTable(
                name: "variantAttribute");

            migrationBuilder.DropIndex(
                name: "IX_orderdetail_VariantID",
                table: "orderdetail");

            migrationBuilder.DropColumn(
                name: "VariantStock",
                table: "variant");

            migrationBuilder.DropColumn(
                name: "VariantID",
                table: "orderdetail");
        }
    }
}
