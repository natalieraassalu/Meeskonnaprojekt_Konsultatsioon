using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ConsultationSlot");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ConsultationSlotId",
                table: "Notification",
                column: "ConsultationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LecturerId",
                table: "Notification",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_StudentId",
                table: "Notification",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSelector_CourseId",
                table: "CourseSelector",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSelector_LecturerId",
                table: "CourseSelector",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSelector_StudentId",
                table: "CourseSelector",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_CourseId",
                table: "CourseMaterial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_MaterialId",
                table: "CourseMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationSlot_LecturerId",
                table: "ConsultationSlot",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPage_SlotId",
                table: "BookingPage",
                column: "SlotId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingPage_StudentId",
                table: "BookingPage",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPage_ConsultationSlot_SlotId",
                table: "BookingPage",
                column: "SlotId",
                principalTable: "ConsultationSlot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingPage_User_StudentId",
                table: "BookingPage",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationSlot_User_LecturerId",
                table: "ConsultationSlot",
                column: "LecturerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Course_CourseId",
                table: "CourseMaterial",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Material_MaterialId",
                table: "CourseMaterial",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSelector_Course_CourseId",
                table: "CourseSelector",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSelector_User_LecturerId",
                table: "CourseSelector",
                column: "LecturerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSelector_User_StudentId",
                table: "CourseSelector",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_ConsultationSlot_ConsultationSlotId",
                table: "Notification",
                column: "ConsultationSlotId",
                principalTable: "ConsultationSlot",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User_LecturerId",
                table: "Notification",
                column: "LecturerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_User_StudentId",
                table: "Notification",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPage_ConsultationSlot_SlotId",
                table: "BookingPage");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingPage_User_StudentId",
                table: "BookingPage");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationSlot_User_LecturerId",
                table: "ConsultationSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Course_CourseId",
                table: "CourseMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Material_MaterialId",
                table: "CourseMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSelector_Course_CourseId",
                table: "CourseSelector");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSelector_User_LecturerId",
                table: "CourseSelector");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSelector_User_StudentId",
                table: "CourseSelector");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_ConsultationSlot_ConsultationSlotId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User_LecturerId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_User_StudentId",
                table: "Notification");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Notification_ConsultationSlotId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_LecturerId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_StudentId",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_CourseSelector_CourseId",
                table: "CourseSelector");

            migrationBuilder.DropIndex(
                name: "IX_CourseSelector_LecturerId",
                table: "CourseSelector");

            migrationBuilder.DropIndex(
                name: "IX_CourseSelector_StudentId",
                table: "CourseSelector");

            migrationBuilder.DropIndex(
                name: "IX_CourseMaterial_CourseId",
                table: "CourseMaterial");

            migrationBuilder.DropIndex(
                name: "IX_CourseMaterial_MaterialId",
                table: "CourseMaterial");

            migrationBuilder.DropIndex(
                name: "IX_ConsultationSlot_LecturerId",
                table: "ConsultationSlot");

            migrationBuilder.DropIndex(
                name: "IX_BookingPage_SlotId",
                table: "BookingPage");

            migrationBuilder.DropIndex(
                name: "IX_BookingPage_StudentId",
                table: "BookingPage");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "ConsultationSlot",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                table: "AspNetUserPasskeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
