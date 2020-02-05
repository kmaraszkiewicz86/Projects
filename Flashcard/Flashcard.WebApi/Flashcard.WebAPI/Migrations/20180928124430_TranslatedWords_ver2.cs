using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Flashcard.WebAPI.Migrations
{
    public partial class TranslatedWords_ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslateWords");

            migrationBuilder.DropTable(
                name: "EnglishWords");

            migrationBuilder.CreateTable(
                name: "LanguageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    LanguageTypeId = table.Column<int>(nullable: false),
                    ParentWordId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_LanguageTypes_LanguageTypeId",
                        column: x => x.LanguageTypeId,
                        principalTable: "LanguageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_Words_ParentWordId",
                        column: x => x.ParentWordId,
                        principalTable: "Words",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_CategoryId",
                table: "Words",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageTypeId",
                table: "Words",
                column: "LanguageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ParentWordId",
                table: "Words",
                column: "ParentWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "LanguageTypes");

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
    }
}
