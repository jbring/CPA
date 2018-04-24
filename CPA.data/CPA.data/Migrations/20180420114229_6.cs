using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhenId",
                table: "Buy",
                column: "WhenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_When_WhenId",
                table: "Buy",
                column: "WhenId",
                principalTable: "When",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_When_WhenId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhenId",
                table: "Buy");
        }
    }
}
