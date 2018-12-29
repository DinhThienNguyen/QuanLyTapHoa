using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("ChiTietHoaDon")]
    class ChiTietHoaDon
    {
        private int maHoaDonBanHang;
        private int maHangHoa;
        private int soLuong;
        private decimal giaTri;
        private decimal giaTriSauKhuyenMai;

        public ChiTietHoaDon()
        {
        }

        public ChiTietHoaDon(int maHoaDonBanHang, int maHangHoa, int soLuong, decimal giaTri, decimal giaTriSauKhuyenMai)
        {
            this.maHoaDonBanHang = maHoaDonBanHang;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.giaTri = giaTri;
            this.giaTriSauKhuyenMai = giaTriSauKhuyenMai;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaHoaDonBanHang")]
        [Key]
        public int MaHoaDonBanHang { get => maHoaDonBanHang; set => maHoaDonBanHang = value; }
        [Column("MaHangHoa")]
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        [Column("SoLuong")]
        public int SoLuong { get => soLuong; set => soLuong = value; }
        [Column("GiaTri")]
        public decimal GiaTri { get => giaTri; set => giaTri = value; }
        [Column("GiaTriSauKhuyenMai")]
        public decimal GiaTriSauKhuyenMai { get => giaTriSauKhuyenMai; set => giaTriSauKhuyenMai = value; }
    }
}
