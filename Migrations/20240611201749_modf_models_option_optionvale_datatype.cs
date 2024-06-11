using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class modf_models_option_optionvale_datatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_optionvalue_option",
                table: "OptionValues");

            migrationBuilder.AlterColumn<string>(
                name: "OptionValueID",
                table: "variant_attribute",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OptionID",
                table: "OptionValues",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OptionValueID",
                table: "OptionValues",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "OptionID",
                table: "Options",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionValues_Options_OptionID",
                table: "OptionValues",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_attribute_optionvalue",
                table: "variant_attribute",
                column: "OptionValueID",
                principalTable: "OptionValues",
                principalColumn: "OptionValueID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionValues_Options_OptionID",
                table: "OptionValues");

            migrationBuilder.DropForeignKey(
                name: "fk_attribute_optionvalue",
                table: "variant_attribute");

            migrationBuilder.AlterColumn<int>(
                name: "OptionValueID",
                table: "variant_attribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<int>(
                name: "OptionID",
                table: "OptionValues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<int>(
                name: "OptionValueID",
                table: "OptionValues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "OptionID",
                table: "Options",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "fk_optionvalue_option",
                table: "OptionValues",
                column: "OptionID",
                principalTable: "Options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
