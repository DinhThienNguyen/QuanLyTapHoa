using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Entity;
using System.IO;
using System.Data.SqlClient;

namespace QuanLyTapHoa.DAO
{
    class EntityManager : DbContext
    {
        

        public EntityManager() : base("name = EntityManagerDB") { }

        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<HoaDonBanHang> HoaDonBanHang { get; set; }
        public virtual DbSet<UuDai> UuDai { get; set; }
        public virtual DbSet<HangHoa> HangHoa { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public virtual DbSet<BaoCaoNhapHang> BaoCaoNhapHang { get; set; }
        public virtual DbSet<ChiTietBaoCaoNhapHang> ChiTietBaoCaoNhapHang { get; set; }
    }
}
