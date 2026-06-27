namespace ECIP.Infrastructure.Persistence;

using ECIP.Core.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Entity Framework Core database context for ECIP.
/// </summary>
public class EcipDbContext : DbContext
{
    public EcipDbContext(DbContextOptions<EcipDbContext> options) : base(options)
    {
    }

    public DbSet<RepositoryEntity> Repositories => Set<RepositoryEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RepositoryEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.RepositoryUrl).HasMaxLength(500);
            entity.Property(e => e.Branch).HasMaxLength(100);
            entity.Property(e => e.LocalPath).HasMaxLength(500);
            entity.Property(e => e.DefaultBranch).HasMaxLength(100);
            entity.HasIndex(e => e.Name).IsUnique();
        });
    }
}
