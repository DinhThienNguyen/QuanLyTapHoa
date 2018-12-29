using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DTO
{
    class HangHoaDTO
    {
        private int maHangHoa;
        private string tenHangHoa;
        private string loaiHangHoa;
        private DateTime ngayHetHan;
        private int soLuong;
        private int soLuongBan;
        private decimal giaBanLe;
        private string donViTinh;
        private KhuyenMaiDTO khuyenMaiDTO;
        private decimal tongGiaTri;

        public HangHoaDTO()
        {
            tenHangHoa = "";
            loaiHangHoa = "";
            khuyenMaiDTO = new KhuyenMaiDTO();
            tongGiaTri = 0;
            soLuongBan = 0;
        }

        public HangHoaDTO(int maHangHoa, string tenHangHoa, string loaiHangHoa, DateTime ngayHetHan, int soLuong, decimal giaBanLe, string donViTinh)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.loaiHangHoa = loaiHangHoa;
            this.ngayHetHan = ngayHetHan;
            this.soLuong = soLuong;
            this.giaBanLe = giaBanLe;
            this.donViTinh = donViTinh;
            khuyenMaiDTO = new KhuyenMaiDTO();
            tongGiaTri = 0;
            soLuongBan = 0;
        }

        public int MaHangHoa { get => maHangHoa; set => maHangHoa = value; }
        public string TenHangHoa { get => tenHangHoa; set => tenHangHoa = value; }
        public string LoaiHangHoa { get => loaiHangHoa; set => loaiHangHoa = value; }
        public DateTime NgayHetHan { get => ngayHetHan; set => ngayHetHan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal GiaBanLe { get => giaBanLe; set => giaBanLe = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float PhanTramKhuyenMai { get => khuyenMaiDTO.PhanTramKhuyenMai; set => khuyenMaiDTO.PhanTramKhuyenMai = value; }
        public int SoLuongMua { get => khuyenMaiDTO.SoLuongMua; set => khuyenMaiDTO.SoLuongMua = value; }
        public int SoLuongTang { get => khuyenMaiDTO.SoLuongTang; set => khuyenMaiDTO.SoLuongTang = value; }
        public decimal TongGiaTri { get => tongGiaTri; set => tongGiaTri = value; }
        public int SoLuongBan { get => soLuongBan; set => soLuongBan = value; }
        internal KhuyenMaiDTO KhuyenMaiDTO { get => khuyenMaiDTO; set => khuyenMaiDTO = value; }
    }
}
