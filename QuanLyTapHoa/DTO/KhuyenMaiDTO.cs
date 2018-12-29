using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class KhuyenMaiDTO
    {
        private int maKhuyenMai;
        private int maHangHoa;
        private string tenKhuyenMai;
        private float phanTramKhuyenMai;
        private int soLuongMua;
        private int soLuongTang;
        private long ngayBatDau;
        private long ngayKetThuc;

        public KhuyenMaiDTO()
        {
            tenKhuyenMai = string.Empty;
            soLuongMua = 0;
            SoLuongTang = 0;
            phanTramKhuyenMai = 0;            
        }

        public KhuyenMaiDTO(int maKhuyenMai, int maHangHoa, string tenKhuyenMai, float phanTramKhuyenMai, int soLuongMua, int soLuongTang, long ngayBatDau, long ngayKetThuc)
        {
            this.maKhuyenMai = maKhuyenMai;
            this.maHangHoa = maHangHoa;
            this.tenKhuyenMai = tenKhuyenMai;
            this.phanTramKhuyenMai = phanTramKhuyenMai;
            this.soLuongMua = soLuongMua;
            this.soLuongTang = soLuongTang;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        public int MaKhuyenMai
        {
            get
            {
                return maKhuyenMai;
            }
            set
            {
                maKhuyenMai = value;
            }
        }

        public int MaHangHoa
        {
            get
            {
                return maHangHoa;
            }
            set
            {
                maHangHoa = value;
            }
        }

        public string TenKhuyenMai
        {
            get
            {
                return tenKhuyenMai;
            }
            set
            {
                tenKhuyenMai = value;
            }
        }

        public float PhanTramKhuyenMai
        {
            get
            {
                return phanTramKhuyenMai;
            }
            set
            {
                phanTramKhuyenMai = value;
            }
        }

        public int SoLuongMua
        {
            get
            {
                return soLuongMua;
            }
            set
            {
                soLuongMua = value;
            }
        }

        public int SoLuongTang
        {
            get
            {
                return soLuongTang;
            }
            set
            {
                soLuongTang = value;
            }
        }

        public long NgayBatDau
        {
            get
            {
                return ngayBatDau;
            }
            set
            {
                ngayBatDau = value;
            }
        }

        public long NgayKetThuc
        {
            get
            {
                return ngayKetThuc;
            }
            set
            {
                ngayKetThuc = value;
            }
        }

        public string NgayBatDauInString
        {
            get
            {
                if (ngayBatDau == 0)
                    return "Không thời hạn";
                return DateTimeOffset.FromUnixTimeSeconds(NgayBatDau).LocalDateTime.ToShortDateString();
            }
            set
            {
                NgayBatDau = ((DateTimeOffset)DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture)).ToUnixTimeSeconds();
            }
        }
        public string NgayKetThucInString
        {
            get
            {
                if (ngayKetThuc == 0)
                    return "Không thời hạn";
                return DateTimeOffset.FromUnixTimeSeconds(NgayKetThuc).LocalDateTime.ToShortDateString();
            }
            set
            {
                NgayKetThuc = ((DateTimeOffset)DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture)).ToUnixTimeSeconds();
            }
        }

    }
}
