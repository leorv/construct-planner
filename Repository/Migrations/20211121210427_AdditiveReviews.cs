using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AdditiveReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clause_Additive_AdditiveID",
                table: "Clause");

            migrationBuilder.DropForeignKey(
                name: "FK_Spreadsheet_Additive_AdditiveId",
                table: "Spreadsheet");

            migrationBuilder.DropIndex(
                name: "IX_Spreadsheet_AdditiveId",
                table: "Spreadsheet");

            migrationBuilder.DropIndex(
                name: "IX_Clause_AdditiveID",
                table: "Clause");

            migrationBuilder.DropColumn(
                name: "AdditiveID",
                table: "Clause");

            migrationBuilder.AlterColumn<long>(
                name: "AdditiveId",
                table: "Spreadsheet",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");

            migrationBuilder.AddColumn<long>(
                name: "AdditiveSpreadsheetId",
                table: "Address",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdditiveClause",
                columns: table => new
                {
                    AdditiveClauseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Closed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdditiveID = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveClause", x => x.AdditiveClauseId);
                    table.ForeignKey(
                        name: "FK_AdditiveClause_Additive_AdditiveID",
                        column: x => x.AdditiveID,
                        principalTable: "Additive",
                        principalColumn: "AdditiveId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveSpreadsheet",
                columns: table => new
                {
                    AdditiveSpreadsheetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EncumberType = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditiveId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveSpreadsheet", x => x.AdditiveSpreadsheetId);
                    table.ForeignKey(
                        name: "FK_AdditiveSpreadsheet_Additive_AdditiveId",
                        column: x => x.AdditiveId,
                        principalTable: "Additive",
                        principalColumn: "AdditiveId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveLevel",
                columns: table => new
                {
                    AdditiveLevelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditiveSpreadsheetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveLevel", x => x.AdditiveLevelId);
                    table.ForeignKey(
                        name: "FK_AdditiveLevel_AdditiveSpreadsheet_AdditiveSpreadsheetId",
                        column: x => x.AdditiveSpreadsheetId,
                        principalTable: "AdditiveSpreadsheet",
                        principalColumn: "AdditiveSpreadsheetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveSpreadsheetItem",
                columns: table => new
                {
                    AdditiveSpreadsheetItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Unit = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManPower = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Material = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    AdditiveLevelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveSpreadsheetItem", x => x.AdditiveSpreadsheetItemId);
                    table.ForeignKey(
                        name: "FK_AdditiveSpreadsheetItem_AdditiveLevel_AdditiveLevelId",
                        column: x => x.AdditiveLevelId,
                        principalTable: "AdditiveLevel",
                        principalColumn: "AdditiveLevelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AdditiveSpreadsheetId",
                table: "Address",
                column: "AdditiveSpreadsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveClause_AdditiveID",
                table: "AdditiveClause",
                column: "AdditiveID");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveLevel_AdditiveSpreadsheetId",
                table: "AdditiveLevel",
                column: "AdditiveSpreadsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveSpreadsheet_AdditiveId",
                table: "AdditiveSpreadsheet",
                column: "AdditiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveSpreadsheetItem_AdditiveLevelId",
                table: "AdditiveSpreadsheetItem",
                column: "AdditiveLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AdditiveSpreadsheet_AdditiveSpreadsheetId",
                table: "Address",
                column: "AdditiveSpreadsheetId",
                principalTable: "AdditiveSpreadsheet",
                principalColumn: "AdditiveSpreadsheetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AdditiveSpreadsheet_AdditiveSpreadsheetId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "AdditiveClause");

            migrationBuilder.DropTable(
                name: "AdditiveSpreadsheetItem");

            migrationBuilder.DropTable(
                name: "AdditiveLevel");

            migrationBuilder.DropTable(
                name: "AdditiveSpreadsheet");

            migrationBuilder.DropIndex(
                name: "IX_Address_AdditiveSpreadsheetId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AdditiveSpreadsheetId",
                table: "Address");

            migrationBuilder.AlterColumn<long>(
                name: "AdditiveId",
                table: "Spreadsheet",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AdditiveID",
                table: "Clause",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Spreadsheet_AdditiveId",
                table: "Spreadsheet",
                column: "AdditiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clause_AdditiveID",
                table: "Clause",
                column: "AdditiveID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clause_Additive_AdditiveID",
                table: "Clause",
                column: "AdditiveID",
                principalTable: "Additive",
                principalColumn: "AdditiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spreadsheet_Additive_AdditiveId",
                table: "Spreadsheet",
                column: "AdditiveId",
                principalTable: "Additive",
                principalColumn: "AdditiveId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
