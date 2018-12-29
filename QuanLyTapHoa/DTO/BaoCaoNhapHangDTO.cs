using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class BaoCaoNhapHangDTO
    {
        private int maBaoCaoNhapHang;
        private long ngayNhapHang;
        private decimal tongTienVon;

        public BaoCaoNhapHangDTO()
        {
        }

        public BaoCaoNhapHangDTO(int maBaoCaoNhapHang, long ngayNhapHang, decimal tongTienVon)
        {
            this.maBaoCaoNhapHang = maBaoCaoNhapHang;
            this.ngayNhapHang = ngayNhapHang;
            this.tongTienVon = tongTienVon;
        }

        public int MaBaoCaoNhapHang { get => maBaoCaoNhapHang; set => maBaoCaoNhapHang = value; }
        public long NgayNhapHang { get => ngayNhapHang; set => ngayNhapHang = value; }
        public decimal TongTienVon { get => tongTienVon; set => tongTienVon = value; }
    }
}
