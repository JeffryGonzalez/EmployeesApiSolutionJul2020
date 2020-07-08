using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 1, true, "CEO", "Sue", "Smith", 150000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 2, true, "DEV", "Bob", "Maple", 80000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 3, false, "DEV", "Sean", "Carlin", 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
