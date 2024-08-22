using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Suv_Xojaligi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_date_to_new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_FileMetadatas_FileId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "Explain",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateTime",
                table: "News",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "News",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_ImageId",
                table: "News",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_FileMetadatas_ImageId",
                table: "News",
                column: "ImageId",
                principalTable: "FileMetadatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_FileMetadatas_FileId",
                table: "Reports",
                column: "FileId",
                principalTable: "FileMetadatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_FileMetadatas_ImageId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_FileMetadatas_FileId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_News_ImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "Explain",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_FileMetadatas_FileId",
                table: "Reports",
                column: "FileId",
                principalTable: "FileMetadatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
