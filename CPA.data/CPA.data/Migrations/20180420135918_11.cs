using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Where_WhereId",
                table: "Buy");

            migrationBuilder.DropTable(
                name: "Where");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhereId",
                table: "Buy");

            migrationBuilder.DropColumn(
                name: "WhereId",
                table: "Buy");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "When",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "What",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceRange",
                table: "What",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Where",
                table: "Buy",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "When");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "What");

            migrationBuilder.DropColumn(
                name: "PriceRange",
                table: "What");

            migrationBuilder.DropColumn(
                name: "Where",
                table: "Buy");

            migrationBuilder.AddColumn<int>(
                name: "WhereId",
                table: "Buy",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Where",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Where", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhereId",
                table: "Buy",
                column: "WhereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Where_WhereId",
                table: "Buy",
                column: "WhereId",
                principalTable: "Where",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
