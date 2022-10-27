using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKinhDoanh
{
    public partial class frmThemLoaiSP : Form
    {
        int soluong, vitri;
        public frmThemLoaiSP(string t, int i, int vt)
        {
            InitializeComponent();
            lbTenSP.Text = t;
            soluong = i;
            vitri = vt;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if((Convert.ToInt32(txtSoluong.Text) > soluong) && (Convert.ToInt32(txtSoluong.Text) < 0))
            {
                MessageBox.Show("Vui lòng nhập số lượng nhỏ hơn số lượng trong kho", "Cảnh báo", MessageBoxButtons.OKCancel);
            }
            else
            {
                int soluong = Convert.ToInt32(txtSoluong.Text);
                this.Close();
                
            }    
        }
    }
}
