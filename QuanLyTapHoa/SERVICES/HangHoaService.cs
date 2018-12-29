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
    class HangHoaService
    {
        public HangHoaDTO ToDTO(HangHoa hangHoa)
        {
            if (hangHoa != null)
            {
                HangHoaDTO hangHoaDTO = new HangHoaDTO(hangHoa.MaHangHoa, hangHoa.TenHangHoa, hangHoa.LoaiHangHoa, DateTimeOffset.FromUnixTimeSeconds(hangHoa.NgayHetHan).LocalDateTime, hangHoa.SoLuong, hangHoa.GiaBanLe, hangHoa.DonViTinh);
                return hangHoaDTO;
            }
            return null;
        }

        public HangHoa ToEntity(HangHoaDTO hangHoaDTO)
        {
            if (hangHoaDTO != null)
            {
                HangHoa hangHoa = new HangHoa(hangHoaDTO.MaHangHoa, hangHoaDTO.TenHangHoa, hangHoaDTO.LoaiHangHoa, ((DateTimeOffset)hangHoaDTO.NgayHetHan).ToUnixTimeSeconds(), hangHoaDTO.SoLuong, hangHoaDTO.GiaBanLe, hangHoaDTO.DonViTinh);
                return hangHoa;
            }
            return null;
        }

        public List<HangHoaDTO> findHangHoaNotExpired(HangHoaDTO hangHoaDTO)
        {
            List<HangHoaDTO> hangHoaDTOs = new List<HangHoaDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<HangHoa> hangHoas = context.HangHoa
                        .Where(hang => hang.TenHangHoa.Contains(hangHoaDTO.TenHangHoa))
                        .Where(hang => hang.LoaiHangHoa.Contains(hangHoaDTO.LoaiHangHoa))
                        .Where(hang => hang.SoLuong > 0)
                        .Where(hang => hang.NgayHetHan > now)
                        .ToList<HangHoa>();
                    foreach (HangHoa temp in hangHoas)
                    {
                        HangHoaDTO hang = ToDTO(temp);                        
                        hangHoaDTOs.Add(hang);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return hangHoaDTOs;
        }

        public List<HangHoaDTO> findHangHoaExpired(HangHoaDTO hangHoaDTO)
        {
            List<HangHoaDTO> hangHoaDTOs = new List<HangHoaDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<HangHoa> hangHoas = context.HangHoa
                        .Where(hang => hang.TenHangHoa.Contains(hangHoaDTO.TenHangHoa))                                                
                        .ToList<HangHoa>();
                    foreach (HangHoa temp in hangHoas)
                    {
                        HangHoaDTO hang = ToDTO(temp);                        
                        hangHoaDTOs.Add(hang);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return hangHoaDTOs;
        }

        public List<HangHoaDTO> findHangById(HangHoaDTO hangHoaDTO)
        {
            List<HangHoaDTO> hangHoaDTOs = new List<HangHoaDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<HangHoa> hangHoas = context.HangHoa
                        .Where(hang => hang.MaHangHoa.Equals(hangHoaDTO.MaHangHoa))
                        .ToList<HangHoa>();
                    foreach (HangHoa temp in hangHoas)
                    {
                        HangHoaDTO hang = ToDTO(temp);
                        hangHoaDTOs.Add(hang);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return hangHoaDTOs;
        }

        public void addHangHoa(HangHoaDTO hangHoaDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HangHoa hangHoa = ToEntity(hangHoaDTO);
                    context.HangHoa.Add(hangHoa);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateHangHoa(HangHoaDTO hangHoaDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HangHoa hangHoa = ToEntity(hangHoaDTO);
                    context.Entry(hangHoa).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteHangHoa(HangHoaDTO hangHoaDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    HangHoa hangHoa = ToEntity(hangHoaDTO);
                    var entry = context.Entry(hangHoa);
                    if (entry.State == EntityState.Detached)
                        context.HangHoa.Attach(hangHoa);
                    context.HangHoa.Remove(hangHoa);
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
