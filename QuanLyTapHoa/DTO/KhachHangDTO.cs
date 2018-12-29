using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class KhachHangDTO
    {
        private int maKhachHang;
        private string tenKhachHang;
        private string soDienThoai;
        private int soLanMuaHang;

        public int MaKhachHang
        {
            get
            {
                return maKhachHang;
            }
            set
            {
                maKhachHang = value;
            }
        }

        public string TenKhachHang
        {
            get
            {
                return tenKhachHang;
            }
            set
            {
                tenKhachHang = value;
            }
        }

        public string SoDienThoai
        {
            get
            {
                return soDienThoai;
            }
            set
            {
                soDienThoai = value;
            }
        }

        public int SoLanMuaHang
        {
            get
            {
                return soLanMuaHang;
            }
            set
            {
                soLanMuaHang = value;
            }
        }
        

        public KhachHangDTO()
        {
            tenKhachHang = string.Empty;
            soDienThoai = string.Empty;
            soLanMuaHang = 0;
        }

        public KhachHangDTO(int MaKhachHang, string TenKhachHang, string SoDienThoai, int SoLanMuaHang)
        {
            maKhachHang = MaKhachHang;
            tenKhachHang = TenKhachHang;
            soDienThoai = SoDienThoai;
            soLanMuaHang = SoLanMuaHang;
        }

        public string ToString()
        {
            return "Mã: " + maKhachHang + "\nTên: " + tenKhachHang + "\nSDT: " + soDienThoai + "\nSố lần mua hàng: " + soLanMuaHang;
        }


    }
}
