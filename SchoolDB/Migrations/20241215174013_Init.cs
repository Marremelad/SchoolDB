using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__C92D71874815D106", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF1B77E07FF", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Roles__8AFACE3AF4B1A459", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__719FE4E83F8D3CE7", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK__Admins__Employee__35BCFE0A",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teachers__EDF25944B708041A", x => x.TeacherID);
                    table.ForeignKey(
                        name: "FK__Teachers__Employ__3F466844",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID_FK = table.Column<int>(type: "int", nullable: false),
                    RoleID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__346186869BE872EF", x => x.EmployeeRoleID);
                    table.ForeignKey(
                        name: "FK__EmployeeR__Emplo__3C69FB99",
                        column: x => x.EmployeeID_FK,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__EmployeeR__RoleI__3D5E1FD2",
                        column: x => x.RoleID_FK,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    AdminID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__CB1927A08EEF8801", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK__Classes__AdminID__36B12243",
                        column: x => x.AdminID_FK,
                        principalTable: "Admins",
                        principalColumn: "AdminID");
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID_FK = table.Column<int>(type: "int", nullable: false),
                    CourseID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseAs__32499E57900CC94D", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK__CourseAss__Cours__37A5467C",
                        column: x => x.CourseID_FK,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__CourseAss__Teach__38996AB5",
                        column: x => x.TeacherID_FK,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentLastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    StudentSSN = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    ClassID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__32C52A79F808D1C4", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK__Students__ClassI__3E52440B",
                        column: x => x.ClassID_FK,
                        principalTable: "Classes",
                        principalColumn: "ClassID");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrolments",
                columns: table => new
                {
                    EnrolmentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID_FK = table.Column<int>(type: "int", nullable: false),
                    CourseID_FK = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    GradeSetter_FK = table.Column<int>(type: "int", nullable: true),
                    GradingDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEn__6DFB01469F6B8C58", x => x.EnrolmentsID);
                    table.ForeignKey(
                        name: "FK__CourseEnr__Cours__398D8EEE",
                        column: x => x.CourseID_FK,
                        principalTable: "Courses",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK__CourseEnr__Grade__3A81B327",
                        column: x => x.GradeSetter_FK,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                    table.ForeignKey(
                        name: "FK__CourseEnr__Stude__3B75D760",
                        column: x => x.StudentID_FK,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_EmployeeID_FK",
                table: "Admins",
                column: "EmployeeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_AdminID_FK",
                table: "Classes",
                column: "AdminID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_CourseID_FK",
                table: "CourseAssignments",
                column: "CourseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_TeacherID_FK",
                table: "CourseAssignments",
                column: "TeacherID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_CourseID_FK",
                table: "CourseEnrolments",
                column: "CourseID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_GradeSetter_FK",
                table: "CourseEnrolments",
                column: "GradeSetter_FK");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrolments_StudentID_FK",
                table: "CourseEnrolments",
                column: "StudentID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeID_FK",
                table: "EmployeeRoles",
                column: "EmployeeID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoleID_FK",
                table: "EmployeeRoles",
                column: "RoleID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassID_FK",
                table: "Students",
                column: "ClassID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_EmployeeID_FK",
                table: "Teachers",
                column: "EmployeeID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAssignments");

            migrationBuilder.DropTable(
                name: "CourseEnrolments");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
