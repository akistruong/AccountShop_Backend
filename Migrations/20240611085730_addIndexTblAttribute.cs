using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class addIndexTblAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "variant_attribute");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "variant_attribute");

            migrationBuilder.CreateIndex(
                name: "IX_optionvalue_attribute_OptionValueID",
                table: "variant_attribute",
                column: "OptionValueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_optionvalue_attribute_OptionValueID",
                table: "variant_attribute");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "variant_attribute",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "variant_attribute",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
