using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHut.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedSettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoogleMapApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c219b37a-f215-4afb-bfdc-f93ea9da84de", "AQAAAAIAAYagAAAAELkdm+GHuOtBPGcVNad0imm4g/5xgbEaFSrDnI5G5PRcbEV/c4e4oisG/0zGTjrMlQ==", "1f797a65-00e0-4466-87ec-cdcdf1711305" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Address", "CreatedAt", "DeletedAt", "Email", "GoogleMapApiKey", "Phone", "UpdatedAt" },
                values: new object[] { 1, "12345 Fake ST NoWhere, AB Country", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@website.com", "https://maps.googleapis.com/maps/api/js?key=AIzaSyCtme10pzgKSPeJVJrG1O3tjR6lk98o4w8&callback=initMap", "(123) 456-7890", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abc63b97-f14a-4601-8dc6-9d0583e118cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ff5bf1-e786-4887-9ce2-76b1a933e91a", "AQAAAAIAAYagAAAAELpinrJJYAE8i+YBaYX8esUNkRjk+dHWF6uJ8h2VytAZP7MN43ljNfYankf96djG+w==", "be161583-d3c1-465f-9e07-21da24bc3d26" });
        }
    }
}
