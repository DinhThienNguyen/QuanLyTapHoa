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
    class BaoCaoNhapHangService
    {
        public BaoCaoNhapHangDTO ToDTO(BaoCaoNhapHang baoCaoNhapHang)
        {
            if (baoCaoNhapHang != null)
            {
                BaoCaoNhapHangDTO baoCaoNhapHangDTO = new BaoCaoNhapHangDTO(baoCaoNhapHang.MaBaoCaoNhapHang, baoCaoNhapHang.NgayNhapHang, baoCaoNhapHang.TongTienVon);
                return baoCaoNhapHangDTO;
            }
            return null;
        }

        public BaoCaoNhapHang ToEntity(BaoCaoNhapHangDTO baoCaoNhapHangDTO)
        {
            if (baoCaoNhapHangDTO != null)
            {
                BaoCaoNhapHang baoCaoNhapHang = new BaoCaoNhapHang(baoCaoNhapHangDTO.MaBaoCaoNhapHang, baoCaoNhapHangDTO.NgayNhapHang, baoCaoNhapHangDTO.TongTienVon);
                return baoCaoNhapHang;
            }
            return null;
        }

        public List<BaoCaoNhapHangDTO> findBaoCaoNhapHang(BaoCaoNhapHangDTO baoCaoNhapHangDTO)
        {
            List<BaoCaoNhapHangDTO> baoCaoNhapHangDTOs = new List<BaoCaoNhapHangDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {                    
                    List<BaoCaoNhapHang> baoCaoNhapHangs = context.BaoCaoNhapHang.
                        Where(bcao => bcao.MaBaoCaoNhapHang == baoCaoNhapHangDTO.MaBaoCaoNhapHang)                       
                        .ToList<BaoCaoNhapHang>();
                    foreach (BaoCaoNhapHang temp in baoCaoNhapHangs)
                    {
                        BaoCaoNhapHangDTO bcao = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        baoCaoNhapHangDTOs.Add(bcao);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return baoCaoNhapHangDTOs;
        }

        public void addBaoCaoNhapHang(BaoCaoNhapHangDTO baoCaoNhapHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    BaoCaoNhapHang baoCaoNhapHang = ToEntity(baoCaoNhapHangDTO);
                    context.BaoCaoNhapHang.Add(baoCaoNhapHang);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateBaoCaoNhapHang(BaoCaoNhapHangDTO baoCaoNhapHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    BaoCaoNhapHang baoCaoNhapHang = ToEntity(baoCaoNhapHangDTO);
                    context.Entry(baoCaoNhapHang).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteBaoCaoNhapHang(BaoCaoNhapHangDTO baoCaoNhapHangDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    BaoCaoNhapHang baoCaoNhapHang = ToEntity(baoCaoNhapHangDTO);
                    var entry = context.Entry(baoCaoNhapHang);
                    if (entry.State == EntityState.Detached)
                        context.BaoCaoNhapHang.Attach(baoCaoNhapHang);
                    context.BaoCaoNhapHang.Remove(baoCaoNhapHang);
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
