using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest;

public partial class AabdtestContext : DbContext
{
    public AabdtestContext()
    {
    }

    public AabdtestContext(DbContextOptions<AabdtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<FamilyPerson> FamilyPeople { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TempDb2");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Family>(entity =>
        {
            entity.ToTable("Family");

            entity.Property(e => e.FamilyName).HasMaxLength(150);
        });

        modelBuilder.Entity<FamilyPerson>(entity =>
        {
            entity.ToTable("FamilyPerson");

            entity.Property(e => e.FamilyFk).HasColumnName("FamilyFK");
            entity.Property(e => e.PersonFk).HasColumnName("PersonFK");

            entity.HasOne(d => d.FamilyFkNavigation).WithMany(p => p.FamilyPeople)
                .HasForeignKey(d => d.FamilyFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FamilyPerson_Family");

            entity.HasOne(d => d.PersonFkNavigation).WithMany(p => p.FamilyPeople)
                .HasForeignKey(d => d.PersonFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FamilyPerson_Person");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Gender).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
