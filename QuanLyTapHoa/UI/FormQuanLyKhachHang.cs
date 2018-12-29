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
    public partial class FormQuanLyKhachHang : Form
    {
        private KhachHangService khachHangService;
        private UuDaiService uuDaiService;
        private KhachHangDTO selectedKhachHang;
        private List<UuDaiDTO> selectedUuDais;

        public FormQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            khachHangService = new KhachHangService();
            uuDaiService = new UuDaiService();
            selectedKhachHang = new KhachHangDTO();
            selectedUuDais = new List<UuDaiDTO>();
            FindKhachHang();
        }

        private void FindKhachHang()
        {
            KhachHangDTO khachHangDTO = new KhachHangDTO();
            khachHangDTO.TenKhachHang = textBoxTenKhachHang.Text == string.Empty ? string.Empty : textBoxTenKhachHang.Text;
            khachHangDTO.SoDienThoai = textBoxSoDienThoai.Text == string.Empty ? string.Empty : textBoxSoDienThoai.Text;
            int SoLanMuaHang = 0;
            if (!textBoxSoLanMuaHang.Text.Equals(string.Empty))
            {
                if (!int.TryParse(textBoxSoLanMuaHang.Text, out SoLanMuaHang))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô số lần mua hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                SoLanMuaHang = int.MinValue;
            }
            khachHangDTO.SoLanMuaHang = SoLanMuaHang;
            List<KhachHangDTO> khachHangs = khachHangService.findKhachHang(khachHangDTO);
            dataGridViewDanhSachKhachHang.DataSource = khachHangs;
        }

        private void FindUuDai()
        {
            UuDaiDTO uuDaiDTO = new UuDaiDTO();
            uuDaiDTO.SoLanMuaHangToiThieu = selectedKhachHang.SoLanMuaHang;
            selectedUuDais = uuDaiService.findUuDaiNotExpired(uuDaiDTO);
            dataGridViewDanhSachKhuyenMai.DataSource = selectedUuDais;
        }

        private void ClearThongTinKhachHang()
        {
            selectedKhachHang = new KhachHangDTO();
            UpdateThongTinKhachHangTextBoxes();
            buttonCapNhatKhachHang.Enabled = false;
            buttonXoaKhachHang.Enabled = false;
        }

        private void UpdateThongTinKhachHangTextBoxes()
        {
            textBoxThongTinTenKhachHang.Text = selectedKhachHang.TenKhachHang;
            textBoxThongTinSoDienThoai.Text = selectedKhachHang.SoDienThoai;
            textBoxThongTinSoLanMuaHang.Text = Convert.ToString(selectedKhachHang.SoLanMuaHang);
        }

        private void AddKhachHang()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn thêm khách hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                KhachHangDTO khachHangDTO = new KhachHangDTO();

                if (textBoxThongTinTenKhachHang.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                khachHangDTO.TenKhachHang = textBoxThongTinTenKhachHang.Text == string.Empty ? string.Empty : textBoxThongTinTenKhachHang.Text;
                long SoDienThoai = 0;
                int SoLuongHangMua = 0;
                int SoLuongHangTang = 0;
                if (textBoxThongTinSoDienThoai.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại của khách!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (!long.TryParse(textBoxThongTinSoDienThoai.Text, out SoDienThoai))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô số điện thoại!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                khachHangDTO.SoDienThoai = textBoxThongTinSoDienThoai.Text;
                int SoLanMuaHang = 0;
                if (textBoxThongTinSoLanMuaHang.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập số lần mua hàng của khách!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (!int.TryParse(textBoxThongTinSoLanMuaHang.Text, out SoLanMuaHang))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô số lần mua hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (SoLanMuaHang < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lần mua hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                khachHangDTO.SoLanMuaHang = SoLanMuaHang;

                khachHangService.addKhachHang(khachHangDTO);
                ClearThongTinKhachHang();
                FindKhachHang();

                MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void UpdateKhachHang()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn cập nhật thông tin khách hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                KhachHangDTO khachHangDTO = new KhachHangDTO();

                if (textBoxThongTinTenKhachHang.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                selectedKhachHang.TenKhachHang = textBoxThongTinTenKhachHang.Text == string.Empty ? string.Empty : textBoxThongTinTenKhachHang.Text;
                long SoDienThoai = 0;
                int SoLuongHangMua = 0;
                int SoLuongHangTang = 0;
                if (textBoxThongTinSoDienThoai.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại của khách!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (!long.TryParse(textBoxThongTinSoDienThoai.Text, out SoDienThoai))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô số điện thoại!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }

                selectedKhachHang.SoDienThoai = textBoxThongTinSoDienThoai.Text;
                int SoLanMuaHang = 0;
                if (textBoxThongTinSoLanMuaHang.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Vui lòng nhập số lần mua hàng của khách!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (!int.TryParse(textBoxThongTinSoLanMuaHang.Text, out SoLanMuaHang))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số vào ô số lần mua hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                if (SoLanMuaHang < 0)
                {
                    MessageBox.Show("Vui lòng chỉ nhập số lớn hơn 0 vào ô số lần mua hàng!", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                selectedKhachHang.SoLanMuaHang = SoLanMuaHang;

                khachHangService.updateKhachHang(selectedKhachHang);
                FindKhachHang();
                FindUuDai();

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void DeleteKhachHang()
        {
            FormXacNhan formXacNhan = new FormXacNhan("Bạn có chắc chắc muốn xóa khách hàng này?");
            if (formXacNhan.ShowDialog() == DialogResult.OK)
            {
                khachHangService.deleteKhachHang(selectedKhachHang);
                FindKhachHang();
                ClearThongTinKhachHang();
                FindUuDai();
                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void buttonThemKhachHang_Click(object sender, EventArgs e)
        {
            AddKhachHang();
        }

        private void buttonCapNhatKhachHang_Click(object sender, EventArgs e)
        {
            UpdateKhachHang();
        }

        private void buttonXoaKhachHang_Click(object sender, EventArgs e)
        {
            DeleteKhachHang();
        }

        private void buttonLamMoiThongTinKhachHang_Click(object sender, EventArgs e)
        {
            ClearThongTinKhachHang();
        }

        private void dataGridViewDanhSachKhachHang_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachKhachHang.CurrentRow.Index != -1)
            {
                selectedKhachHang = new KhachHangDTO(
                    Convert.ToInt32(dataGridViewDanhSachKhachHang.CurrentRow.Cells["MaKhachHang"].Value),
                    Convert.ToString(dataGridViewDanhSachKhachHang.CurrentRow.Cells["TenKhachHang"].Value),
                    Convert.ToString(dataGridViewDanhSachKhachHang.CurrentRow.Cells["SoDienThoai"].Value),
                    Convert.ToInt32(dataGridViewDanhSachKhachHang.CurrentRow.Cells["SoLanMuaHang"].Value)
                    );
                UpdateThongTinKhachHangTextBoxes();
                FindUuDai();
            }
        }

        private void textBoxTenKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhachHang();
            }
        }

        private void textBoxSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhachHang();
            }
        }

        private void textBoxSoLanMuaHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindKhachHang();
            }
        }

        private void buttonTimKhachHang_Click(object sender, EventArgs e)
        {
            FindKhachHang();
        }
    }
}
