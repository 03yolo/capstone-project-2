using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Models;

    public class PomsDbContext : DbContext
    {
        public PomsDbContext (DbContextOptions<PomsDbContext> options)
            : base(options)
        {
        }

        public DbSet<poms_website_project_2._0.Models.UserModel> UserModel { get; set; } = default!;

public DbSet<poms_website_project_2._0.Models.LearnerModel> LearnerModel { get; set; } = default!;

public DbSet<poms_website_project_2._0.Models.FacultyModel> FacultyModel { get; set; } = default!;

public DbSet<poms_website_project_2._0.Models.AssessmentModel> AssessmentModel { get; set; } = default!;

    public DbSet<GradeModel> GradeModel { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GradeModel>(entity =>
        {
            entity.HasKey(e => e.GradeId);

            entity.HasOne(g => g.Learner)
                  .WithMany()
                  .HasForeignKey(g => g.LearnerId)
                  .OnDelete(DeleteBehavior.Restrict); // Important!

            entity.HasOne(g => g.Faculty)
                  .WithMany()
                  .HasForeignKey(g => g.FacultyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Subject)
                  .WithMany()
                  .HasForeignKey(g => g.SubjectId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

}

