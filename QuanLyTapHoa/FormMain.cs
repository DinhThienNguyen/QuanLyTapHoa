using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTapHoa.UI;


namespace QuanLyTapHoa
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //FormQuanLyKhachHang formQuanLyKhachHang = new FormQuanLyKhachHang();
            //formQuanLyKhachHang.TopLevel = false;
            //formQuanLyKhachHang.Dock = DockStyle.Fill;
            //panelMain.Controls.Add(formQuanLyKhachHang);
            //formQuanLyKhachHang.Show();

            FormQuanLyHangHoa formQuanLyKhachHang = new FormQuanLyHangHoa();
            formQuanLyKhachHang.TopLevel = false;
            formQuanLyKhachHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formQuanLyKhachHang);
            formQuanLyKhachHang.Show();

        }
    }
}
