using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Models;

namespace SchoolDB.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }

    public virtual DbSet<CourseEnrolment> CourseEnrolments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("YourConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4E83F8D3CE7");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.EmployeeIdFk).HasColumnName("EmployeeID_FK");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admins__Employee__35BCFE0A");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927A08EEF8801");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.AdminIdFk).HasColumnName("AdminID_FK");
            entity.Property(e => e.ClassName).HasMaxLength(35);

            entity.HasOne(d => d.AdminIdFkNavigation).WithMany(p => p.Classes)
                .HasForeignKey(d => d.AdminIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__AdminID__36B12243");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71874815D106");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(35);
        });

        modelBuilder.Entity<CourseAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__CourseAs__32499E57900CC94D");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CourseIdFk).HasColumnName("CourseID_FK");
            entity.Property(e => e.TeacherIdFk).HasColumnName("TeacherID_FK");

            entity.HasOne(d => d.CourseIdFkNavigation).WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.CourseIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseAss__Cours__37A5467C");

            entity.HasOne(d => d.TeacherIdFkNavigation).WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.TeacherIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseAss__Teach__38996AB5");
        });

        modelBuilder.Entity<CourseEnrolment>(entity =>
        {
            entity.HasKey(e => e.EnrolmentsId).HasName("PK__CourseEn__6DFB01469F6B8C58");

            entity.Property(e => e.EnrolmentsId).HasColumnName("EnrolmentsID");
            entity.Property(e => e.CourseIdFk).HasColumnName("CourseID_FK");
            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GradeSetterFk).HasColumnName("GradeSetter_FK");
            entity.Property(e => e.StudentIdFk).HasColumnName("StudentID_FK");

            entity.HasOne(d => d.CourseIdFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.CourseIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Cours__398D8EEE");

            entity.HasOne(d => d.GradeSetterFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.GradeSetterFk)
                .HasConstraintName("FK__CourseEnr__Grade__3A81B327");

            entity.HasOne(d => d.StudentIdFkNavigation).WithMany(p => p.CourseEnrolments)
                .HasForeignKey(d => d.StudentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseEnr__Stude__3B75D760");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1B77E07FF");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeFirstName).HasMaxLength(35);
            entity.Property(e => e.EmployeeLastName).HasMaxLength(35);
        });

        modelBuilder.Entity<EmployeeRole>(entity =>
        {
            entity.HasKey(e => e.EmployeeRoleId).HasName("PK__Employee__346186869BE872EF");

            entity.Property(e => e.EmployeeRoleId).HasColumnName("EmployeeRoleID");
            entity.Property(e => e.EmployeeIdFk).HasColumnName("EmployeeID_FK");
            entity.Property(e => e.RoleIdFk).HasColumnName("RoleID_FK");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeR__Emplo__3C69FB99");

            entity.HasOne(d => d.RoleIdFkNavigation).WithMany(p => p.EmployeeRoles)
                .HasForeignKey(d => d.RoleIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeR__RoleI__3D5E1FD2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AF4B1A459");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(35);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79F808D1C4");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassIdFk).HasColumnName("ClassID_FK");
            entity.Property(e => e.StudentFirstName).HasMaxLength(35);
            entity.Property(e => e.StudentLastName).HasMaxLength(35);
            entity.Property(e => e.StudentSsn)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("StudentSSN");

            entity.HasOne(d => d.ClassIdFkNavigation).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__ClassI__3E52440B");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF25944B708041A");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.EmployeeIdFk).HasColumnName("EmployeeID_FK");

            entity.HasOne(d => d.EmployeeIdFkNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.EmployeeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teachers__Employ__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
