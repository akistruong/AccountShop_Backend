using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountShop.Migrations
{
    /// <inheritdoc />
    public partial class modf_model_coupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplyTo",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CouponType",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "coupon",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxUses",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxUses_Per_User",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinQtyOrder",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsedCount",
                table: "coupon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyTo",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "CouponType",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "MaxUses",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "MaxUses_Per_User",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "MinQtyOrder",
                table: "coupon");

            migrationBuilder.DropColumn(
                name: "UsedCount",
                table: "coupon");
        }
    }
}
