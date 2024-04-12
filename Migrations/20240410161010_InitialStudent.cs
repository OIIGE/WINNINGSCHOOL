using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATTWOOLSCHOOL.Migrations
{
    /// <inheritdoc />
    public partial class InitialStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VarChar(50)", nullable: false),
                    LastName = table.Column<string>(type: "VarChar(50)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "VarChar(50)", nullable: false),
                    ParentFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPhoneNumber = table.Column<string>(type: "VarChar(50)", nullable: false),
                    ParentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuidanceEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
