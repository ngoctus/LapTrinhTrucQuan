using Microsoft.EntityFrameworkCore;

namespace AnKhangClinic.Models;

public partial class AnKhangClinicContext : DbContext
{
    public AnKhangClinicContext()
    {
    }

    public AnKhangClinicContext(DbContextOptions<AnKhangClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BacSi> BacSis { get; set; }

    public virtual DbSet<LichKham> LichKhams { get; set; }

    // Connection string: sửa Server cho đúng máy của bạn (ví dụ (localdb)\MSSQLLocalDB hoặc .\SQLEXPRESS)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AnKhangClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BacSi>(entity =>
        {
            entity.HasKey(e => e.MaBS).HasName("PK_BacSi");

            entity.ToTable("BacSi");

            entity.Property(e => e.ChuyenKhoa).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SDT)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LichKham>(entity =>
        {
            entity.HasKey(e => e.MaLich).HasName("PK_LichKham");

            entity.ToTable("LichKham");

            entity.Property(e => e.GioKham).HasPrecision(0);
            entity.Property(e => e.SDT)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenBenhNhan).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.MaBSNavigation).WithMany(p => p.LichKhams)
                .HasForeignKey(d => d.MaBS)
                .HasConstraintName("FK_LichKham_BacSi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
