using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHut.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eb68790-998e-46c3-ad25-2483922a2364", "AQAAAAIAAYagAAAAEIEszOUNjxN5L/wRZmOpM6v45UMUURhlRUhs4m8VcOvrjDGcGOMC9Yo+9+opUjA59w==", "693f0590-8fe1-4724-a910-39f6395192a0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0017221-9bd8-40cb-9d5b-40b98de1a804", "AQAAAAIAAYagAAAAEEA0VqVyOA69S3jLfBOhy60W+UlBeBbxB3KLae98afTbV4wZRZc10GTc9l7ziKbNHg==", "3bd7854d-28b5-4efb-be98-b0b69e4cdd52" });
        }
    }
}
