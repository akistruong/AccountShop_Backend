using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class model_TblUser_addField_LoginMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoginMethod",
                table: "tbl_user",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                defaultValue: "Default");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginMethod",
                table: "tbl_user");
        }
    }
}
