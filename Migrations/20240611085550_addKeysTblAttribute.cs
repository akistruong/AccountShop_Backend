using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class addKeysTblAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute");

            migrationBuilder.AddColumn<int>(
                name: "OptionValueID",
                table: "variant_attribute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute",
                columns: new[] { "VariantId", "OptionValueID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute");

            migrationBuilder.DropColumn(
                name: "OptionValueID",
                table: "variant_attribute");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute",
                column: "VariantId");
        }
    }
}
