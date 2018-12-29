using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class UuDaiDTO
    {
        private int maUuDai;
        private string tenUuDai;
        private decimal soTienUuDaiToiDa;
        private int soLanMuaHangToiThieu;
        private long ngayBatDau;
        private long ngayKetThuc;

        public UuDaiDTO()
        {
            tenUuDai = string.Empty;
            soTienUuDaiToiDa = 0;
            soLanMuaHangToiThieu = 0;
            ngayBatDau = 0;
            ngayKetThuc = 0;
        }

        public UuDaiDTO(int maUuDai, string tenUuDai, decimal soTienUuDaiToiDa, int soLanMuaHangToiThieu, long ngayBatDau, long ngayKetThuc)
        {
            this.maUuDai = maUuDai;
            this.tenUuDai = tenUuDai;
            this.soTienUuDaiToiDa = soTienUuDaiToiDa;
            this.soLanMuaHangToiThieu = soLanMuaHangToiThieu;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
        }

        public int MaUuDai { get => maUuDai; set => maUuDai = value; }
        public string TenUuDai { get => tenUuDai; set => tenUuDai = value; }
        public decimal SoTienUuDaiToiDa { get => soTienUuDaiToiDa; set => soTienUuDaiToiDa = value; }
        public int SoLanMuaHangToiThieu { get => soLanMuaHangToiThieu; set => soLanMuaHangToiThieu = value; }
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

        public long NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public long NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
    }
}
