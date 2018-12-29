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
    class UuDaiService
    {
        public UuDaiDTO ToDTO(UuDai uuDai)
        {
            if (uuDai != null)
            {
                UuDaiDTO uuDaiDTO = new UuDaiDTO(uuDai.MaUuDai, uuDai.TenUuDai, uuDai.SoTienUuDaiToiDa, uuDai.SoLanMuaHangToiThieu, uuDai.NgayBatDau, uuDai.NgayKetThuc);
                return uuDaiDTO;
            }
            return null;
        }

        public UuDai ToEntity(UuDaiDTO uuDaiDTO)
        {
            if (uuDaiDTO != null)
            {
                UuDai uuDai = new UuDai(uuDaiDTO.MaUuDai, uuDaiDTO.TenUuDai, uuDaiDTO.SoTienUuDaiToiDa, uuDaiDTO.SoLanMuaHangToiThieu, uuDaiDTO.NgayBatDau, uuDaiDTO.NgayKetThuc);
                return uuDai;
            }
            return null;
        }

        public List<UuDaiDTO> findUuDaiNotExpired(UuDaiDTO uuDaiDTO)
        {
            List<UuDaiDTO> uuDaiDTOs = new List<UuDaiDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<UuDai> uuDais = context.UuDai
                        .Where(uDai => uDai.SoLanMuaHangToiThieu <= uuDaiDTO.SoLanMuaHangToiThieu)
                        .Where(udai => (udai.NgayBatDau < now && now < udai.NgayKetThuc) || (udai.NgayBatDau == 0 && udai.NgayKetThuc == 0))
                        .ToList<UuDai>();
                    foreach (UuDai temp in uuDais)
                    {
                        UuDaiDTO uDai = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        uuDaiDTOs.Add(uDai);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return uuDaiDTOs;
        }

        public List<UuDaiDTO> findUuDaiExpired(UuDaiDTO uuDaiDTO)
        {
            List<UuDaiDTO> uuDaiDTOs = new List<UuDaiDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    long now = DateTimeOffset.Now.ToUnixTimeSeconds();
                    List<UuDai> uuDais;
                    if (uuDaiDTO.NgayBatDau == 0 && uuDaiDTO.NgayKetThuc == 0)
                    {
                        uuDais = context.UuDai
                        .Where(uDai => uDai.TenUuDai.Contains(uuDaiDTO.TenUuDai))
                        .Where(uDai => uDai.SoTienUuDaiToiDa <= uuDaiDTO.SoTienUuDaiToiDa)
                        .Where(uDai => uDai.SoLanMuaHangToiThieu >= uuDaiDTO.SoLanMuaHangToiThieu)
                        .Where(udai => (udai.NgayBatDau == 0 && udai.NgayKetThuc == 0))
                        .ToList<UuDai>();
                    }
                    else
                    {
                        uuDais = context.UuDai
                           .Where(uDai => uDai.TenUuDai.Contains(uuDaiDTO.TenUuDai))
                           .Where(uDai => uDai.SoTienUuDaiToiDa <= uuDaiDTO.SoTienUuDaiToiDa)
                           .Where(uDai => uDai.SoLanMuaHangToiThieu >= uuDaiDTO.SoLanMuaHangToiThieu)
                           .Where(udai => (udai.NgayBatDau >= uuDaiDTO.NgayBatDau && udai.NgayKetThuc <= uuDaiDTO.NgayKetThuc))
                           .ToList<UuDai>();
                    }
                    
                    foreach (UuDai temp in uuDais)
                    {
                        UuDaiDTO uDai = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        uuDaiDTOs.Add(uDai);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return uuDaiDTOs;
        }

        public void addUuDai(UuDaiDTO uuDaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    UuDai uuDai = ToEntity(uuDaiDTO);
                    context.UuDai.Add(uuDai);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateUuDai(UuDaiDTO uuDaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    UuDai uuDai = ToEntity(uuDaiDTO);
                    context.Entry(uuDai).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteUuDai(UuDaiDTO uuDaiDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    UuDai uuDai = ToEntity(uuDaiDTO);
                    var entry = context.Entry(uuDai);
                    if (entry.State == EntityState.Detached)
                        context.UuDai.Attach(uuDai);
                    context.UuDai.Remove(uuDai);
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
