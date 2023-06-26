using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class twentythree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Persons_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationStatuses_Applications_ApplicationId",
                table: "ApplicationStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Institutions_InstitutionId",
                table: "Campuses");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteFaculties_Campuses_CampusId",
                table: "InstituteFaculties");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteFaculties_Faculties_FacultyId",
                table: "InstituteFaculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles");

            migrationBuilder.DropIndex(
                name: "IX_Campuses_InstitutionId",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Campuses");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "StoredFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Qualifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "Qualifications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Institutions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                table: "InstituteFaculties",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CampusId",
                table: "InstituteFaculties",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionsId",
                table: "Campuses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationId",
                table: "ApplicationStatuses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AlterColumn<int>(
                name: "Province",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PostalCode",
                table: "Address",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_InstitutionsId",
                table: "Campuses",
                column: "InstitutionsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Persons_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationStatuses_Applications_ApplicationId",
                table: "ApplicationStatuses",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Institutions_InstitutionsId",
                table: "Campuses",
                column: "InstitutionsId",
                principalTable: "Institutions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteFaculties_Campuses_CampusId",
                table: "InstituteFaculties",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteFaculties_Faculties_FacultyId",
                table: "InstituteFaculties",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Subjects_SubjectId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Persons_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationStatuses_Applications_ApplicationId",
                table: "ApplicationStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_Campuses_Institutions_InstitutionsId",
                table: "Campuses");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteFaculties_Campuses_CampusId",
                table: "InstituteFaculties");

            migrationBuilder.DropForeignKey(
                name: "FK_InstituteFaculties_Faculties_FacultyId",
                table: "InstituteFaculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles");

            migrationBuilder.DropIndex(
                name: "IX_Campuses_InstitutionsId",
                table: "Campuses");

            migrationBuilder.DropColumn(
                name: "InstitutionsId",
                table: "Campuses");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "StoredFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Qualifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "Qualifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Institutions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "FacultyId",
                table: "InstituteFaculties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CampusId",
                table: "InstituteFaculties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionId",
                table: "Campuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationId",
                table: "ApplicationStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InstitutionId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicantId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Province",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_InstitutionId",
                table: "Campuses",
                column: "InstitutionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Institutions_InstitutionId",
                table: "Applications",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Persons_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationStatuses_Applications_ApplicationId",
                table: "ApplicationStatuses",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campuses_Institutions_InstitutionId",
                table: "Campuses",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteFaculties_Campuses_CampusId",
                table: "InstituteFaculties",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstituteFaculties_Faculties_FacultyId",
                table: "InstituteFaculties",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
