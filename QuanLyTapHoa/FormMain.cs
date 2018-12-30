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
<<<<<<< HEAD
            FormQuanLyHangHoa formQuanLyHangHoa = new FormQuanLyHangHoa();
            formQuanLyHangHoa.TopLevel = false;
            formQuanLyHangHoa.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formQuanLyHangHoa);
            formQuanLyHangHoa.Show();
=======
            FormQuanLyKhachHang formQuanLyKhachHang = new FormQuanLyKhachHang();
            formQuanLyKhachHang.TopLevel = false;
            formQuanLyKhachHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formQuanLyKhachHang);
            formQuanLyKhachHang.Show();

>>>>>>> dc64227ea2a4fced0ec6d9530381775c73400964
        }
    }
}
