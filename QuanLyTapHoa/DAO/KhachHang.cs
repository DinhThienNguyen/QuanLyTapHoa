using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAO
{
    [Table("KhachHang")]
    class KhachHang
    {                
        private int maKhachHang;        
        private string tenKhachHang;        
        private string soDienThoai;        
        private int soLanMuaHang;

        public KhachHang(int maKhachHang, string tenKhachHang, string soDienThoai, int soLanMuaHang)
        {
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.soDienThoai = soDienThoai;
            this.soLanMuaHang = soLanMuaHang;
        }

        public KhachHang()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MaKhachHang")]
        [Key]
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

        [Column("TenKhachHang")]
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

        [Column("SoDienThoai")]
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

        [Column("SoLanMuaHang")]
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

    }
}
