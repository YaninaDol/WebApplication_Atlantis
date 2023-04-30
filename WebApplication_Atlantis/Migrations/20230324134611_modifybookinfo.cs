﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Atlantis.Migrations
{
    /// <inheritdoc />
    public partial class modifybookinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BookingInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BookingInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BookingInfos");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BookingInfos");
        }
    }
}
