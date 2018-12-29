using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class ChiTietBaoCaoNhapHangDTO
    {
        private int maBaoCaoNhapHang;
        private int maHangHoa;
        private int soLuongNhap;
        private decimal tienVon;

        public ChiTietBaoCaoNhapHangDTO()
        {
        }

        public ChiTietBaoCaoNhapHangDTO(int maBaoCaoNhapHang, int maHangHoa, int soLuongNhap, decimal tienVon)
        {
            this.maBaoCaoNhapHang = maBaoCaoNhapHang;
            this.maHangHoa = maHangHoa;
            this.soLuongNhap = soLuongNhap;
            this.tienVon = tienVon;
        }

        public int MaBaoCaoNhapHang { get => maBaoCaoNhapHang; set => maBaoCaoNhapHang = value; }
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        public decimal TienVon { get => tienVon; set => tienVon = value; }
    }
}
