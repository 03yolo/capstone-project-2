using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Models;

public class PomsDbContext : DbContext
{
    public PomsDbContext (DbContextOptions<PomsDbContext> options): base(options)
    {
    }
    // INDEPENDENT MODELS
    public DbSet<poms_website_project_2._0.Models.ChangePasswordModel> ChangePasswordModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.FacultyModel> FacultyModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.HomeCarouselItemModel> HomeCarouselItemModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.LearnerModel> LearnerModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.ParentModel> ParentModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.RoleModel> RoleModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.SchoolYearModel> SchoolYearModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.SectionModel> SectionModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.SubjectModel> SubjectModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.UserModel> UserModel { get; set; } = default!;

   // DEPENDENT MODELS
    public DbSet<poms_website_project_2._0.Models.AdminDetailModel> AdminDetailModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.AssessmentGradeModel> AssessmentGradeModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.AssessmentModel> AssessmentModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.AttendanceModel> AttendanceModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.AuditLogModel> AuditLogModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.FacultyLoadModel> FacultyLoadModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.GradeModel> GradeModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.NotificationModel> NotificationModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.ParentLearnerModel> ParentLearnerModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.QuarterModel> QuarterModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.SchoolFormModel> SchoolFormModel { get; set; } = default!;

    public DbSet<poms_website_project_2._0.Models.SectionEnrolmentModel> SectionEnrolmentModel { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AdminDetailModel>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasOne(g => g.Admin)
                  .WithMany()
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentGradeModel>(entity =>
        {
            entity.HasKey(e => e.AssessmentGradeId);

            entity.HasOne(g => g.Faculty)
                  .WithMany()
                  .HasForeignKey(g => g.FacultyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Quarter)
                  .WithMany()
                  .HasForeignKey(g => g.QuarterId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Subject)
                  .WithMany()
                  .HasForeignKey(g => g.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Assessment)
                  .WithMany()
                  .HasForeignKey(g => g.AssessmentId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentModel>(entity =>
        {
            entity.HasKey(e => e.AssessmentId);

            entity.HasOne(g => g.Faculty)
                  .WithMany()
                  .HasForeignKey(g => g.FacultyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Quarter)
                  .WithMany()
                  .HasForeignKey(g => g.QuarterId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Subject)
                  .WithMany()
                  .HasForeignKey(g => g.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AttendanceModel>(entity =>
        {
            entity.HasKey(e => e.AttendanceId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuditLogModel>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.HasOne(g => g.User)
                  .WithMany()
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<FacultyLoadModel>(entity =>
        {
            entity.HasKey(e => e.LoadId);

            entity.HasOne(g => g.Faculty)
                  .WithMany()
                  .HasForeignKey(g => g.FacultyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.SchoolYear)
                  .WithMany()
                  .HasForeignKey(g => g.SchoolYearId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Section)
                  .WithMany()
                  .HasForeignKey(g => g.SectionId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Subject)
                  .WithMany()
                  .HasForeignKey(g => g.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<GradeModel>(entity =>
        {
            entity.HasKey(e => e.GradeId);

            entity.HasOne(e => e.Learner)
                .WithMany()
                .HasForeignKey(e => e.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Faculty)
                .WithMany()
                .HasForeignKey(e => e.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Subject)
                .WithMany()
                .HasForeignKey(e => e.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<NotificationModel>(entity =>
        {
            entity.HasKey(e => e.NotificationId);

            entity.HasOne(g => g.User)
                  .WithMany()
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ParentLearnerModel>(entity =>
        {
            entity.HasKey(e => e.ParentId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Parent)
                  .WithMany()
                  .HasForeignKey(g => g.ParentId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<QuarterModel>(entity =>
        {
            entity.HasKey(e => e.QuarterId);

            entity.HasOne(g => g.SchoolYear)
                  .WithMany()
                  .HasForeignKey(g => g.SchoolYearId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SchoolFormModel>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SectionEnrolmentModel>(entity =>
        {
            entity.HasKey(e => e.EnrolId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.SchoolYear)
                  .WithMany()
                  .HasForeignKey(g => g.SchoolYearId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Section)
                  .WithMany()
                  .HasForeignKey(g => g.SectionId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

