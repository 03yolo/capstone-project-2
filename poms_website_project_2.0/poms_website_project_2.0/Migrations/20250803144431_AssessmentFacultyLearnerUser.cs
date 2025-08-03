using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poms_website_project_2._0.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentFacultyLearnerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYearModel",
                columns: table => new
                {
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartYear = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYearModel", x => x.SchoolYearId);
                });

            migrationBuilder.CreateTable(
                name: "SectionModel",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeLevel = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionModel", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectModel",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectModel", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserModel_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuarterModel",
                columns: table => new
                {
                    QuarterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false),
                    QuarterNo = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterModel", x => x.QuarterId);
                    table.ForeignKey(
                        name: "FK_QuarterModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminDetailModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDetailModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AdminDetailModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_FacultyModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnerModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Lrn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GradeLevel = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnerModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_LearnerModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationModel",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationModel", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_NotificationModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentModel",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ParentModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentModel",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    QuarterId = table.Column<int>(type: "int", nullable: false),
                    AssessmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentNo = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    DateGiven = table.Column<DateOnly>(type: "date", nullable: true),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentModel", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_AssessmentModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentModel_QuarterModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "QuarterModel",
                        principalColumn: "QuarterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyLoadModel",
                columns: table => new
                {
                    LoadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyLoadModel", x => x.LoadId);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceModel",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    SchoolDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AttendanceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceModel", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_AttendanceModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeModel",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WwScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WwTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WwPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PtScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PtTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PtPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QaScore = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QaTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QaPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncodedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModel", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_GradeModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolFormModel",
                columns: table => new
                {
                    FormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    FormType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedBy = table.Column<int>(type: "int", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneratedByNavigationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFormModel", x => x.FormId);
                    table.ForeignKey(
                        name: "FK_SchoolFormModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolFormModel_UserModel_GeneratedByNavigationUserId",
                        column: x => x.GeneratedByNavigationUserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionEnrolmentModel",
                columns: table => new
                {
                    EnrolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrolmentModel", x => x.EnrolId);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentLearnerModel",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentLearnerModel", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_ParentModel_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ParentModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentGradeModel",
                columns: table => new
                {
                    AssessmentGradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    QuarterId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateGiven = table.Column<DateOnly>(type: "date", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentGradeModel", x => x.AssessmentGradeId);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_AssessmentModel_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "AssessmentModel",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_QuarterModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "QuarterModel",
                        principalColumn: "QuarterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_AssessmentId",
                table: "AssessmentGradeModel",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_FacultyId",
                table: "AssessmentGradeModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_LearnerId",
                table: "AssessmentGradeModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_SchoolYearId",
                table: "AssessmentGradeModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_SubjectId",
                table: "AssessmentGradeModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_FacultyId",
                table: "AssessmentModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_SchoolYearId",
                table: "AssessmentModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_SubjectId",
                table: "AssessmentModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceModel_LearnerId",
                table: "AttendanceModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_FacultyId",
                table: "FacultyLoadModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SchoolYearId",
                table: "FacultyLoadModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SectionId",
                table: "FacultyLoadModel",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SubjectId",
                table: "FacultyLoadModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_FacultyId",
                table: "GradeModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_LearnerId",
                table: "GradeModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_SubjectId",
                table: "GradeModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_UserId",
                table: "NotificationModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentLearnerModel_LearnerId",
                table: "ParentLearnerModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterModel_SchoolYearId",
                table: "QuarterModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFormModel_GeneratedByNavigationUserId",
                table: "SchoolFormModel",
                column: "GeneratedByNavigationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFormModel_LearnerId",
                table: "SchoolFormModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_LearnerId",
                table: "SectionEnrolmentModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SchoolYearId",
                table: "SectionEnrolmentModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SectionId",
                table: "SectionEnrolmentModel",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_RoleId",
                table: "UserModel",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDetailModel");

            migrationBuilder.DropTable(
                name: "AssessmentGradeModel");

            migrationBuilder.DropTable(
                name: "AttendanceModel");

            migrationBuilder.DropTable(
                name: "FacultyLoadModel");

            migrationBuilder.DropTable(
                name: "GradeModel");

            migrationBuilder.DropTable(
                name: "NotificationModel");

            migrationBuilder.DropTable(
                name: "ParentLearnerModel");

            migrationBuilder.DropTable(
                name: "SchoolFormModel");

            migrationBuilder.DropTable(
                name: "SectionEnrolmentModel");

            migrationBuilder.DropTable(
                name: "AssessmentModel");

            migrationBuilder.DropTable(
                name: "ParentModel");

            migrationBuilder.DropTable(
                name: "LearnerModel");

            migrationBuilder.DropTable(
                name: "SectionModel");

            migrationBuilder.DropTable(
                name: "FacultyModel");

            migrationBuilder.DropTable(
                name: "QuarterModel");

            migrationBuilder.DropTable(
                name: "SubjectModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "SchoolYearModel");

            migrationBuilder.DropTable(
                name: "RoleModel");
        }
    }
}
