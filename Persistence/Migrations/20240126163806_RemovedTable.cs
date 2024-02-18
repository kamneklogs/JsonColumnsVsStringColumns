﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonColumnsVsStringColumns.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WithJsonColumns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WithJsonColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NestedObject_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NestedObject_Values = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithJsonColumns", x => x.Id);
                });
        }
    }
}
