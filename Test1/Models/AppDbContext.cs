using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test1.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentFacility> DepartmentFacilities { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<MajorFacility> MajorFacilities { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffMajorFacility> StaffMajorFacilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DELL\\SQLEXPRESS;Database=exam_distribution_test;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83FB268923B");

            entity.ToTable("department");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<DepartmentFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departme__3213E83F4A346509");

            entity.ToTable("department_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdDepartment).HasColumnName("id_department");
            entity.Property(e => e.IdFacility).HasColumnName("id_facility");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK__departmen__id_de__4F7CD00D");

            entity.HasOne(d => d.IdFacilityNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdFacility)
                .HasConstraintName("FK__departmen__id_fa__5070F446");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.DepartmentFacilities)
                .HasForeignKey(d => d.IdStaff)
                .HasConstraintName("FK__departmen__id_st__5165187F");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__facility__3213E83FE17BDE0F");

            entity.ToTable("facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__major__3213E83FF7126CE7");

            entity.ToTable("major");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<MajorFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__major_fa__3213E83FF5F94FF5");

            entity.ToTable("major_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdDepartmentFacility).HasColumnName("id_department_facility");
            entity.Property(e => e.IdMajor).HasColumnName("id_major");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdDepartmentFacilityNavigation).WithMany(p => p.MajorFacilities)
                .HasForeignKey(d => d.IdDepartmentFacility)
                .HasConstraintName("FK__major_fac__id_de__5629CD9C");

            entity.HasOne(d => d.IdMajorNavigation).WithMany(p => p.MajorFacilities)
                .HasForeignKey(d => d.IdMajor)
                .HasConstraintName("FK__major_fac__id_ma__571DF1D5");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff__3213E83F81AFD4AD");

            entity.ToTable("staff");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountFe)
                .HasMaxLength(255)
                .HasColumnName("account_fe");
            entity.Property(e => e.AccountFpt)
                .HasMaxLength(255)
                .HasColumnName("account_fpt");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StaffCode)
                .HasMaxLength(255)
                .HasColumnName("staff_code");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<StaffMajorFacility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff_ma__3213E83F749C66B5");

            entity.ToTable("staff_major_facility");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IdMajorFacility).HasColumnName("id_major_facility");
            entity.Property(e => e.IdStaff).HasColumnName("id_staff");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdMajorFacilityNavigation).WithMany(p => p.StaffMajorFacilities)
                .HasForeignKey(d => d.IdMajorFacility)
                .HasConstraintName("FK__staff_maj__id_ma__59FA5E80");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.StaffMajorFacilities)
                .HasForeignKey(d => d.IdStaff)
                .HasConstraintName("FK__staff_maj__id_st__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
