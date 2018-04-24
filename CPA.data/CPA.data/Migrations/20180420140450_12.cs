using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Platform = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Where",
                table: "Buy",
                nullable: false,
                defaultValue: 0);
        }
    }
}
