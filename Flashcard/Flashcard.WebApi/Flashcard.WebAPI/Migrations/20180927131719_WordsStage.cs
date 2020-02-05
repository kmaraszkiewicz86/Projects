using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Flashcard.WebAPI.Migrations
{
    public partial class WordsStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnglishWords_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslateWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnglishWordId = table.Column<int>(nullable: false),
                    TranslatedWord = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateWords_EnglishWords_EnglishWordId",
                        column: x => x.EnglishWordId,
                        principalTable: "EnglishWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnglishWords_CategoryId",
                table: "EnglishWords",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslateWords_EnglishWordId",
                table: "TranslateWords",
                column: "EnglishWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslateWords");

            migrationBuilder.DropTable(
                name: "EnglishWords");
        }
    }
}
