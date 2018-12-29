using QuanLyTapHoa.DAO;
using QuanLyTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.SERVICES
{
    class HoaDonBanHangService
    {
        public HoaDonBanHangDTO ToDTO(HoaDonBanHang hoaDonBanHang)
        {
            if (hoaDonBanHang != null)
            {
                HoaDonBanHangDTO hoaDonBanHangDTO = new HoaDonBanHangDTO(hoaDonBanHang.MaHoaDonBanHang,hoaDonBanHang.MaKhachHang,hoaDonBanHang.NgayKhoiTao,hoaDonBanHang.GiaTriHoaDon, hoaDonBanHang.GiaTriHoaDonSauKhuyenMai, hoaDonBanHang.GiaTriHoaDonSauUuDai, hoaDonBanHang.SoTienNhan, hoaDonBanHang.SoTienThua);
                return hoaDonBanHangDTO;
            }
            return null;
        }

        public HoaDonBanHang ToEntity(HoaDonBanHangDTO hoaDonBanHangDTO)
        {
            if (hoaDonBanHangDTO != null)
            {
                HoaDonBanHang hoaDonBanHang = new HoaDonBanHang(hoaDonBanHangDTO.MaHoaDonBanHang, hoaDonBanHangDTO.MaKhachHang, hoaDonBanHangDTO.NgayKhoiTao, hoaDonBanHangDTO.GiaTriHoaDon, hoaDonBanHangDTO.GiaTriHoaDonSauKhuyenMai, hoaDonBanHangDTO.GiaTriHoaDonSauUuDai, hoaDonBanHangDTO.SoTienNhan, hoaDonBanHangDTO.SoTienThua);
                return hoaDonBanHang;
            }
            return null;
        }

        public void addHoaDonBanHang(HoaDonBanHangDTO hoaDonBanHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HoaDonBanHang hoaDonBanHang = ToEntity(hoaDonBanHangDTO);
                    context.HoaDonBanHang.Add(hoaDonBanHang);
                    context.SaveChanges();
                    hoaDonBanHangDTO.MaHoaDonBanHang = hoaDonBanHang.MaHoaDonBanHang;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateHoaDonBanHang(HoaDonBanHangDTO hoaDonBanHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HoaDonBanHang hoaDonBanHang = ToEntity(hoaDonBanHangDTO);
                    context.Entry(hoaDonBanHang).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteHoaDonBanHang(HoaDonBanHangDTO hoaDonBanHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HoaDonBanHang hoaDonBanHang = ToEntity(hoaDonBanHangDTO);
                    var entry = context.Entry(hoaDonBanHang);
                    if (entry.State == EntityState.Detached)
                        context.HoaDonBanHang.Attach(hoaDonBanHang);
                    context.HoaDonBanHang.Remove(hoaDonBanHang);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
