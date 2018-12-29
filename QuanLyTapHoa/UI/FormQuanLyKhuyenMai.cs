using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTapHoa.DAO;
using QuanLyTapHoa.SERVICES;
using QuanLyTapHoa.DTO;

namespace QuanLyTapHoa.UI
{
    public partial class FormQuanLyKhuyenMai : Form
    {
        private KhuyenMaiService khuyenMaiService;
        private HangHoaService hangHoaService;
        private KhuyenMaiDTO selectedKhuyenMai;
        private List<HangHoaDTO> selectHangHoaDTOs;
        private bool comboBoxThoiHanKhuyenMaiLoaded = false;
        private bool comboBoxThongTinThoiHanKhuyenMaiLoaded = false;

        public FormQuanLyKhuyenMai()
        {
            InitializeComponent();
        }

        private void FormQuanLyKhuyenMai_Load(object sender, EventArgs e)
        {
            khuyenMaiService = new KhuyenMaiService();
            hangHoaService = new HangHoaService();
            selectedKhuyenMai = new KhuyenMaiDTO();
            selectHangHoaDTOs = new List<HangHoaDTO>();
            comboBoxThongTinThoiHanKhuyenMai.DisplayMember = "Text";
            comboBoxThongTinThoiHanKhuyenMai.ValueMember = "Value";
            comboBoxThoiHanKhuyenMai.DisplayMember = "Text";
            comboBoxThoiHanKhuyenMai.ValueMember = "Value";
            List<Object> items1 = new List<object>();
            items1.Add(new { Text = "Không thời hạn", Value = "Không thời hạn" });
            items1.Add(new { Text = "Có thời hạn", Value = "Có thời hạn" });
            List<Object> items2 = new List<object>();
            items2.Add(new { Text = "Không thời hạn", Value = "Không thời hạn" });
            items2.Add(new { Text = "Có thời hạn", Value = "Có thời hạn" });
            comboBoxThoiHanKhuyenMai.DataSource = items1;
            comboBoxThongTinThoiHanKhuyenMai.DataSource = items2;
            comboBoxThoiHanKhuyenMaiLoaded = true;
            comboBoxThongTinThoiHanKhuyenMaiLoaded = true;
            FindProducts();
            FindKhuyenMai();
        }

        private void FindKhuyenMai()
        {
            KhuyenMaiDTO khuyenMaiDTO = new KhuyenMaiDTO();

            khuyenMaiDTO.TenKhuyenMai = textBoxTenKhuyenMai.Text == string.Empty ? string.Empty : textBoxTenKhuyenMai.Text;
            float PhanTramKhuyenMai = 0;
            int SoLuongHangMua = 0;
            int SoLuongHangTang = 0;
            if (textBoxPhanTramKhuyenMai.Text != string.Empty)
            {
                if (!float.TryParse(textBoxPhanTramKhuyenMai.Text, out PhanTramKhuyenMai))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô phần trăm khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                PhanTramKhuyenMai = float.MaxValue;
            }
            khuyenMaiDTO.PhanTramKhuyenMai = PhanTramKhuyenMai;
            if (textBoxSoLuongHangMua.Text != string.Empty)
            {
                if (!int.TryParse(textBoxSoLuongHangMua.Text, out SoLuongHangMua))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng mua!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                SoLuongHangMua = int.MaxValue;
            }
            khuyenMaiDTO.SoLuongMua = SoLuongHangMua;
            if (textBoxSoLuongHangTang.Text != string.Empty)
            {
                if (!int.TryParse(textBoxSoLuongHangTang.Text, out SoLuongHangTang))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng tặng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                SoLuongHangTang = int.MaxValue;
            }
            khuyenMaiDTO.SoLuongTang = SoLuongHangTang;
            if (comboBoxThoiHanKhuyenMai.SelectedValue.Equals("Không thời hạn"))
            {
                khuyenMaiDTO.NgayBatDau = 0;
                khuyenMaiDTO.NgayKetThuc = 0;
            }
            else
            {
                khuyenMaiDTO.NgayBatDau = ((DateTimeOffset)dateTimePickerNgayBatDau.Value).ToUnixTimeSeconds();
                khuyenMaiDTO.NgayKetThuc = ((DateTimeOffset)dateTimePickerNgayKetThuc.Value).ToUnixTimeSeconds();
            }
            List<KhuyenMaiDTO> khuyenMaiDTOs = khuyenMaiService.findKhuyenMaiExpired(khuyenMaiDTO);
            dataGridViewDanhSachKhuyenMai.DataSource = khuyenMaiDTOs;
        }

        private void AddKhuyenMai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn thêm khuyến mãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                KhuyenMaiDTO khuyenMaiDTO = new KhuyenMaiDTO();

                if (textBoxThongTinTenKhuyenMai.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                khuyenMaiDTO.TenKhuyenMai = textBoxThongTinTenKhuyenMai.Text == string.Empty ? string.Empty : textBoxThongTinTenKhuyenMai.Text;
                float PhanTramKhuyenMai = 0;
                int SoLuongHangMua = 0;
                int SoLuongHangTang = 0;
                if (textBoxThongTinPhanTramKhuyenMai.Text != string.Empty)
                {
                    if (!float.TryParse(textBoxThongTinPhanTramKhuyenMai.Text, out PhanTramKhuyenMai))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô phần trăm khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (PhanTramKhuyenMai < 0 || PhanTramKhuyenMai > 100)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số từ 1 đến 100 vào ô phần trăm khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                khuyenMaiDTO.PhanTramKhuyenMai = PhanTramKhuyenMai;
                if (textBoxThongTinSoLuongHangMua.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxThongTinSoLuongHangMua.Text, out SoLuongHangMua))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng mua!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuongHangMua < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng mua!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                khuyenMaiDTO.SoLuongMua = SoLuongHangMua;
                if (textBoxThongTinSoLuongHangTang.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxThongTinSoLuongHangTang.Text, out SoLuongHangTang))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng tặng!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuongHangTang < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng tặng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                khuyenMaiDTO.SoLuongTang = SoLuongHangTang;
                if (comboBoxThongTinThoiHanKhuyenMai.SelectedValue.Equals("Không thời hạn"))
                {
                    khuyenMaiDTO.NgayBatDau = 0;
                    khuyenMaiDTO.NgayKetThuc = 0;
                }
                else
                {
                    khuyenMaiDTO.NgayBatDau = ((DateTimeOffset)dateTimePickerNgayBatDau.Value).ToUnixTimeSeconds();
                    khuyenMaiDTO.NgayKetThuc = ((DateTimeOffset)dateTimePickerNgayKetThuc.Value).ToUnixTimeSeconds();
                }
                if (selectHangHoaDTOs.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cho khuyến mãi này!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                khuyenMaiDTO.MaHangHoa = selectHangHoaDTOs[0].MaHangHoa;
                khuyenMaiService.addKhuyenMai(khuyenMaiDTO);
                ClearThongTinKhuyenMai();
                MessageBox.Show("Thêm khuyến mãi mới thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void UpdateKhuyenMai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn cập nhật khuyến mãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                KhuyenMaiDTO khuyenMaiDTO = new KhuyenMaiDTO();

                if (textBoxThongTinTenKhuyenMai.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedKhuyenMai.TenKhuyenMai = textBoxThongTinTenKhuyenMai.Text == string.Empty ? string.Empty : textBoxThongTinTenKhuyenMai.Text;
                float PhanTramKhuyenMai = 0;
                int SoLuongHangMua = 0;
                int SoLuongHangTang = 0;
                if (textBoxThongTinPhanTramKhuyenMai.Text != string.Empty)
                {
                    if (!float.TryParse(textBoxThongTinPhanTramKhuyenMai.Text, out PhanTramKhuyenMai))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô phần trăm khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (PhanTramKhuyenMai < 0 || PhanTramKhuyenMai > 100)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số từ 1 đến 100 vào ô phần trăm khuyến mãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                selectedKhuyenMai.PhanTramKhuyenMai = PhanTramKhuyenMai;
                if (textBoxThongTinSoLuongHangMua.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxThongTinSoLuongHangMua.Text, out SoLuongHangMua))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng mua!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuongHangMua < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng mua!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedKhuyenMai.SoLuongMua = SoLuongHangMua;
                if (textBoxThongTinSoLuongHangTang.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxThongTinSoLuongHangTang.Text, out SoLuongHangTang))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lượng hàng tặng!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuongHangTang < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng tặng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedKhuyenMai.SoLuongTang = SoLuongHangTang;
                if (comboBoxThongTinThoiHanKhuyenMai.SelectedValue.Equals("Không thời hạn"))
                {
                    selectedKhuyenMai.NgayBatDau = 0;
                    selectedKhuyenMai.NgayKetThuc = 0;
                }
                else
                {
                    selectedKhuyenMai.NgayBatDau = ((DateTimeOffset)dateTimePickerNgayBatDau.Value).ToUnixTimeSeconds();
                    selectedKhuyenMai.NgayKetThuc = ((DateTimeOffset)dateTimePickerNgayKetThuc.Value).ToUnixTimeSeconds();
                }
                if (selectHangHoaDTOs.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cho khuyến mãi này!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedKhuyenMai.MaHangHoa = selectHangHoaDTOs[0].MaHangHoa;
                khuyenMaiService.updateKhuyenMai(selectedKhuyenMai);
                FindKhuyenMai();
                MessageBox.Show("Cập nhật thành công thông tin khuyến mãi!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DeleteKhuyenMai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn xóa khuyến mãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                khuyenMaiService.deleteKhuyenMai(selectedKhuyenMai);
                FindKhuyenMai();
                FindHangHoa();
                ClearThongTinKhuyenMai();
                MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void FindHangHoa()
        {
            HangHoaDTO hangHoaDTO = new HangHoaDTO();
            hangHoaDTO.MaHangHoa = selectedKhuyenMai.MaHangHoa;
            selectHangHoaDTOs = hangHoaService.findHangById(hangHoaDTO);
            
        }

        private void FindProducts()
        {
            HangHoaDTO hangHoaDTO = new HangHoaDTO();
            hangHoaDTO.TenHangHoa = textBoxTenHangHoa.Text == string.Empty ? string.Empty : textBoxTenHangHoa.Text;
            List<HangHoaDTO> hangHoaDTOs = hangHoaService.findHangHoaNotExpired(hangHoaDTO);
            dataGridViewHangHoa.DataSource = hangHoaDTOs;
        }

        private void ClearThongTinKhuyenMai()
        {
            selectedKhuyenMai = new KhuyenMaiDTO();
            selectHangHoaDTOs = new List<HangHoaDTO>();
            UpdateKhuyenMaiTextBoxes();
            buttonCapNhatKhuyenMai.Enabled = false;
            buttonXoaKhuyenMai.Enabled = false;
        }

        private void UpdateKhuyenMaiTextBoxes()
        {
            textBoxThongTinTenKhuyenMai.Text = selectedKhuyenMai.TenKhuyenMai;
            textBoxThongTinPhanTramKhuyenMai.Text = Convert.ToString(selectedKhuyenMai.PhanTramKhuyenMai);
            textBoxThongTinSoLuongHangMua.Text = Convert.ToString(selectedKhuyenMai.SoLuongMua);
            textBoxThongTinSoLuongHangTang.Text = Convert.ToString(selectedKhuyenMai.SoLuongTang);
            dataGridViewSelectedHangHoa.DataSource = selectHangHoaDTOs;
            if (selectedKhuyenMai.NgayBatDau == 0 && selectedKhuyenMai.NgayKetThuc == 0)
            {
                comboBoxThongTinThoiHanKhuyenMai.SelectedValue = "Không thời hạn";
                panelThongTinThoiHanKhuyenMai.Visible = false;
            }
            else
            {
                comboBoxThongTinThoiHanKhuyenMai.SelectedValue = "Có thời hạn";
                panelThongTinThoiHanKhuyenMai.Visible = true;
                dateTimePickerThongTinNgayBatDau.Value = DateTimeOffset.FromUnixTimeSeconds(selectedKhuyenMai.NgayBatDau).LocalDateTime;
                dateTimePickerThongTinNgayKetThuc.Value = DateTimeOffset.FromUnixTimeSeconds(selectedKhuyenMai.NgayKetThuc).LocalDateTime;
            }
        }

        private void dataGridViewDanhSachKhuyenMai_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachKhuyenMai.CurrentRow.Index != -1)
            {
                selectedKhuyenMai = new KhuyenMaiDTO(
                    Convert.ToInt32(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["MaKhuyenMai"].Value),
                    Convert.ToInt32(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["MaHangHoa"].Value),
                    Convert.ToString(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["TenKhuyenMai"].Value),
                    Convert.ToSingle(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["PhanTramKhuyenMai"].Value),
                    Convert.ToInt32(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["SoLuongMua"].Value),
                    Convert.ToInt32(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["SoLuongTang"].Value),
                    Convert.ToInt64(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["NgayBatDau"].Value),
                    Convert.ToInt64(dataGridViewDanhSachKhuyenMai.CurrentRow.Cells["NgayKetThuc"].Value)
                    );
                FindHangHoa();
                UpdateKhuyenMaiTextBoxes();
                buttonCapNhatKhuyenMai.Enabled = true;
                buttonXoaKhuyenMai.Enabled = true;
                buttonThemKhuyenMai.Enabled = true;
            }
        }

        private void textBoxTenHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindProducts();
            }
        }

        private void buttonTimHangHoa_Click(object sender, EventArgs e)
        {
            FindProducts();
        }

        private void buttonFindKhuyenMai_Click(object sender, EventArgs e)
        {
            FindKhuyenMai();
        }

        private void textBoxTenKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhuyenMai();
            }
        }

        private void textBoxPhanTramKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhuyenMai();
            }
        }

        private void textBoxSoLuongHangMua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhuyenMai();
            }
        }

        private void textBoxSoLuongHangTang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhuyenMai();
            }
        }

        private void dataGridViewHangHoa_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewHangHoa.CurrentRow.Index != -1)
            {
                selectHangHoaDTOs = new List<HangHoaDTO>();

                HangHoaDTO hangHoaDTO = new HangHoaDTO(
                   Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["MaHangHoaDanhSachHangHoa"].Value),
                   Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["TenHangHoa"].Value),
                   Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["LoaiHangHoa"].Value),
                   Convert.ToDateTime(dataGridViewHangHoa.CurrentRow.Cells["NgayHetHan"].Value),
                   Convert.ToInt32(dataGridViewHangHoa.CurrentRow.Cells["SoLuong"].Value),
                   Convert.ToDecimal(dataGridViewHangHoa.CurrentRow.Cells["GiaBanLe"].Value),
                   Convert.ToString(dataGridViewHangHoa.CurrentRow.Cells["DonViTinh"].Value)
                    );
                selectHangHoaDTOs.Add(hangHoaDTO);
                dataGridViewSelectedHangHoa.DataSource = selectHangHoaDTOs;                
            }
        }

        private void buttonThemKhuyenMai_Click(object sender, EventArgs e)
        {
            AddKhuyenMai();
        }

        private void buttonCapNhatKhuyenMai_Click(object sender, EventArgs e)
        {
            UpdateKhuyenMai();
        }

        private void buttonXoaKhuyenMai_Click(object sender, EventArgs e)
        {
            DeleteKhuyenMai();
            ClearThongTinKhuyenMai();
        }

        private void buttonLamMoiThongTinKhuyenMai_Click(object sender, EventArgs e)
        {
            ClearThongTinKhuyenMai();
        }

        private void comboBoxThoiHanKhuyenMai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxThoiHanKhuyenMaiLoaded)
            {
                if (comboBoxThoiHanKhuyenMai.SelectedValue.Equals("Không thời hạn"))
                {
                    panelThoiHanKhuyenMai.Visible = false;
                }
                else
                {
                    panelThoiHanKhuyenMai.Visible = true;
                }
            }
        }

        private void comboBoxThongTinThoiHanKhuyenMai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxThongTinThoiHanKhuyenMaiLoaded)
            {
                if (comboBoxThongTinThoiHanKhuyenMai.SelectedValue.Equals("Không thời hạn"))
                {
                    panelThongTinThoiHanKhuyenMai.Visible = false;
                }
                else
                {
                    panelThongTinThoiHanKhuyenMai.Visible = true;
                }
            }
        }
    }
}
