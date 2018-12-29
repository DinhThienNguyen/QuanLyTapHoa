using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("KhuyenMai")]
    class KhuyenMai
    {
        private int maKhuyenMai;
        private int maHangHoa;
        private string tenKhuyenMai;
        private float phanTramKhuyenMai;
        private int soLuongMua;
        private int soLuongTang;
        private long ngayBatDau;
        private long ngayKetThuc;

        public KhuyenMai()
        {

        }

        public KhuyenMai(int maKhuyenMai, int maHangHoa, string tenKhuyenMai, float phanTramKhuyenMai, int soLuongMua, int soLuongTang, long ngayBatDau, long ngayKetThuc)
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaKhuyenMai")]
        [Key]
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

        [Column("MaHangHoa")]
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

        [Column("TenKhuyenMai")]
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

        [Column("PhanTramKhuyenMai")]
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

        [Column("SoLuongMua")]
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

        [Column("SoLuongTang")]
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

        [Column("NgayBatDau")]
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

        [Column("NgayKetThuc")]
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
    }
}
