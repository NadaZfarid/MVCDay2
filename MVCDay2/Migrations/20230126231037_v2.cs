using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDay2.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_Emp_SSN",
                table: "Dependents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents");

            migrationBuilder.DropIndex(
                name: "IX_Dependents_Emp_SSN",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "DepId",
                table: "Dependents");

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "Emp_Projs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dependents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Emp_SSN",
                table: "Dependents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents",
                columns: new[] { "Emp_SSN", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_Emp_SSN",
                table: "Dependents",
                column: "Emp_SSN",
                principalTable: "Employees",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Employees_Emp_SSN",
                table: "Dependents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents");

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "Emp_Projs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dependents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Emp_SSN",
                table: "Dependents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepId",
                table: "Dependents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_Emp_SSN",
                table: "Dependents",
                column: "Emp_SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Employees_Emp_SSN",
                table: "Dependents",
                column: "Emp_SSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }
    }
}
