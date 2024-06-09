using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultProject.DAL.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class ReAddFirstNameLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "WeatherForecasts",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "WeatherForecasts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(
                "ALTER TABLE" +
                " \"WeatherForecasts\"" +
                " ADD COLUMN \"FullName\"" +
                " text GENERATED ALWAYS AS (\"FirstName\" || ' ' || \"LastName\") STORED");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "WeatherForecasts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "WeatherForecasts",
                newName: "Author");
        }
    }
}
