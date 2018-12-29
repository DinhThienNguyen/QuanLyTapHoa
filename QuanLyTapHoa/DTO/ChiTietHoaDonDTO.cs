using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class ChiTietHoaDonDTO
    {
        private int maHoaDonBanHang;
        private int maHangHoa;
        private int soLuong;
        private decimal giaTri;
        private decimal giaTriSauKhuyenMai;

        public ChiTietHoaDonDTO()
        {
        }

        public ChiTietHoaDonDTO(int maHoaDonBanHang, int maHangHoa, int soLuong, decimal giaTri, decimal giaTriSauKhuyenMai)
        {
            this.maHoaDonBanHang = maHoaDonBanHang;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.giaTri = giaTri;
            this.giaTriSauKhuyenMai = giaTriSauKhuyenMai;
        }
        
        public int MaHoaDonBanHang { get => maHoaDonBanHang; set => maHoaDonBanHang = value; }        
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }        
        public int SoLuong { get => soLuong; set => soLuong = value; }        
        public decimal GiaTri { get => giaTri; set => giaTri = value; }        
        public decimal GiaTriSauKhuyenMai { get => giaTriSauKhuyenMai; set => giaTriSauKhuyenMai = value; }
    }
}
