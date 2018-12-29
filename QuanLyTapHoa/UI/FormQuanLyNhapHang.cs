using QuanLyTapHoa.DTO;
using QuanLyTapHoa.SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTapHoa.UI
{
    public partial class FormQuanLyNhapHang : Form
    {
        private HangHoaService hangHoaService;

        public FormQuanLyNhapHang()
        {
            InitializeComponent();
        }

        private void FormQuanLyNhapHang_Load(object sender, EventArgs e)
        {
            hangHoaService = new HangHoaService();
        }

        private void FindProducts()
        {
            HangHoaDTO hangHoaDTO = new HangHoaDTO();
            hangHoaDTO.TenHangHoa = textBoxTenHangHoa.Text == string.Empty ? string.Empty : textBoxTenHangHoa.Text;
            List<HangHoaDTO> hangHoaDTOs = hangHoaService.findHangHoaExpired(hangHoaDTO);
            if (hangHoaDTOs.Count != 0)
            {                
                dataGridViewHangHoa.DataSource = hangHoaDTOs;
            }             
        }

        private void buttonTimHangHoa_Click(object sender, EventArgs e)
        {
            FindProducts();
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

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
