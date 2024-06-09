using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultProject.DAL.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    TemperatureC = table.Column<int>(type: "integer", nullable: false),
                    TemperatureF = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                });

            migrationBuilder
                .Sql(
                    "ALTER TABLE" +
                    " \"WeatherForecasts\"" +
                    " ADD CONSTRAINT constraint_weatherForecast_temperatureC CHECK(\"TemperatureC\" between -100 and 80)");
            
            migrationBuilder
                .Sql(
                    "ALTER TABLE" +
                    "  \"WeatherForecasts\"" +
                    " ADD CONSTRAINT constraint_weatherForecast_temperatureF CHECK(\"TemperatureF\" between -100 and 80)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");
        }
    }
}
