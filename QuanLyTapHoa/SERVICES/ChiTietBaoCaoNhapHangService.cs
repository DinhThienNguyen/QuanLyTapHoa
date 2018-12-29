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
    class ChiTietBaoCaoNhapHangService
    {
        public ChiTietBaoCaoNhapHangDTO ToDTO(ChiTietBaoCaoNhapHang chiTietBaoCao)
        {
            if (chiTietBaoCao != null)
            {
                ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO = new ChiTietBaoCaoNhapHangDTO(chiTietBaoCao.MaBaoCaoNhapHang, chiTietBaoCao.MaHangHoa, chiTietBaoCao.SoLuongNhap, chiTietBaoCao.TienVon);
                return chiTietBaoCaoDTO;
            }
            return null;
        }

        public ChiTietBaoCaoNhapHang ToEntity(ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO)
        {
            if (chiTietBaoCaoDTO != null)
            {
                ChiTietBaoCaoNhapHang chiTietBaoCao = new ChiTietBaoCaoNhapHang(chiTietBaoCaoDTO.MaBaoCaoNhapHang, chiTietBaoCaoDTO.MaHangHoa, chiTietBaoCaoDTO.SoLuongNhap, chiTietBaoCaoDTO.TienVon);
                return chiTietBaoCao;
            }
            return null;
        }

        public List<ChiTietBaoCaoNhapHangDTO> findChiTietBaoCaoNhapHang(ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO)
        {
            List<ChiTietBaoCaoNhapHangDTO> chiTietBaoCaoNhapHangDTOs = new List<ChiTietBaoCaoNhapHangDTO>();
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    List<ChiTietBaoCaoNhapHang> chiTietBaoCaoNhapHangs = context.ChiTietBaoCaoNhapHang.
                        Where(ctbcao => ctbcao.MaBaoCaoNhapHang == chiTietBaoCaoDTO.MaBaoCaoNhapHang)
                        .Where(ctbcao => ctbcao.MaHangHoa == chiTietBaoCaoDTO.MaHangHoa)
                        .ToList<ChiTietBaoCaoNhapHang>();
                    foreach (ChiTietBaoCaoNhapHang temp in chiTietBaoCaoNhapHangs)
                    {
                        ChiTietBaoCaoNhapHangDTO ctbcao = ToDTO(temp);
                        //Console.Write(khach.ToString())
                        chiTietBaoCaoNhapHangDTOs.Add(ctbcao);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return chiTietBaoCaoNhapHangDTOs;
        }

        public void addChiTietBaoCaoNhapHang(ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietBaoCaoNhapHang chiTietBaoCao = ToEntity(chiTietBaoCaoDTO);
                    context.ChiTietBaoCaoNhapHang.Add(chiTietBaoCao);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void updateChiTietBaoCaoNhapHang(ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietBaoCaoNhapHang chiTietBaoCao = ToEntity(chiTietBaoCaoDTO);
                    context.Entry(chiTietBaoCao).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void deleteChiTietBaoCaoNhapHang(ChiTietBaoCaoNhapHangDTO chiTietBaoCaoDTO)
        {
            using (EntityManager context = new EntityManager())
            {
                try
                {
                    ChiTietBaoCaoNhapHang chiTietBaoCao = ToEntity(chiTietBaoCaoDTO);
                    var entry = context.Entry(chiTietBaoCao);
                    if (entry.State == EntityState.Detached)
                        context.ChiTietBaoCaoNhapHang.Attach(chiTietBaoCao);
                    context.ChiTietBaoCaoNhapHang.Remove(chiTietBaoCao);
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
