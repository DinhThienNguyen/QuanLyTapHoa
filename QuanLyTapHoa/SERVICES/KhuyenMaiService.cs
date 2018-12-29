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
    class KhuyenMaiService
    {
        public KhuyenMaiDTO ToDTO(KhuyenMai khuyenMai)
        {
            if (khuyenMai != null)
            {
                KhuyenMaiDTO khuyenMaiDTO = new KhuyenMaiDTO(khuyenMai.MaKhuyenMai, khuyenMai.MaHangHoa, khuyenMai.TenKhuyenMai, khuyenMai.PhanTramKhuyenMai, khuyenMai.SoLuongMua, khuyenMai.SoLuongTang, khuyenMai.NgayBatDau, khuyenMai.NgayKetThuc);
                return khuyenMaiDTO;
            }
            return null;
        }

        public KhuyenMai ToEntity(KhuyenMaiDTO khuyenMaiDTO)
        {
            if (khuyenMaiDTO != null)
            {
                KhuyenMai khuyenMai = new KhuyenMai(khuyenMaiDTO.MaKhuyenMai, khuyenMaiDTO.MaHangHoa, khuyenMaiDTO.TenKhuyenMai, khuyenMaiDTO.PhanTramKhuyenMai, khuyenMaiDTO.SoLuongMua, khuyenMaiDTO.SoLuongTang, khuyenMaiDTO.NgayBatDau, khuyenMaiDTO.NgayKetThuc);
                return khuyenMai;
            }
            return null;
        }

        public List<KhuyenMaiDTO> findKhuyenMai(KhuyenMaiDTO khuyenMaiDTO)
        {
            List<KhuyenMaiDTO> khuyenMaiDTOs = new List<KhuyenMaiDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<KhuyenMai> khuyenMais = context.KhuyenMai.
                        Where(kmai => kmai.MaHangHoa == khuyenMaiDTO.MaHangHoa)
                        .Where(kmai => (kmai.NgayBatDau < now && now < kmai.NgayKetThuc) || (kmai.NgayBatDau == 0 && kmai.NgayKetThuc == 0))
                        .ToList<KhuyenMai>();
                    foreach (KhuyenMai temp in khuyenMais)
                    {
                        KhuyenMaiDTO kmai = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        khuyenMaiDTOs.Add(kmai);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return khuyenMaiDTOs;
        }

        public List<KhuyenMaiDTO> findKhuyenMaiExpired(KhuyenMaiDTO khuyenMaiDTO)
        {
            List<KhuyenMaiDTO> khuyenMaiDTOs = new List<KhuyenMaiDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<KhuyenMai> khuyenMais;
                    if (khuyenMaiDTO.NgayBatDau == 0 && khuyenMaiDTO.NgayKetThuc == 0)
                    {
                        khuyenMais = context.KhuyenMai
                        .Where(kmai => kmai.TenKhuyenMai.Contains(khuyenMaiDTO.TenKhuyenMai))
                        .Where(kmai => kmai.PhanTramKhuyenMai <= khuyenMaiDTO.PhanTramKhuyenMai)
                        .Where(kmai => kmai.SoLuongMua <= khuyenMaiDTO.SoLuongMua)
                        .Where(kmai => (kmai.NgayBatDau == 0 && kmai.NgayKetThuc == 0))
                        .ToList<KhuyenMai>();
                    }
                    else
                    {
                        khuyenMais = context.KhuyenMai
                            .Where(kmai => kmai.TenKhuyenMai.Contains(khuyenMaiDTO.TenKhuyenMai))
                            .Where(kmai => kmai.PhanTramKhuyenMai <= khuyenMaiDTO.PhanTramKhuyenMai)
                            .Where(kmai => kmai.SoLuongMua <= khuyenMaiDTO.SoLuongMua)
                            .Where(kmai => (kmai.NgayBatDau >= khuyenMaiDTO.NgayBatDau && kmai.NgayKetThuc <= khuyenMaiDTO.NgayKetThuc))
                            .ToList<KhuyenMai>();
                    }

                    foreach (KhuyenMai temp in khuyenMais)
                    {
                        KhuyenMaiDTO kmai = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        khuyenMaiDTOs.Add(kmai);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return khuyenMaiDTOs;
        }

        public void addKhuyenMai(KhuyenMaiDTO khuyenMaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhuyenMai khuyenMai = ToEntity(khuyenMaiDTO);
                    context.KhuyenMai.Add(khuyenMai);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateKhuyenMai(KhuyenMaiDTO khuyenMaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhuyenMai khuyenMai = ToEntity(khuyenMaiDTO);
                    context.Entry(khuyenMai).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteKhuyenMai(KhuyenMaiDTO khuyenMaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    KhuyenMai khuyenMai = ToEntity(khuyenMaiDTO);
                    var entry = context.Entry(khuyenMai);
                    if (entry.State == EntityState.Detached)
                        context.KhuyenMai.Attach(khuyenMai);
                    context.KhuyenMai.Remove(khuyenMai);
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
