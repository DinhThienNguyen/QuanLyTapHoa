using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("UuDai")]
    class UuDai
    {
        private int maUuDai;
        private string tenUuDai;
        private decimal soTienUuDaiToiDa;
        private int soLanMuaHangToiThieu;
        private long ngayBatDau;
        private long ngayKetThuc;

        public UuDai()
        {
        }

        public UuDai(int maUuDai, string tenUuDai, decimal soTienUuDaiToiDa, int soLanMuaHangToiThieu, long ngayBatDau, long ngayKetThuc)
        {
            this.maUuDai = maUuDai;
            this.tenUuDai = tenUuDai;
            this.soTienUuDaiToiDa = soTienUuDaiToiDa;
            this.soLanMuaHangToiThieu = soLanMuaHangToiThieu;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaUuDai")]
        [Key]
        public int MaUuDai { get => maUuDai; set => maUuDai = value; }
        [Column("TenUuDai")]
        public string TenUuDai { get => tenUuDai; set => tenUuDai = value; }
        [Column("SoTienUuDaiToiDa")]
        public decimal SoTienUuDaiToiDa { get => soTienUuDaiToiDa; set => soTienUuDaiToiDa = value; }
        [Column("SoLanMuaHangToiThieu")]
        public int SoLanMuaHangToiThieu { get => soLanMuaHangToiThieu; set => soLanMuaHangToiThieu = value; }
        [Column("NgayBatDau")]
        public long NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        [Column("NgayKetThuc")]
        public long NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
    }
}
