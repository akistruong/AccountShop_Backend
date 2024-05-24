using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class models_variantAtt_addFieldValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "variantAttribute",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "variantAttribute");
        }
    }
}
