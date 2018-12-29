using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("BaoCaoNhapHang")]
    class BaoCaoNhapHang
    {
        private int maBaoCaoNhapHang;
        private long ngayNhapHang;
        private decimal tongTienVon;

        public BaoCaoNhapHang()
        {
        }

        public BaoCaoNhapHang(int maBaoCaoNhapHang, long ngayNhapHang, decimal tongTienVon)
        {
            this.maBaoCaoNhapHang = maBaoCaoNhapHang;
            this.ngayNhapHang = ngayNhapHang;
            this.tongTienVon = tongTienVon;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaBaoCaoNhapHang")]
        [Key]
        public int MaBaoCaoNhapHang { get => maBaoCaoNhapHang; set => maBaoCaoNhapHang = value; }
        [Column("NgayNhapHang")]
        public long NgayNhapHang { get => ngayNhapHang; set => ngayNhapHang = value; }
        [Column("TongTienVon")]
        public decimal TongTienVon { get => tongTienVon; set => tongTienVon = value; }
    }
}
