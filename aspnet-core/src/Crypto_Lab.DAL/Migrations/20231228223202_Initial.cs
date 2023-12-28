using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crypto_Lab.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "交易所名稱"),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "交易所名稱"),
                    NumMarketPairs = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "市場上交易對數量"),
                    Fiats = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "交易所可兌換法定貨幣(JSON)"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "最後更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblExchanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblMarketPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "主鍵")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "交易所名稱"),
                    ExchangeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "交易所名稱"),
                    BaseAsset = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "交易對象"),
                    QuoteAsset = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "定價資產"),
                    Price = table.Column<decimal>(type: "decimal(10,9)", nullable: false, comment: "價格")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMarketPairs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblExchanges");

            migrationBuilder.DropTable(
                name: "TblMarketPairs");
        }
    }
}
