using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class HoaDonBanHangDTO
    {
        private int maHoaDonBanHang;
        private int maKhachHang;
        private long ngayKhoiTao;
        private decimal giaTriHoaDon;
        private decimal giaTriHoaDonSauKhuyenMai;
        private decimal giaTriHoaDonSauUuDai;
        private decimal soTienNhan;
        private decimal soTienThua;

        public HoaDonBanHangDTO()
        {
        }

        public HoaDonBanHangDTO(int maHoaDonBanHang, int maKhachHang, long ngayKhoiTao, decimal giaTriHoaDon, decimal giaTriHoaDonSauKhuyenMai, decimal giaTriHoaDonSauUuDai, decimal soTienNhan, decimal soTienThua)
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
        
        public int MaHoaDonBanHang { get => maHoaDonBanHang; set => maHoaDonBanHang = value; }        
        public int MaKhachHang { get => maKhachHang; set => maKhachHang = value; }        
        public long NgayKhoiTao { get => ngayKhoiTao; set => ngayKhoiTao = value; }        
        public decimal GiaTriHoaDon { get => giaTriHoaDon; set => giaTriHoaDon = value; }        
        public decimal GiaTriHoaDonSauKhuyenMai { get => giaTriHoaDonSauKhuyenMai; set => giaTriHoaDonSauKhuyenMai = value; }        
        public decimal GiaTriHoaDonSauUuDai { get => giaTriHoaDonSauUuDai; set => giaTriHoaDonSauUuDai = value; }        
        public decimal SoTienNhan { get => soTienNhan; set => soTienNhan = value; }        
        public decimal SoTienThua { get => soTienThua; set => soTienThua = value; }
    }
}
