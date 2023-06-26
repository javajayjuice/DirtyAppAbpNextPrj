using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "StoredFiles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "ApplicantSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "ApplicantSubjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "StoredFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "ApplicantSubjects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "ApplicantSubjects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
