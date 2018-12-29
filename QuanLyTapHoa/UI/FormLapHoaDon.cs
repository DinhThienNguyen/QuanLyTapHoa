using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTapHoa.DAO;
using QuanLyTapHoa.SERVICES;
using QuanLyTapHoa.DTO;

namespace QuanLyTapHoa.UI
{
    public partial class FormLapHoaDon : Form
    {
        private KhachHangService khachHangService;
        private HangHoaService hangHoaService;
        private KhuyenMaiService khuyenMaiService;
        private UuDaiService uuDaiService;
        private HoaDonBanHangService hoaDonBanHangService;
        private ChiTietHoaDonService chiTietHoaDonService;
        private long NgayKhoiTaoHoaDon;
        private BindingList<HangHoaDTO> selectedHangHoaHoaDon;
        private KhachHangDTO selectedKhach;
        decimal TriGiaHoaDon = 0;
        decimal TriGiaHoaDonSauKhuyenMai = 0;
        decimal TriGiaHoaDonSauUuDai = 0;
        decimal SoTienNhan = 0;
        decimal SoTienThua = 0;    

        public FormLapHoaDon()
        {
            InitializeComponent();
        }

        private void FormLapHoaDon_Load(object sender, EventArgs e)
        {
            //DataGridViewButtonColumn xoaHangHoaHoaDonButtonColumn = new DataGridViewButtonColumn();
            //xoaHangHoaHoaDonButtonColumn.Name = "xoaHangHoaHoaDonButtonColumn";
            //xoaHangHoaHoaDonButtonColumn.HeaderText = "Xóa";
            //xoaHangHoaHoaDonButtonColumn.Text = "Xóa";
            //xoaHangHoaHoaDonButtonColumn.UseColumnTextForButtonValue = true;
            //xoaHangHoaHoaDonButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewHangHoaHoaDon.CellClick += dataGridViewHangHoaHoaDon_CellClick;
            labelTriGiaHoaDonGoc.Text = Convert.ToString(TriGiaHoaDon);
            labelTienThua.Text = Convert.ToString(SoTienThua);
            labelTriGiaHoaDonSauKhuyenMai.Text = Convert.ToString(TriGiaHoaDonSauKhuyenMai);
            labelTriGiaHoaDonSauUuDai.Text = Convert.ToString(TriGiaHoaDonSauUuDai);
            //if (dataGridViewHangHoaHoaDon.Columns["XoaHangHoaHoaDon"] == null)
            //{
            //    dataGridViewHangHoaHoaDon.Columns.Add(xoaHangHoaHoaDonButtonColumn);
            //}

            khachHangService = new KhachHangService();
            hangHoaService = new HangHoaService();
            khuyenMaiService = new KhuyenMaiService();
            uuDaiService = new UuDaiService();
            chiTietHoaDonService = new ChiTietHoaDonService();
            hoaDonBanHangService = new HoaDonBanHangService();
            selectedHangHoaHoaDon = new BindingList<HangHoaDTO>();
            dataGridViewHangHoaHoaDon.DataSource = selectedHangHoaHoaDon;

            //var source = new BindingSource();            
            //source.DataSource = selectedHangHoaHoaDon;
            //dataGridViewHangHoaHoaDon.DataSource = source;

            PopulateKhachHangGridView();
            PopulateHangHoaGridView();
            ClearKhachInHoaDon();
        }

        private void FindProducts()
        {
            HangHoaDTO hangHoaDTO = new HangHoaDTO();
            hangHoaDTO.TenHangHoa = textBoxTenHangHoa.Text == string.Empty ? string.Empty : textBoxTenHangHoa.Text;
            List<HangHoaDTO> hangHoaDTOs = hangHoaService.findHangHoaNotExpired(hangHoaDTO);
            if (hangHoaDTOs.Count != 0)
            {
                FindKhuyenMaiForProduct(hangHoaDTOs);
                dataGridViewHangHoa.DataSource = hangHoaDTOs;
            }
            else
            {
                FormFindRelatedProductsConfimation formFindRelatedProductsConfimation = new FormFindRelatedProductsConfimation();
                if (formFindRelatedProductsConfimation.ShowDialog() == DialogResult.OK)
                {
                    formFindRelatedProductsConfimation.Close();
                    hangHoaDTOs = hangHoaService.findHangHoaExpired(hangHoaDTO);
                    if (hangHoaDTOs.Count != 0)
                    {
                        hangHoaDTO = new HangHoaDTO();
                        hangHoaDTO.LoaiHangHoa = hangHoaDTOs[0].LoaiHangHoa;
                        hangHoaDTOs = hangHoaService.findHangHoaNotExpired(hangHoaDTO);
                        if (hangHoaDTOs.Count != 0)
                        {
                            FindKhuyenMaiForProduct(hangHoaDTOs);
                            dataGridViewHangHoa.DataSource = hangHoaDTOs;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        private void FindKhuyenMaiForProduct(List<HangHoaDTO> hangHoaDTOs)
        {
            KhuyenMaiDTO khuyenMaiDTO = new KhuyenMaiDTO();
            for (int i = 0; i < hangHoaDTOs.Count; i++)
            {
                khuyenMaiDTO.MaHangHoa = hangHoaDTOs[i].MaHangHoa;
                List<KhuyenMaiDTO> khuyenMaiDTOs = khuyenMaiService.findKhuyenMai(khuyenMaiDTO);
                if (khuyenMaiDTOs.Count > 0)
                    hangHoaDTOs[i].KhuyenMaiDTO = khuyenMaiDTOs[0];
            }
        }

        private void CalculateTriGiaHoaDon()
        {
            TriGiaHoaDon = 0;
            TriGiaHoaDonSauKhuyenMai = 0;
            TriGiaHoaDonSauUuDai = 0;
            foreach (HangHoaDTO hangHoaDTO in selectedHangHoaHoaDon)
            {
                TriGiaHoaDon += hangHoaDTO.GiaBanLe * hangHoaDTO.SoLuongBan;
                TriGiaHoaDonSauKhuyenMai += hangHoaDTO.TongGiaTri;
            }
            TriGiaHoaDonSauUuDai = TriGiaHoaDonSauKhuyenMai;
            
            if (selectedKhach.MaKhachHang != 0)
            {
                UuDaiDTO uuDaiDTO = new UuDaiDTO();
                uuDaiDTO.SoLanMuaHangToiThieu = selectedKhach.SoLanMuaHang;
                List<UuDaiDTO> uuDaiDTOs = uuDaiService.findUuDaiNotExpired(uuDaiDTO);
                if (selectedKhach.SoLanMuaHang >= uuDaiDTOs[0].SoLanMuaHangToiThieu)
                {
                    string tempTriGiaHoaDonSauKhuyenMai = Convert.ToString(TriGiaHoaDonSauKhuyenMai);
                    string tempSoTienGiamUuDai = Convert.ToString(uuDaiDTOs[0].SoTienUuDaiToiDa);
                    if(tempTriGiaHoaDonSauKhuyenMai.Length - tempSoTienGiamUuDai.Length >= 1)
                    {
                        tempTriGiaHoaDonSauKhuyenMai = tempTriGiaHoaDonSauKhuyenMai.Substring(tempTriGiaHoaDonSauKhuyenMai.Length - tempSoTienGiamUuDai.Length);
                        if(Convert.ToDecimal(tempTriGiaHoaDonSauKhuyenMai) - Convert.ToDecimal(tempSoTienGiamUuDai) >= 0)
                        {
                            TriGiaHoaDonSauUuDai = TriGiaHoaDonSauKhuyenMai - Convert.ToDecimal(uuDaiDTOs[0].SoTienUuDaiToiDa);
                        }
                    }
                }
            }
            UpdateHoaDonLabel();
        }

        private void LapHoaDon()
        {                        
            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            if(SoTienNhan < TriGiaHoaDonSauKhuyenMai)
            {
                MessageBox.Show("Số tiền nhận phải lớn hơn thành tiền của hóa đơn!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (selectedHangHoaHoaDon.Count == 0)
            {
                MessageBox.Show("Danh sách hàng hóa được mua trống!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            HoaDonBanHangDTO hoaDonBanHangDTO = new HoaDonBanHangDTO(
                0,
                selectedKhach.MaKhachHang,
                now,
                TriGiaHoaDon,
                TriGiaHoaDonSauKhuyenMai,
                TriGiaHoaDonSauUuDai,
                SoTienNhan,
                SoTienThua
                );
            hoaDonBanHangService.addHoaDonBanHang(hoaDonBanHangDTO);
            foreach(HangHoaDTO hang in selectedHangHoaHoaDon)
            {
                decimal khuyenMai = (hang.TongGiaTri * Convert.ToDecimal(hang.PhanTramKhuyenMai)) / 100;                
                ChiTietHoaDonDTO chiTietHoaDonDTO = new ChiTietHoaDonDTO(
                    hoaDonBanHangDTO.MaHoaDonBanHang,
                    hang.MaHangHoa,
                    hang.SoLuongBan,
                    hang.TongGiaTri,
                    hang.TongGiaTri - khuyenMai
                    );
                chiTietHoaDonService.addChiTietHoaDon(chiTietHoaDonDTO);
                hang.SoLuong -= hang.SoLuongBan;
                hangHoaService.updateHangHoa(hang);
            }
            if (selectedKhach.MaKhachHang != 0)
            {
                selectedKhach.SoLanMuaHang++;
                khachHangService.updateKhachHang(selectedKhach);
            }
            ClearHoaDon();
            FindProducts();
            FindKhachHang();
            MessageBox.Show("Lập hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK);            
        }

        private void PopulateKhachHangGridView()
        {
            List<KhachHangDTO> khachHangs = khachHangService.getAllKhachHang();
            dataGridViewKhachHang.DataSource = khachHangs;
        }

        private void PopulateHangHoaGridView()
        {
            //HangHoaDTO hangHoaDTO = new HangHoaDTO();
            //List<HangHoaDTO> hangHoaDTOs = hangHoaService.findHangHoaNotExpired(hangHoaDTO);
            //dataGridViewHangHoa.DataSource = hangHoaDTOs;
            FindProducts();
        }

        private void buttonFindKhachHang_Click(object sender, EventArgs e)
        {
            FindKhachHang();
        }

        private void FindKhachHang()
        {
            KhachHangDTO khachHangDTO = new KhachHangDTO();
            khachHangDTO.TenKhachHang = textBoxTenKhachHang.Text == string.Empty ? string.Empty : textBoxTenKhachHang.Text;
            khachHangDTO.SoDienThoai = textBoxSoDienThoai.Text == string.Empty ? string.Empty : textBoxSoDienThoai.Text;
            List<KhachHangDTO> khachHangs = khachHangService.findKhachHang(khachHangDTO);
            dataGridViewKhachHang.DataSource = khachHangs;
        }

        private void buttonTimHangHoa_Click(object sender, EventArgs e)
        {
            FindProducts();
        }

        private void UpdateHoaDonLabel()
        {
            labelTienThua.Text = Convert.ToString(SoTienThua);
            labelTriGiaHoaDonGoc.Text = Convert.ToString(TriGiaHoaDon);
            labelTriGiaHoaDonSauKhuyenMai.Text = Convert.ToString(TriGiaHoaDonSauKhuyenMai);
            labelTriGiaHoaDonSauUuDai.Text = Convert.ToString(TriGiaHoaDonSauUuDai);
        }

        private void ClearHoaDon()
        {
            ClearKhachInHoaDon();
            selectedHangHoaHoaDon.Clear();
            TriGiaHoaDon = 0;
            TriGiaHoaDonSauKhuyenMai = 0;
            TriGiaHoaDonSauUuDai = 0;
            SoTienNhan = 0;
            SoTienThua = 0;
            textBoxTienNhan.Text = string.Empty;
            UpdateHoaDonLabel();
            textBoxTienNhan.Text = string.Empty;
            buttonLapHoaDon.Enabled = false;
        }

        private void ClearKhachInHoaDon()
        {
            selectedKhach = new KhachHangDTO();
            selectedKhach.MaKhachHang = 0;
            selectedKhach.TenKhachHang = "Khách vãng lai";
            labelKhachInHoaDon.Text = selectedKhach.TenKhachHang;
        }

        private void textBoxTenHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindProducts();
            }
        }

        private void dataGridViewHangHoa_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewHangHoa.CurrentRow.Index != -1)
            {
                HangHoaDTO hangHoaDTO = new HangHoaDTO(
                    Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["MaHangHoa"].Value),
                    Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["TenHangHoa"].Value),
                    Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["LoaiHangHoa"].Value),
                    Convert.ToDateTime(dataGridViewHangHoa.CurrentRow.Cells["NgayHetHan"].Value),
                    Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["SoLuong"].Value),
                    Convert.ToDecimal(dataGridViewHangHoa.CurrentRow.Cells["GiaBanLe"].Value),
                    Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["DonViTinh"].Value)
                    );
                hangHoaDTO.PhanTramKhuyenMai = Convert.ToSingle(dataGridViewHangHoa.CurrentRow.Cells["PhanTramKhuyenMai"].Value);
                hangHoaDTO.SoLuongMua = Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["SoLuongMua"].Value);
                hangHoaDTO.SoLuongTang = Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["SoLuongTang"].Value);
                FormXacNhanSoLuong formXacNhanSoLuong = new FormXacNhanSoLuong(hangHoaDTO.SoLuong);
                if (formXacNhanSoLuong.ShowDialog() == DialogResult.OK)
                {
                    HangHoaDTO hang;
                    bool hangExisted = false;
                    for (int i = 0; i < selectedHangHoaHoaDon.Count; i++)
                    {
                        hang = selectedHangHoaHoaDon[i];
                        if (hang.MaHangHoa == hangHoaDTO.MaHangHoa)
                        {
                            hangExisted = true;
                            if (hang.SoLuongBan + formXacNhanSoLuong.SoLuong > hangHoaDTO.SoLuong)
                            {
                                MessageBox.Show("Số lượng cần bán phải nhỏ hơn số lượng hiện có!", "Lỗi", MessageBoxButtons.OK);
                                return;
                            }
                            else
                            {                                
                                selectedHangHoaHoaDon[i].SoLuongBan += formXacNhanSoLuong.SoLuong;
                                CalculateProductPrice(selectedHangHoaHoaDon[i]);                                
                            }
                        }
                    }

                    if (!hangExisted)
                    {
                        hangHoaDTO.SoLuongBan = formXacNhanSoLuong.SoLuong;
                        CalculateProductPrice(hangHoaDTO);
                        selectedHangHoaHoaDon.Add(hangHoaDTO);
                    }
                }
                buttonLapHoaDon.Enabled = true;
                dataGridViewHangHoaHoaDon.Refresh();
                CalculateTriGiaHoaDon();
            }
        }

        private void CalculateProductPrice(HangHoaDTO hangHoaDTO)
        {
            hangHoaDTO.TongGiaTri = hangHoaDTO.GiaBanLe * hangHoaDTO.SoLuongBan;
            if (hangHoaDTO.SoLuongMua > 0 && hangHoaDTO.SoLuongBan > hangHoaDTO.SoLuongMua)
            {
                if (hangHoaDTO.PhanTramKhuyenMai > 0)
                {
                    decimal khuyenMai = (hangHoaDTO.TongGiaTri * Convert.ToDecimal(hangHoaDTO.PhanTramKhuyenMai)) / 100;
                    hangHoaDTO.TongGiaTri = hangHoaDTO.TongGiaTri - khuyenMai;
                }
                else if (hangHoaDTO.SoLuongTang > 0)
                {
                    if (hangHoaDTO.SoLuongTang + hangHoaDTO.SoLuongBan > hangHoaDTO.SoLuong)
                    {
                        MessageBox.Show("Hàng này đang có khuyến mãi mua " + hangHoaDTO.SoLuongMua + " tặng " + hangHoaDTO.SoLuongTang + ". Hiện số lượng hàng không đủ dể tặng khuyến mãi!", "Thông báo", MessageBoxButtons.OK);                       
                    }
                    else
                    {
                        hangHoaDTO.SoLuongBan += hangHoaDTO.SoLuongTang;
                    }
                }
            }           
        }

        private void dataGridViewHangHoaHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewHangHoaHoaDon.Columns["XoaHang"].Index)
            {
                //Console.WriteLine(dataGridViewHangHoaHoaDon.CurrentCell.RowIndex);
                selectedHangHoaHoaDon.RemoveAt(dataGridViewHangHoaHoaDon.CurrentCell.RowIndex);
                CalculateTriGiaHoaDon();
            }
        }

        private void buttonClearKhachInHoaDon_Click(object sender, EventArgs e)
        {
            ClearKhachInHoaDon();
        }

        private void dataGridViewKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.CurrentRow.Index != -1)
            {
                selectedKhach.MaKhachHang = Convert.ToInt32(dataGridViewKhachHang.CurrentRow.Cells["MaKhachHang"].Value);
                selectedKhach.TenKhachHang = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["TenKhachHang"].Value);
                selectedKhach.SoDienThoai = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["SoDienThoai"].Value);
                selectedKhach.SoLanMuaHang = Convert.ToInt32(dataGridViewKhachHang.CurrentRow.Cells["SoLanMuaHang"].Value);
                labelKhachInHoaDon.Text = selectedKhach.TenKhachHang;
                CalculateTriGiaHoaDon();
            }
        }

        private void textBoxTienNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!decimal.TryParse(textBoxTienNhan.Text, out SoTienNhan))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Tiền nhận!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                SoTienThua = SoTienNhan - TriGiaHoaDonSauUuDai;
                labelTienThua.Text = Convert.ToString(SoTienThua);
            }
        }

        private void buttonLapHoaDon_Click(object sender, EventArgs e)
        {
            LapHoaDon();
        }
    }
}
