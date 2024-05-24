using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class tbl_variantAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "variant_attribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "varchar(50)", nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", nullable: false),
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
                name: "variant_attribute");
        }
    }
}
