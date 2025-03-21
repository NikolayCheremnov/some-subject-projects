using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudDbExample.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Copybooks",
            columns: ["Id", "Description", "PageCount", "Price"],
            values: new object[,]
            {
                { 1, "Тетрадь в клетку, 48 листов", 48, 120.50m },
                { 2, "Тетрадь в линейку, 24 листа", 24, 80.00m },
                { 3, "Тетрадь для рисования, 32 листа", 32, 150.00m },
                { 4, "Тетрадь в клетку, 96 листов", 96, 200.00m },
                { 5, "Тетрадь в линейку, 48 листов", 48, 130.00m },
                { 6, "Тетрадь для заметок, 64 листа", 64, 180.00m },
                { 7, "Тетрадь в клетку, 12 листов", 12, 50.00m },
                { 8, "Тетрадь в линейку, 18 листов", 18, 60.00m },
                { 9, "Тетрадь для черчения, 40 листов", 40, 170.00m },
                { 10, "Тетрадь в клетку, 60 листов", 60, 140.00m }
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Copybooks",
                keyColumn: "Id",
                keyValues: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
            );
        }
    }
}
