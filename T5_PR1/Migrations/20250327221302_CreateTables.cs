﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace T5_PR1.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumAigua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comarca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipi = table.Column<int>(type: "int", nullable: false),
                    Consum = table.Column<double>(type: "float", nullable: false),
                    Any = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumAigua", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndicadorEnergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Any = table.Column<int>(type: "int", nullable: false),
                    ProduccioNeta = table.Column<double>(type: "float", nullable: false),
                    ConsumGasolina = table.Column<double>(type: "float", nullable: false),
                    DemandaElectrica = table.Column<double>(type: "float", nullable: false),
                    ProduccioDisponible = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicadorEnergia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSimulation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnergyNeeded = table.Column<double>(type: "float", nullable: false),
                    CostEnergy = table.Column<double>(type: "float", nullable: false),
                    PriceEnergy = table.Column<double>(type: "float", nullable: false),
                    Rati = table.Column<double>(type: "float", nullable: false),
                    GeneratedEnergy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumAigua");

            migrationBuilder.DropTable(
                name: "IndicadorEnergia");

            migrationBuilder.DropTable(
                name: "Simulations");
        }
    }
}
