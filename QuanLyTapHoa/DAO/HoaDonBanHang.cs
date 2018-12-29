using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("HoaDonBanHang")]
    class HoaDonBanHang
    {
        private int maHoaDonBanHang;
        private int maKhachHang;
        private long ngayKhoiTao;
        private decimal giaTriHoaDon;
        private decimal giaTriHoaDonSauKhuyenMai;
        private decimal giaTriHoaDonSauUuDai;
        private decimal soTienNhan;
        private decimal soTienThua;

        public HoaDonBanHang()
        {
        }

        public HoaDonBanHang(int maHoaDonBanHang, int maKhachHang, long ngayKhoiTao, decimal giaTriHoaDon, decimal giaTriHoaDonSauKhuyenMai, decimal giaTriHoaDonSauUuDai, decimal soTienNhan, decimal soTienThua)
        {
            this.maHoaDonBanHang = maHoaDonBanHang;
            this.maKhachHang = maKhachHang;
            this.ngayKhoiTao = ngayKhoiTao;
            this.giaTriHoaDon = giaTriHoaDon;
            this.giaTriHoaDonSauKhuyenMai = giaTriHoaDonSauKhuyenMai;
            this.giaTriHoaDonSauUuDai = giaTriHoaDonSauUuDai;
            this.soTienNhan = soTienNhan;
            this.soTienThua = soTienThua;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaHoaDonBanHang")]
        [Key]
        public int MaHoaDonBanHang { get => maHoaDonBanHang; set => maHoaDonBanHang = value; }

        [Column("MaKhachHang")]
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        [Column("NgayKhoiTao")]
        public long NgayKhoiTao { get => ngayKhoiTao; set => ngayKhoiTao = value; }
        [Column("GiaTriHoaDon")]
        public decimal GiaTriHoaDon { get => giaTriHoaDon; set => giaTriHoaDon = value; }
        [Column("GiaTriHoaDonSauKhuyenMai")]
        public decimal GiaTriHoaDonSauKhuyenMai { get => giaTriHoaDonSauKhuyenMai; set => giaTriHoaDonSauKhuyenMai = value; }
        [Column("GiaTriHoaDonSauUuDai")]
        public decimal GiaTriHoaDonSauUuDai { get => giaTriHoaDonSauUuDai; set => giaTriHoaDonSauUuDai = value; }
        [Column("SoTienNhan")]
        public decimal SoTienNhan { get => soTienNhan; set => soTienNhan = value; }
        [Column("SoTienThua")]
        public decimal SoTienThua { get => soTienThua; set => soTienThua = value; }
    }
}
