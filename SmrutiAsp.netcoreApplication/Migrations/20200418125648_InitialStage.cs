using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmrutiAsp.netcoreApplication.Migrations
{
    public partial class InitialStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Joining_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Hobbies = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
