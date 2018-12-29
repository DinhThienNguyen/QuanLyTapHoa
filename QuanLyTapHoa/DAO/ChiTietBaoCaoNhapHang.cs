using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("ChiTietBaoCaoNhapHang")]
    class ChiTietBaoCaoNhapHang
    {
        private int maBaoCaoNhapHang;
        private int maHangHoa;
        private int soLuongNhap;
        private decimal tienVon;

        public ChiTietBaoCaoNhapHang()
        {
        }

        public ChiTietBaoCaoNhapHang(int maBaoCaoNhapHang, int maHangHoa, int soLuongNhap, decimal tienVon)
        {
            this.maBaoCaoNhapHang = maBaoCaoNhapHang;
            this.maHangHoa = maHangHoa;
            this.soLuongNhap = soLuongNhap;
            this.tienVon = tienVon;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaBaoCaoNhapHang", Order = 1)]
        [Key]
        public int MaBaoCaoNhapHang { get => maBaoCaoNhapHang; set => maBaoCaoNhapHang = value; }
        [Column("MaHangHoa", Order = 2)]
        [Key]
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        [Column("Ma")]
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        [Column("MaHoaDonBanHang")]
        public decimal TienVon { get => tienVon; set => tienVon = value; }
    }
}
