using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace lab5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCharacteristic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandEndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerLicenseDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerLicenseValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerMoreInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNumberOfDriverLicense = table.Column<int>(type: "int", nullable: false),
                    OwnerPassport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    CarColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarLastCheckupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarNumberOfBody = table.Column<int>(type: "int", nullable: false),
                    CarNumberOfMotor = table.Column<int>(type: "int", nullable: false),
                    CarNumberOfPassport = table.Column<int>(type: "int", nullable: false),
                    CarPhoto = table.Column<int>(type: "int", nullable: false),
                    CarRegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarRegistrationNumber = table.Column<int>(type: "int", nullable: false),
                    CarReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandID",
                table: "Cars",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerID",
                table: "Cars",
                column: "OwnerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
