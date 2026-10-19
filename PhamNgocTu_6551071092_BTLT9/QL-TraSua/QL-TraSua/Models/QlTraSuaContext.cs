using Microsoft.EntityFrameworkCore;

namespace QL_TraSua.Models;

public partial class QlTraSuaContext : DbContext
{
    public QlTraSuaContext(DbContextOptions<QlTraSuaContext> options) : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    public virtual DbSet<DanhMucMon> DanhMucMons { get; set; }
    public virtual DbSet<HoaDon> HoaDons { get; set; }
    public virtual DbSet<MonUong> MonUongs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DanhMucMon>(entity =>
        {
            entity.ToTable("DanhMucMon");
            entity.HasKey(e => e.MaDM);
            entity.Property(e => e.TenDM).HasMaxLength(50);
        });

        modelBuilder.Entity<MonUong>(entity =>
        {
            entity.ToTable("MonUong");
            entity.HasKey(e => e.MaMon);
            entity.Property(e => e.TenMon).HasMaxLength(100);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.MonUongs)
                .HasForeignKey(d => d.MaDM)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MonUong_DanhMucMon");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.ToTable("HoaDon");
            entity.HasKey(e => e.MaHD);
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HinhThucTT).HasMaxLength(20);
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.ToTable("ChiTietHoaDon");
            entity.HasKey(e => new { e.MaHD, e.MaMon });
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHD)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

            entity.HasOne(d => d.MaMonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaMon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_MonUong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
