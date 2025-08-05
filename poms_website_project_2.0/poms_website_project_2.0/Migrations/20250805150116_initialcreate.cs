using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poms_website_project_2._0.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeCarouselItemModel",
                columns: table => new
                {
                    CarouselItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UploadedBy = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCarouselItemModel", x => x.CarouselItemId);
                });

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
                name: "QuarterModel",
                columns: table => new
                {
                    QuarterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolYearId = table.Column<int>(type: "int", nullable: false),
                    QuarterNo = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SchoolYearModelSchoolYearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterModel", x => x.QuarterId);
                    table.ForeignKey(
                        name: "FK_QuarterModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuarterModel_SchoolYearModel_SchoolYearModelSchoolYearId",
                        column: x => x.SchoolYearModelSchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId");
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminDetailUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserModel_AdminDetailModel_AdminDetailUserId",
                        column: x => x.AdminDetailUserId,
                        principalTable: "AdminDetailModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_UserModel_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogModel",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordPk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogModel", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_AuditLogModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationModel", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_NotificationModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationModel_UserModel_UserModelUserId",
                        column: x => x.UserModelUserId,
                        principalTable: "UserModel",
                        principalColumn: "UserId");
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentModel_QuarterModel_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "QuarterModel",
                        principalColumn: "QuarterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
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
                    SchoolYearId = table.Column<int>(type: "int", nullable: false),
                    FacultyModelUserId = table.Column<int>(type: "int", nullable: true),
                    SchoolYearModelSchoolYearId = table.Column<int>(type: "int", nullable: true),
                    SectionModelSectionId = table.Column<int>(type: "int", nullable: true),
                    SubjectModelSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyLoadModel", x => x.LoadId);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_FacultyModel_FacultyModelUserId",
                        column: x => x.FacultyModelUserId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SchoolYearModel_SchoolYearModelSchoolYearId",
                        column: x => x.SchoolYearModelSchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId");
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SectionModel_SectionModelSectionId",
                        column: x => x.SectionModelSectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId");
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacultyLoadModel_SubjectModel_SubjectModelSubjectId",
                        column: x => x.SubjectModelSubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceModel",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    SchoolDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AttendanceStatus = table.Column<int>(type: "int", nullable: false),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceModel", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_AttendanceModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttendanceModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
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
                    EncodedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacultyModelUserId = table.Column<int>(type: "int", nullable: true),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true),
                    SubjectModelSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeModel", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_GradeModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeModel_FacultyModel_FacultyModelUserId",
                        column: x => x.FacultyModelUserId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_GradeModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_GradeModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradeModel_SubjectModel_SubjectModelSubjectId",
                        column: x => x.SubjectModelSubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId");
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
                    GeneratedByNavigationUserId = table.Column<int>(type: "int", nullable: false),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolFormModel", x => x.FormId);
                    table.ForeignKey(
                        name: "FK_SchoolFormModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolFormModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
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
                    SchoolYearId = table.Column<int>(type: "int", nullable: false),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true),
                    SchoolYearModelSchoolYearId = table.Column<int>(type: "int", nullable: true),
                    SectionModelSectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionEnrolmentModel", x => x.EnrolId);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SchoolYearModel_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SchoolYearModel_SchoolYearModelSchoolYearId",
                        column: x => x.SchoolYearModelSchoolYearId,
                        principalTable: "SchoolYearModel",
                        principalColumn: "SchoolYearId");
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SectionModel_SectionId",
                        column: x => x.SectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionEnrolmentModel_SectionModel_SectionModelSectionId",
                        column: x => x.SectionModelSectionId,
                        principalTable: "SectionModel",
                        principalColumn: "SectionId");
                });

            migrationBuilder.CreateTable(
                name: "ParentLearnerModel",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    LearnerId = table.Column<int>(type: "int", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true),
                    ParentModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentLearnerModel", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_ParentModel_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ParentModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParentLearnerModel_ParentModel_ParentModelUserId",
                        column: x => x.ParentModelUserId,
                        principalTable: "ParentModel",
                        principalColumn: "UserId");
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
                    FacultyModelUserId = table.Column<int>(type: "int", nullable: true),
                    LearnerModelUserId = table.Column<int>(type: "int", nullable: true),
                    QuarterModelQuarterId = table.Column<int>(type: "int", nullable: true),
                    SubjectModelSubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentGradeModel", x => x.AssessmentGradeId);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_AssessmentModel_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "AssessmentModel",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_FacultyModel_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_FacultyModel_FacultyModelUserId",
                        column: x => x.FacultyModelUserId,
                        principalTable: "FacultyModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_LearnerModel_LearnerId",
                        column: x => x.LearnerId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_LearnerModel_LearnerModelUserId",
                        column: x => x.LearnerModelUserId,
                        principalTable: "LearnerModel",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_QuarterModel_QuarterId",
                        column: x => x.QuarterId,
                        principalTable: "QuarterModel",
                        principalColumn: "QuarterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_QuarterModel_QuarterModelQuarterId",
                        column: x => x.QuarterModelQuarterId,
                        principalTable: "QuarterModel",
                        principalColumn: "QuarterId");
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_SubjectModel_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssessmentGradeModel_SubjectModel_SubjectModelSubjectId",
                        column: x => x.SubjectModelSubjectId,
                        principalTable: "SubjectModel",
                        principalColumn: "SubjectId");
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
                name: "IX_AssessmentGradeModel_FacultyModelUserId",
                table: "AssessmentGradeModel",
                column: "FacultyModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_LearnerId",
                table: "AssessmentGradeModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_LearnerModelUserId",
                table: "AssessmentGradeModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_QuarterId",
                table: "AssessmentGradeModel",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_QuarterModelQuarterId",
                table: "AssessmentGradeModel",
                column: "QuarterModelQuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_SubjectId",
                table: "AssessmentGradeModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentGradeModel_SubjectModelSubjectId",
                table: "AssessmentGradeModel",
                column: "SubjectModelSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_FacultyId",
                table: "AssessmentModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_QuarterId",
                table: "AssessmentModel",
                column: "QuarterId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentModel_SubjectId",
                table: "AssessmentModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceModel_LearnerId",
                table: "AttendanceModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceModel_LearnerModelUserId",
                table: "AttendanceModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogModel_UserId",
                table: "AuditLogModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_FacultyId",
                table: "FacultyLoadModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_FacultyModelUserId",
                table: "FacultyLoadModel",
                column: "FacultyModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SchoolYearId",
                table: "FacultyLoadModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SchoolYearModelSchoolYearId",
                table: "FacultyLoadModel",
                column: "SchoolYearModelSchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SectionId",
                table: "FacultyLoadModel",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SectionModelSectionId",
                table: "FacultyLoadModel",
                column: "SectionModelSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SubjectId",
                table: "FacultyLoadModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyLoadModel_SubjectModelSubjectId",
                table: "FacultyLoadModel",
                column: "SubjectModelSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_FacultyId",
                table: "GradeModel",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_FacultyModelUserId",
                table: "GradeModel",
                column: "FacultyModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_LearnerId",
                table: "GradeModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_LearnerModelUserId",
                table: "GradeModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_SubjectId",
                table: "GradeModel",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeModel_SubjectModelSubjectId",
                table: "GradeModel",
                column: "SubjectModelSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_UserId",
                table: "NotificationModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_UserModelUserId",
                table: "NotificationModel",
                column: "UserModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentLearnerModel_LearnerId",
                table: "ParentLearnerModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentLearnerModel_LearnerModelUserId",
                table: "ParentLearnerModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentLearnerModel_ParentModelUserId",
                table: "ParentLearnerModel",
                column: "ParentModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterModel_SchoolYearId",
                table: "QuarterModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterModel_SchoolYearModelSchoolYearId",
                table: "QuarterModel",
                column: "SchoolYearModelSchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFormModel_GeneratedByNavigationUserId",
                table: "SchoolFormModel",
                column: "GeneratedByNavigationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFormModel_LearnerId",
                table: "SchoolFormModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFormModel_LearnerModelUserId",
                table: "SchoolFormModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_LearnerId",
                table: "SectionEnrolmentModel",
                column: "LearnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_LearnerModelUserId",
                table: "SectionEnrolmentModel",
                column: "LearnerModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SchoolYearId",
                table: "SectionEnrolmentModel",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SchoolYearModelSchoolYearId",
                table: "SectionEnrolmentModel",
                column: "SchoolYearModelSchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SectionId",
                table: "SectionEnrolmentModel",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionEnrolmentModel_SectionModelSectionId",
                table: "SectionEnrolmentModel",
                column: "SectionModelSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_AdminDetailUserId",
                table: "UserModel",
                column: "AdminDetailUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_RoleId",
                table: "UserModel",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminDetailModel_UserModel_UserId",
                table: "AdminDetailModel",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminDetailModel_UserModel_UserId",
                table: "AdminDetailModel");

            migrationBuilder.DropTable(
                name: "AssessmentGradeModel");

            migrationBuilder.DropTable(
                name: "AttendanceModel");

            migrationBuilder.DropTable(
                name: "AuditLogModel");

            migrationBuilder.DropTable(
                name: "FacultyLoadModel");

            migrationBuilder.DropTable(
                name: "GradeModel");

            migrationBuilder.DropTable(
                name: "HomeCarouselItemModel");

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
                name: "SchoolYearModel");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "AdminDetailModel");

            migrationBuilder.DropTable(
                name: "RoleModel");
        }
    }
}
