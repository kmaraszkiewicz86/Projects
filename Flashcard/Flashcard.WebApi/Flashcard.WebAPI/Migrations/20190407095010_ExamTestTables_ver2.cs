using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Flashcard.WebAPI.Migrations
{
    public partial class ExamTestTables_ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamTestId",
                table: "WordAnswerWords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WordAnswerWords_ExamTestId",
                table: "WordAnswerWords",
                column: "ExamTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordAnswerWords_ExamTests_ExamTestId",
                table: "WordAnswerWords",
                column: "ExamTestId",
                principalTable: "ExamTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordAnswerWords_ExamTests_ExamTestId",
                table: "WordAnswerWords");

            migrationBuilder.DropIndex(
                name: "IX_WordAnswerWords_ExamTestId",
                table: "WordAnswerWords");

            migrationBuilder.DropColumn(
                name: "ExamTestId",
                table: "WordAnswerWords");
        }
    }
}
