using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class modf_models_option_optionvale_addContrainst_optionvalue_option : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionValues_Options_OptionID",
                table: "OptionValues");

            migrationBuilder.AddForeignKey(
                name: "fk_optionvalue_option",
                table: "OptionValues",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_optionvalue_option",
                table: "OptionValues");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionValues_Options_OptionID",
                table: "OptionValues",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
