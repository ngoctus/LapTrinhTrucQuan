using Microsoft.EntityFrameworkCore;

namespace DaNgoaiApp.Data;

// Tương đương kết quả của:
// dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Data --context QL_DaNgoaiContext --force
public partial class QL_DaNgoaiContext : DbContext
{
    public QL_DaNgoaiContext() { }

    public QL_DaNgoaiContext(DbContextOptions<QL_DaNgoaiContext> options) : base(options) { }

    public virtual DbSet<ChuyenDi> ChuyenDis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuyenDi>(entity =>
        {
            entity.HasKey(e => e.MaChuyen).HasName("PK_ChuyenDi");
            entity.ToTable("ChuyenDi");

            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.NganSach).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PhuongTien).HasMaxLength(30);
            entity.Property(e => e.TenChuyen).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
