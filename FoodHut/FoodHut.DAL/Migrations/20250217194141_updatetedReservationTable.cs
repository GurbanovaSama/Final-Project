using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHut.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatetedReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ff5bf1-e786-4887-9ce2-76b1a933e91a", "AQAAAAIAAYagAAAAELpinrJJYAE8i+YBaYX8esUNkRjk+dHWF6uJ8h2VytAZP7MN43ljNfYankf96djG+w==", "be161583-d3c1-465f-9e07-21da24bc3d26" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8eb68790-998e-46c3-ad25-2483922a2364", "AQAAAAIAAYagAAAAEIEszOUNjxN5L/wRZmOpM6v45UMUURhlRUhs4m8VcOvrjDGcGOMC9Yo+9+opUjA59w==", "693f0590-8fe1-4724-a910-39f6395192a0" });
        }
    }
}
