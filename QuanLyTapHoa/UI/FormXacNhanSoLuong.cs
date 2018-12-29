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
    public partial class FormXacNhanSoLuong : Form
    {
        private int maxSoLuong;
        public int SoLuong = 0;
        public FormXacNhanSoLuong(int max)
        {
            maxSoLuong = max;
            InitializeComponent();
        }        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBoxSoLuong.Text, out parsedValue))
            {
                MessageBox.Show("Vui lòng chỉ nhập số!", "Lỗi", MessageBoxButtons.OK);               
                return;
            }
            SoLuong = Convert.ToInt32(textBoxSoLuong.Text);
            if (SoLuong <= 0)
            {
                MessageBox.Show("Số lượng cần bán phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if(SoLuong <= maxSoLuong)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Số lượng cần bán phải nhỏ hơn số lượng hiện có!", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}
