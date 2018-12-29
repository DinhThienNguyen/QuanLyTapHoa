using QuanLyTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using QuanLyTapHoa.DAO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.SERVICES
{
    class ChiTietHoaDonService
    {
        public ChiTietHoaDonDTO ToDTO(ChiTietHoaDon chiTietHoaDon)
        {
            if (chiTietHoaDon != null)
            {
                ChiTietHoaDonDTO chiTietHoaDonDTO = new ChiTietHoaDonDTO(chiTietHoaDon.MaHoaDonBanHang, chiTietHoaDon.MaHangHoa, chiTietHoaDon.SoLuong, chiTietHoaDon.GiaTri, chiTietHoaDon.GiaTriSauKhuyenMai);
                return chiTietHoaDonDTO;
            }
            return null;
        }

        public ChiTietHoaDon ToEntity(ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            if (chiTietHoaDonDTO != null)
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(chiTietHoaDonDTO.MaHoaDonBanHang, chiTietHoaDonDTO.MaHangHoa, chiTietHoaDonDTO.SoLuong, chiTietHoaDonDTO.GiaTri, chiTietHoaDonDTO.GiaTriSauKhuyenMai);
                return chiTietHoaDon;
            }
            return null;
        }

        public void addChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietHoaDon chiTietHoaDon = ToEntity(chiTietHoaDonDTO);
                    context.ChiTietHoaDon.Add(chiTietHoaDon);
                    context.SaveChanges();
                    //hoaDonBanHangDTO.MaHoaDonBanHang = hoaDonBanHang.MaHoaDonBanHang;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietHoaDon chiTietHoaDon = ToEntity(chiTietHoaDonDTO);
                    context.Entry(chiTietHoaDon).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDonDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietHoaDon chiTietHoaDon = ToEntity(chiTietHoaDonDTO);
                    var entry = context.Entry(chiTietHoaDon);
                    if (entry.State == EntityState.Detached)
                        context.ChiTietHoaDon.Attach(chiTietHoaDon);
                    context.ChiTietHoaDon.Remove(chiTietHoaDon);
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
