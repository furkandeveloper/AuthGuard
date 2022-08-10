using AuthGuard.Domain;
using AuthGuard.EntityFrameworkCore.ValueGenerators;
using Microsoft.EntityFrameworkCore;

namespace AuthGuard.EntityFrameworkCore;

/// <summary>
/// Auth Guard Db Context
/// </summary>
public class AuthGuardDbContext : DbContext
{
    public AuthGuardDbContext(DbContextOptions<AuthGuardDbContext> options)
        : base(options)
    {
    }

    #region Tables

    public virtual DbSet<Employee> Employees { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Employee

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(pk => pk.Id);

            entity
                .Property(p => p.FirstName)
                .HasMaxLength(200);
            
            entity
                .Property(p => p.LastName)
                .HasMaxLength(200);

            entity
                .Property(p => p.Id)
                .HasValueGenerator<GuidValueGenerator>()
                .ValueGeneratedOnAdd();
            
            entity
                .Property(p => p.CreationDate)
                .HasValueGenerator<DateValueGenerator>()
                .ValueGeneratedOnAdd();
            
            entity
                .Property(p => p.ModificationDate)
                .HasValueGenerator<DateValueGenerator>()
                .ValueGeneratedOnUpdate();
        });

        #endregion
    }
}