using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Custor.Portal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyNameLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyNameAmharic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterpriseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeNameLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeNameAmharic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
