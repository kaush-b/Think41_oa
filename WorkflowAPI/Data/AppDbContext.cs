using Microsoft.EntityFrameworkCore;
using WorkflowAPI.Models;

namespace WorkflowAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Workflow> Workflows => Set<Workflow>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<Dependency> Dependencies => Set<Dependency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Workflow>()
            .HasIndex(w => w.WorkflowStrId)
            .IsUnique();

        modelBuilder.Entity<Step>()
            .HasIndex(s => s.StepStrId)
            .IsUnique();

        modelBuilder.Entity<Dependency>()
            .HasOne(d => d.Step)
            .WithMany(s => s.Dependencies)
            .HasForeignKey(d => d.StepId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Dependency>()
            .HasOne(d => d.PrerequisiteStep)
            .WithMany(s => s.Prerequisites)
            .HasForeignKey(d => d.PrerequisiteStepId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
