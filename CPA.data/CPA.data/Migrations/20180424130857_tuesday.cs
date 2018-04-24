using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CPA.data.Migrations
{
    public partial class tuesday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.RenameColumn(
                name: "IsBarginBuy",
                table: "Why",
                newName: "IsBarginPurchase");

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    WhatId = table.Column<int>(nullable: true),
                    WhenId = table.Column<int>(nullable: true),
                    WhereId = table.Column<int>(nullable: true),
                    WhyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_What_WhatId",
                        column: x => x.WhatId,
                        principalTable: "What",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_When_WhenId",
                        column: x => x.WhenId,
                        principalTable: "When",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Where_WhereId",
                        column: x => x.WhereId,
                        principalTable: "Where",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Why_WhyId",
                        column: x => x.WhyId,
                        principalTable: "Why",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CustomerId",
                table: "Purchase",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_WhatId",
                table: "Purchase",
                column: "WhatId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_WhenId",
                table: "Purchase",
                column: "WhenId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_WhereId",
                table: "Purchase",
                column: "WhereId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_WhyId",
                table: "Purchase",
                column: "WhyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.RenameColumn(
                name: "IsBarginPurchase",
                table: "Why",
                newName: "IsBarginBuy");

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    WhatId = table.Column<int>(nullable: true),
                    WhenId = table.Column<int>(nullable: true),
                    WhereId = table.Column<int>(nullable: true),
                    WhyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buy_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buy_What_WhatId",
                        column: x => x.WhatId,
                        principalTable: "What",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buy_When_WhenId",
                        column: x => x.WhenId,
                        principalTable: "When",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buy_Where_WhereId",
                        column: x => x.WhereId,
                        principalTable: "Where",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buy_Why_WhyId",
                        column: x => x.WhyId,
                        principalTable: "Why",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buy_CustomerId",
                table: "Buy",
                column: "CustomerId");

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
        }
    }
}
