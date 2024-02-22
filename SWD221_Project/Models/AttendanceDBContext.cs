using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SWD221_Project.Models
{
    public partial class AttendanceDBContext : DbContext
    {
        public AttendanceDBContext()
        {
        }

        public AttendanceDBContext(DbContextOptions<AttendanceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<BelongTo> BelongTos { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentWorkProgress> StudentWorkProgresses { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ClassID");

                entity.Property(e => e.DateAttended).HasColumnType("date");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Attendanc__Class__31EC6D26");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Attendanc__Stude__30F848ED");
            });

            modelBuilder.Entity<BelongTo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BelongTo");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ClassID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__BelongTo__ClassI__2B3F6F97");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__BelongTo__Studen__2A4B4B5E");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ClassID");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Class__TeacherID__286302EC");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<StudentWorkProgress>(entity =>
            {
                entity.HasKey(e => e.ProgressId)
                    .HasName("PK__StudentW__BAE29C85A586F90F");

                entity.ToTable("StudentWorkProgress");

                entity.Property(e => e.ProgressId).HasColumnName("ProgressID");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("StudentID");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentWorkProgresses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentWo__Stude__34C8D9D1");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.StudentWorkProgresses)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK__StudentWo__WorkI__35BCFE0A");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TeacherID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Work");

                entity.Property(e => e.WorkId).HasColumnName("WorkID");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ClassID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.WorkName).HasMaxLength(50);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Work__ClassID__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
