using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RCG.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ProductMain",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    FileActualname = table.Column<string>(nullable: false),
                    FileTempname = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Sku = table.Column<string>(nullable: false),
                    Length = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    ProductMainId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductMain_ProductMainId",
                        column: x => x.ProductMainId,
                        principalTable: "ProductMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ApplConfigs",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DisplayName", "LastModifiedBy", "LastModifiedOn", "Name", "ShowtoUser", "Value" },
                values: new object[] { 1L, null, new DateTime(2021, 4, 16, 7, 19, 7, 843, DateTimeKind.Utc).AddTicks(5504), "Indesign Index File Save Path", null, null, "IndesignIndexFileSavePath", true, "C:\\Indesign\\IndexFiles\\" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsAdmin", "LastModifiedBy", "LastModifiedOn", "Name", "PasswordHash", "Username" },
                values: new object[] { 1L, null, new DateTime(2021, 4, 16, 7, 19, 7, 841, DateTimeKind.Utc).AddTicks(1090), true, null, null, "Super Admin", "BHJ/7xKctZbcNVqU/TCQaFqnxB9TlAgwawptL4Gr2bc=", "MusaSA" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMainId",
                table: "Products",
                column: "ProductMainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplConfigs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductMain");
        }
    }
}
