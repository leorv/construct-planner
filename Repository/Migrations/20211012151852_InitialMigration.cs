using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    SourceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(48)", maxLength: 48, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Day = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    SourceFamily = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EncumberType = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.SourceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Photo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SourceItem",
                columns: table => new
                {
                    SourceItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManPower = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Material = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalUnitValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceItem", x => x.SourceItemId);
                    table.ForeignKey(
                        name: "FK_SourceItem_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Object = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Closed = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Input",
                columns: table => new
                {
                    InputId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SourceItemId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Input", x => x.InputId);
                    table.ForeignKey(
                        name: "FK_Input_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "SourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Input_SourceItem_SourceItemId",
                        column: x => x.SourceItemId,
                        principalTable: "SourceItem",
                        principalColumn: "SourceItemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Additive",
                columns: table => new
                {
                    AdditiveId = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    Year = table.Column<int>(type: "INT", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Justification = table.Column<string>(type: "VARCHAR(2048)", maxLength: 2048, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalValue = table.Column<decimal>(type: "DECIMAL(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Closed = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Additive", x => x.AdditiveId);
                    table.ForeignKey(
                        name: "FK_Additive_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Additive_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BDI",
                columns: table => new
                {
                    BDIId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonnelAdministration = table.Column<double>(type: "double", nullable: false),
                    GeneralExpenses = table.Column<double>(type: "double", nullable: false),
                    Risks = table.Column<double>(type: "double", nullable: false),
                    Insurance = table.Column<double>(type: "double", nullable: false),
                    Warranty = table.Column<double>(type: "double", nullable: false),
                    FinantialExpenses = table.Column<double>(type: "double", nullable: false),
                    Profit = table.Column<double>(type: "double", nullable: false),
                    PIS = table.Column<double>(type: "double", nullable: false),
                    Cofins = table.Column<double>(type: "double", nullable: false),
                    CPRB = table.Column<double>(type: "double", nullable: false),
                    ISS = table.Column<double>(type: "double", nullable: false),
                    BDIValue = table.Column<double>(type: "double", nullable: false),
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDI", x => x.BDIId);
                    table.ForeignKey(
                        name: "FK_BDI_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContractAgreement",
                columns: table => new
                {
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsAgree = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAgreement", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_ContractAgreement_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractAgreement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContractUser",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractUser", x => new { x.UserId, x.ContractId });
                    table.ForeignKey(
                        name: "FK_ContractUser_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditiveAgreement",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AdditiveId = table.Column<long>(type: "BIGINT", nullable: false),
                    IsAgree = table.Column<sbyte>(type: "TINYINT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditiveAgreement", x => new { x.UserId, x.AdditiveId });
                    table.ForeignKey(
                        name: "FK_AdditiveAgreement_Additive_AdditiveId",
                        column: x => x.AdditiveId,
                        principalTable: "Additive",
                        principalColumn: "AdditiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditiveAgreement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clause",
                columns: table => new
                {
                    ClauseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Closed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false),
                    AdditiveID = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clause", x => x.ClauseId);
                    table.ForeignKey(
                        name: "FK_Clause_Additive_AdditiveID",
                        column: x => x.AdditiveID,
                        principalTable: "Additive",
                        principalColumn: "AdditiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clause_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Spreadsheet",
                columns: table => new
                {
                    SpreadsheetId = table.Column<long>(type: "bigint", nullable: false)
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
                    ContractId = table.Column<long>(type: "BIGINT", nullable: false),
                    AdditiveId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spreadsheet", x => x.SpreadsheetId);
                    table.ForeignKey(
                        name: "FK_Spreadsheet_Additive_AdditiveId",
                        column: x => x.AdditiveId,
                        principalTable: "Additive",
                        principalColumn: "AdditiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spreadsheet_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostalCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complement = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpreadsheetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Spreadsheet_SpreadsheetId",
                        column: x => x.SpreadsheetId,
                        principalTable: "Spreadsheet",
                        principalColumn: "SpreadsheetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpreadsheetId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelId);
                    table.ForeignKey(
                        name: "FK_Level_Spreadsheet_SpreadsheetId",
                        column: x => x.SpreadsheetId,
                        principalTable: "Spreadsheet",
                        principalColumn: "SpreadsheetId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpreadsheetItem",
                columns: table => new
                {
                    SpreadsheetItemId = table.Column<long>(type: "bigint", nullable: false)
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
                    LevelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpreadsheetItem", x => x.SpreadsheetItemId);
                    table.ForeignKey(
                        name: "FK_SpreadsheetItem_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Additive_ContractId",
                table: "Additive",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Additive_UserId",
                table: "Additive",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditiveAgreement_AdditiveId",
                table: "AdditiveAgreement",
                column: "AdditiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_SpreadsheetId",
                table: "Address",
                column: "SpreadsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_BDI_ContractId",
                table: "BDI",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Clause_AdditiveID",
                table: "Clause",
                column: "AdditiveID");

            migrationBuilder.CreateIndex(
                name: "IX_Clause_ContractId",
                table: "Clause",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_UserId",
                table: "Contract",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAgreement_UserId",
                table: "ContractAgreement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractUser_ContractId",
                table: "ContractUser",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Input_SourceId",
                table: "Input",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Input_SourceItemId",
                table: "Input",
                column: "SourceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_SpreadsheetId",
                table: "Level",
                column: "SpreadsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceItem_SourceId",
                table: "SourceItem",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spreadsheet_AdditiveId",
                table: "Spreadsheet",
                column: "AdditiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spreadsheet_ContractId",
                table: "Spreadsheet",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SpreadsheetItem_LevelId",
                table: "SpreadsheetItem",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditiveAgreement");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BDI");

            migrationBuilder.DropTable(
                name: "Clause");

            migrationBuilder.DropTable(
                name: "ContractAgreement");

            migrationBuilder.DropTable(
                name: "ContractUser");

            migrationBuilder.DropTable(
                name: "Input");

            migrationBuilder.DropTable(
                name: "SpreadsheetItem");

            migrationBuilder.DropTable(
                name: "SourceItem");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Spreadsheet");

            migrationBuilder.DropTable(
                name: "Additive");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
