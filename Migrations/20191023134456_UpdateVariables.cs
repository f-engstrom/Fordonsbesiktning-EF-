using Microsoft.EntityFrameworkCore.Migrations;

namespace Fordonsbesiktning_EF_.Migrations
{
    public partial class UpdateVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registrationumber",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Registrationumber",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
