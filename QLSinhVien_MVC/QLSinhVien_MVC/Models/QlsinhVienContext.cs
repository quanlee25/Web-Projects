using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLSinhVien_MVC.Models;

public partial class QlsinhVienContext : DbContext
{
    public QlsinhVienContext()
    {
    }

    public QlsinhVienContext(DbContextOptions<QlsinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=QUAN\\SQLEXPRESS;Database=QLSinhVien;uid=sa;pwd=020505;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__Lop__3B98D2738468533F");

            entity.ToTable("Lop");

            entity.Property(e => e.TenLop).HasMaxLength(50);
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SinhVien__2725081AD8451DD4");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSv).HasColumnName("MaSV");
            entity.Property(e => e.HoTen).HasMaxLength(50);

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__SinhVien__MaLop__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
