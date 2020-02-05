using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Flashcard.WebAPI.Migrations
{
    public partial class ExamTestTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    KnownLanguageTypeId = table.Column<int>(nullable: false),
                    LearningLanguageTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTests_LanguageTypes_KnownLanguageTypeId",
                        column: x => x.KnownLanguageTypeId,
                        principalTable: "LanguageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExamTests_LanguageTypes_LearningLanguageTypeId",
                        column: x => x.LearningLanguageTypeId,
                        principalTable: "LanguageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WordAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsValidAnswer = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    WordAnswerWordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamTestWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExamTestId = table.Column<int>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTestWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTestWords_ExamTests_ExamTestId",
                        column: x => x.ExamTestId,
                        principalTable: "ExamTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamTestWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WordAnswerWords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WordAnswerId = table.Column<int>(nullable: false),
                    WordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordAnswerWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordAnswerWords_WordAnswers_WordAnswerId",
                        column: x => x.WordAnswerId,
                        principalTable: "WordAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordAnswerWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamTests_KnownLanguageTypeId",
                table: "ExamTests",
                column: "KnownLanguageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTests_LearningLanguageTypeId",
                table: "ExamTests",
                column: "LearningLanguageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTestWords_ExamTestId",
                table: "ExamTestWords",
                column: "ExamTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTestWords_WordId",
                table: "ExamTestWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordAnswerWords_WordAnswerId",
                table: "WordAnswerWords",
                column: "WordAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_WordAnswerWords_WordId",
                table: "WordAnswerWords",
                column: "WordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamTestWords");

            migrationBuilder.DropTable(
                name: "WordAnswerWords");

            migrationBuilder.DropTable(
                name: "ExamTests");

            migrationBuilder.DropTable(
                name: "WordAnswers");
        }
    }
}
