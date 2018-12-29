using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTapHoa.DTO;
using QuanLyTapHoa.DAO;
using System.Data.Entity;

namespace QuanLyTapHoa.SERVICES
{
    class KhachHangService
    {
        public List<KhachHangDTO> getAllKhachHang()
        {
            List<KhachHangDTO> khachHangDTOs = new List<KhachHangDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    List<KhachHang> khachHangs = context.KhachHang.ToList<KhachHang>();
                    foreach (KhachHang temp in khachHangs)
                    {
                        KhachHangDTO khachHangDTO = ToDTO(temp);
                        //Console.Write(khachHangDTO.ToString());
                        khachHangDTOs.Add(khachHangDTO);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return khachHangDTOs;
        }

        public KhachHangDTO ToDTO(KhachHang khachHang)
        {
            if (khachHang != null)
            {
                KhachHangDTO khachHangDTO = new KhachHangDTO(khachHang.MaKhachHang, khachHang.TenKhachHang, khachHang.SoDienThoai, khachHang.SoLanMuaHang);
                return khachHangDTO;
            }
            return null;
        }

        public KhachHang ToEntity(KhachHangDTO khachHangDTO)
        {
            if (khachHangDTO != null)
            {
                KhachHang khachHang = new KhachHang(khachHangDTO.MaKhachHang, khachHangDTO.TenKhachHang, khachHangDTO.SoDienThoai, khachHangDTO.SoLanMuaHang);
                return khachHang;
            }
            return null;
        }

        public List<KhachHangDTO> findKhachHang(KhachHangDTO khachHangDTO)
        {
            List<KhachHangDTO> khachHangDTOs = new List<KhachHangDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    List<KhachHang> khachHangs = context.KhachHang.
                        Where(khach => khach.TenKhachHang.Contains(khachHangDTO.TenKhachHang))
                        .Where(khach => khach.SoDienThoai.Contains(khachHangDTO.SoDienThoai))
                        .Where(khach => khach.SoLanMuaHang >= khachHangDTO.SoLanMuaHang)
                        .ToList<KhachHang>();
                    foreach (KhachHang temp in khachHangs)
                    {
                        KhachHangDTO khach = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        khachHangDTOs.Add(khach);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return khachHangDTOs;
        }

        public void addKhachHang(KhachHangDTO khachHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhachHang khachHang = ToEntity(khachHangDTO);
                    context.KhachHang.Add(khachHang);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateKhachHang(KhachHangDTO khachHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhachHang khachHang = ToEntity(khachHangDTO);
                    context.Entry(khachHang).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteKhachHang(KhachHangDTO khachHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhachHang khachHang = ToEntity(khachHangDTO);
                    var entry = context.Entry(khachHang);
                    if (entry.State == EntityState.Detached)
                        context.KhachHang.Attach(khachHang);
                    context.KhachHang.Remove(khachHang);
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
