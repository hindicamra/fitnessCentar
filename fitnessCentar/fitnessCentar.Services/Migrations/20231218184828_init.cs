﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fitnessCentar.Services.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanIshranes",
                columns: table => new
                {
                    PlanIshraneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIshranes", x => x.PlanIshraneId);
                });

            migrationBuilder.CreateTable(
                name: "TipClanarines",
                columns: table => new
                {
                    TipClanarineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipClanarines", x => x.TipClanarineId);
                });

            migrationBuilder.CreateTable(
                name: "Trenings",
                columns: table => new
                {
                    TreningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenings", x => x.TreningId);
                });

            migrationBuilder.CreateTable(
                name: "Ulogas",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulogas", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.KorisnikId);
                    table.ForeignKey(
                        name: "FK_Korisniks_Ulogas_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Ulogas",
                        principalColumn: "UlogaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clanarinas",
                columns: table => new
                {
                    ClanarinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    TipClanarineId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trajanje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarinas", x => x.ClanarinaId);
                    table.ForeignKey(
                        name: "FK_Clanarinas_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clanarinas_TipClanarines_TipClanarineId",
                        column: x => x.TipClanarineId,
                        principalTable: "TipClanarines",
                        principalColumn: "TipClanarineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanIshraneKorisniks",
                columns: table => new
                {
                    PlanIshraneKorisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanIshraneId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanIshraneKorisniks", x => x.PlanIshraneKorisnikId);
                    table.ForeignKey(
                        name: "FK_PlanIshraneKorisniks_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_PlanIshraneKorisniks_PlanIshranes_PlanIshraneId",
                        column: x => x.PlanIshraneId,
                        principalTable: "PlanIshranes",
                        principalColumn: "PlanIshraneId");
                });

            migrationBuilder.CreateTable(
                name: "Recenzijas",
                columns: table => new
                {
                    RecenzijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    TreningId = table.Column<int>(type: "int", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocjena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzijas", x => x.RecenzijaId);
                    table.ForeignKey(
                        name: "FK_Recenzijas_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzijas_Trenings_TreningId",
                        column: x => x.TreningId,
                        principalTable: "Trenings",
                        principalColumn: "TreningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacijas",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreningId = table.Column<int>(type: "int", nullable: false),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacijas", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacijas_Trenings_TreningId",
                        column: x => x.TreningId,
                        principalTable: "Trenings",
                        principalColumn: "TreningId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placanjas",
                columns: table => new
                {
                    PlacanjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<float>(type: "real", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClanarinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placanjas", x => x.PlacanjeId);
                    table.ForeignKey(
                        name: "FK_Placanjas_Clanarinas_ClanarinaId",
                        column: x => x.ClanarinaId,
                        principalTable: "Clanarinas",
                        principalColumn: "ClanarinaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanarinas_KorisnikId",
                table: "Clanarinas",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanarinas_TipClanarineId",
                table: "Clanarinas",
                column: "TipClanarineId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisniks_UlogaId",
                table: "Korisniks",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Placanjas_ClanarinaId",
                table: "Placanjas",
                column: "ClanarinaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanIshraneKorisniks_KorisnikId",
                table: "PlanIshraneKorisniks",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanIshraneKorisniks_PlanIshraneId",
                table: "PlanIshraneKorisniks",
                column: "PlanIshraneId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzijas_KorisnikId",
                table: "Recenzijas",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzijas_TreningId",
                table: "Recenzijas",
                column: "TreningId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_KorisnikId",
                table: "Rezervacijas",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijas_TreningId",
                table: "Rezervacijas",
                column: "TreningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Placanjas");

            migrationBuilder.DropTable(
                name: "PlanIshraneKorisniks");

            migrationBuilder.DropTable(
                name: "Recenzijas");

            migrationBuilder.DropTable(
                name: "Rezervacijas");

            migrationBuilder.DropTable(
                name: "Clanarinas");

            migrationBuilder.DropTable(
                name: "PlanIshranes");

            migrationBuilder.DropTable(
                name: "Trenings");

            migrationBuilder.DropTable(
                name: "Korisniks");

            migrationBuilder.DropTable(
                name: "TipClanarines");

            migrationBuilder.DropTable(
                name: "Ulogas");
        }
    }
}
