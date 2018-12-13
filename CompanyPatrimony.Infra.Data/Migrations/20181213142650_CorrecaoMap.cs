using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyPatrimony.Infra.Data.Migrations
{
    public partial class CorrecaoMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Brands_BrandId",
                table: "Brand");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brand_BrandId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "NumberTumble",
                table: "Brand");

            migrationBuilder.CreateTable(
                name: "Patrimony",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    NumberTumble = table.Column<string>(type: "varchar(50)", nullable: false),
                    BrandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimony_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_BrandId",
                table: "Patrimony",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patrimony");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "Brand",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brand",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberTumble",
                table: "Brand",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_BrandId",
                table: "Brand",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Brands_BrandId",
                table: "Brand",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
