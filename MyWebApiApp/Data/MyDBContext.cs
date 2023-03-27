using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{


    // dinh nghia DB Context => Quan trong la ke thua
    public class MyDBContext : DbContext
    {
        // quan trong nhat dung cho database nao => tao chuoi ket noi nam trong apsetting.json
        // lam cac logic ben apsetting.json va startup.cs 
        // khai bao ham tao voi cac options tu dong lay ke thua tu lop cha :base(options)

        public MyDBContext(DbContextOptions options) : base(options) { }

        // muon map thanh database thi khai bao
        // DbSet se dai dien cho mot cai tap thuc the ve hang hoa muon them xoa sua thi sai HangHoas
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()"); // getutcdate lay ra gio hien tai nhung tinh theo mui gio so 0
                e.Property(dh => dh.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh, e.MaHh });

                // Dinh nghia moi quan he
                entity.HasOne(e => e.DonHang)
                       .WithMany(e => e.DonHangChiTiets)
                       .HasForeignKey(e => e.MaDh)
                       .HasConstraintName("FK_DHCT_DonHang");

                // Dinh nghia moi quan he
                entity.HasOne(e => e.HangHoa)
                       .WithMany(e => e.DonHangChiTiets)
                       .HasForeignKey(e => e.MaHh)
                       .HasConstraintName("FK_DHCT_HangHoa");
            });
        }

    }
}
