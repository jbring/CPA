using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Impulse",
                table: "Why",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBarginBuy",
                table: "Why",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromPriceRunner",
                table: "Why",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTestWinner",
                table: "Why",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Impulse",
                table: "Why");

            migrationBuilder.DropColumn(
                name: "IsBarginBuy",
                table: "Why");

            migrationBuilder.DropColumn(
                name: "IsFromPriceRunner",
                table: "Why");

            migrationBuilder.DropColumn(
                name: "IsTestWinner",
                table: "Why");
        }
    }
}
