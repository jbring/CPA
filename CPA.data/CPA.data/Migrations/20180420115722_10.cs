using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Buy",
                nullable: true,
                oldClrType: typeof(int));

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy",
                column: "CustomerId",
                unique: true);

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
