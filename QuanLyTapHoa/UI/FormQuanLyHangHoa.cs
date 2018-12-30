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
    public partial class FormQuanLyHangHoa : Form
    {
        private HangHoaService hangHoaService;
        private HangHoaDTO selectedHangHoa;
        private bool comboBoxThoiHanLoaded = false;

        public FormQuanLyHangHoa()
        {
            InitializeComponent();
        }

        private void FormQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            hangHoaService = new HangHoaService();
            selectedHangHoa = new HangHoaDTO();
            comboBoxThoiHan.DisplayMember = "Text";
            comboBoxThoiHan.ValueMember = "Value";
            List<Object> items1 = new List<object>();
            items1.Add(new { Text = "Còn hạn sử dụng", Value = "Còn hạn sử dụng" });
            items1.Add(new { Text = "Hết hạn sử dụng", Value = "Hết hạn sử dụng" });            
            comboBoxThoiHan.DataSource = items1;
            comboBoxThoiHanLoaded = true;
            FindHangHoa();
        }

        private void FindHangHoa()
        {
            HangHoaDTO hangHoaDTO = new HangHoaDTO();
            hangHoaDTO.TenHangHoa = textBoxTimTenHangHoa.Text == string.Empty ? string.Empty : textBoxTimTenHangHoa.Text;
            hangHoaDTO.LoaiHangHoa = textBoxTimLoaiHangHoa.Text == string.Empty ? string.Empty : textBoxTimLoaiHangHoa.Text;
            List<HangHoaDTO> hangHoaDTOs;
            if (comboBoxThoiHan.SelectedValue.Equals("Hết hạn sử dụng"))
            {
                hangHoaDTOs = hangHoaService.findHangHoaExpired(hangHoaDTO);
            }
            else
            {
                hangHoaDTO.NgayHetHan = dateTimePickerTimNgayHetHan.Value;
                hangHoaDTOs = hangHoaService.findHangHoaNotExpired(hangHoaDTO);
            }
            dataGridViewDanhSachHangHoa.DataSource = hangHoaDTOs;
        }

        private void ClearThongTinHangHoa()
        {
            selectedHangHoa = new HangHoaDTO();
            UpdateHangHoaTextBoxes();
            buttonCapNhatHangHoa.Enabled = false;
            buttonXoaHangHoa.Enabled = false;
        }

        private void UpdateHangHoaTextBoxes()
        {
            textBoxTenHangHoa.Text = selectedHangHoa.TenHangHoa;
            textBoxTenLoaiHangHoa.Text = selectedHangHoa.LoaiHangHoa;
            textBoxSoLuong.Text = Convert.ToString(selectedHangHoa.SoLuong);
            textBoxGiaBanLe.Text = Convert.ToString(selectedHangHoa.GiaBanLe);
            textBoxDonViTinh.Text = selectedHangHoa.DonViTinh;
            dateTimePickerNgayHetHan.Value = selectedHangHoa.NgayHetHan;
        }

        private void AddHangHoa()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn thêm mặt hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                HangHoaDTO hangHoaDTO = new HangHoaDTO();

                if (textBoxTenHangHoa.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên mặt hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                hangHoaDTO.TenHangHoa = textBoxTenHangHoa.Text;

                if (textBoxTenLoaiHangHoa.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên loại hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                hangHoaDTO.LoaiHangHoa = textBoxTenLoaiHangHoa.Text;

                hangHoaDTO.NgayHetHan = dateTimePickerNgayHetHan.Value;

                int SoLuong = 0;
                if (textBoxSoLuong.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxSoLuong.Text, out SoLuong))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô số lượng!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuong < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                hangHoaDTO.SoLuong = SoLuong;

                decimal GiaBanLe = 0;
                if (textBoxGiaBanLe.Text != string.Empty)
                {
                    if (!decimal.TryParse(textBoxGiaBanLe.Text, out GiaBanLe))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô giá bán lẻ!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (GiaBanLe < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô giá bán lẻ!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                hangHoaDTO.GiaBanLe = GiaBanLe;

                if (textBoxDonViTinh.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                hangHoaDTO.DonViTinh = textBoxDonViTinh.Text;

                hangHoaService.addHangHoa(hangHoaDTO);
                ClearThongTinHangHoa();
                FindHangHoa();
                MessageBox.Show("Thêm hàng hóa mới thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void UpdateHangHoa()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn cập nhật thông tin mặt hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                if (textBoxTenHangHoa.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên mặt hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedHangHoa.TenHangHoa = textBoxTenHangHoa.Text;

                if (textBoxTenLoaiHangHoa.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên loại hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedHangHoa.LoaiHangHoa = textBoxTenLoaiHangHoa.Text;

                selectedHangHoa.NgayHetHan = dateTimePickerNgayHetHan.Value;

                int SoLuong = 0;
                if (textBoxSoLuong.Text != string.Empty)
                {
                    if (!int.TryParse(textBoxSoLuong.Text, out SoLuong))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô số lượng!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (SoLuong < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lượng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedHangHoa.SoLuong = SoLuong;

                decimal GiaBanLe = 0;
                if (textBoxGiaBanLe.Text != string.Empty)
                {
                    if (!decimal.TryParse(textBoxGiaBanLe.Text, out GiaBanLe))
                    {
                        MessageBox.Show("Vui lòng chỉ nhập số vào ô giá bán lẻ!", "Lỗi", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (GiaBanLe < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô giá bán lẻ!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedHangHoa.GiaBanLe = GiaBanLe;

                if (textBoxDonViTinh.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedHangHoa.DonViTinh = textBoxDonViTinh.Text;

                hangHoaService.updateHangHoa(selectedHangHoa);
                FindHangHoa();
                MessageBox.Show("Cập nhật thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DeleteHangHoa()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn xóa mặt hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                hangHoaService.deleteHangHoa(selectedHangHoa);
                FindHangHoa();
                ClearThongTinHangHoa();
                MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dataGridViewDanhSachHangHoa_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachHangHoa.CurrentRow.Index != -1)
            {
                selectedHangHoa = new HangHoaDTO(
                    Convert.ToInt32(dataGridViewDanhSachHangHoa.CurrentRow.Cells["MaHangHoa"].Value),
                    Convert.ToString(dataGridViewDanhSachHangHoa.CurrentRow.Cells["TenHangHoa"].Value),
                    Convert.ToString(dataGridViewDanhSachHangHoa.CurrentRow.Cells["LoaiHangHoa"].Value),
                    Convert.ToDateTime(dataGridViewDanhSachHangHoa.CurrentRow.Cells["NgayHetHan"].Value),
                    Convert.ToInt32(dataGridViewDanhSachHangHoa.CurrentRow.Cells["SoLuong"].Value),
                    Convert.ToDecimal(dataGridViewDanhSachHangHoa.CurrentRow.Cells["GiaBanLe"].Value),
                    Convert.ToString(dataGridViewDanhSachHangHoa.CurrentRow.Cells["DonViTinh"].Value)
                    );

                UpdateHangHoaTextBoxes();
                buttonCapNhatHangHoa.Enabled = true;
                buttonXoaHangHoa.Enabled = true;
            }
        }

        private void buttonThemHangHoa_Click(object sender, EventArgs e)
        {
            AddHangHoa();
        }

        private void buttonXoaHangHoa_Click(object sender, EventArgs e)
        {
            DeleteHangHoa();
        }

        private void buttonCapNhatHangHoa_Click(object sender, EventArgs e)
        {
            UpdateHangHoa();
        }

        private void buttonDatLai_Click(object sender, EventArgs e)
        {
            ClearThongTinHangHoa();
        }

        private void buttonTim_Click(object sender, EventArgs e)
        {
            FindHangHoa();
        }

        private void comboBoxThoiHan_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxThoiHanLoaded)
            {
                if (comboBoxThoiHan.SelectedValue.Equals("Hết hạn sử dụng"))
                {
                    panelThoiHan.Visible = false;
                }
                else
                {
                    panelThoiHan.Visible = true;
                }
            }
        }
    }
}
