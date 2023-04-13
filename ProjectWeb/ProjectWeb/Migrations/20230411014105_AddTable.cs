using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Accounts",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "char(5)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Accounts", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_TB_M_Accounts_TB_M_Employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_Profilings",
                columns: table => new
                {
                    employee_nik = table.Column<string>(type: "char(5)", nullable: false),
                    education_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_Profilings", x => x.employee_nik);
                    table.ForeignKey(
                        name: "FK_TB_TR_Profilings_TB_M_Educations_education_id",
                        column: x => x.education_id,
                        principalTable: "TB_M_Educations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_TR_Profilings_TB_M_Employees_employee_nik",
                        column: x => x.employee_nik,
                        principalTable: "TB_M_Employees",
                        principalColumn: "nik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TR_AccountRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_nik = table.Column<string>(type: "char(5)", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TR_AccountRoles", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_TR_AccountRoles_TB_M_Accounts_account_nik",
                        column: x => x.account_nik,
                        principalTable: "TB_M_Accounts",
                        principalColumn: "employee_nik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_TR_AccountRoles_TB_M_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "TB_M_Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_AccountRoles_account_nik",
                table: "TB_TR_AccountRoles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_AccountRoles_role_id",
                table: "TB_TR_AccountRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TR_Profilings_education_id",
                table: "TB_TR_Profilings",
                column: "education_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TR_AccountRoles");

            migrationBuilder.DropTable(
                name: "TB_TR_Profilings");

            migrationBuilder.DropTable(
                name: "TB_M_Accounts");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");
        }
    }
}
