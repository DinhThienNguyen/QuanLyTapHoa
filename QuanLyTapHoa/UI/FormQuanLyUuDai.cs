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
using QuanLyTapHoa.DTO;
using QuanLyTapHoa.SERVICES;

namespace QuanLyTapHoa.UI
{
    public partial class FormQuanLyUuDai : Form
    {
        private UuDaiService uuDaiService;
        private KhachHangService khachHangService;
        private UuDaiDTO selectedUuDai;
        private bool comboBoxThoiHanUuDaiLoaded = false;
        private bool comboBoxThongTinThoiHanUuDaiLoaded = false;

        public FormQuanLyUuDai()
        {
            InitializeComponent();
        }

        private void FormQuanLyUuDai_Load(object sender, EventArgs e)
        {
            uuDaiService = new UuDaiService();
            khachHangService = new KhachHangService();
            selectedUuDai = new UuDaiDTO();
            comboBoxThongTinThoiHanUuDai.DisplayMember = "Text";
            comboBoxThongTinThoiHanUuDai.ValueMember = "Value";
            comboBoxThoiHanUuDai.DisplayMember = "Text";
            comboBoxThoiHanUuDai.ValueMember = "Value";
            List<Object> items1 = new List<object>();
            items1.Add(new { Text = "Không thời hạn", Value = "Không thời hạn" });
            items1.Add(new { Text = "Có thời hạn", Value = "Có thời hạn" });
            List<Object> items2 = new List<object>();
            items2.Add(new { Text = "Không thời hạn", Value = "Không thời hạn" });
            items2.Add(new { Text = "Có thời hạn", Value = "Có thời hạn" });
            comboBoxThoiHanUuDai.DataSource = items1;
            comboBoxThongTinThoiHanUuDai.DataSource = items2;
            comboBoxThoiHanUuDaiLoaded = true;
            comboBoxThongTinThoiHanUuDaiLoaded = true;
            FindUuDai();
        }

        private void FindUuDai()
        {
            UuDaiDTO uuDaiDTO = new UuDaiDTO();
            uuDaiDTO.TenUuDai = textBoxTenUuDai.Text == string.Empty ? string.Empty : textBoxTenUuDai.Text;
            decimal SoTienUuDaiToiDa = 0;
            int SoLanMuaHangToiThieu = 0;
            if (textBoxSoTienUuDaiToiDa.Text != string.Empty)
            {
                if (!decimal.TryParse(textBoxSoTienUuDaiToiDa.Text, out SoTienUuDaiToiDa))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số tiền ưu đãi tối đa!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                SoTienUuDaiToiDa = decimal.MaxValue;
            }
            uuDaiDTO.SoTienUuDaiToiDa = SoTienUuDaiToiDa;
            if (textBoxSoLanMuaHangToiThieu.Text != string.Empty)
            {
                if (!int.TryParse(textBoxSoLanMuaHangToiThieu.Text, out SoLanMuaHangToiThieu))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lần mua hàng tối thiểu!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                SoLanMuaHangToiThieu = 0;
            }
            uuDaiDTO.SoLanMuaHangToiThieu = SoLanMuaHangToiThieu;
            if (comboBoxThoiHanUuDai.SelectedValue.Equals("Không thời hạn"))
            {
                uuDaiDTO.NgayBatDau = 0;
                uuDaiDTO.NgayKetThuc = 0;
            }
            else
            {
                uuDaiDTO.NgayBatDau = ((DateTimeOffset)dateTimePickerNgayBatDau.Value).ToUnixTimeSeconds();
                uuDaiDTO.NgayKetThuc = ((DateTimeOffset)dateTimePickerNgayKetThuc.Value).ToUnixTimeSeconds();
            }
            List<UuDaiDTO> uuDaiDTOs = uuDaiService.findUuDaiExpired(uuDaiDTO);
            dataGridViewDanhSachUuDai.DataSource = uuDaiDTOs;
        }

        private void FindKhachHang()
        {
            KhachHangDTO khachHangDTO = new KhachHangDTO();
            khachHangDTO.SoLanMuaHang = selectedUuDai.SoLanMuaHangToiThieu;
            List<KhachHangDTO> khachHangDTOs = khachHangService.findKhachHang(khachHangDTO);
            dataGridViewKhachHang.DataSource = khachHangDTOs;
        }

        private void AddUuDai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn thêm ưu đãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                UuDaiDTO uuDaiDTO = new UuDaiDTO();
                if (textBoxThongTinTenUuDai.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên ưu đãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                uuDaiDTO.TenUuDai = textBoxThongTinTenUuDai.Text == string.Empty ? string.Empty : textBoxThongTinTenUuDai.Text;
                decimal SoTienUuDaiToiDa = 0;
                int SoLanMuaHangToiThieu = 0;
                if (!decimal.TryParse(textBoxThongTinTienUuDaiToiDa.Text, out SoTienUuDaiToiDa))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số tiền ưu đãi tối đa!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                uuDaiDTO.SoTienUuDaiToiDa = SoTienUuDaiToiDa;
                if (!int.TryParse(textBoxThongTinSoLanMuaHangToiThieu.Text, out SoLanMuaHangToiThieu))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lần mua hàng tối thiểu!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                uuDaiDTO.SoLanMuaHangToiThieu = SoLanMuaHangToiThieu;
                if (comboBoxThongTinThoiHanUuDai.SelectedValue.Equals("Không thời hạn"))
                {
                    uuDaiDTO.NgayBatDau = 0;
                    uuDaiDTO.NgayKetThuc = 0;
                }
                else
                {
                    uuDaiDTO.NgayBatDau = ((DateTimeOffset)dateTimePickerThongTinNgayBatDau.Value).ToUnixTimeSeconds();
                    uuDaiDTO.NgayKetThuc = ((DateTimeOffset)dateTimePickerThongTinNgayKetThuc.Value).ToUnixTimeSeconds();
                }
                uuDaiService.addUuDai(uuDaiDTO);
                FindUuDai();
                FindKhachHang();
                ClearThongTinUuDai();
                MessageBox.Show("Thêm ưu đãi thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void UpdateUuDai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn cập nhật ưu đãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                if (textBoxThongTinTenUuDai.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên ưu đãi!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedUuDai.TenUuDai = textBoxThongTinTenUuDai.Text == string.Empty ? string.Empty : textBoxThongTinTenUuDai.Text;
                decimal SoTienUuDaiToiDa = 0;
                int SoLanMuaHangToiThieu = 0;
                if (!decimal.TryParse(textBoxThongTinTienUuDaiToiDa.Text, out SoTienUuDaiToiDa))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số tiền ưu đãi tối đa!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedUuDai.SoTienUuDaiToiDa = SoTienUuDaiToiDa;
                if (!int.TryParse(textBoxThongTinSoLanMuaHangToiThieu.Text, out SoLanMuaHangToiThieu))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô Số lần mua hàng tối thiểu!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedUuDai.SoLanMuaHangToiThieu = SoLanMuaHangToiThieu;
                if (comboBoxThongTinThoiHanUuDai.SelectedValue.Equals("Không thời hạn"))
                {
                    selectedUuDai.NgayBatDau = 0;
                    selectedUuDai.NgayKetThuc = 0;
                }
                else
                {
                    selectedUuDai.NgayBatDau = ((DateTimeOffset)dateTimePickerThongTinNgayBatDau.Value).ToUnixTimeSeconds();
                    selectedUuDai.NgayKetThuc = ((DateTimeOffset)dateTimePickerThongTinNgayKetThuc.Value).ToUnixTimeSeconds();
                }
                uuDaiService.updateUuDai(selectedUuDai);
                FindUuDai();
                FindKhachHang();
                MessageBox.Show("Cập nhật thành công thông tin ưu đãi!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DeleteUuDai()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn xóa ưu đãi này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                uuDaiService.deleteUuDai(selectedUuDai);
                FindUuDai();
                FindKhachHang();
                MessageBox.Show("Xóa ưu đãi thành công!", "Thông báo", MessageBoxButtons.OK);
                ClearThongTinUuDai();
            }
        }

        private void dataGridViewDanhSachUuDai_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachUuDai.CurrentRow.Index != -1)
            {
                selectedUuDai = new UuDaiDTO(
                Convert.ToInt32(dataGridViewDanhSachUuDai.CurrentRow.Cells["MaUuDai"].Value),
                Convert.ToString(dataGridViewDanhSachUuDai.CurrentRow.Cells["TenUuDai"].Value),
                Convert.ToDecimal(dataGridViewDanhSachUuDai.CurrentRow.Cells["SoTienUuDaiToiDa"].Value),
                Convert.ToInt32(dataGridViewDanhSachUuDai.CurrentRow.Cells["SoLanMuaHangToiThieu"].Value),
                Convert.ToInt64(dataGridViewDanhSachUuDai.CurrentRow.Cells["NgayBatDau"].Value),
                Convert.ToInt64(dataGridViewDanhSachUuDai.CurrentRow.Cells["NgayKetThuc"].Value)
                );

                UpdateUuDaiTextBoxes();
                FindKhachHang();
                buttonCapNhatUuDai.Enabled = true;
                buttonXoaUuDai.Enabled = true;
                buttonThemUuDai.Enabled = true;
            }
        }

        private void UpdateUuDaiTextBoxes()
        {
            textBoxThongTinTenUuDai.Text = selectedUuDai.TenUuDai;
            textBoxThongTinTienUuDaiToiDa.Text = Convert.ToString(selectedUuDai.SoTienUuDaiToiDa);
            textBoxThongTinSoLanMuaHangToiThieu.Text = Convert.ToString(selectedUuDai.SoLanMuaHangToiThieu);
            if (selectedUuDai.NgayBatDau == 0 && selectedUuDai.NgayKetThuc == 0)
            {
                comboBoxThongTinThoiHanUuDai.SelectedValue = "Không thời hạn";
                panelThongTinThoiHanUuDai.Visible = false;
            }
            else
            {
                comboBoxThongTinThoiHanUuDai.SelectedValue = "Có thời hạn";
                panelThongTinThoiHanUuDai.Visible = true;
                dateTimePickerThongTinNgayBatDau.Value = DateTimeOffset.FromUnixTimeSeconds(selectedUuDai.NgayBatDau).LocalDateTime;
                dateTimePickerThongTinNgayKetThuc.Value = DateTimeOffset.FromUnixTimeSeconds(selectedUuDai.NgayKetThuc).LocalDateTime;
            }
        }

        private void ClearThongTinUuDai()
        {
            selectedUuDai = new UuDaiDTO();
            UpdateUuDaiTextBoxes();
            buttonCapNhatUuDai.Enabled = false;
            buttonXoaUuDai.Enabled = false;
        }

        private void buttonThemUuDai_Click(object sender, EventArgs e)
        {
            AddUuDai();
        }

        private void buttonCapNhatUuDai_Click(object sender, EventArgs e)
        {
            UpdateUuDai();
        }

        private void buttonXoaUuDai_Click(object sender, EventArgs e)
        {
            DeleteUuDai();
        }

        private void buttonLamMoiThongTinUuDai_Click(object sender, EventArgs e)
        {
            ClearThongTinUuDai();
        }

        private void buttonFindUuDai_Click(object sender, EventArgs e)
        {
            FindUuDai();
        }

        private void comboBoxThoiHanUuDai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxThoiHanUuDaiLoaded)
            {
                if (comboBoxThoiHanUuDai.SelectedValue.Equals("Không thời hạn"))
                {
                    panelThoiHanUuDai.Visible = false;
                }
                else
                {
                    panelThoiHanUuDai.Visible = true;
                }
            }
        }

        private void comboBoxThongTinThoiHanUuDai_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxThongTinThoiHanUuDaiLoaded)
            {
                if (comboBoxThongTinThoiHanUuDai.SelectedValue.Equals("Không thời hạn"))
                {
                    panelThongTinThoiHanUuDai.Visible = false;
                }
                else
                {
                    panelThongTinThoiHanUuDai.Visible = true;
                }
            }
        }

        private void textBoxTenUuDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindUuDai();
            }
        }

        private void textBoxSoTienUuDaiToiDa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindUuDai();
            }
        }

        private void textBoxSoLanMuaHangToiThieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindUuDai();
            }
        }
    }
}
