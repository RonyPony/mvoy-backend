using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvoy.data.Migrations
{
    public partial class fjdfgndskjngkdjfn4444 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginName = table.Column<string>(type: "varchar(80)", nullable: false),
                    DestinyName = table.Column<string>(type: "varchar(80)", nullable: false),
                    duration = table.Column<double>(type: "float", nullable: false),
                    distance = table.Column<double>(type: "float", nullable: false),
                    leavingTime = table.Column<string>(type: "varchar(80)", nullable: false),
                    driverId = table.Column<string>(type: "varchar(80)", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    arrivingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contactInfoId = table.Column<int>(type: "int", nullable: false),
                    isDriver = table.Column<bool>(type: "bit", nullable: false),
                    cedula = table.Column<string>(type: "varchar(80)", nullable: false),
                    email = table.Column<string>(type: "varchar(80)", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", nullable: false),
                    midName = table.Column<string>(type: "varchar(80)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<string>(type: "varchar(80)", nullable: false),
                    gender = table.Column<string>(type: "char(1)", nullable: false),
                    creationDate = table.Column<string>(type: "varchar(80)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    userType = table.Column<string>(type: "varchar(80)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usersContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    relativeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    relativePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usersContactInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ownerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    licencia = table.Column<string>(type: "varchar(80)", nullable: false),
                    seguro = table.Column<string>(type: "varchar(80)", nullable: false),
                    chasis = table.Column<string>(type: "varchar(80)", nullable: false),
                    placa = table.Column<string>(type: "varchar(80)", nullable: false),
                    color = table.Column<string>(type: "varchar(80)", nullable: false),
                    marca = table.Column<string>(type: "varchar(80)", nullable: false),
                    modelo = table.Column<string>(type: "varchar(80)", nullable: false),
                    hasinsurance = table.Column<string>(type: "varchar(80)", nullable: false),
                    year = table.Column<string>(type: "varchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "usersContactInfo");

            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
