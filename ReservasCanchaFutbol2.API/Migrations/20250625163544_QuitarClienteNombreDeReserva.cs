using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasCanchaFutbol2.API.Migrations
{
    /// <inheritdoc />
    public partial class QuitarClienteNombreDeReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteNombre",
                table: "Reservas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteNombre",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
