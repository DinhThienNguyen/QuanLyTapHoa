using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("HangHoa")]
    class HangHoa
    {
        private int maHangHoa;
        private string tenHangHoa;
        private string loaiHangHoa;
        private long ngayHetHan;
        private int soLuong;
        private decimal giaBanLe;
        private string donViTinh;

        public HangHoa()
        {
        }

        public HangHoa(int maHangHoa, string tenHangHoa, string loaiHangHoa, long ngayHetHan, int soLuong, decimal giaBanLe, string donViTinh)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.loaiHangHoa = loaiHangHoa;
            this.ngayHetHan = ngayHetHan;
            this.soLuong = soLuong;
            this.giaBanLe = giaBanLe;
            this.donViTinh = donViTinh;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaHangHoa")]
        [Key]
        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        [Column("TenHangHoa")]
        public string TenHangHoa { get => tenHangHoa; set => tenHangHoa = value; }
        [Column("LoaiHangHoa")]
        public string LoaiHangHoa { get => loaiHangHoa; set => loaiHangHoa = value; }
        [Column("NgayHetHan")]
        public long NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        [Column("SoLuong")]
        public int SoLuong { get => soLuong; set => soLuong = value; }
        [Column("GiaBanLe")]
        public decimal GiaBanLe { get => giaBanLe; set => giaBanLe = value; }
        [Column("DonViTinh")]
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
    }
}
