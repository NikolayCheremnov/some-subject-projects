using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockerizedAppExampleWithDb.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: ["Id", "Name", "Email", "PhoneNumber", "RegisteredAt", "BirthDate"],
                values: new object[,]
                {
                    {1, "Иванов Иван Иванович", "ivanov@mail.ru", "+7-111-111-11-11", new DateOnly(2025, 1, 1), new DateOnly(1980, 12, 30) },
                    {2, "Петров Петр Петрович", "petrov@mail.ru", null, new DateOnly(2025, 1, 1), new DateOnly(1985, 10, 5) },
                    {3, "Петров Петр Петрович", "petrov_2@mail.ru", null, new DateOnly(2025, 1, 1), new DateOnly(1985, 10, 5) },
                    {4, "Сидоров Сидр Сидорович", null, "+7-222-222-22-22", new DateOnly(2025, 1, 1), new DateOnly(1999, 5, 8) },
                    {5, "Сидоров Сидр Сидорович", null, "+7-222-222-22-33", new DateOnly(2025, 1, 1), new DateOnly(1999, 1, 1) },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Copybooks",
               keyColumn: "Id",
               keyValues: [1, 2, 3, 4, 5]
           );
        }
    }
}
