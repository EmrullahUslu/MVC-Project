using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPayCar.Model.Migrations
{
    /// <inheritdoc />
    public partial class Db_Kontrol_Edildi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kilometer",
                table: "Carscs",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "CarbrandsID",
                table: "Carscs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Carbrandss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carscs_CarbrandsID",
                table: "Carscs",
                column: "CarbrandsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carscs_Carbrandss_CarbrandsID",
                table: "Carscs",
                column: "CarbrandsID",
                principalTable: "Carbrandss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carscs_Carbrandss_CarbrandsID",
                table: "Carscs");

            migrationBuilder.DropIndex(
                name: "IX_Carscs_CarbrandsID",
                table: "Carscs");

            migrationBuilder.DropColumn(
                name: "CarbrandsID",
                table: "Carscs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Carbrandss");

            migrationBuilder.AlterColumn<double>(
                name: "Kilometer",
                table: "Carscs",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
