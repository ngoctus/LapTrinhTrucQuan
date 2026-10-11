using Microsoft.EntityFrameworkCore;

namespace TriThucBooks.Models;

public partial class TriThucBooksContext : DbContext
{
    public TriThucBooksContext()
    {
    }

    public TriThucBooksContext(DbContextOptions<TriThucBooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

    // Connection string: sửa Server cho đúng máy của bạn (ví dụ (localdb)\MSSQLLocalDB hoặc .\SQLEXPRESS)
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TriThucBooksDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TheLoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaTL).HasName("PK_TheLoaiSach");

            entity.ToTable("TheLoaiSach");

            entity.HasIndex(e => e.TenTheLoai, "UQ_TheLoaiSach_TenTheLoai").IsUnique();

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuongSach).HasDefaultValue(0);
            entity.Property(e => e.TenTheLoai).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
