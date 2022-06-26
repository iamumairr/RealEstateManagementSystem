using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateManagementSystem.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Homes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoOfBathrooms",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoOfBedrooms",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Homes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SquareFoot",
                table: "Homes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearBuilt",
                table: "Homes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Homes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_CategoryId",
                table: "Homes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Categories_CategoryId",
                table: "Homes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Categories_CategoryId",
                table: "Homes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Homes_CategoryId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "NoOfBathrooms",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "NoOfBedrooms",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "SquareFoot",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "YearBuilt",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Homes");
        }
    }
}
