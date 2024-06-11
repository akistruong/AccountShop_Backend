using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class changePKTbl_Attreibute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "variant_attribute");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "variant_attribute");

            migrationBuilder.RenameColumn(
                name: "AttributeId",
                table: "variant_attribute",
                newName: "OptionValueID");

            migrationBuilder.RenameIndex(
                name: "idx_attribute",
                table: "variant_attribute",
                newName: "IX_optionvalue_attribute_OptionValueID");

            migrationBuilder.AlterColumn<int>(
                name: "OptionValueID",
                table: "variant_attribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute",
                columns: new[] { "VariantId", "OptionValueID" });

            migrationBuilder.AddForeignKey(
                name: "FK_variant_attribute_OptionValues_OptionValueID",
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
                name: "FK_variant_attribute_OptionValues_OptionValueID",
                table: "variant_attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute");

            migrationBuilder.RenameColumn(
                name: "OptionValueID",
                table: "variant_attribute",
                newName: "AttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_optionvalue_attribute_OptionValueID",
                table: "variant_attribute",
                newName: "idx_attribute");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeId",
                table: "variant_attribute",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

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

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "variant_attribute",
                column: "AttributeId");
        }
    }
}
