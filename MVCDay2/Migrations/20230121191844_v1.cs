using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDay2.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    SuperSSN = table.Column<int>(name: "Super_SSN", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_Super_SSN",
                        column: x => x.SuperSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Dept_Locs",
                columns: table => new
                {
                    Deptid = table.Column<int>(name: "Dept_id", type: "int", nullable: false),
                    Locatoin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept_Locs", x => new { x.Deptid, x.Locatoin });
                    table.ForeignKey(
                        name: "FK_Dept_Locs_Departments_Dept_id",
                        column: x => x.Deptid,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deptid = table.Column<int>(name: "Dept_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dept_id",
                        column: x => x.Deptid,
                        principalTable: "Departments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpSSN = table.Column<int>(name: "Emp_SSN", type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    BDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Name, x.EmpSSN });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_Emp_SSN",
                        column: x => x.EmpSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emp_Projs",
                columns: table => new
                {
                    EmpSSN = table.Column<int>(name: "Emp_SSN", type: "int", nullable: false),
                    ProjId = table.Column<int>(name: "Proj_Id", type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp_Projs", x => new { x.EmpSSN, x.ProjId });
                    table.ForeignKey(
                        name: "FK_Emp_Projs_Employees_Emp_SSN",
                        column: x => x.EmpSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emp_Projs_Projects_Proj_Id",
                        column: x => x.ProjId,
                        principalTable: "Projects",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_Emp_SSN",
                table: "Dependents",
                column: "Emp_SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Emp_Projs_Proj_Id",
                table: "Emp_Projs",
                column: "Proj_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Super_SSN",
                table: "Employees",
                column: "Super_SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dept_id",
                table: "Projects",
                column: "Dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Dept_Locs");

            migrationBuilder.DropTable(
                name: "Emp_Projs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
