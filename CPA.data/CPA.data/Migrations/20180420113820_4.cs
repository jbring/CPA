using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
