using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCG.Data.Migrations
{
    public partial class ApplicationConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ApplConfigs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    ShowtoUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplConfigs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplConfigs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DisplayName", "LastModifiedBy", "LastModifiedOn", "Name", "ShowtoUser", "Value" },
                values: new object[] { 1L, null, new DateTime(2021, 3, 22, 14, 48, 5, 494, DateTimeKind.Utc).AddTicks(1752), "Indesign Index File Save Path", null, null, "IndesignIndexFileSavePath", true, "C:\\Indesign\\IndexFiles\\" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 22, 14, 48, 5, 491, DateTimeKind.Utc).AddTicks(1676));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplConfigs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 15, 5, 8, 19, 980, DateTimeKind.Utc).AddTicks(8923));
        }
    }
}
