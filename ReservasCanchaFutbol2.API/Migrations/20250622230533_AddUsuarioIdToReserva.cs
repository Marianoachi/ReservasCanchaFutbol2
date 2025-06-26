﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservasCanchaFutbol2.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioIdToReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reservas");
        }
    }
}
