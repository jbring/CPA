using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_When_WhenId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhenId",
                table: "Buy");

            migrationBuilder.AlterColumn<int>(
                name: "WhyId",
                table: "Buy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WhenId",
                table: "Buy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WhatId",
                table: "Buy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WhereId",
                table: "Buy",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "What",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_What", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Why",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Why", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhatId",
                table: "Buy",
                column: "WhatId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhenId",
                table: "Buy",
                column: "WhenId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhereId",
                table: "Buy",
                column: "WhereId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_WhyId",
                table: "Buy",
                column: "WhyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_What_WhatId",
                table: "Buy",
                column: "WhatId",
                principalTable: "What",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_When_WhenId",
                table: "Buy",
                column: "WhenId",
                principalTable: "When",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Where_WhereId",
                table: "Buy",
                column: "WhereId",
                principalTable: "Where",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Why_WhyId",
                table: "Buy",
                column: "WhyId",
                principalTable: "Why",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Customers_CustomerId",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_What_WhatId",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_When_WhenId",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Where_WhereId",
                table: "Buy");

            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Why_WhyId",
                table: "Buy");

            migrationBuilder.DropTable(
                name: "What");

            migrationBuilder.DropTable(
                name: "Where");

            migrationBuilder.DropTable(
                name: "Why");

            migrationBuilder.DropIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhatId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhenId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhereId",
                table: "Buy");

            migrationBuilder.DropIndex(
                name: "IX_Buy_WhyId",
                table: "Buy");

            migrationBuilder.DropColumn(
                name: "WhereId",
                table: "Buy");

            migrationBuilder.AlterColumn<int>(
                name: "WhyId",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WhenId",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WhatId",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
