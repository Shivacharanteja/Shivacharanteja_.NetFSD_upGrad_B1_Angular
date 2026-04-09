using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment2.DBFirstModels;

public partial class DBFirstContext : DbContext
{
    public DBFirstContext()
    {
    }

    public DBFirstContext(DbContextOptions<DBFirstContext> options)
        : base(options)
    {
    }

    

    public virtual DbSet<Department> Departments { get; set; }

    

    

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Shiva\\SqlExpress;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07021BBEB9");

            entity.ToTable("Department");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

       

       

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC071126A346");

            entity.ToTable("Teacher");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Teacher__Departm__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
