using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Models;
using poms_website_project_2._0.Data.Entities;


public class PomsDbContext : DbContext
{
    public PomsDbContext (DbContextOptions<PomsDbContext> options): base(options)
    {
    }
    // INDEPENDENT MODELS
    // public DbSet<poms_website_project_2._0.Models.ChangePasswordModel> ChangePasswordModel { get; set; } = default!;

    public DbSet<Faculty> Faculty{ get; set; } = default!;

    // public DbSet<poms_website_project_2._0.Models.HomeCarouselItemModel> HomeCarouselItemModel { get; set; } = default!;

    public DbSet<Learner> Learner { get; set; } = default!;

    public DbSet<Parent> Parent { get; set; } = default!;

    public DbSet<Role> Role { get; set; } = default!;

    public DbSet<SchoolYear> SchoolYear{ get; set; } = default!;

    public DbSet<Section> Section { get; set; } = default!;

    public DbSet<Subject> Subject{ get; set; } = default!;

    public DbSet<User> User { get; set; } = default!;

   // DEPENDENT MODELS
    public DbSet<AdminDetail> AdminDetail { get; set; } = default!;

    public DbSet<AssessmentGrade> AssessmentGrade { get; set; } = default!;

    public DbSet<Assessment> Assessment { get; set; } = default!;

    public DbSet<Attendance> Attendance { get; set; } = default!;

    // public DbSet<AuditLog> AuditLog { get; set; } = default!;

    public DbSet<FacultyLoad> FacultyLoad { get; set; } = default!;

    public DbSet<Grade> Grade { get; set; } = default!;

    public DbSet<Notification> Notification { get; set; } = default!;

    public DbSet<ParentLearner> ParentLearner { get; set; } = default!;

    public DbSet<Quarter> Quarter { get; set; } = default!;

    public DbSet<SchoolForm> SchoolForm { get; set; } = default!;

    public DbSet<SectionEnrolment> SectionEnrolment { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AdminDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.HasOne(g => g.Admin)
                  .WithMany()
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentGrade>(entity =>
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

        modelBuilder.Entity<Assessment>(entity =>
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

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

       
        modelBuilder.Entity<FacultyLoad>(entity =>
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

        modelBuilder.Entity<Grade>(entity =>
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

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId);

            entity.HasOne(g => g.User)
                  .WithMany()
                  .HasForeignKey(g => g.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ParentLearner>(entity =>
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

        modelBuilder.Entity<Quarter>(entity =>
        {
            entity.HasKey(e => e.QuarterId);

            entity.HasOne(g => g.SchoolYear)
                  .WithMany()
                  .HasForeignKey(g => g.SchoolYearId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SchoolForm>(entity =>
        {
            entity.HasKey(e => e.FormId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SectionEnrolment>(entity =>
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

